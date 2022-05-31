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
        public ActionResult Index(HttpPostedFileBase fileupload, string fileTypeRad)//INSIDE HOME
        {
            //if statement to determine which folder to upload the file to depending on the radioBtn selected
            if(fileTypeRad == "Document")
            {
                //upoload to Document folder
                if (fileupload != null && fileupload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);

                    var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);

                    fileupload.SaveAs(path);
                }
               
            }
            else if(fileTypeRad == "Image")
            {
                //upload to Image folder
                if (fileupload != null && fileupload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);

                    var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);

                    fileupload.SaveAs(path);
                }
            }
            else if (fileTypeRad == "Video")
            {
                //upload to video folder
                if (fileupload != null && fileupload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);

                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);

                    fileupload.SaveAs(path);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Biography: Mila Mbopha";

            return View();
        }

    }
}