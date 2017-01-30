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

        [Authorize]
        public ActionResult Index()
        {
            string userEmail = User.Identity.Name;
            var profile = profileService.GetByUserEmail(userEmail).ToMvcProfile();      
            return View(profile);
        }

        [Authorize]
        public ActionResult Edit(ProfileViewModel profileViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    profileViewModel.ImageMimeType = image.ContentType;
                    profileViewModel.Image = new byte[image.ContentLength];
                    image.InputStream.Read(profileViewModel.Image, 0, image.ContentLength);
                }
                profileService.UpdateProfile(profileViewModel.ToBllProfile());
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public FileResult GetImage(int id)
        {
            ProfileViewModel profile = profileService.GetById(id).ToMvcProfile();
            if (profile.Image != null)
            {
                return File(profile.Image, profile.ImageMimeType);
            }
            return new FilePathResult(HttpContext.Server.MapPath("~/Content/AvatarImage/2112715.png"), "image/jpeg");
        }
    }
}