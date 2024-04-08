using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;
namespace Cv.Controllers
{
    public class AboutAdminController : Controller
    {
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAbout(TblAbout tblAbout)
        {
         
            repo.Add(tblAbout);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var about = repo.Find(x => x.Id == id);
            repo.Delete(about);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            TblAbout tblAbout = repo.Find(x => x.Id == id);
            return View(tblAbout);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout tblAbout)
        {
            TblAbout value = repo.Find(x => x.Id == tblAbout.Id);
            value.Name = tblAbout.Name;
            value.Surname = tblAbout.Surname;
            value.Adress = tblAbout.Adress;
            value.Phone = tblAbout.Phone;
            value.Mail = tblAbout.Mail;
            value.Description = tblAbout.Description;
            value.Photo = tblAbout.Photo;
            repo.Update(tblAbout);
            return RedirectToAction("Index");
        }
    }
}