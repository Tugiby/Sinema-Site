using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class uye
    {
        [Key]
        public int uyeid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string soyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string email { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string telefonno { get; set; }
        public DateTime kayıttarih { get; set; }

        public DateTime dogumtarih { get; set; }


        public ICollection<odeme> odemes { get; set; }

    }
}