using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Siniflar;

namespace proje1.Controllers
{
    public class carilerController : Controller
    {
        context c = new context();
        public ActionResult Index()
        {
            var degerler = c.caribilgiss.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult yenicari()
        {
            return View();


        }

        [HttpPost]
        public ActionResult yenicari(caribilgi p)         //müsteri ekleme silme ve güncelleme işlemleri
        {
            p.durum=true;
            c.caribilgiss.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
      
        }

        public ActionResult carisil(int id)
        {
            var car = c.caribilgiss.Find(id);
            car.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult carigetir(int id)
        {

            var cari = c.caribilgiss.Find(id);
            cari.durum = true;
            return View("carigetir", cari);


        }


        public ActionResult cariguncelle(caribilgi p)
        {
            var cari = c.caribilgiss.Find(p.cariid);
            cari.cariad = p.cariad;
            cari.carisoyad = p.carisoyad;
            cari.carimail = p.carimail;
            cari.durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");

        }






    }



}