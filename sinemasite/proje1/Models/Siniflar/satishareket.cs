using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class satishareket
    {
        [Key]
        public int satisid { get; set; }

        public DateTime satistarih { get; set; }
        public decimal fiyat { get; set; }

        public decimal toplamtutar { get; set; }

        public int adet { get; set; }

        public int filmid { get; set; }

        public int personelid { get; set; }

        public int cariid { get; set; }

        public int salonid { get; set; }//sonradan
        public string koltukno { get; set; }//sonradan


        public virtual filmozellik filmozellik { get; set; }
        public virtual personel personel { get; set; }
        public virtual caribilgi caribilgis { get; set; }
        public virtual salonlar salonlars { get; set; }//sonradan

        public virtual seanslar seanslars { get; set; }

    }
}