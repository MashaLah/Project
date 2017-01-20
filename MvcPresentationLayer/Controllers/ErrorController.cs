﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentationLayer.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
           // return new NotFoundResult();
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
            // return new NotFoundResult();
        }
    }
}