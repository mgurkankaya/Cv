using Cv.Models.Entity;
using Cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Controllers
{
    [Authorize]
    public class EducationAdminController : Controller
    {
        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation tblEducation)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.Add(tblEducation);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            TblEducation tblEducation = repo.Find(x => x.Id == id);
            repo.Delete(tblEducation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            TblEducation tblEducation = repo.Find(x => x.Id == id);
            return View(tblEducation);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation tblEducation)
        {
            TblEducation value = repo.Find(x => x.Id == tblEducation.Id);
            value.Title = tblEducation.Title;
            value.Subtitle = tblEducation.Subtitle;
            value.Subtitle2 = tblEducation.Subtitle2;
            value.Date = tblEducation.Date;
            repo.Update(tblEducation);
            return RedirectToAction("Index");
        }
    }
}