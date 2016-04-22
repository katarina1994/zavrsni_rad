using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class Jelo
    {
        public int ID { get; set; }       
        public String Naziv_jelo { get; set; }
        public double Cijena { get; set; }
        public int RestoranID { get; set; }
        public virtual Restoran Restoran { get; set; }
    }
}