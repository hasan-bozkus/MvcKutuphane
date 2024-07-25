using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        MvcKutuphaneYonetimSistemiEntities db = new MvcKutuphaneYonetimSistemiEntities();
        
        public ActionResult Index()
        {
            var values = db.Hareketler.Where(x => x.İslemDurum == true).ToList();
            return View(values);
        }
    }
}