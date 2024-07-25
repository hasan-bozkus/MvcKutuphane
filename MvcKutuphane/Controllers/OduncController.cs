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


        [HttpGet]
        public ActionResult OduncIade(int id)
        {
            var result = db.Hareketler.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult OduncIade(Hareketler hareketler)
        {
            var result = db.Hareketler.Find(hareketler.HareketID);
            result.UyeGetirTarih = hareketler.UyeGetirTarih;
            result.İslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}