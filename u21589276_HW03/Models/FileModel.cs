using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace u21589276_HW03.Models
{
    public class FileModel
    {
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "Download option")]
        public string DownloadOption { get; set; }

        [Display(Name = "Delete Option")]
        public string DeleteOption { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}