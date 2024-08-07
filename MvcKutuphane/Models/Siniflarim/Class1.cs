using MvcKutuphane.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKutuphane.Models.Siniflarim
{
    public class Class1
    {
       public IEnumerable<Kitap> Kitaplar { get; set; }
       public IEnumerable<Hakkimizda> Hakkimizda { get; set; }
    }
}