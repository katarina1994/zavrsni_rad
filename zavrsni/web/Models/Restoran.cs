using System;
using System.Data.Entity.Spatial;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;
using System.Globalization;
using System.Threading;

namespace web.Models
{
    public class Restoran
    {
        public int ID { get; set; }
        public String Naziv { get; set; }
        public String Adresa { get; set; }
        public int RadijusDostave { get; set; }
        public DbGeography Location { get; set; }
  

        /*public Restoran(params string[] podaci)
                {
                    ID = Convert.ToInt32(podaci[0]);
                    Naziv = podaci[1];
                    Adresa = podaci[2];
                    RadijusDostave = Convert.ToInt32(podaci[3]);
                }*/


        public static DbGeography CreatePoint(double latitude, double longitude)
        {
            Thread.Sleep(1000);
            var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
                                     "POINT({0} {1})", longitude, latitude);
            // 4326 is most common coordinate system used by GPS/Maps
            return DbGeography.PointFromText(text, 4326);
        }
        
    }
}
