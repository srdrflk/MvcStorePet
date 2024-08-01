using MvcStore.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStore.Controllers
{
    public class SatisController : Controller
    {
        DbMvcMagazaEntities db = new DbMvcMagazaEntities();
        // GET: Satis
        public ActionResult Index()
        {
            var li = db.tblSatislar.ToList();

            return View(li);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urn = (from x in db.tblUrunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.Id.ToString()

                                        }).ToList();

            ViewBag.urun = urn;

            List<SelectListItem> prs = (from x in db.tblPersonel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad + " " + x.Soyad,
                                            Value = x.Id.ToString()

                                        }).ToList();

            ViewBag.personel = prs;

            List<SelectListItem> mus = (from x in db.tblMusteri.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad + " " + x.Soyad,
                                            Value = x.Id.ToString()

                                        }).ToList();

            ViewBag.musteri = mus;

            //List<SelectListItem> fyt = (from x in db.tblUrunler.ToList()
            //                            select new SelectListItem
            //                            {
            //                                Text = x.SatisFiyat.ToString(),
            //                                Value = x.SatisFiyat.ToString()

            //                            }).ToList();

            //ViewBag.fiyat = fyt;


            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(tblSatislar p)
        {
            var urn = db.tblUrunler.Where(x => x.Id == p.tblUrunler.Id).FirstOrDefault();
            var pers = db.tblPersonel.Where(x => x.Id == p.tblPersonel.Id).FirstOrDefault();
            var mus = db.tblMusteri.Where(x => x.Id == p.tblMusteri.Id).FirstOrDefault();
            //var fyt = db.tblUrunler.Where(x => x.SatisFiyat == p.tblUrunler.SatisFiyat).FirstOrDefault();
            //p.tblUrunler = fyt;
            p.tblUrunler = urn;
            p.tblPersonel = pers;
            p.tblMusteri = mus;
            p.Tarih = DateTime.Now;
            db.tblSatislar.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}