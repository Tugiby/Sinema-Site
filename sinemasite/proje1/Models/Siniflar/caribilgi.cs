using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace proje1.Models.Siniflar
{
    public class caribilgi                      //caribilgi classı. müşteri işlemleri için kullanılacak değişkenler
    {
        [Key]
        public int cariid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string cariad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string carisoyad { get; set; }
       
        
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string carimail { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string carisifre {  get; set; }


        public Boolean durum { get; set; }



        public ICollection<satishareket> satisharekets { get; set; }
    }
}
