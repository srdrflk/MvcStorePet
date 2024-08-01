using MvcStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Controllers
{
    public class KategoriController : Controller
    {
        DbMvcMagazaEntities db = new DbMvcMagazaEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var li = db.tblKategori.ToList();
            return View(li);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(tblKategori p)
        {
            db.tblKategori.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var li = db.tblKategori.Find(id);
            db.tblKategori.Remove(li);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult List(int id)
        {
            var li = db.tblKategori.Find(id);
            return View(li);
        }

        public ActionResult Guncelle(tblKategori p)
        {
            var gü = db.tblKategori.Find(p.Id);
            gü.Ad = p.Ad;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}