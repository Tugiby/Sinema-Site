using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Data.SqlTypes;

namespace proje1.Models.Siniflar
{
    public class filmozellik //film özellikerli
    {
        [Key]
        public int filmid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string filmad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string yonetmen { get; set; }


        public int biletfiyat { get; set; } // Veri tipi düzeltildi.

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string filmgorsel { get; set; }

        public Boolean durum {  get; set; } 

        public int kategoriid {  get; set; }    
        public virtual seanslar seanslar { get; set; }

        public int seansid { get; set; }
        public virtual Kategori kategori { get; set; }


        public ICollection<satishareket> satisharekets { get; set; }
        










    }
}
