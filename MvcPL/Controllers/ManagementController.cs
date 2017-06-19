using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPL.Infrastructure;
namespace MvcPL.Controllers
{
    [Authorize(Roles = "administrator")]
    public class ManagementController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly ISectionService sectionService;

        public ManagementController(IUserService userService, IRoleService roleService, ISectionService sectionService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.sectionService = sectionService;
        }

        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Users()
        {
            IEnumerable<UserEntity> userList = userService.GetAll();
            var date = new List<ProfileViewModel>();
            foreach (var element in userList)
            {
                date.Add(new ProfileViewModel()
                {
                    Email = element.Email,
                    Nickname = element.Nickname,
                    Id = element.Id,
                    Roles = userService.GetRoles(element)
                });
            }

            return Json(date, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteUser(int? id)
        {
            if (ReferenceEquals(id,null)) return RedirectToAction("Main");
            userService.Delete((int)id);
            return RedirectToAction("Main");
        }

        public ActionResult Section()
        {
            return Json(sectionService.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateSection()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSection(SectionViewModel viewModel)
        {
            sectionService.Create(viewModel.ToBllSection());
            return RedirectToAction("Main");
        }
        public ActionResult EditSection()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSection(SectionViewModel viewModel)
        {
            sectionService.Update(viewModel.ToBllSection());
            return RedirectToAction("Main");
        }
        public ActionResult DeleteSection(int? id)
        {
            if (ReferenceEquals(id, null)) return RedirectToAction("Main");
            sectionService.Delete((int)id);
            return RedirectToAction("Main");
        }
    }
}