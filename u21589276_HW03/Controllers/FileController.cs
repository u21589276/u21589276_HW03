using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21589276_HW03.Models;

namespace u21589276_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Files()
        {
            //Fetch all files in the Folders.

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));
            string[] filePathsImg = Directory.GetFiles(Server.MapPath("~/Media/Images/"));
            string[] filePathsVid = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            foreach (string filePath in filePathsImg)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            foreach (string filePath in filePathsVid)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }
        public FileResult DownloadFile(string fileName)
        {
            //download statement: when the clicke file is not found it will try find the following correct folder.
            try
            {
                string path = Server.MapPath("~/Media/Documents/") + fileName;
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                return File(bytes, "application/octet-stream", fileName);
            }
            catch
            {
                try
                {
                    string pathImg = Server.MapPath("~/Media/Images/") + fileName;
                    byte[] bytesImg = System.IO.File.ReadAllBytes(pathImg);
                    return File(bytesImg, "application/octet-stream", fileName);
                }
                catch
                {
                    string pathVid = Server.MapPath("~/Media/Videos/") + fileName;
                    byte[] bytesVid = System.IO.File.ReadAllBytes(pathVid);
                    return File(bytesVid, "application/octet-stream", fileName);
                }
            }

           
        }
        public ActionResult DeleteFile(string fileName)
        {
            try
            {
                string path = Server.MapPath("~/Media/Documents/") + fileName;
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                System.IO.File.Delete(path);
            }
            catch
            {
                try
                {
                    string pathImg = Server.MapPath("~/Media/Images/") + fileName;
                    byte[] bytesImg = System.IO.File.ReadAllBytes(pathImg);
                    System.IO.File.Delete(pathImg);
                }
                catch
                {
                    string pathVid = Server.MapPath("~/Media/Videos/") + fileName;
                    byte[] bytesVid = System.IO.File.ReadAllBytes(pathVid);
                    System.IO.File.Delete(pathVid);
                }

            }

            return RedirectToAction("Files");
          
        }
    }
}