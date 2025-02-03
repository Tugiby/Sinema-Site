using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class giderler
    {
        [Key]
        public int giderid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string gideraciklama { get; set; }

        public DateTime gidertarih { get; set; }

        public decimal gidertutar {  get; set; }    
    }
}