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
            List<SelectListItem> members = (from x in db.Uyeler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UyeAd + " " + x.UyeSoyad,
                                                Value = x.UyeID.ToString()
                                            }).ToList();
            ViewBag.members = members;

            List<SelectListItem> books = (from x in db.Kitap.Where(y => y.Durum == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KitapAd,
                                              Value = x.KitapID.ToString()
                                          }).ToList();
            ViewBag.books = books;

            List<SelectListItem> employee = (from x in db.Personel.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.employee = employee;

            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(Hareketler hareketler)
        {
            var members = db.Uyeler.Where(x => x.UyeID == hareketler.Uyeler.UyeID).FirstOrDefault();
            var books = db.Kitap.Where(x => x.KitapID == hareketler.Kitap1.KitapID).FirstOrDefault();
            var employee = db.Personel.Where(x => x.PersonelID == hareketler.Personel1.PersonelID).FirstOrDefault();
            hareketler.Uyeler = members;
            hareketler.Kitap1 = books;
            hareketler.Personel1 = employee;
            hareketler.İslemDurum = false;
            db.Hareketler.Add(hareketler);
            db.SaveChanges();
            return RedirectToAction("Index");
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