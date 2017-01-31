﻿using BLL.Interface.Services;
using MvcPresentationLayer.Infrastruct.Mappers;
using MvcPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentationLayer.Controllers
{
    public class TopicController : Controller
    { 
        private readonly ITopicService topicService;
        private readonly IUserService userService;


        public TopicController(ITopicService topicService, IUserService userService)
        {
            this.topicService = topicService;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateTopic(int sectionId)
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTopic(Topic topic)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                topic.UserId = userService.GetUserEntityByEmail(userName).Id;
                topic.Date = DateTime.Now;
                topicService.CreateTopic(topic.ToBllTopic());
                return RedirectToAction("Index","Home",null);
            }
            return PartialView(topic);
        }
    }
}