using proje1.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace proje1.Controllers
{
    public class CaripanelController : Controller
    {
        // GET: caripanel
        context c = new context();
        [Authorize]
        public ActionResult Index()                                     //müşteri paneli kodları 
        {
            var mail = Session["carimail"] as string;
            if (string.IsNullOrEmpty(mail))
            {
                return RedirectToAction("Login", "Account"); // Giriş yapmadıysa yönlendir
            }
            var degerler = c.caribilgiss.FirstOrDefault(x => x.carimail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult BiletAl()
        {


            List<SelectListItem> filmList = (from x in c.filmozelliks.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.filmad,
                                                 Value = x.filmid.ToString()
                                             }).ToList();

            List<SelectListItem> seansList = (from x in c.seanslars.ToList() 
                                              select new SelectListItem
                                              {
                                                  Text = x.Seans.ToString(), 
                                                  Value = x.seansid.ToString()
                                              }).ToList();
            List<SelectListItem> salonlist = (from x in c.salonlars.ToList() 
                                           select new SelectListItem
                                           {
                                               Text = x.salonad,
                                               Value = x.salonid.ToString()
                                           }).ToList();

            ViewBag.FilmListesi = filmList;
            ViewBag.SeansListesi = seansList;
            ViewBag.SalonListesi = salonlist;

            return View();
        }


        [HttpPost]
        public ActionResult BiletAl(satishareket s)
        {

            var mail = Session["carimail"] as string;
           

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

        public ActionResult biletlerim()
        {
            var mail = Session["carimail"] as string;
            var id = c.caribilgiss.Where(x => x.carimail == mail.ToString()).Select(y => y.cariid).FirstOrDefault();
            var degerler = c.satisharekets.Where(x => x.cariid == id).ToList();
            return View(degerler);
        }

        public ActionResult caribilgiguncelle()
        {
            var mail = Session["carimail"] as string;
            var id = c.caribilgiss.Where(x => x.carimail == mail.ToString()).Select(y => y.cariid).FirstOrDefault();
            var degerler = c.satisharekets.Where(x => x.cariid == id).ToList();
            return View(degerler);
        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}

