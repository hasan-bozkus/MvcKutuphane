using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entities;

namespace MvcKutuphane.Controllers
{
	public class YazarController : Controller
	{
		MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

		public ActionResult Index()
		{
			var values = db.Yazar.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult YazarEkle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YazarEkle(Yazar yazar)
		{
			if(!ModelState.IsValid)
			{
				return View();
			}
			db.Yazar.Add(yazar);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult YazarSil(int id)
		{
			var value = db.Yazar.Find(id);
			db.Yazar.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult YazarGuncelle(int id)
		{
			var value = db.Yazar.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult YazarGuncelle(Yazar yazar)
		{
			var value = db.Yazar.Find(yazar.YazarID);
			value.YazarAd = yazar.YazarAd;
			value.YazarSoyad = yazar.YazarSoyad;
			value.YazarDetay = yazar.YazarDetay;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult YazarKitaplar(int id)
		{
			var writer = db.Kitap.Where(x => x.Yazar == id).ToList();
			var writerName = db.Yazar.Where(x => x.YazarID == id).Select(y => y.YazarAd + " " + y.YazarSoyad).FirstOrDefault();
			ViewBag.writerName = writerName;
			return View(writer);
		}
	}
}