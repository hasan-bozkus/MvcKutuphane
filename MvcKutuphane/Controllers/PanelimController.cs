﻿using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {

        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var memberMail = (string)Session["Email"];
            var values = db.Uyeler.FirstOrDefault(z => z.EMail == memberMail);

            return View(values);
        }

        [HttpPost]
        public ActionResult Index2(Uyeler uyeler)
        {
            var user = (string)Session["EMail"];
            var member = db.Uyeler.FirstOrDefault(x=> x.EMail == user);
            member.Sifre = uyeler.Sifre;
            member.UyeAd = uyeler.UyeAd;
            member.UyeSoyad = uyeler.UyeSoyad;
            member.UyeOkul = uyeler.UyeOkul;
            member.KullaniciAd = uyeler.KullaniciAd;
            member.Fotograf = uyeler.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}