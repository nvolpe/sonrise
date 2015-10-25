using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sonrise.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fort Collins and Loveland Landscape Company | Sonrise Sprinklers";
            return View();
        }
    }
}
