using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21589276_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Biography: Mila Mbopha";

            return View();
        }
        public ActionResult Files()
        {
            ViewBag.Message = "Your Files.";

            //add list to image view
            List<Models.FileModel> files = new List<Models.FileModel>();
           
            return View(files);
        }

        public ActionResult Images()
        {
            ViewBag.Message = "Your Files.";

            //add list to image view
            List<Models.FileModel> files = new List<Models.FileModel>();

            return View();
        }

        public ActionResult Videos()
        {
            ViewBag.Message = "Your Files.";

            //add list to image view
            List<Models.FileModel> files = new List<Models.FileModel>();

            return View();
        }
        

    }
}