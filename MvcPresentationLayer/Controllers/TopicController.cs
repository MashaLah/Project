﻿using BLL.Interface.Services;
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
        /*List<Topic> topics = new List<Topic>()
        {
            new Topic() { Id=1, Title="Fridge repair", Description="bla bla",
                Date =DateTime.Now, ForumId=1, Posts=new List<Post>()
                {
                    new Post() { Id=1,Text="bla bla bla bla bla bla bla bla",
                    Date=DateTime.Now,TopicId=1},
                     new Post() { Id=2,Text="bla bla bla bla bla bla bla bla bla",
                    Date=DateTime.Now,TopicId=1},
                      new Post() { Id=3,Text="bla bla bla bla bla bla bla bla bla bla ",
                    Date=DateTime.Now,TopicId=1},
                       new Post() { Id=4,Text="bla bla bla bla bla bla bla bla qqqqq",
                    Date=DateTime.Now,TopicId=1},
                        new Post() { Id=5,Text="bla bla bla bla bla bla bla bla sdcsdsadas",
                    Date=DateTime.Now,TopicId=1},
                         new Post() { Id=6,Text="bla bla bla bla bla bla bla bla ipiopip",
                    Date=DateTime.Now,TopicId=1},
                          new Post() { Id=7,Text="bla bla bla bla bla bla bla bla hdhdhd",
                    Date=DateTime.Now,TopicId=1},
                           new Post() { Id=8,Text="bla bla bla bla bla bla bla bla wertyu",
                    Date=DateTime.Now,TopicId=1},
                            new Post() { Id=9,Text="bla bla bla bla bla bla bla bla uytrew",
                    Date=DateTime.Now,TopicId=1},
                             new Post() { Id=10,Text="bla bla bla bla bla bla bla bla kjhgfds",
                    Date=DateTime.Now,TopicId=11},
                              new Post() { Id=12,Text="bla bla bla bla bla bla bla bla asdfghjk",
                    Date=DateTime.Now,TopicId=1},
                } },
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

        // GET: Topic
        /* public ActionResult Index(int? id, int page = 1)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             int pageSize = 5;
             var tpc = topics.Find(f => f.Id == id);
             IEnumerable<Post> postsPerPage = tpc.Posts.Skip((page - 1) * pageSize).Take(pageSize);
             //int postsPerPage = tpc.Posts.Skip((page - 1) * pageSize).Take(pageSize).Count();
             PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tpc.Posts.Count };
             PostsViewModel pvm = new PostsViewModel { PageInfo = pageInfo, Posts = postsPerPage,Topic=tpc };
             if (tpc == null)
             {
                 return HttpNotFound();
             }
             return View(pvm);
            // Answer(id, page);
         }*/

        private readonly ITopicService topicService;
        private readonly IForumService forumService;

        public TopicController(ITopicService topicService, IForumService forumService)
        {
            this.topicService = topicService;
            this.forumService = forumService;
        }

        public ActionResult Index(int forumId)
        {
            var topics = topicService.GetAllTopicEntities().Where(t => t.ForumId == forumId);
            ViewData["ForumForTopics"] = forumService.GetForumEntity(forumId).Title;
            return View(topics);
        }

       /* public PartialViewResult Answer(int? id, int page)
        {*/
       /*if (id == null)
       {
           return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
       }*/
       /* int pageSize = 5;
        var tpc = topics.Find(f => f.Id == id);
        IEnumerable<Post> postsPerPage = tpc.Posts.Skip((page - 1) * pageSize).Take(pageSize);
        //int postsPerPage = tpc.Posts.Skip((page - 1) * pageSize).Take(pageSize).Count();
        PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tpc.Posts.Count };
        PostsViewModel pvm = new PostsViewModel { PageInfo = pageInfo, Posts = postsPerPage, Topic = tpc };
        */
       /*if (tpc == null)
     {
         return HttpNotFound();
     }*/
       /*return PartialView(pvm);
   }*/

        public ActionResult Add(string text)
        {
            /*Post post = new Post()
            {
                Id = 13,
                Text = text,
                Date = DateTime.Now,
                TopicId = 1
            };
            topics[0].Posts.Add(post);
            if (Request.IsAjaxRequest())
            {
                return PartialView("Answer");
            }*/
            //return View();
            return RedirectToAction("Index");
        }

        /* [HttpPost]
         public ActionResult Add(string text)
         {
              Post post = new Post()
              {
                  Id = 13,
                  Text = "answer text",
                  Date = DateTime.Now,
                  TopicId = 1
              };
              topics[0].Posts.Add(post);
             if (Request.IsAjaxRequest())
             {
                 //return PartialView();
                 return Json(topics);
             }
             //return View();
             return RedirectToAction("Index");
         }*/

        // GET: Sellers/Create
        public ActionResult Create()
        {
            //ViewBag.SellingPointID = new SelectList(db.SellingPoints, "SellingPointID", "Adress");
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        //[ValidateAntiForgeryToken]
        // public ActionResult Create(/*[Bind(Include = "SellerID,SellerName,SellingPointID")]*/ Post post)
        /* {
             if (ModelState.IsValid)
             {
                 topics[0].Posts.Add(post);
                // db.SaveChanges();
                 return RedirectToAction("Index");
             }

             //ViewBag.SellingPointID = new SelectList(db.SellingPoints, "SellingPointID", "Adress", seller.SellingPointID);
             return View(post);
         }*/

        [ValidateAntiForgeryToken]
        public ActionResult Create(Topic topic)
        {
            /*string userName = User.Identity.Name;
            forum.UserId = userService.GetUserEntityByEmail(userName).Id;
            //forum.SectionId = int.Parse(Request.Form["sectionId"]);
            forum.Date = DateTime.Now;
            forumService.CreateForum(forum.ToBllForum());*/
            return RedirectToAction("Index");
        }
    }
}