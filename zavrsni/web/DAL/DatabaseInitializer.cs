using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Threading.Tasks;
using web.Models;
using web.Repositories;
using System.Globalization;
using GoogleMaps.LocationServices;
using System.Threading;

namespace web.DAL
{
    // public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //base.Seed(context);


            // ovlasti
            var ovlasti = new List<Ovlast>
            {
                new Ovlast{ ID=1, Naziv="Administrator" },
                new Ovlast{ ID=2, Naziv="Korisnik1" },
                new Ovlast{ ID=3, Naziv="Voditelj" }
            };
            ovlasti.ForEach(s => context.Ovlasti.Add(s));
            context.SaveChanges();


            //Restoran restoran = new Restoran(podaci);
            // restorani
            var locationService = new GoogleLocationService();
            context.Restorani.Add(new Restoran
            {
                
                ID = 1,
                RadijusDostave = 3,
                Naziv = String.Format("{0:00}restoran1", 1),
                Adresa = "nova cesta 173, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("nova cesta 173, zagreb").Latitude, locationService.GetLatLongFromAddress("nova cesta 173, zagreb").Longitude)
            });
        
            context.Restorani.Add(new Restoran
            {
                ID = 2,
                RadijusDostave = 6,
                Naziv = String.Format("{0:00}restoran2", 2),
                Adresa = "tkalciceva 11, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("tkalciceva 11, zagreb").Latitude, locationService.GetLatLongFromAddress("tkalciceva 11, zagreb").Longitude)
            });
           
            context.Restorani.Add(new Restoran
            {
                ID = 3,
                RadijusDostave = 5,
                Naziv = String.Format("{0:00}restoran3", 3),
                Adresa = "Trg stjepana radica 61, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("stjepana radica 61, zagreb").Latitude, locationService.GetLatLongFromAddress("stjepana radica 61, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 4,
                RadijusDostave = 2,
                Naziv = String.Format("{0:00}restoran4", 4),
                Adresa = "bana josipa jelacica 2, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("bana josipa jelacica 2, zagreb").Latitude, locationService.GetLatLongFromAddress("bana josipa jelacica 2, zagreb").Longitude)
            });
         
            context.Restorani.Add(new Restoran
            {
                ID = 5,
                RadijusDostave = 3,
                Naziv = String.Format("{0:00}restoran5", 5),
                Adresa = "marina drzica 143, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("marina drzica 143, zagreb").Latitude, locationService.GetLatLongFromAddress("marina drzica 143, zagreb").Longitude)
            });
           
            context.Restorani.Add(new Restoran
            {
                ID = 6,
                RadijusDostave = 4,
                Naziv = String.Format("{0:00}restoran6", 6),
                Adresa = "avenija dubrovnik 55, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("avenija dubrovnik 55, zagreb").Latitude, locationService.GetLatLongFromAddress("avenija dubrovnik 55, zagreb").Longitude)

            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 7,
                RadijusDostave = 3,
                Naziv = String.Format("{0:00}restoran7", 7),
                Adresa = "sveucilisna aleja 78, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("sveucilisna aleja 78, zagreb").Latitude, locationService.GetLatLongFromAddress("sveucilisna aleja 78, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 8,
                RadijusDostave = 6,
                Naziv = String.Format("{0:00}restoran8", 8),
                Adresa = "ulica grada vukovara 100, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("ulica grada vukovara 100, zagreb").Latitude, locationService.GetLatLongFromAddress("ulica grada vukovara 100, zagreb").Longitude)
            });
           
            context.Restorani.Add(new Restoran
            {
                ID = 9,
                RadijusDostave = 7,
                Naziv = String.Format("{0:00}restoran9", 9),
                Adresa = "dalmatinska ulica 4, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("dalmatinska ulica 4, zagreb").Latitude, locationService.GetLatLongFromAddress("dalmatinska ulica 4, zagreb").Longitude)
            });
            
            context.Restorani.Add(new Restoran
            {
                ID = 10,
                RadijusDostave = 4,
                Naziv = String.Format("{0:00}restoran10", 10),
                Adresa = "ulica marka marulica 89, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("ulica marka marulica 89, zagreb").Latitude, locationService.GetLatLongFromAddress("ulica marka marulica 89, zagreb").Longitude)
            });

            context.Restorani.Add(new Restoran
            {
                ID = 11,
                RadijusDostave = 3,
                Naziv = String.Format("{0:00}restoran11", 11),
                Adresa = "slavonska avenija 23, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("slavonska avenija 23, zagreb").Latitude, locationService.GetLatLongFromAddress("slavonska avenija 23, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 12,
                RadijusDostave = 3,
                Naziv = String.Format("{0:00}restoran12", 12),
                Adresa = "ljubljanica 5, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("ljubljanica 5, zagreb").Latitude, locationService.GetLatLongFromAddress("ljubljanica 5, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 13,
                RadijusDostave = 7,
                Naziv = String.Format("{0:00}restoran13", 13),
                Adresa = "zagrebacka ulica 156, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("zagrebacka ulica 156, zagreb").Latitude, locationService.GetLatLongFromAddress("zagrebacka ulica 156, zagreb").Longitude)
            });
            
            context.Restorani.Add(new Restoran
            {
                ID = 14,
                RadijusDostave = 6,
                Naziv = String.Format("{0:00}restoran14", 14),
                Adresa = "ilica 132, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("ilica 132, zagreb").Latitude, locationService.GetLatLongFromAddress("ilica 132, zagreb").Longitude)
            });
            
            context.Restorani.Add(new Restoran
            {
                ID = 15,
                RadijusDostave = 4,
                Naziv = String.Format("{0:00}restoran15", 15),
                Adresa = "jarun 43, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("jarun 43, zagreb").Latitude, locationService.GetLatLongFromAddress("jarun 43, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 16,
                RadijusDostave = 2,
                Naziv = String.Format("{0:00}restoran16", 16),
                Adresa = "varazdinska ulica 50, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("varazdinska ulica 50, zagreb").Latitude, locationService.GetLatLongFromAddress("varazdinska ulica 50, zagreb").Longitude)
            });



            context.SaveChanges();


            // korisnici
            addUsers(context);
        }

        private void addUsers(DatabaseContext context)
        {
            UserManager<Korisnik> _userManager = new UserManager<Korisnik>(new UserStore<Korisnik>(context));



            var korisnik1 = new Korisnik
            {
                UserName = "korisnik1",
                Password = "korisnik1",
                ConfirmPassword = "korisnik1",
                Ime = "kor_Naziv",
                Prezime = "kor_prezNaziv",
                OvlastID = 2

            };
            _userManager.Create(korisnik1, korisnik1.Password);



            // admin
            var administrator = new Korisnik
            {
                UserName = "administrator",
                Password = "administrator",
                ConfirmPassword = "administrator",
                Ime = "admin_Naziv",
                Prezime = "admin_prezNaziv",
                OvlastID = 1
            };
            _userManager.Create(administrator, administrator.Password);

            // clan odbora
            var voditelj = new Korisnik
            {
                UserName = "voditelj",
                Password = "voditelj",
                ConfirmPassword = "voditelj",
                Ime = "vod_Naziv",
                Prezime = "vod_prezNaziv",
                OvlastID = 3
            };
            _userManager.Create(voditelj, voditelj.Password);
        }
    }
}