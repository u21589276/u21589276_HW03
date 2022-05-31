﻿using System;
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
            
            List<FileModel> files = new List<FileModel>();

            foreach (string filePathDocs in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathDocs) });
            }

            return View(files);
        }
        public FileResult DownloadFile(string fileName)
        {
            
                string path = Server.MapPath("~/Media/Documents/") + fileName;

                byte[] bytes = System.IO.File.ReadAllBytes(path);

                return File(bytes, "application/octet-stream", fileName);
     
           
        }
        public ActionResult DeleteFile(string fileName)
        {
                string path = Server.MapPath("~/Media/Documents/") + fileName;

                byte[] bytes = System.IO.File.ReadAllBytes(path);

                System.IO.File.Delete(path);
         
            
            return RedirectToAction("Files");
          
        }
    }
}