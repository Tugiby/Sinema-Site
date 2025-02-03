using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class odeme
    {
        [Key]
        public int odemeid { get; set; }
        public decimal tutar {  get; set; }

        public DateTime odemetarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string odemeturu { get; set; }
        

     
        public virtual uye uyes { get; set; }
        







    }
}