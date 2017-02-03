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
        private readonly IUserService service;
        private readonly IRoleService roleService;

        public UserController(IUserService service, IRoleService roleService)
        {
            this.service = service;
            this.roleService = roleService;
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var users = service.GetAllUserEntities().Select(user => user.ToMvcUser());

            var roles = roleService.GetAllRoleEntities().Select(s => s.ToMvcRole());
            foreach (var user in users)
            {
                ViewBag.Roles =
                     new SelectList(roles, "Id", "Name", user.RoleId);
                user.IsChanged = false;
            }
            List<User> u = new List<User>();

            foreach (var user in users)
            {
                u.Add(user);
            }
            return View(u);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(List<User> users)
        {
            var editedUsers = users.Where(u => u.IsChanged == true);
            foreach (var user in editedUsers)
            {
                service.UpdateUser(user.ToBllUser());
            }
            return RedirectToAction("Index");
        }
    }
}