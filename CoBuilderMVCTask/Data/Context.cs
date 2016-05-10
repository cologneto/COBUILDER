using CoBuilderMVCTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoBuilderMVCTask.Data
{
    public class Context : DbContext
    {
        public DbSet<BannerDB> BannersDatabase { get; set; }
    }
}