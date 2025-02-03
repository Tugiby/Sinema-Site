using proje1.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace proje1.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        context c = new context();
        public ActionResult Index()             //müşteri admin personel için login işlemleri
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult partial1(caribilgi p)
        {
            c.caribilgiss.Add(p);
            c.SaveChanges();


            return PartialView();
        }
        [HttpGet]
        public ActionResult carilogin1()
        {
            return View();


        }
        [HttpPost]
        public ActionResult carilogin1(caribilgi ca)
        {
            var bilgiler = c.caribilgiss.FirstOrDefault(x => x.carimail == ca.carimail && x.carisifre == ca.carisifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.carimail, false);
                Session["carimail"] = bilgiler.carimail.ToString();
                return RedirectToAction("Index", "caripanel");
            }
            else
            {
                return RedirectToAction("Index", "login");
            }




        }
        [HttpGet]
        public ActionResult adminlogin()
        {
            return View();
        }

        public ActionResult adminlogin(admin p)
        {
            var bilgiler = c.admins.FirstOrDefault
                (x => x.adminkullaniciad == p.adminkullaniciad && x.adminsifre == p.adminsifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.adminkullaniciad, false);
                Session["adminkullaniciad"] = bilgiler.adminkullaniciad.ToString();
                return RedirectToAction("Index", "kategori");
            }
            else
            {
                return RedirectToAction("Index", "login");
            }
        }
    }
}
