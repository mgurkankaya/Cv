using Cv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin tblAdmin)
        {
            DbCvEntities db = new DbCvEntities();
            var info = db.TblAdmin.FirstOrDefault(x=>x.Username == tblAdmin.Username && x.Password == tblAdmin.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Username, false);
                Session["Username"] = info.Username.ToString();
                return RedirectToAction("Index","AboutAdmin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}