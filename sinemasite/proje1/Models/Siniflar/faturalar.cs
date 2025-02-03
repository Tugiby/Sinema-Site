using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace proje1.Models.Siniflar
{
    public class faturalar
    {
        [Key]
        public int faturaid { get; set; }

        [Range(0, 999999)]
        public int faturasırano { get; set; }

        [Range(0, 999999)]
        public int faturaserino { get; set; }

        public DateTime faturatarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string vergidairesi { get; set; }

        public DateTime faturasaat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string faturaalan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string faturaveren { get; set; }

        public filmozellik filmozellik { get; set; }

        public ICollection<faturagirdiler> faturagirdilers { get; set; }

        
    }
}
