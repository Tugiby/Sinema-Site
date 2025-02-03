using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class departman
    {
        [Key]
        public int departmanid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string departmanad { get; set; }

        public bool durum { get; set; }
    }
}