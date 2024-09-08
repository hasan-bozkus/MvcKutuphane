using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        public ActionResult Index()
        {
            var users = db.Admin.ToList();
            return View(users);
        }

        public ActionResult Index2()
        {
            var users = db.Admin.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index2", "Ayarlar");
        }

        public ActionResult AdminSil(int id)
        {
            var values = db.Admin.Find(id);
            db.Admin.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index2", "Ayarlar");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var values = db.Admin.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult AdminGuncelle(Admin admin)
        {
            var values = db.Admin.Find(admin.AdminID);
            values.Kullanici = admin.Kullanici;
            values.Yetki = admin.Yetki;
            values.Sifre = admin.Sifre;
            db.SaveChanges();
            return RedirectToAction("Index2", "Ayarlar");
        }
    }
}