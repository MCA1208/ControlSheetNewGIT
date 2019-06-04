using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlSheet.Controllers
{
    public class ControlSheetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Proyect()
        {           

            return View();
        }
        public ActionResult Report()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}