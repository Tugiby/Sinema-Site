﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Siniflar;

namespace proje1.Controllers
{
    public class filmController : Controller
    {
        // GET: film
        context c = new context();
        public ActionResult Index()                         //film ekleme kaldırma güncelleme işlemleri
        {
            var filmler = c.filmozelliks.Where(x => x.durum == true).ToList();
            return View(filmler);
        }


        [HttpGet]
        public ActionResult yenifilm()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.Kategoriad,
                                               Value=x.Kategoriid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;    
            return View();
        }

        [HttpPost]
        public ActionResult yenifilm(filmozellik p)
        {
            c.filmozelliks.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult filmsil(int id)
        {
            var deger = c.filmozelliks.Find(id);
            deger.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
     
        }

        public ActionResult filmgetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Kategoriad,
                                               Value = x.Kategoriid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            var filmdeger = c.filmozelliks.Find(id);
           
            return View("filmgetir",filmdeger);
        }

        public ActionResult filmguncelle(filmozellik p)
        {
            var urn=c.filmozelliks.Find(p.filmid);
            urn.filmad = p.filmad;
            urn.yonetmen=p.yonetmen;
            urn.kategoriid = p.kategoriid;
            urn.durum = p.durum;
            urn.biletfiyat = p.biletfiyat;
            urn.seansid = p.seansid;
            urn.filmgorsel = p.filmgorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FilmKategoriListesi()
        {
            var filmler = c.filmozelliks
                .Include("Kategori")  // String olarak belirtiyoruz
                .Where(x => x.durum == true)
                .ToList();
            return View(filmler);
        }
    }
}