using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class SnowRemovalController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Snow Removal Page";
            return View();
        }
    }
}
