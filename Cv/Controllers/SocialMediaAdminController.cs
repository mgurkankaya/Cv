using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;
namespace Cv.Controllers
{
    public class SocialMediaAdminController : Controller
    {
        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
           return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia tblSocialMedia)
        {
            repo.Add(tblSocialMedia);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int  id)
        {
            var value = repo.Find(x=>x.ID== id);    
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia tblSocialMedia)
        {
            var value = repo.Find(x => x.ID == tblSocialMedia.ID);
            value.Status=true;
            value.SMName = tblSocialMedia.SMName;
            value.Link = tblSocialMedia.Link;
            value.Class = tblSocialMedia.Class;
            repo.Update(value);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = repo.Find(x=>x.ID == id);
            value.Status = false;
            repo.Update(value);
            return RedirectToAction("Index");   
        }
    }
}