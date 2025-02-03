using proje1.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje1.Controllers
{
    public class personelController : Controller
    {
        context c = new context();
        public ActionResult Index()                         //personel ekleme kaldırma ve güncelleme işlemleri
        {
            var degerler = c.personels.Where(x => x.durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult personelekle()
        {
            List<SelectListItem> deger1 = (from x in c.departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanad,
                                               Value = x.departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;



            return View();


        }

        [HttpPost]
        public ActionResult personelekle(personel p)
        {
            p.durum = true;
            c.personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult personelsil(int id)
        {
            var dep = c.personels.Find(id);
            dep.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult personelgetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanad,
                                               Value = x.departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var per = c.personels.Find(id);
            per.durum = true;
            return View("personelgetir", per);

        }


        public ActionResult personelguncelle(personel p)
        {
            var pers = c.personels.Find(p.personelid);
            pers.personelad = p.personelad;
            pers.personelsoyad = p.personelsoyad;
            pers.personelgorsel = p.personelgorsel;
            pers.departmanid = p.departmanid;
            pers.durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}