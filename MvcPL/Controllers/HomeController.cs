using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly ISectionService sectionService;
        private readonly ITopicService topicService;



        public HomeController(IUserService userService, ISectionService sectionService, ITopicService topicService)
        {
            this.userService = userService;
            this.sectionService = sectionService;
            this.topicService = topicService;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<SectionViewModel> list = sectionService.GetAll().ToSectionViewModel(sectionService).ToList();
            return View(list);
        }
        [AllowAnonymous]
        public ActionResult Search(string name)
        {
            List<TopicEntity> result = topicService.Search(name).ToList();
            if (ReferenceEquals(result, null))
                return null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}