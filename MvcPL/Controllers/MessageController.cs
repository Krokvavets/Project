using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;


        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (ReferenceEquals(id, null)|| ReferenceEquals(id, null)) return HttpNotFound();
            var message = messageService.GetById((int)id);
            if (ReferenceEquals(message, null)) return HttpNotFound();
            messageService.Delete((int)id);
            return Redirect("/Topic/Topic?id=" + message.TopicId);
        }
        public ActionResult Edit(int? id)
        {
            if ((id == null || messageService.GetById((int)id) == null))
                return RedirectToAction("Index");
            return View(messageService.GetById((int)id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MessageEntity message)
        {
            if (ReferenceEquals(message, null)|| String.IsNullOrEmpty(message.Text))
                return Redirect("/Topic/Topic?id=" + message.TopicId);
            message.Note = "Edited";            
            messageService.Update(message);
            return Redirect("/Topic/Topic?id=" + message.TopicId);
        }
    }
}