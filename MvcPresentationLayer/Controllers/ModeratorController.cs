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

        public ModeratorController(IPostService postService, ITopicService topicService, IStateService stateService/*, IProfileService profieService*/)
        {
            this.postService = postService;
            this.topicService = topicService;
            this.stateService = stateService;
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
    }
}