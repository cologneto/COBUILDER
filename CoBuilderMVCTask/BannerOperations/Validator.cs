using System;
using System.ComponentModel.DataAnnotations;

namespace CoBuilderMVCTask
{
   
        public class CustomDateAttribute : RangeAttribute
        {
            public CustomDateAttribute()
              : base(typeof(DateTime),
                      DateTime.Now.ToShortDateString(),
                      DateTime.Now.AddMonths(6).ToShortDateString())
            { }
        }
   
}