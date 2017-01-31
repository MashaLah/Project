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
        private readonly ISectionService service;

        public HomeController(ISectionService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetSections()
        {
            var sections = service.GetAllSectionEntities().Select(section => section.ToMvcSection());
            return View(sections);
        }

         [HttpGet]
         [Authorize(Roles = "admin")]
         public ActionResult Create()
         {
             return PartialView();
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Section section)
        {
            if (ModelState.IsValid)
            {
                service.CreateSection(section.ToBllSection());
                if (Request.IsAjaxRequest())
                {
                    return RedirectToAction("GetSections");
                }
                return RedirectToAction("Index");
            }
            return View(section);
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteSection(int id)
        {
            Section section = service.GetSectionEntity(id).ToMvcSection();
            if (section.Topics != null)
                return PartialView(section);
            return View("Index");
        }

        [HttpPost,ActionName("DeleteSection")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult ConfirmDelete(int id)
        {
            SectionEntity section = service.GetSectionEntity(id);
            if (section.Topics == null)
            {
                service.DeleteSection(section);
                if (Request.IsAjaxRequest())
                {
                    return RedirectToAction("GetSections");
                }
                return RedirectToAction("Index");
            }
            else ModelState.AddModelError("", "Section has topics.");
            return PartialView("DeleteSection");
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
    }
}