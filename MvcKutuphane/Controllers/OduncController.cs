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
            var values = db.Hareketler.ToList();
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
            db.Hareketler.Add(hareketler);
            db.SaveChanges();
            return RedirectToAction("OduncVer");
        }

        public ActionResult OduncIade()
        {
            return View();
        }
    }
}