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
        public ActionResult Index(HttpPostedFileBase uploadFileOpt, string fileTypeRad)//INSIDE HOME
        {
            //if statement to determine which folder to upload the file to depending on the radioBtn selected
            if(fileTypeRad == "Document")
            {
                //upoload to Document folder
                if (uploadFileOpt != null && uploadFileOpt.ContentLength > 0)
                {
                    var fileToSave = Path.GetFileName(uploadFileOpt.FileName);

                    var saveInPath = Path.Combine(Server.MapPath("~/Media/Documents"), fileToSave);

                    uploadFileOpt.SaveAs(saveInPath);
                }
               
            }
            else if(fileTypeRad == "Image")
            {
                //upload to Image folder
                if (uploadFileOpt != null && uploadFileOpt.ContentLength > 0)
                {
                    var fileToSave = Path.GetFileName(uploadFileOpt.FileName);

                    var saveInPath = Path.Combine(Server.MapPath("~/Media/Images"), fileToSave);

                    uploadFileOpt.SaveAs(saveInPath);
                }
            }
            else if (fileTypeRad == "Video")
            {
                //upload to video folder
                if (uploadFileOpt != null && uploadFileOpt.ContentLength > 0)
                {
                    var fileToSave = Path.GetFileName(uploadFileOpt.FileName);

                    var saveInPath = Path.Combine(Server.MapPath("~/Media/Videos"), fileToSave);

                    uploadFileOpt.SaveAs(saveInPath);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Biography";

            return View();
        }

    }
}