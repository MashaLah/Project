using BLL.Interface.Services;
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
        private readonly IStateService stateService;

        public TopicController(ITopicService topicService, IUserService userService, IStateService stateService)
        {
            this.topicService = topicService;
            this.userService = userService;
            this.stateService = stateService;
        }


        [AllowAnonymous]
        public ActionResult Index(int forumId)
        {
            var topics = topicService.GetAllTopicEntities()
                .Where(t => t.ForumId == forumId && t.StateId == 1)
                .Select(t => t.ToMvcTopic());
            return View(topics);
        }

       /* [HttpGet]
        [Authorize]
        public ActionResult CreateTopic(int sectionId)
        {
            return PartialView();
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTopic(Topic topic)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                topic.UserId = userService.GetUserEntityByEmail(userName).Id;
                topic.Date = DateTime.Now;
                topic.StateId= stateService.GetStateEntity(3).Id;
                topicService.CreateTopic(topic.ToBllTopic());
            }
            return RedirectToAction("Index");
        }
    }
}