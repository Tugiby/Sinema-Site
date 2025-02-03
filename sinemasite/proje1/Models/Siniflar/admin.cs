using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class admin              //admin classı. admin işlemleri için kullanılacak değişkenler
    {
        [Key]
        public int adminid { get; set; }
           

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string adminkullaniciad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string adminsifre { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string adminyetki { get; set; }



    }
}