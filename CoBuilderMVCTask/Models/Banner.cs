using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace CoBuilderMVCTask.Models
{
    public class Banner
    {
        [Display(Name = "Banner Name: ")]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        
       
        [Display(Name = "Valid From")]
        [DataType(DataType.DateTime)]
        
        [CustomDate(ErrorMessage = "wadhfjsk")]
        public DateTime ValidFrom { get; set; }

        
        [Display(Name = "Valid From")]
        [DataType(DataType.DateTime)]
        
        [CustomDate(ErrorMessage = "wadhfjsk")]
        //[Range(typeof(DateTime), "1/1/2016 1:00:00 AM", "1/1/2016 1:00:00 AM", ErrorMessage = "Date is out of Range")]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Select image: ")]
        [Required(ErrorMessage = "{0} is required")]
        public byte[] File { get; set; }
    }
}