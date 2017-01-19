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
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IUserService userService;

        public ProfileController(IProfileService profileService, IUserService userService)
        {
            this.profileService = profileService;
            this.userService = userService;
        }

        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            //в репозиторий get profile by user id get user id be email
            string userEmail = User.Identity.Name;
            var profile = profileService.GetByUserEmail(userEmail).ToMvcProfile();      
            return View(profile);
        }

        public ActionResult ChangeAvatar()
        {
            throw new NotImplementedException();
        }
    }
}