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
        const int PageSize = 5;

        public PostController(IPostService postService, ITopicService topicService, IUserService userService, IStateService stateService)
        {
            this.postService = postService;
            this.topicService = topicService;
            this.userService = userService;
            this.stateService = stateService;
        }

        // GET: Post
        [AllowAnonymous]
        public ActionResult Index(int topicId, int page = 1)
        {
            Topic topic = topicService.GetTopicEntity(topicId).ToMvcTopic();
            PageInfo pageInfo = new PageInfo
            {
                Topic = topic,
                PageNumber = page,
                PageSize = PageSize,
                TotalItems = getNumberOfPosts(topicId)
            };
            return View(pageInfo);
        }

        [AllowAnonymous]
        public ActionResult GetPosts(int topicId, int page=1)
        {
            IEnumerable<Post> posts = postService.GetModeratoredPostEntities()
                .Where(post => post.TopicId == topicId)
                .OrderBy(post => post.Date)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(post => post.ToMvcPost());
            if (Request.IsAjaxRequest())
            {
                return Json(posts, JsonRequestBehavior.AllowGet);
            }
            return View(posts);
       }

        private int getTotalPages(int topicId)
        {
            int totalItems = postService.GetModeratoredPostEntities()
                .Where(post => post.TopicId == topicId).Count();
            return (int)Math.Ceiling((decimal)totalItems / PageSize);
        }

        private int getNumberOfPosts(int topicId)
        {
            return postService.GetModeratoredPostEntities()
                .Where(post => post.TopicId == topicId).Count();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                post.UserId = userService.GetUserEntityByEmail(userName).Id;
                post.Date = DateTime.Now;
                post.StateId = stateService.GetStateEntity(3).Id;
                postService.CreatePost(post.ToBllPost());
                return RedirectToAction("Index",new { topicId=post.TopicId});
            }
            return View("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditByAdmin(int id)
        {
            Post post = postService.GetPostEntity(id).ToMvcPost();
            post.Text = "Sensored by moderator";
            postService.UpdatePost(post.ToBllPost());
            return RedirectToAction("GetPosts");
        }
    }
}