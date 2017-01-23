using BLL.Interface.Services;
using MvcPresentationLayer.Infrastruct.Mappers;
using MvcPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using BLL.Interface.Entities;


namespace MvcPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        /* List<Section> sections = new List<Section>()
         {
             new Section() {Id=1, Name="Technologies",Forums= new List<Forum>()
             {
                 new Forum() {Id=1, SectionId=1, Title="Appliances", Date=DateTime.Now},
                  new Forum() {Id=2, SectionId=1, Title="Mobile", Date=DateTime.Now}
             } },
             new Section() {Id=2, Name="Finaces",Forums= new List<Forum>()
             {new Forum() {Id=3, SectionId=2, Title="Exchange", Date=DateTime.Now} } },
             new Section() {Id=3, Name="Other",Forums= new List<Forum>() { new Forum() { Id = 4, SectionId = 3, Title = "Christmas", Date = DateTime.Now } } }
         };

         List<Post> posts = new List<Post>() { };*/

        private readonly ISectionService service;

        public HomeController(ISectionService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            //var sections = service.GetAllSectionEntities().Select(section => section.ToMvcSection());
            //return View(sections);
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetSections()
        {
            var sections = service.GetAllSectionEntities().Select(section => section.ToMvcSection());
            if (Request.IsAjaxRequest())
            {
                return PartialView(sections);
            }
            return View(sections);
        }

        /* [HttpGet]
         [Authorize(Roles = "admin")]
         public ActionResult Create()
         {
             return View();
         }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Section section)
        {
            //if ajax request
            service.CreateSection(section.ToBllSection());
            return RedirectToAction("GetSections");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            SectionEntity section = service.GetSectionEntity(id);
            service.DeleteSection(section);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditSection(int id)
        {
            Section section = service.GetSectionEntity(id).ToMvcSection();
            return PartialView(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult EditSection(Section section)
        {
            if (ModelState.IsValid)
            {
                service.UpdateSection(section.ToBllSection());
                return RedirectToAction("Index");
            }
            return View(section);
        }

        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.AuthType = User.Identity.AuthenticationType;
            }
            ViewBag.Login = User.Identity.Name;
            ViewBag.IsAdminInRole = User.IsInRole("Administrator") ?
                "You have administrator rights." : "You do not have administrator rights.";

            return View();
            //HttpContext.Profile["FirstName"] = "Вася";
            //HttpContext.Profile["LastName"] = "Иванов";
            //HttpContext.Profile.SetPropertyValue("Age",23);
            //Response.Write(HttpContext.Profile.GetPropertyValue("FirstName"));
            //Response.Write(HttpContext.Profile.GetPropertyValue("LastName"));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreatePartial()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        public ActionResult CreateForumPartial()
        {
            return PartialView();
        }
    }
}