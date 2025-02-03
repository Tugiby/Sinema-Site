using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
   
    public class faturagirdiler
    {
        [Key]
        public int faturagirdiid { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string faturaaçıklama { get; set; }

        public int faturamiktar { get; set; }

        public decimal faturabirimfiyat  { get; set; }
   
        public decimal faturatutar {  get; set; }

        public DateTime faturatarih { get; set; }
        public faturalar faturalar {  get; set; }
    }
}