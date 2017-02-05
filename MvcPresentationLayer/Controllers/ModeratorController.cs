using BLL.Interface.Services;
using MvcPresentationLayer.Infrastruct.Mappers;
using MvcPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentationLayer.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly IPostService postService;
        private readonly ITopicService topicService;
        private readonly IStateService stateService;
        private readonly IForumService forumService;

        public ModeratorController(IPostService postService, ITopicService topicService, 
            IStateService stateService, IForumService forumService)
        {
            this.postService = postService;
            this.topicService = topicService;
            this.stateService = stateService;
            this.forumService = forumService;
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var posts = postService.GetAllPostEntities()
                .Where(post=>post.StateId==3)
                .Select(post => post.ToMvcPost());
            var states = stateService.GetAllStateEntities().Select(s=>s.ToMvcState());
            foreach (var post in posts)
            {
               ViewBag.States = 
                    new SelectList(states, "Id", "Name", post.StateId);
            }
            List<Post> p = new List<Post>();
 
            foreach (var post in posts)
            {
                p.Add(post);
            }
            return View(p);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(List<Post> posts)
        {
            var editedPosts = posts.Where(p => p.StateId != 3);
            foreach (var p in editedPosts)
            {
                if (p.StateId == 2)
                    p.Text = "Sensored by moderator";
                postService.UpdatePost(p.ToBllPost());
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult ApproveTopics()
        {
            var topics = topicService.GetAllTopicEntities()
                .Where(topic => topic.StateId == 3)
                .Select(topic => topic.ToMvcTopic());
            var states = stateService.GetAllStateEntities().Select(s => s.ToMvcState());
            var forums = forumService.GetAllForumEntities().Select(f => f.ToMvcForum());
            foreach (var topic in topics)
            {
                ViewBag.States =
                     new SelectList(states, "Id", "Name", topic.StateId);
                ViewBag.Forums =
                     new SelectList(forums, "Id", "Title", topic.ForumId);
            }
            List<Topic> t = new List<Topic>();

            foreach (var topic in topics)
            {
                t.Add(topic);
            }
            return View(t);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ApproveTopics(List<Topic> topics)
        {
            var editedTopics = topics.Where(p => p.StateId != 3);
            foreach (var t in editedTopics)
            {
                if (t.StateId == 2)
                    topicService.DeleteTopic(t.ToBllTopic());
                topicService.UpdateTopic(t.ToBllTopic());
            }
            return RedirectToAction("Index");
        }
    }
}