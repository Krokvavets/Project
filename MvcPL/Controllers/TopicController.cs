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
    public class TopicController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly ISectionService sectionService;
        private readonly ITopicService topicService;
        private readonly IMessageService messageService;


        public TopicController(IUserService userService, IRoleService roleService, ISectionService sectionService,
                                ITopicService topicService, IMessageService messageService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.sectionService = sectionService;
            this.topicService = topicService;
            this.messageService = messageService;
        }
        public ActionResult CreateTopic(int sectionId)
        {
            TopicViewModel viewModel = new TopicViewModel() { SectionId = sectionId };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTopic(TopicViewModel viewModel)
        {
            topicService.Create(viewModel.ToBllTopic());
            if (!ReferenceEquals(topicService.GetById(viewModel.Id), null))
                messageService.Create(new MessageEntity() { Text = viewModel.TextMessage, TopicId = viewModel.Id,
                                                        UserId = userService.GetUserByEmail(HttpContext.User.Identity.Name).Id });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (ReferenceEquals(id, null))return HttpNotFound();
            var topic = topicService.GetById((int)id);
            if (ReferenceEquals(topic, null)) return HttpNotFound();
            var model = new TopicViewModel();
            model.Id = topic.Id;
            model.Name = topic.Name;
            if (!ReferenceEquals(topicService.GetMessages(topic.Id), null))
                model.Messages = topicService.GetMessages(topic.Id).ToList();
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (ReferenceEquals(id, null)) return HttpNotFound();
            var topic = topicService.GetById((int)id);
            if (ReferenceEquals(topic, null)) return HttpNotFound();
            topicService.Delete((int)id);
            return RedirectToAction("Index");
        }
        public ActionResult EditTopic(int? id)
        {
            if ((id == null || topicService.GetById((int)id) == null))
                return RedirectToAction("Index");
            return View(topicService.GetById((int)id).ToViewTopicViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTopic(TopicViewModel viewModel)
        {
            if(ReferenceEquals(sectionService.GetById(viewModel.SectionId), null))
                return RedirectToAction("Index");
            topicService.Update(viewModel.ToBllTopic());
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        public ActionResult Topic(int? id)
        {
            if (ReferenceEquals(id, null)|| ReferenceEquals(topicService.GetById((int)id), null)) return HttpNotFound();
            ViewData["Name"] = topicService.GetById((int)id).Name;
            ViewData["Id"] = id;
            var listModel = new List<MessageViewModel>();
            List<MessageEntity> messages = topicService.GetMessages((int)id).ToList();
            List<UserEntity> users = userService.GetAll().ToList();
            if (ReferenceEquals(messages, null)) return RedirectToAction("Index");
            foreach (var item in messages)
                listModel.Add(new MessageViewModel() { Message = item, User = users.FirstOrDefault(u => u.Id == item.UserId) });
            return View(listModel);
        }
        [HttpPost]
        public ActionResult NewMessage(string mess, int id)
        {
            messageService.Create(new MessageEntity()
            {
                Text = mess,
                UserId = userService.GetUserByEmail(HttpContext.User.Identity.Name).Id,
                TopicId = id,
                CreationDate = DateTime.Now
            });
            return Redirect("/Topic/Topic?id=" + id);
        }
    }
}