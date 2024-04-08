using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;

namespace Cv.Controllers
{
    public class CertificationAdminController : Controller
    {
        GenericRepository<TblCertification> repo = new GenericRepository<TblCertification>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }


        [HttpGet]
        public ActionResult AddCertification()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddCertification(TblCertification tblCertification)
        {
            var newTime = DateTime.Now.ToString("HH:mm:ss tt");

            tblCertification.Time = newTime;
            repo.Add(tblCertification);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertification(int id)
        {
            var certification = repo.Find(x => x.Id == id);
            repo.Delete(certification);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCertification(int id)
        {
            TblCertification tblCertification = repo.Find(x => x.Id == id);
            return View(tblCertification);
        }

        [HttpPost]
        public ActionResult UpdateCertification(TblCertification tblCertification)
        {
            var newTime = DateTime.Now.ToString("HH:mm:ss tt");
            TblCertification value = repo.Find(x => x.Id == tblCertification.Id);
            
            value.Certifications = tblCertification.Certifications;
            value.Time = newTime;
            value.Date = tblCertification.Date;
            repo.Update(tblCertification);
            return RedirectToAction("Index");
        }
    }
}

//DateTime.Now.ToString("HH:mm:ss tt");