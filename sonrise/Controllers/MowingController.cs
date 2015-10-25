using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class MowingController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fort Collins Lawn Mowing Service and Lawn Maintenance | Sonrise";
            return View();
        }
    }
}
