using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class OdabranoJelo

    {

        public int ID { get; set; }
        public int Kolicina { get; set; }
        public string Mail { get; set; }
        public string Adresa { get; set; }
        public string Vrijeme { get; set; }
        public int UkupnaCijena { get; set; }
        public int JeloID { get; set; }        
        public int RestoranID { get; set; }       
        public virtual Jelo Jelo { get; set; }
        public virtual Restoran Restoran { get; set; }

    }
}