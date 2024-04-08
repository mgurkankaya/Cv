using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;
namespace Cv.Controllers
{
    public class InterestAdminController : Controller
    {
        GenericRepository<TblInterest> repo = new GenericRepository<TblInterest>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }


        [HttpGet]
        public ActionResult AddInterest()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddInterest(TblInterest tblInterest)
        {
            repo.Add(tblInterest);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInterest(int id)
        {
            var interest = repo.Find(x => x.Id == id);
            repo.Delete(interest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInterest(int id)
        {
            TblInterest tblInterest = repo.Find(x => x.Id == id);
            return View(tblInterest);
        }

        [HttpPost]
        public ActionResult UpdateInterest(TblInterest tblInterest)
        {
            TblInterest value = repo.Find(x => x.Id == tblInterest.Id);
            value.Description = tblInterest.Description;
            repo.Update(tblInterest);
            return RedirectToAction("Index");
        }
    }
}