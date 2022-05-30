using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21589276_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        //File Upload Recieve
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase fileupload)//INSIDE HOME
        {
            
            if (fileupload != null && fileupload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(fileupload.FileName);

                var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);

                fileupload.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Biography: Mila Mbopha";

            return View();
        }

        //============================================================================
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