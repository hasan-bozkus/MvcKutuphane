using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(Uyeler uyeler)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            db.Uyeler.Add(uyeler);
            db.SaveChanges();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}