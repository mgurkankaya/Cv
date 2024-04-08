using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;


namespace Cv.Controllers
{
    public class SkillAdminController : Controller
    {
        GenericRepository<TblSkill> repo = new GenericRepository<TblSkill>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddSkill(TblSkill tblSkill)
        {
            repo.Add(tblSkill);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x=>x.Id==id);
            repo.Delete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            TblSkill tblSkill = repo.Find(x => x.Id == id);
            return View(tblSkill);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkill tblSkill)
        {
            TblSkill value = repo.Find(x => x.Id == tblSkill.Id);
            value.Skill = tblSkill.Skill;
            value.Rate = tblSkill.Rate;
            repo.Update(tblSkill);
            return RedirectToAction("Index");
        }

    }
}