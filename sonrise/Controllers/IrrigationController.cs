using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class IrrigationController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fort Collins Lawn Irrigation Systems | Sonrise Sprinklers Colorado";
            return View();
        }
    }
}
