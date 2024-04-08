using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entity;
using Cv.Repositories;

namespace Cv.Controllers
{
    public class ContactAdminController : Controller
    {
        GenericRepository<TblContact> repo = new GenericRepository<TblContact>();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        public ActionResult DeleteContact(int id)
        {
            TblContact tblContact = repo.Find(x => x.Id == id);
            repo.Delete(tblContact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            TblContact tblContact = repo.Find(x => x.Id == id);
            return View(tblContact);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact tblContact)
        {
            TblContact value = repo.Find(x => x.Id == tblContact.Id);
            value.NameSurname = tblContact.NameSurname;
            value.Mail = tblContact.Mail;
            value.Subject = tblContact.Subject;
            value.Message = tblContact.Message;
            repo.Update(tblContact);
            return RedirectToAction("Index");
        }
    }
}