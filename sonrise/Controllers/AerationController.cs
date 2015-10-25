using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class AerationController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fort Collins Lawn Aeration and Core Aeration | Sonrise Sprinklers";

            return View();
        }
    }
}
