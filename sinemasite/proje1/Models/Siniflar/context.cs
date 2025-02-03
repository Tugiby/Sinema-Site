using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace proje1.Models.Siniflar
{

    // Model sınıfları burada (context sınıfının dışında)




    public class FilmSatisModel

    {

        public string filmad { get; set; }

        public int SatilanBilet { get; set; }

        public decimal? ToplamHasilat { get; set; }

    }



    public class SalonDolulukModel

    {

        public string salonad { get; set; }

        public int ToplamKapasite { get; set; }

        public int SatilanBilet { get; set; }

        public decimal? DolulukOrani { get; set; }

    }



    public class GunlukRaporModel

    {

        public int BiletSayisi { get; set; }

        public decimal? ToplamHasilat { get; set; }

        public int SatilanFilmSayisi { get; set; }

        public int KullanilanSalonSayisi { get; set; }

    }



    public class KategoriRaporModel

    {
        [Key]
        public int kategoriid { get; set; }
        public string Kategoriad { get; set; }
        public int FilmSayisi { get; set; }
        public int SatilanBilet { get; set; }
        public decimal ToplamHasilat { get; set; }  // nullable kaldırıldı
        public virtual Kategori Kategoris { get; set; } 
    }



    public class context: DbContext
    {
        //sql tablolar buradan erişecek
        public DbSet<admin> admins { get; set; }
        public DbSet<caribilgi> caribilgiss { get; set; }
        public DbSet<departman> departmans { get; set; }
        public DbSet<faturagirdiler> faturagirdilers { get; set; }
        public DbSet<faturalar> faturalars { get; set; }
        public DbSet<filmozellik> filmozelliks { get; set; }
        public DbSet<giderler> giderlers { get; set; }
        public DbSet<gosterim> gosterims { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<odeme> odemes { get; set; }
        public DbSet<personel> personels { get; set; }
        public DbSet<salonlar> salonlars { get; set; }
        public DbSet<satishareket> satisharekets { get; set; }
        public DbSet<seanslar> seanslars { get; set; }
        public DbSet<uye> uyes { get; set; }

        public decimal GetBugunTotalHasilat()
        {
            return Database.SqlQuery<decimal>("SELECT dbo.FN_BugunTotalHasilat()").FirstOrDefault();
        }
        public virtual decimal GetToplamSatisTutari()

        {

            return Database.SqlQuery<decimal>("EXEC SP_ToplamSatisTutari").FirstOrDefault();

        }



        public virtual decimal GetMusteriHarcama(string cariMail)

        {

            return Database.SqlQuery<decimal>(

                "SELECT dbo.FN_MusteriToplamHarcama(@cariMail)",

                new SqlParameter("@cariMail", cariMail)).FirstOrDefault();

        }



        public virtual int GetBosKoltukSayisi(int salonId)

        {

            return Database.SqlQuery<int>(

                "SELECT dbo.FN_BosKoltukSayisi(@salonId)",

                new SqlParameter("@salonId", salonId)).FirstOrDefault();

        }



        public virtual decimal GetFilmHasilat(int filmId)

        {

            return Database.SqlQuery<decimal>(

                "SELECT dbo.FN_FilmSatisTutari(@filmId)",

                new SqlParameter("@filmId", filmId)).FirstOrDefault();

        }
        public int GetToplamFilmSayisi()
        {
            return Database.SqlQuery<int>("SELECT dbo.FN_ToplamFilmSayisi()").FirstOrDefault();
        }



        // Stored Procedure'ler

        public List<filmozellik> GetAktifFilmler()

        {

            return Database.SqlQuery<filmozellik>("EXEC SP_AktifFilmler").ToList();

        }



        public List<satishareket> GetMusteriBiletleri(string cariMail)

        {

            return Database.SqlQuery<satishareket>(

                "EXEC SP_MusteriBiletGecmisi @cariMail",

                new SqlParameter("@cariMail", cariMail)).ToList();

        }



        public void BiletSatisYap(int filmId, string cariMail, int salonId, string koltukNo)

        {

            Database.ExecuteSqlCommand(

                "EXEC SP_BiletSatisYap @filmId, @cariMail, @salonId, @koltukNo",

                new SqlParameter("@filmId", filmId),

                new SqlParameter("@cariMail", cariMail),

                new SqlParameter("@salonId", salonId),

                new SqlParameter("@koltukNo", koltukNo));

        }



        public class FilmSatisModel

        {

            public string filmad { get; set; }

            public int SatilanBilet { get; set; }

            public decimal? ToplamHasilat { get; set; }

        }



        public List<FilmSatisModel> GetEnCokSatilanFilmler()   //var

        {

            return Database.SqlQuery<FilmSatisModel>("EXEC SP_EnCokSatilanFilmler").ToList();

        }



        public class SalonDolulukModel

        {

            public string salonad { get; set; }

            public int ToplamKapasite { get; set; }

            public int SatilanBilet { get; set; }

            public decimal? DolulukOrani { get; set; }

        }



        public List<SalonDolulukModel> GetSalonDolulukOranlari()   //(var)

        {

            return Database.SqlQuery<SalonDolulukModel>("EXEC SP_SalonDolulukOranlari").ToList();

        }



        public class GunlukRaporModel

        {

            public int BiletSayisi { get; set; }

            public decimal? ToplamHasilat { get; set; }

            public int SatilanFilmSayisi { get; set; }

            public int KullanilanSalonSayisi { get; set; }

        }



        public GunlukRaporModel GetGunlukRapor()  //sp   (var)

        {

            return Database.SqlQuery<GunlukRaporModel>("EXEC SP_GunlukSatisRaporu").FirstOrDefault();

        }



        public class KategoriRaporModel     //sp için class tanımlala

        {

            public string Kategoriad { get; set; }

            public int FilmSayisi { get; set; }

            public int SatilanBilet { get; set; }

            public decimal? ToplamHasilat { get; set; }

        }



        public List<KategoriRaporModel> GetKategoriRaporu()   //kullanıldı

        {

            return Database.SqlQuery<KategoriRaporModel>("EXEC SP_KategoriRaporu").ToList();

        }



        // En çok bilet alan müşteri

        public string GetEnCokBiletAlanMusteri() //var

        {

            return Database.SqlQuery<string>("SELECT dbo.FN_EnCokBiletAlanMusteri()").FirstOrDefault();

        }



        // Film doluluk oranı

        public decimal GetFilmDolulukOrani(int filmId) //var

        {

            return Database.SqlQuery<decimal>(

                "SELECT dbo.FN_FilmDolulukOrani(@filmId)",

                new SqlParameter("@filmId", filmId)).FirstOrDefault();

        }



        // Günlük ortalama satış

        public decimal GetGunlukOrtalamaSatis()   //var

        {

            return Database.SqlQuery<decimal>("SELECT dbo.FN_GunlukOrtalamaSatis()").FirstOrDefault();

        }



        // Kategori hasılatı

        public decimal GetKategoriHasilat(int kategoriId)   

        {

            return Database.SqlQuery<decimal>(

                "SELECT dbo.FN_KategoriHasilat(@kategoriId)",

                new SqlParameter("@kategoriId", kategoriId)).FirstOrDefault();

        }

    }
}
