using MvcStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcStore.Controllers
{
    public class LoginController : Controller
    {
        DbMvcMagazaEntities db = new DbMvcMagazaEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblAdmin p)
        {
            var li = db.tblAdmin.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if (li != null)
            {
                FormsAuthentication.SetAuthCookie(li.Kullanici, false);                
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı.";
                if (TempData["ErrorMessage"] != null)
                {
                    ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
                }
                return View();
            }
        }
    }
}