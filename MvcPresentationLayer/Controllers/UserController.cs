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
    public class UserController : Controller
    {
        //List<User> users = new List<User>() { };

        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET: User
        public ActionResult Index()
        {
            var model = service.GetAllUserEntities().Select(user => user.ToMvcUser());

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit()
        {
            var model = service.GetAllUserEntities().Select(u => u.ToMvcUser());

            return View(model);
        }
    }
}