using MvcStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcStore.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcMagazaEntities db = new DbMvcMagazaEntities();
        // GET: Musteri
        [Authorize]
        public ActionResult Index()
        {
            var li = db.tblMusteri.Where(x => x.Durum == true).ToList();

            return View(li);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(tblMusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            p.Durum = true;
            db.tblMusteri.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(tblMusteri p)
        {
            var li = db.tblMusteri.Find(p.Id);
            li.Durum = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult List(int id)
        {
            var li = db.tblMusteri.Find(id);
            return View(li);
        }

        public ActionResult Guncelle(tblMusteri p)
        {
            var g = db.tblMusteri.Find(p.Id);
            g.Ad = p.Ad;
            g.Soyad = p.Soyad;
            g.Sehir = p.Sehir;
            g.Bakiye = p.Bakiye;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}