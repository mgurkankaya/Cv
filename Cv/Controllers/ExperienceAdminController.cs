using Cv.Models.Entity;
using Cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Controllers
{
    public class ExperienceAdminController : Controller
    {
        // GET: ExperienceAdmin
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience tblExperience)
        {
            repo.Add(tblExperience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            TblExperience tblExperience = repo.Find(x=> x.Id == id);
            repo.Delete(tblExperience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExperience tblExperience = repo.Find(x=>x.Id == id); 
            return View(tblExperience);
        }

        [HttpPost]
        public ActionResult GetExperience(TblExperience tblExperienceP)
        {
            TblExperience value = repo.Find(x => x.Id == tblExperienceP.Id);
            value.Title = tblExperienceP.Title;
            value.Subtitle = tblExperienceP.Subtitle;
            value.Date = tblExperienceP.Date;
            value.Description = tblExperienceP.Description;
            repo.Update(tblExperienceP);
            return RedirectToAction("Index");
        }
    }
}