using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcPL.Providers;

namespace MvcPL.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService service;
        private readonly IRoleService roleService;

        public ProfileController(IUserService service, IRoleService roleService)
        {
            this.service = service;
            this.roleService = roleService;
        }

        public ActionResult UserProfile(int id)
        {
            return View(service.GetById(id).ToProfileViewModel());
        }
        public ActionResult UserOwnProfile()
        {
            return RedirectToAction("UserProfile", "Profile",new { service.GetUserByEmail(HttpContext.User.Identity.Name).Id }); 
        }
        /// <summary>
        /// The method return photo to view 
        /// </summary>
        /// <param name="Id">User id</param>
        /// <returns>photo</returns>
        public FileContentResult GetImage(int id)
        {
            byte[] img = service.GetById(id).Photo;
            if (img != null)
            {
                return File(img, "photo");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Edit(int? id)
        {
            int userId = service.GetUserByEmail(HttpContext.User.Identity.Name).Id;
            if ((id == null || service.GetById((int)id) == null))
                return RedirectToAction("Index", "Home");
            var date = new CustomRoleProvider();
            if (!date.IsUserInRole(HttpContext.User.Identity.Name, "Administrator") && userId != (int)id)
                return RedirectToAction("Index", "Home");
            var viewModel = service.GetById((int)id).ToProfileViewModel();
            if (date.IsUserInRole(viewModel.Email, "Administrator"))
                viewModel.Administrator = true;
            if (date.IsUserInRole(viewModel.Email, "Moderator"))
                viewModel.Moderator = true;
            if (date.IsUserInRole(viewModel.Email, "User"))
                viewModel.User = true;
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileViewModel profile, HttpPostedFileBase image = null)
        {
           if (ModelState.IsValid)
            {
                if (image != null)
                {
                    profile.Photo = new byte[image.ContentLength]; ;
                    image.InputStream.Read(profile.Photo, 0, image.ContentLength);
                }
                else
                {
                    profile.Photo = service.GetById(profile.Id).Photo;
                }
                service.Update(profile.ToBllUser());
                var date = new CustomRoleProvider();
                date.SetOrRemoveRole(profile);
            }
            return RedirectToAction("UserProfile", "Profile", new { profile.Id });
        }
    }
}