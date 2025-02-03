 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Siniflar;

namespace proje1.Controllers
{
    public class satisController : Controller
    {
        context c = new context();
        public ActionResult Index()                         //bilet satış işlemleri koltukların dinamik şekilde gelmesi için ayrıca json kullandım
        {
            var degerler = c.satisharekets.ToList();

            return View(degerler);
        }


        [HttpGet]
        public ActionResult yenisatis()
        {
            List<SelectListItem> deger1 = (from x in c.filmozelliks.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.filmad,
                                               Value = x.filmid.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.caribilgiss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariad + " " + x.carisoyad,
                                               Value = x.cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelad + " " + x.personelsoyad,
                                               Value = x.personelid.ToString()
                                           }).ToList();


            List<SelectListItem> deger4 = (from x in c.salonlars.ToList() //
                                           select new SelectListItem
                                           {
                                               Text = x.salonad,
                                               Value = x.salonid.ToString()
                                           }).ToList();



            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();




        }

        [HttpPost]
        public ActionResult yenisatis(satishareket s)
        {

           
            if (s.salonid == 0)
            {
                // Eğer salon seçilmemişse hata mesajı göster.
                ModelState.AddModelError("salonid", "Lütfen bir salon seçiniz.");
                return View("yenisatis"); // Formu tekrar göster
            }

            s.satistarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            // Salonun dolu koltuklarını güncelle
            var salon = c.salonlars.Find(s.salonid);
            if (salon != null)
            {
                var doluKoltuklar = salon.dolukoltuklar?.Split(',')?.ToList() ?? new List<string>();
                doluKoltuklar.Add(s.koltukno);
                salon.dolukoltuklar = string.Join(",", doluKoltuklar);
                salon.kapasite--; // Kapasiteden 1 düş
            }

            c.satisharekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult satissil(int id)
        {
            var car = c.caribilgiss.Find(id);
            car.durum = false;


            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public JsonResult koltuklar(int id)
        {
            var salon = c.salonlars.Find(id);
            if (salon != null)
            {
                var doluKoltuklar = salon.dolukoltuklar?.Split(',') ?? new string[0];
                var tumKoltuklar = Enumerable.Range(1, salon.kapasite)
                                              .Select(x => "A" + x) // Örnek: A1, A2
                                              .Except(doluKoltuklar);
                return Json(tumKoltuklar, JsonRequestBehavior.AllowGet);
            }
            return Json(new string[0], JsonRequestBehavior.AllowGet);
        }

        public ActionResult satisgetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.filmozelliks.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.filmad,
                                               Value = x.filmid.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in c.caribilgiss.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariad + " " + x.carisoyad,
                                               Value = x.cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelad + " " + x.personelsoyad,
                                               Value = x.personelid.ToString()
                                           }).ToList();





            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;


            var deger = c.satisharekets.Find(id);
            return View("satisgetir", deger);





        }

        public ActionResult satisguncelle(satishareket p)
        {
            var sat = c.satisharekets.Find(p.satisid);
            sat.cariid = p.cariid;
            sat.adet = p.adet;
            sat.fiyat = p.fiyat;
            sat.personelid = p.personelid;
            sat.satistarih = p.satistarih;
            sat.toplamtutar = p.toplamtutar;
            sat.filmid=p.filmid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}




