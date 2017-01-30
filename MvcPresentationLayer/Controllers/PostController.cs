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
        public ActionResult Index(int topicId, int page = 1)
        {
            ViewBag.TopicTitle = topicService.GetTopicEntity(topicId).Title;
            ViewBag.TopicDescription = topicService.GetTopicEntity(topicId).Description;
            //ViewBag.topicId = topicId;
            PageInfo pageInfo = new PageInfo
            {
                topicId = topicId,
                PageNumber = page,
                PageSize = PageSize,
                TotalItems = getNumberOfPosts(topicId)
            };
            //IEnumerable<Post> posts = getPosts(topicId,page);
            return View(pageInfo);
        }

        [AllowAnonymous]
       // [HttpGet]
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
                // return PartialView(posts);
                return Json(posts, JsonRequestBehavior.AllowGet);
            }
            return View(posts);
           // return Json(pvm, JsonRequestBehavior.AllowGet);
       }

        /*private IEnumerable<Post> getPosts(int page)
        {
            var posts = postService.GetModeratoredPostEntities()
                .Where(post => post.TopicId == currentTopicId)
                .OrderBy(post=>post.Date)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(post => post.ToMvcPost());
            return posts;
        }*/

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
           // if (!string.IsNullOrEmpty(post))
            {
                string userName = User.Identity.Name;
                post.UserId = userService.GetUserEntityByEmail(userName).Id;
                //post.TopicId = int.Parse(Request.Form["topicId"]);
                post.Date = DateTime.Now;
                post.StateId = stateService.GetStateEntity(3).Id;//возможно перенести это ниже
                postService.CreatePost(post.ToBllPost());
                return RedirectToAction("GetPosts",new { topicId=post.TopicId});
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

        /*[Authorize(Roles = "admin")]
        public ActionResult EditSection(int id)
        {
            Section section = service.GetSectionEntity(id).ToMvcSection();
            return Json(section, JsonRequestBehavior.AllowGet);
        }*/
    }
}