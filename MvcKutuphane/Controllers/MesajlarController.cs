using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();    

        public ActionResult Index()
        {
            var memberMail = (string)Session["EMail"].ToString();
            var values = db.Mesajlar.Where(x => x.Alici == memberMail.ToString()).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesajlar)
        {
            var memberMail = (string)Session["EMail"].ToString();
            mesajlar.Gonderen = memberMail;
            mesajlar.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Mesajlar.Add(mesajlar);
            db.SaveChanges();
            return RedirectToAction("GidenMesaj");
        }

        public ActionResult GidenMesaj()
        {
            var memberMail = (string)Session["EMail"].ToString();
            var values = db.Mesajlar.Where(x => x.Gonderen == memberMail.ToString()).ToList();
            return View(values);
        }
    }
}