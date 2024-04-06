using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;

namespace Cv.Controllers
{
    
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var value = db.TblAbout.ToList();
            return View(value);
        }

        public PartialViewResult Abouts()
        {
            var about = db.TblAbout.ToList();
            return PartialView(about);
        }

        public PartialViewResult Experiences()
        {
            var experience = db.TblExperience.ToList();
            return PartialView(experience);
        }

        public PartialViewResult Educations()
        {
            var education = db.TblEducation.ToList();
            return PartialView(education);
        }

        public PartialViewResult Skills()
        {
            var skill = db.TblSkill.ToList();
            return PartialView(skill);
        }

        public PartialViewResult Interests()
        {
            var interest = db.TblInterest.ToList();
            return PartialView(interest);
        }

        public PartialViewResult Certifications()
        {
            var certification = db.TblCertification.ToList();
            return PartialView(certification);
        }
        [HttpGet]
        public PartialViewResult Contacts()
        {
            var contact = db.TblContact.ToList();
            return PartialView(contact);
        }
        [HttpPost]
        public PartialViewResult Contacts(TblContact tblContact)
        {
            tblContact.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(tblContact);
            db.SaveChanges();
            return PartialView();
        }
    }
}

