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

        public ActionResult Index()
        {
            var sections = service.GetAllSectionEntities().Select(section => section.ToMvcSection());
            return View(sections);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Section section)
        {
            service.CreateSection(section.ToBllSection());
            return RedirectToAction("Index");
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
    }
}