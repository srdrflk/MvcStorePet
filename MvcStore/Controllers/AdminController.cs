using MvcStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Controllers
{
    public class AdminController : Controller
    {

        DbMvcMagazaEntities db = new DbMvcMagazaEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(tblAdmin p)
        {
            db.tblAdmin.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}