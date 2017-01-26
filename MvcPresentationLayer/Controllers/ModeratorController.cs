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

        // GET: Moderator
        public ActionResult Index()
        {
            var sections = postService.GetAllPostEntities()
                .Where(post=>post.StateId==3)
                .Select(post => post.ToMvcPost());
            return View(sections);
        }

        public void Edit(IEnumerable<Post> posts)
        {
           // if(isDenied)
        }
    }
}