using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class HolidayLightingController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Holiday Lighting Page";
            return View();
        }
    }
}
