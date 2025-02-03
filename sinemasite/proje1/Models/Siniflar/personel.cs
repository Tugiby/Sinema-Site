using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class personel
    {
        [Key]
        public int personelid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string personelad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string personelsoyad { get; set; }

  

        [Column(TypeName = "Varchar")]
        [StringLength(250)] //url adresi için
        public string personelgorsel {  get; set; }

        public DateTime? isegiristarih { get; set; }

        public Boolean durum {  get; set; } 
        public ICollection<satishareket> satisharekets { get; set; }

        public int departmanid {  get; set; }
        public virtual departman departman { get; set; }



    }
}