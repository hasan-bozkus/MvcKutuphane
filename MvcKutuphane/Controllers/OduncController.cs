using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        public ActionResult Index()
        {
            var values = db.Hareketler.Where(x=>x.İslemDurum == false).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(Hareketler hareketler)
        {
            hareketler.İslemDurum = false;
            db.Hareketler.Add(hareketler);
            db.SaveChanges();
            return RedirectToAction("OduncVer");
        }


        public ActionResult OduncIade(int id)
        {
            Hareketler hareketler = new Hareketler();
            hareketler.HareketID = id;

            var result = db.Hareketler.Find(hareketler.HareketID);
            DateTime baslangicTarih = DateTime.Parse(result.İadeTarih.ToString());
            DateTime bitisTarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan timeSpan = bitisTarih - baslangicTarih;
            ViewBag.timeSpan = timeSpan.TotalDays;
            return View(result);
        }

        public ActionResult OduncGuncelle(Hareketler hareketler)
        {
            var result = db.Hareketler.Find(hareketler.HareketID);
            result.UyeGetirTarih = hareketler.UyeGetirTarih;
            result.İslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}