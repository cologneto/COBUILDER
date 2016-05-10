using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoBuilderMVCTask.Models
{
    public class BannerDB
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Valid From")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(HtmlEncode = true,ApplyFormatInEditMode =true)]
        [CustomDate(ErrorMessage = "wadhfjsk")]
        public DateTime ValidFrom { get; set; }

        [Display(Name = "Valid To")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(HtmlEncode = true,ApplyFormatInEditMode =true)]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Select image: ")]
        [Required(ErrorMessage = "{0} is required")]
        public byte[] File { get; set; }
    }
}