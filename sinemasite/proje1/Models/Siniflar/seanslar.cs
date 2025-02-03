using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class seanslar
    {
        [Key]
        public int seansid { get; set; }
        
        public DateTime? Seans { get; set; }


        public ICollection<filmozellik>filmozelliks { get; set; }
        public ICollection<satishareket> satisharekets { get; set; }


    }



        

    }
