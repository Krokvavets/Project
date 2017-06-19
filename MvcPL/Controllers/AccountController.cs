using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcPL.Providers;
using System.IO;
using System.Drawing;

namespace MvcPL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService service; 

        public AccountController(IUserService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel, HttpPostedFileBase image = null)
        {
            FormsAuthentication.SignOut();
            var anyUser = service.GetAll().Any(u => u.Email.Contains(viewModel.Email));

            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    viewModel.Photo = new byte[image.ContentLength];
                    image.InputStream.Read(viewModel.Photo, 0, image.ContentLength);
                }
                else
                {
                    Image ImageFromFile =Image.FromFile(@"C:\Users\jupranec\documents\visual studio 2017\Projects\Forum\MvcPL\Style\img\dbe9ab5c9701.jpeg");
                    ImageConverter converter = new ImageConverter();
                    Bitmap bmp = new Bitmap(ImageFromFile);
                    viewModel.Photo = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
                }
                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(viewModel);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(viewModel);
        }
        [AllowAnonymous]
        public JsonResult ValidateEmail(string email)
        {
            if (service.GetUserByEmail(email) != null)
            {
                return Json("User with this email already exists",
                    JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}