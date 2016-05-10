using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoBuilderMVCTask.Models
{
    public class NumbersRange
    {
        [Display(Name ="Negative Number")]
        [Required(ErrorMessage ="{0} is required")]
        [Range(-100,0, ErrorMessage ="Please enter a number between -100 to 0")]
        public int min { get; set; }

        [Display(Name = "Positive Number")]
        [Required(ErrorMessage = "{0} is required")]
        [Range(0, 100, ErrorMessage = "Please enter a number between 0 to 100")]
        public int max { get; set; }
    }
}