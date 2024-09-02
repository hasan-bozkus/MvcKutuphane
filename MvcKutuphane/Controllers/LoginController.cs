using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        public ActionResult GirisYap(Uyeler uyeler)
        {
            var values = db.Uyeler.FirstOrDefault(x => x.EMail == uyeler.EMail && x.Sifre == uyeler.Sifre);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.EMail, false);
                Session["Email"] = values.EMail.ToString();
                //TempData["UyeID"] = values.UyeID.ToString();
                //TempData["UyeAd"] = values.UyeAd.ToString();
                //TempData["UyeSoyad"] = values.UyeSoyad.ToString();
                //TempData["KullaniciAd"] = values.KullaniciAd.ToString();
                //TempData["Sifre"] = values.Sifre.ToString();
                //TempData["UyeOkul"] = values.UyeOkul.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}