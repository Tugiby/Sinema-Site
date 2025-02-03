using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Siniflar;

namespace proje1.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        context c = new context();
        public ActionResult Index()                         //film kategori türü ekleme kaldırma güncelleme
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult kategoriekle()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult kategoriekle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult kategorisil(int id)
        {
            var ktg=c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kategorigetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
            
        }

        public ActionResult kategoriguncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.Kategoriid);
            ktgr.Kategoriad=k.Kategoriad;
            c.SaveChanges();
            return RedirectToAction("Index");

        }


    }

}