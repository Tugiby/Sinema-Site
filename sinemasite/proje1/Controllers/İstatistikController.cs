using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Siniflar;

namespace proje1.Controllers
{

    public class İstatistikController : Controller
    {
        // GET: İstatistik

        context c = new context();


        public ActionResult Index()                         //bazı fonksiyon ve splerimi kullandığım satıslarla ilgili istatislik sayfam

        {

            ViewBag.ToplamSatis = c.GetToplamSatisTutari();

            ViewBag.EnCokSatanFilmler = c.GetEnCokSatilanFilmler();

            ViewBag.SalonDoluluk = c.GetSalonDolulukOranlari();

            ViewBag.GunlukRapor = c.GetGunlukRapor();

            ViewBag.KategoriRapor = c.GetKategoriRaporu();

            return View();
        }

        public ActionResult DetayliRapor()
        {
            context c = new context();

            // En çok bilet alan müşteri
            ViewBag.EnCokBiletAlanMusteri = c.GetEnCokBiletAlanMusteri();

            // Günlük ortalama satış
            ViewBag.GunlukOrtalamaSatis = c.GetGunlukOrtalamaSatis();

            // Günlük rapor
            var gunlukRapor = c.GetGunlukRapor();
            ViewBag.GunlukRapor = gunlukRapor;

            // Kategori raporunu SP'den al
            var kategoriRapor = c.Database.SqlQuery<KategoriRaporModel>("EXEC SP_KategoriRaporu").ToList();
            ViewBag.KategoriRapor = kategoriRapor;

            // Bugünkü toplam hasılatı hesapla
            decimal bugunToplam = kategoriRapor?.Sum(x => x.ToplamHasilat) ?? 0m;
            ViewBag.BugunToplam = bugunToplam;
            //toplamfilmsayısı
            ViewBag.ToplamFilm = c.GetToplamFilmSayisi();



            // Tüm kategorilerin hasılatı
            var kategoriler = c.Kategoris.ToList();
            var kategoriHasilatlar = new Dictionary<int, decimal>();
            foreach (var kategori in kategoriler)
            {
                kategoriHasilatlar[kategori.Kategoriid] = c.GetKategoriHasilat(kategori.Kategoriid);
            }
            ViewBag.KategoriHasilatlar = kategoriHasilatlar;

            ViewBag.BugunToplam = c.GetBugunTotalHasilat();




            return View();
        }
    }
}