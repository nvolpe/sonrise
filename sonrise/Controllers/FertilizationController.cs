using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class FertilizationController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fertilization Page";
            return View();
        }
    }
}
