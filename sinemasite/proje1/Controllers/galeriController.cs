using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Siniflar;

namespace proje1.Controllers
{
    public class galeriController : Controller
    {
        // GET: galeri
        context c=new context();    
        public ActionResult Index()                         //film fotoğraflarının olduğu bir view için controlller
        {
            var degerler =c.filmozelliks.ToList();

            return View(degerler);
        }
    }
}