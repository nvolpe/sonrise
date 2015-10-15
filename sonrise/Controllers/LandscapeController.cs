using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class LandscapeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fort Collins Landscape and Lawn Care Services | Sonrise Sprinklers";
            return View();
        }
    }
}
