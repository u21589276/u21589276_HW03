using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21589276_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Videos()
        {
            return View();
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Videos/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult DeleteFile()
        {
            return View();
        }
    }
}