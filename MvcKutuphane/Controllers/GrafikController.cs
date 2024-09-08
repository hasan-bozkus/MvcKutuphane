using MvcKutuphane.Models;
using MvcKutuphane.Models.Siniflarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        
      

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult VisualizeKitapResult()
        {
            return Json(Liste());
        }

        public List<Class2> Liste()
        {
            List<Class2> cs = new List<Class2>();
            cs.Add(new Class2() {
                Yayinevi = "Güneş",
                Sayi = 7
            });
            cs.Add(new Class2() {
                Yayinevi = "Mars",
                Sayi = 4
            });
            cs.Add(new Class2() {
                Yayinevi = "Jüpiter",
                Sayi = 6
            });
            return cs;
        }
    }
}