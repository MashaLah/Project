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
        private readonly IStateService stateService;
        //private readonly IProfileService profieService;

        public PostController(IPostService postService, ITopicService topicService, IUserService userService, IStateService stateService)
        {
            this.postService = postService;
            this.topicService = topicService;
            this.userService = userService;
            this.stateService = stateService;
           // this.postService = postService;
        }

        // GET: Post
        [AllowAnonymous]
        public ActionResult Index(int topicId)
        {
            ViewBag.TopicTitle = topicService.GetTopicEntity(topicId).Title;
            ViewBag.TopicDescription = topicService.GetTopicEntity(topicId).Description;
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetPosts(int topicId)
        {
            var posts = postService.GetModeratoredPostEntities().Where(post => post.TopicId == topicId).Select(post => post.ToMvcPost());
            if (Request.IsAjaxRequest())
            {
                return PartialView(posts);
            }
            return View(posts);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                post.UserId = userService.GetUserEntityByEmail(userName).Id;
                //post.TopicId = int.Parse(Request.Form["topicId"]);
                post.Date = DateTime.Now;
                post.StateId = stateService.GetStateEntity(3).Id;//возможно перенести это ниже
                postService.CreatePost(post.ToBllPost());
                return RedirectToAction("GetPosts",new { topicId=post.TopicId});
            }
            return View(post);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditByAdmin(int id)
        {
            Post post = postService.GetPostEntity(id).ToMvcPost();
            post.Text = "Sensored by moderator";
            postService.UpdatePost(post.ToBllPost());
            return RedirectToAction("GetPosts");
        }

        /*[Authorize(Roles = "admin")]
        public ActionResult EditSection(int id)
        {
            Section section = service.GetSectionEntity(id).ToMvcSection();
            return Json(section, JsonRequestBehavior.AllowGet);
        }*/
    }
}