using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entities;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();


        public ActionResult Index()
        {
            var values = db.Kategoriler.Where(x => x.Durum == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler kategoriler)
        {
            db.Kategoriler.Add(kategoriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var values = db.Kategoriler.Find(id);
            //db.Kategoriler.Remove(values);
            values.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGetir(int id)
        {
            var values = db.Kategoriler.Find(id);
            return View("KategoriGetir", values);
        }

        [HttpPost]
        public ActionResult KategoriGetir(Kategoriler kategoriler)
        {
            var values = db.Kategoriler.Find(kategoriler.KategoriID);
            values.KategoriAd = kategoriler.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}