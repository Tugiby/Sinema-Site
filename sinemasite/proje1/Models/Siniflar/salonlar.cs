using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proje1.Models.Siniflar
{
    public class salonlar
    {
        [Key]
        public int salonid { get; set; }
        public string salonad { get; set; }
        public int kapasite { get; set; }
        
        public string dolukoltuklar { get; set; } //sonradan

        public int filmid {  get; set; }



        public ICollection<satishareket> satisharekets { get; set; }


    }
}