using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        public ActionResult Index()
        {
            var values = db.Duyurular.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(Duyurular duyurular)
        {
            db.Duyurular.Add(duyurular);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(int id)
        {
            var result = db.Duyurular.Find(id);

            return View(result);
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyurular = db.Duyurular.Find(id);
            db.Duyurular.Remove(duyurular);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult DuyuruGuncelle(Duyurular duyurular)
        {
            var result = db.Duyurular.Find(duyurular.DuyuruID);
            result.Tarih = duyurular.Tarih;
            result.Kategori = duyurular.Kategori;
            result.Icerik = duyurular.Icerik;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}