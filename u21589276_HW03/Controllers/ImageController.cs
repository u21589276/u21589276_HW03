using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21589276_HW03.Models;

namespace u21589276_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Image()
        {
            //Fetch all files in the Folder (Directory).

            string[] filePath = Directory.GetFiles(Server.MapPath("~/Media/Images/"));

            //the list of the files from the folder taken from model and set to list
            List<FileModel> files = new List<FileModel>();

            foreach (string filePathimg in filePath)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathimg) });
            }
            return View(files);
            
        }

        public FileResult DownloadFile(string fileName)
        {
            //find path of file and select to download it
            string filepath = Server.MapPath("~/Media/Images/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(filepath);

            //returns the file information to be downloaded
            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult DeleteFile(string fileName)
        {
            //find path of file and select to delete it
            string filepath = Server.MapPath("~/Media/Images/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(filepath);

            System.IO.File.Delete(filepath);

           //returns to the image.cshtml view
            return RedirectToAction("Image");
         
        }
    }
}