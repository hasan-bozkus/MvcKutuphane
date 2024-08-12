using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        public ActionResult Index()
        {
            var uyeCount = db.Uyeler.Count();
            ViewBag.uyeCount = uyeCount;

            var kitapCount = db.Kitap.Count();
            ViewBag.kitapCount = kitapCount;

            var emanetKitap = db.Kitap.Where(x => x.Durum == false).Count();
            ViewBag.emanetKitap = emanetKitap;

            var kasaTutar = db.Cezalar.Sum(x => x.Para);
            ViewBag.kasaTutar = kasaTutar;

            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0) 
            {
                string dosyaYolu = Path.Combine(Server.MapPath("~/Web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);
            }
            return RedirectToAction("Galeri");
        }
    }
}