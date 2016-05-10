using CoBuilderMVCTask.Data;
using CoBuilderMVCTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoBuilderMVCTask.Controllers
{
    public class BannerController : Controller
    {
        public object TodaySlides { get; private set; }

        // GET: Banner
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Banner banner, HttpPostedFileBase upload)
        {

            if (Request.Files != null && Request.Files.Count == 1)
            {
                upload = Request.Files[0];
                if (upload != null && upload.ContentLength > 0)
                {
                    var content = new byte[upload.ContentLength];
                    upload.InputStream.Read(content, 0, upload.ContentLength);
                    banner.File = content;

                    var context = new Context();

                    context.BannersDatabase.Add(new BannerDB
                    {
                        Name = banner.Name,
                        File = banner.File,
                        ValidFrom = banner.ValidFrom,
                        ValidTo = banner.ValidTo
                    });
                    context.SaveChanges();
                    // the rest of your db code here
                }
            }
            return RedirectToAction("Create");

        }


        public ActionResult BannerList()
        {
            var banners = new List<BannerDB>();

            using (var db = new Context())
            {
                banners.AddRange(db.BannersDatabase.ToList());
            }

            return View(banners);
        }

        public ActionResult DeletePopUp(int id)
        {
            BannerDB bannerForDelete;
            using (var db = new Context())
            {
                bannerForDelete = db.BannersDatabase.Find(id);

            }


            return PartialView(bannerForDelete);
        }


        public ActionResult Delete(int id)
        {

            using (var db = new Context())
            {

                db.BannersDatabase.RemoveRange(db.BannersDatabase.Where(x => x.Id == id));
                db.SaveChanges();
            }

            return RedirectToAction("BannerList");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            BannerDB banForEdit;

            using (var db = new Context())
            {
                banForEdit = db.BannersDatabase.Where(x => x.Id == id).ToArray()[0];
            }

            return View(banForEdit);
        }

        [HttpPost]
        public ActionResult Edit(BannerDB ban, HttpPostedFileBase upload, string file)
        {

            var sdfio = Request.ContentLength;
            
            var db = new Context();
            
            upload = Request.Files[0];
            if (upload != null && upload.ContentLength > 0)
            {
                var content = new byte[upload.ContentLength];
                upload.InputStream.Read(content, 0, upload.ContentLength);
                ban.File = content;

            }

            db.Entry(ban).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("BannerList");
            
        }

        [HttpGet]
        public ActionResult Slider()
        {
            DateTime now = DateTime.Now;
            var slidesList = new List<BannerDB>();
            var db = new Context();

            using (db)
            {
                slidesList = db.BannersDatabase.Where(x => (x.ValidTo >= now))
                                                .Where(y => y.ValidFrom <= now)
                                                 .ToList();
            }
            return View(slidesList);
        }
    }
}