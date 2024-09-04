using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {

        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var memberMail = (string)Session["Email"];
            //var values = db.Uyeler.FirstOrDefault(z => z.EMail == memberMail);
            var values = db.Duyurular.ToList();

            var memberName = db.Uyeler.Where(x => x.EMail == memberMail).Select(y => y.UyeAd).FirstOrDefault();
            ViewBag.memberName = memberName;

            var memberSurname = db.Uyeler.Where(x => x.EMail == memberMail).Select(y => y.UyeSoyad).FirstOrDefault();
            ViewBag.memberSurname = memberSurname;

            var memberImage = db.Uyeler.Where(x => x.EMail == memberMail).Select(y => y.Fotograf).FirstOrDefault();
            ViewBag.memberImage = memberImage;

            var userName = db.Uyeler.Where(x => x.EMail == memberMail).Select(y => y.KullaniciAd).FirstOrDefault();
            ViewBag.userName = userName;

            var memberSchool = db.Uyeler.Where(x => x.EMail == memberMail).Select(y => y.UyeOkul).FirstOrDefault();
            ViewBag.memberSchool = memberSchool;

            var memberPhone = db.Uyeler.Where(x => x.EMail == memberMail).Select(y => y.Telefon).FirstOrDefault();
            ViewBag.memberPhone = memberPhone;

            var memberEMail = db.Uyeler.Where(x => x.EMail == memberMail).Select(y => y.EMail).FirstOrDefault();
            ViewBag.memberEMail = memberEMail;

            var memberID = db.Uyeler.Where(x => x.EMail == memberEMail).Select(y => y.UyeID).FirstOrDefault();
            var bookReceivedCount = db.Hareketler.Where(x => x.Uye == memberID).Count();
            ViewBag.bookReceivedCount = bookReceivedCount;

            var receivedMail = db.Mesajlar.Where(x => x.Alici == memberMail).Count();
            ViewBag.receivedMail = receivedMail;

            var AnnouncementCount = db.Duyurular.Count();
            ViewBag.AnnouncementCount = AnnouncementCount;
            return View(values);
        }

        [HttpPost]
        public ActionResult Index2(Uyeler uyeler)
        {
            var user = (string)Session["EMail"];
            var member = db.Uyeler.FirstOrDefault(x => x.EMail == user);
            member.Sifre = uyeler.Sifre;
            member.UyeAd = uyeler.UyeAd;
            member.UyeSoyad = uyeler.UyeSoyad;
            member.UyeOkul = uyeler.UyeOkul;
            member.KullaniciAd = uyeler.KullaniciAd;
            member.Fotograf = uyeler.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarim()
        {
            var user = (string)Session["EMail"];
            var id = db.Uyeler.Where(x => x.EMail == user.ToString()).Select(z => z.UyeID).FirstOrDefault();
            var values = db.Hareketler.Where(x => x.Uye == id).ToList();
            return View(values);
        }

        public ActionResult Duyurular()
        {
            var values = db.Duyurular.ToList();
            return View(values);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        public PartialViewResult Partial2()
        {
            var memberMail = (string)Session["Email"];
            var memberId = db.Uyeler.Where(x => x.EMail == memberMail).Select(y =>y.UyeID).FirstOrDefault();
            var values = db.Uyeler.Find(memberId);
            return PartialView("Partial2", values);
        }
    }
}