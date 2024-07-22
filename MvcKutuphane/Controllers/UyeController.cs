using MvcKutuphane.Models.Entities;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {

        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        public ActionResult Index(int page = 1)
        {
            //var values = db.Uyeler.ToList();
            var values = db.Uyeler.ToList().ToPagedList(page, 3);
            return View(values);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult UyeEkle(Uyeler uyeler)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Uyeler.Add(uyeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var result = db.Uyeler.Find(id);
            db.Uyeler.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UyeGuncelle(int id)
        {
            var result = db.Uyeler.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UyeGuncelle(Uyeler uyeler)
        {
            var result = db.Uyeler.Find(uyeler.UyeID);
            result.UyeAd = uyeler.UyeAd;
            result.UyeSoyad = uyeler.UyeSoyad;
            result.KullaniciAd = uyeler.KullaniciAd;
            result.Fotograf = uyeler.Fotograf;
            result.EMail = uyeler.EMail;
            result.UyeOkul = uyeler.UyeOkul;
            result.UyeAd = uyeler.UyeAd;
            result.Telefon = uyeler.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}