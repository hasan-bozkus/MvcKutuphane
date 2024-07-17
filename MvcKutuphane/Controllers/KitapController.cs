using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
	public class KitapController : Controller
	{
		MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();

		public ActionResult Index(string query)
		{
			var result = from k in db.Kitap select k;
			if(!string.IsNullOrEmpty(query))
			{
				result = result.Where(x => x.KitapAd.Contains(query));
			}

			return View(result.ToList());
		}

		[HttpGet]
		public ActionResult KitapEkle()
		{
			List<SelectListItem> kategoriList = (from i in db.Kategoriler.ToList()
												 select new SelectListItem
												 {
													 Text = i.KategoriAd,
													 Value = i.KategoriID.ToString()
												 }).ToList();
			ViewBag.kategoriList = kategoriList;

			List<SelectListItem> yazarList = (from i in db.Yazar.ToList()
											  select new SelectListItem
											  {
												  Text = i.YazarAd + " " + i.YazarSoyad,
												  Value = i.YazarID.ToString()
											  }).ToList();
			ViewBag.yazarList = yazarList;
			return View();
		}

		[HttpPost]
		public ActionResult KitapEkle(Kitap kitap)
		{
			var category = db.Kategoriler.Where(x => x.KategoriID == kitap.Kategoriler.KategoriID).FirstOrDefault();
			var writer = db.Yazar.Where(x => x.YazarID == kitap.Yazar1.YazarID).FirstOrDefault();
			kitap.Kategoriler = category;
			kitap.Durum = true;
			kitap.Yazar1 = writer;
			db.Kitap.Add(kitap);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KitapSil(int id)
		{
			var result = db.Kitap.Find(id);
			db.Kitap.Remove(result);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult KitapGuncelle(int id)
		{
			var value = db.Kitap.Find(id);
			List<SelectListItem> kategoriList = (from i in db.Kategoriler.ToList()
												 select new SelectListItem
												 {
													 Text = i.KategoriAd,
													 Value = i.KategoriID.ToString()
												 }).ToList();
			ViewBag.kategoriList = kategoriList;

			List<SelectListItem> yazarList = (from i in db.Yazar.ToList()
											  select new SelectListItem
											  {
												  Text = i.YazarAd + " " + i.YazarSoyad,
												  Value = i.YazarID.ToString()
											  }).ToList();
			ViewBag.yazarList = yazarList;
			return View(value);
		}

		[HttpPost]
		public ActionResult KitapGuncelle(Kitap kitap)
		{
			var result = db.Kitap.Find(kitap.KitapID);
			result.KitapAd = kitap.KitapAd;
			result.BasimYil = kitap.BasimYil;
			result.Sayfa = kitap.Sayfa;
			result.YayinEvi = kitap.YayinEvi;
			var category = db.Kategoriler.Where(x => x.KategoriID == kitap.Kategoriler.KategoriID).FirstOrDefault();
			var writer = db.Yazar.Where(x => x.YazarID == kitap.Yazar1.YazarID).FirstOrDefault();
			result.Kategori = category.KategoriID;
			result.Yazar = writer.YazarID;
			result.Durum = true;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}