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
            ViewBag.Title = "Contact Us Page";
            return View();
        }
    }
}
