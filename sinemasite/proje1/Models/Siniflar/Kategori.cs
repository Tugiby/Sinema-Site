using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class Kategori           //kategoriler
    {
        [Key]
        public int Kategoriid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Kategoriad { get; set;}

        public ICollection<filmozellik> filmozelliks { get; set; } 


    }
}