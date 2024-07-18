using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        public ActionResult Index()
        {
            var values = db.Personel.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            db.Personel.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var result = db.Personel.Find(id);
            db.Personel.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            var result = db.Personel.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            var result = db.Personel.Find(personel.PersonelID);
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            
            result.PersonelAd = personel.PersonelAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}