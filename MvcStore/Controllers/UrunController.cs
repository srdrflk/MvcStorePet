using MvcStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Controllers
{
    public class UrunController : Controller
    {
        DbMvcMagazaEntities db = new DbMvcMagazaEntities();

        // GET: Urun
        public ActionResult Index(string p)
        {
            //var li = db.tblUrunler.Where(x => x.Durum == true).ToList();
            var li = db.tblUrunler.Where(x => x.Durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                li = li.Where(x => x.Ad.Contains(p) && x.Durum == true);
            }

            return View(li.ToList());
        }

        public ActionResult PasifUrunler()
        {


            var li = db.tblUrunler.Where(x => x.Durum == false).ToList();

            return View(li);
        }

        public ActionResult PasifList(int id)
        {
            List<SelectListItem> drm = (from x in db.tblUrunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Durum.ToString(),
                                            Value = x.Durum.ToString()
                                        }).ToList();


            var li = db.tblUrunler.Find(id);
            ViewBag.durum = drm;
            return View(li);
        }

        public ActionResult PasifGuncelle(tblUrunler p)
        {
            var g = db.tblUrunler.Find(p.Id);
            g.Ad = p.Ad;
            g.Marka = p.Marka;
            g.Stok = p.Stok;
            g.AlisFiyat = p.AlisFiyat;
            g.SatisFiyat = p.SatisFiyat;
            //var ktg = db.tblKategori.Where(x => x.Id == p.tblKategori.Id).FirstOrDefault();
            //g.Kategori = ktg.Id;
            g.Kategori = p.Kategori;
            g.Durum = p.Durum;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.tblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.Id.ToString()

                                        }).ToList();

            ViewBag.drop = ktg;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(tblUrunler p)
        {
            var ktgr = db.tblKategori.Where(x => x.Id == p.tblKategori.Id).FirstOrDefault();
            p.tblKategori = ktgr;
            db.tblUrunler.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult List(int id)
        {
            List<SelectListItem> ktg = (from x in db.tblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.Id.ToString()
                                        }).ToList();

            var li = db.tblUrunler.Find(id);
            ViewBag.kat = ktg;

            return View(li);

        }

        public ActionResult Guncelle(tblUrunler p)
        {
            var g = db.tblUrunler.Find(p.Id);
            g.Ad = p.Ad;
            g.Marka = p.Marka;
            g.Stok = p.Stok;
            g.AlisFiyat = p.AlisFiyat;
            g.SatisFiyat = p.SatisFiyat;
            g.Durum = p.Durum;
            var ktg = db.tblKategori.Where(x => x.Id == p.tblKategori.Id).FirstOrDefault();
            g.Kategori = ktg.Id;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(tblUrunler p)
        {
            var li = db.tblUrunler.Find(p.Id);
            li.Durum = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}