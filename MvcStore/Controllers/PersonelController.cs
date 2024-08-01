using MvcStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Controllers
{
    public class PersonelController : Controller
    {
        DbMvcMagazaEntities db = new DbMvcMagazaEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var li = db.tblPersonel.ToList();

            return View(li);
        }

        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniPersonel(tblPersonel p)
        {
            db.tblPersonel.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index"); 
        }

        public ActionResult List(int id)
        {
            var li = db.tblPersonel.Find(id);

            return View(li);
        }

        public ActionResult Guncelle(tblPersonel p)
        {
            var g = db.tblPersonel.Where(x => x.Id == p.Id).FirstOrDefault();
            g.Ad = p.Ad;
            g.Soyad = p.Soyad;
            g.Departman = p.Departman;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var li = db.tblPersonel.Find(id);
            db.tblPersonel.Remove(li);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}