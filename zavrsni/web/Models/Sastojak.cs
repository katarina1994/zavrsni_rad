using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class Sastojak
    {

        public int ID { get; set; }
        public String Naziv_sastojak { get; set; }
        public int JeloID { get; set; }
        public virtual Jelo Jelo { get; set; }

    }
}