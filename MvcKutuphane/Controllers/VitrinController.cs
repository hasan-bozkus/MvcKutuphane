using MvcKutuphane.Models.Entities;
using MvcKutuphane.Models.Siniflarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Kitaplar = db.Kitap.ToList();
            cs.Hakkimizda = db.Hakkimizda.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(Iletisim iletisim)
        {
            db.Iletisim.Add(iletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}