using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Siniflar;

namespace proje1.Controllers
{
    public class departmanController : Controller
    {
        context c = new context();
        public ActionResult Index()                                        //departman ekleme kaldırma ve güncelleme işlemleri
        {
            var degerler = c.departmans.Where(x => x.durum == true).ToList();
            return View(degerler);
        }

        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult departmanekle()
        {
            return View();
        }



        [HttpPost]
        public ActionResult departmanekle(departman d)
        {
            c.departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult departmansil(int id)
        {
            var dep = c.departmans.Find(id);
            dep.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult departmangetir(int id)
        {
            var dpt = c.departmans.Find(id);
            dpt.durum = true;
            return View("departmangetir",dpt);   

           

    
        }



        public ActionResult departmanguncelle(departman p)
        {
            var dept = c.departmans.Find(p.departmanid);
            dept.departmanad = p.departmanad;
            dept.durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");

        }




    }

}