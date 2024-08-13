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

        public ActionResult LinqKart()
        {
            var kitapSayi = db.Kitap.Count();
            ViewBag.kitapSayi = kitapSayi;

            var uyeSayi = db.Uyeler.Count();
            ViewBag.uyeSayi = uyeSayi;

            var kasaTutar = db.Cezalar.Sum(x => x.Para);
            ViewBag.kasaTutar = kasaTutar;

            var oduncKitapSayi = db.Kitap.Where(x => x.Durum == false).Count();
            ViewBag.oduncKitapSayi = oduncKitapSayi;

            var kategoriSayi = db.Kategoriler.Count();
            ViewBag.kategoriSayi = kategoriSayi;

            var enAktifUye = db.EnAktifUye().FirstOrDefault();
            ViewBag.enAktifUye = enAktifUye;

            var enCokOkunanKitap = db.EnCokOkunanKitap().FirstOrDefault();
            ViewBag.enCokOkunanKitap = enCokOkunanKitap;

            var enFazlaKitpliYazar = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.enFazlaKitapliYazar = enFazlaKitpliYazar;

            var enFazlaKitapliYayinevi = db.Kitap.GroupBy(x => x.YayinEvi).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.enfazlaKitapliYayinevi = enFazlaKitapliYayinevi;

            var enBasariliPersonel = db.EnBasariliPersonel().FirstOrDefault();
            ViewBag.enBasariliPersonel = enBasariliPersonel;

            var toplamMesajSayisi = db.Iletisim.Count();
            ViewBag.toplamMesajSayisi = toplamMesajSayisi;

            var bugunVerilenEmanetKitapSayisi = db.BugunEmanetVerilenKitapSayisi().FirstOrDefault();
            ViewBag.bugunVerilenEmanetKitapSayisi = bugunVerilenEmanetKitapSayisi;

            return View();
        }
    }
}