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
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ITopicService topicService;
        private readonly IUserService userService;


        public PostController(IPostService postService, ITopicService topicService, IUserService userService)
        {
            this.postService = postService;
            this.topicService = topicService;
            this.userService = userService;
        }

        // GET: Post
        [AllowAnonymous]
        public ActionResult Index(int topicId)
        {
            //var posts = postService.GetAllPostEntities().Where(post => post.TopicId == topicId).Select(post => post.ToMvcPost());
            ViewBag.TopicTitle = topicService.GetTopicEntity(topicId).Title;
            ViewBag.TopicDescription = topicService.GetTopicEntity(topicId).Description;
            return View(/*posts*/);
        }

        [AllowAnonymous]
        public ActionResult GetPosts(int topicId)
        {
            var posts = postService.GetAllPostEntities().Where(post => post.TopicId == topicId).Select(post => post.ToMvcPost());
            // if (Request.IsAjaxRequest())
            // {
            return PartialView(posts);
           // }
           // return View(sections);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                post.UserId = userService.GetUserEntityByEmail(userName).Id;
                //forum.SectionId = int.Parse(Request.Form["sectionId"]);
                post.Date = DateTime.Now;
                postService.CreatePost(post.ToBllPost());
                return RedirectToAction("Index");
            }
            return View(post);
        }
    }
}