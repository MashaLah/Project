using BLL.Interface.Services;
using MvcPresentationLayer.Infrastruct.Mappers;
using MvcPresentationLayer.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcPresentationLayer.Controllers
{
    public class ForumController : Controller
    {
        /* List<Forum> forums = new List<Forum>()
         {
             new Forum() {Id=1, SectionId=1, Title="Appliances", Date=DateTime.Now,
                 Topics =new List<Topic>()
                 {
                   new Topic() { Id=1, Title="Fridge repair", Description="bla bla",
                       Date =DateTime.Now, ForumId=1},
                   new Topic() { Id=2, Title="Choosing cleaner", Description="bla bla cleaner",
                       Date =DateTime.Now, ForumId=1}
                 } },
             new Forum() {Id=2, SectionId=1, Title="Mobile", Date=DateTime.Now,
             Topics =new List<Topic>()
             {
             new Topic() { Id=3, Title="Mobile repair", Description="bla bla",
                 Date =DateTime.Now, ForumId=2},
             new Topic() { Id=4, Title="Choosing mobile", Description="bla bla mobile",
                 Date =DateTime.Now, ForumId=2},
             } },
             new Forum() {Id=3, SectionId=2, Title="Exchange", Date=DateTime.Now,
             Topics =new List<Topic>()
             {
                 new Topic() { Id=5, Title="Dollar", Description="bla bla",
                 Date =DateTime.Now, ForumId=3},
             new Topic() { Id=6, Title="Euro", Description="bla bla euro",
                 Date =DateTime.Now, ForumId=3},
             } },
             new Forum() {Id=4, SectionId=3, Title="Christmas", Date=DateTime.Now,Topics =new List<Topic>()
             {
                new Topic() { Id=7, Title="Santa", Description="bla bla",
                 Date =DateTime.Now, ForumId=4},
             new Topic() { Id=8, Title="Dishes", Description="bla bla dishes",
                 Date =DateTime.Now, ForumId=4},
             } }
         };

         List<Topic> topics = new List<Topic>()
         {
             new Topic() { Id=1, Title="Fridge repair", Description="bla bla",
                 Date =DateTime.Now, ForumId=1},
             new Topic() { Id=2, Title="Choosing cleaner", Description="bla bla cleaner",
                 Date =DateTime.Now, ForumId=1},
             new Topic() { Id=3, Title="Mobile repair", Description="bla bla",
                 Date =DateTime.Now, ForumId=2},
             new Topic() { Id=4, Title="Choosing mobile", Description="bla bla mobile",
                 Date =DateTime.Now, ForumId=2},
             new Topic() { Id=5, Title="Dollar", Description="bla bla",
                 Date =DateTime.Now, ForumId=3},
             new Topic() { Id=6, Title="Euro", Description="bla bla euro",
                 Date =DateTime.Now, ForumId=3},
              new Topic() { Id=7, Title="Santa", Description="bla bla",
                 Date =DateTime.Now, ForumId=4},
             new Topic() { Id=8, Title="Dishes", Description="bla bla dishes",
                 Date =DateTime.Now, ForumId=4},
         };*/

        // GET: Forum
        /* public ActionResult Index(int? id)
         {
             // var frms = forums;
             // return View(frms);
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             var frm = forums.Find(f => f.Id == id);
             if (frm == null)
             {
                 return HttpNotFound();
             }
             return View(frm);
         }*/

        private readonly IForumService forumService;
        //private readonly ISectionService sectionService;
        private readonly IUserService userService;

        public ForumController(IForumService forumService, IUserService userService /*ISectionService sectionService*/)
        {
            this.forumService = forumService;
            this.userService = userService;
           // this.sectionService = sectionService;
        }

        public ActionResult Index(/*int id*/)
        {
            //var forum = forumService.GetForumEntity(id).ToMvcForum();
            //var forums = forumService.GetAllForumEntitiesByParentId(id).Select(forum => forum.ToMvcForum());
            return View(/*forum*/);
        }

        public ActionResult GetTopics(int id)
        {
            var forum = forumService.GetForumEntity(id).ToMvcForum();
            return PartialView(forum);
        }

         [HttpGet]
         public ActionResult Create(/*int sectionId*/)
         {
             return View();
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Forum forum)
        {
            string userName = User.Identity.Name;
            forum.UserId = userService.GetUserEntityByEmail(userName).Id;
            //forum.SectionId = int.Parse(Request.Form["sectionId"]);
            forum.Date = DateTime.Now;
            forumService.CreateForum(forum.ToBllForum());
            return RedirectToAction("Index");
        }

       /* [HttpGet]
        public ActionResult CreateForumPartial() 
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForumPartial(Forum forum)
        {
            string userName = User.Identity.Name;
            forum.UserId = userService.GetUserEntityByEmail(userName).Id;
            //forum.SectionId = int.Parse(Request.Form["sectionId"]);
            forum.Date = DateTime.Now;
            forumService.CreateForum(forum.ToBllForum());
            return RedirectToAction("Index");
        }*/
    }
}