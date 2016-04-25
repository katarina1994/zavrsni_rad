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
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>
    //public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
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
                Naziv = "Pizzeria Italy",
                Adresa = "Nova cesta 173, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Nova cesta 173, Zagreb").Latitude, locationService.GetLatLongFromAddress("nova cesta 173, zagreb").Longitude)
            });
        
            context.Restorani.Add(new Restoran
            {
                ID = 2,
                RadijusDostave = 6,
                Naziv = "Nokturno",
                Adresa = "Tkalciceva 11, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Tkalciceva 11, Zagreb").Latitude, locationService.GetLatLongFromAddress("tkalciceva 11, zagreb").Longitude)
            });
           
            context.Restorani.Add(new Restoran
            {
                ID = 3,
                RadijusDostave = 2,
                Naziv = "Restoran Mali Raj",
                Adresa = "Trg Stjepana Radica 6, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Trg Stjepana Radica 6, Zagreb").Latitude, locationService.GetLatLongFromAddress("stjepana radica 61, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 4,
                RadijusDostave = 2,
                Naziv = "Grill House",
                Adresa = "Trg bana Josipa Jelacica 2, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Trg bana Josipa Jelacica 2, Zagreb").Latitude, locationService.GetLatLongFromAddress("bana josipa jelacica 2, zagreb").Longitude)
            });
         
            context.Restorani.Add(new Restoran
            {
                ID = 5,
                RadijusDostave = 3,
                Naziv = "Pizzeria Pegor",
                Adresa = "Ulica Marina Drzica 143, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ulica Marina Drzica 143, Zagreb").Latitude, locationService.GetLatLongFromAddress("marina drzica 143, zagreb").Longitude)
            });
           
            context.Restorani.Add(new Restoran
            {
                ID = 6,
                RadijusDostave = 4,
                Naziv = "Cookies",
                Adresa = "Avenija Dubrovnik 55, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Avenija Dubrovnik 55, Zagreb").Latitude, locationService.GetLatLongFromAddress("avenija dubrovnik 55, zagreb").Longitude)

            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 7,
                RadijusDostave = 3,
                Naziv = "Italian Fantasy",
                Adresa = "Sveucilisna aleja 78, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Sveucilisna aleja 78, Zagreb").Latitude, locationService.GetLatLongFromAddress("sveucilisna aleja 78, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 8,
                RadijusDostave = 6,
                Naziv = "Cakes and Cholcolate",
                Adresa = "Ulica grada Vukovara 100, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ulica grada Vukovara 100, Zagreb").Latitude, locationService.GetLatLongFromAddress("ulica grada vukovara 100, zagreb").Longitude)
            });
           
            context.Restorani.Add(new Restoran
            {
                ID = 9,
                RadijusDostave = 7,
                Naziv = "Steak House",
                Adresa = "Dalmatinska ulica 14, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Dalmatinska ulica 14, Zagreb").Latitude, locationService.GetLatLongFromAddress("dalmatinska ulica 4, zagreb").Longitude)
            });
            
            context.Restorani.Add(new Restoran
            {
                ID = 10,
                RadijusDostave = 4,
                Naziv = "Pizzeria Maslina",
                Adresa = "Ulica Marka Marulica 89, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ulica Marka Marulica 89, Zagreb").Latitude, locationService.GetLatLongFromAddress("ulica marka marulica 89, zagreb").Longitude)
            });

            context.Restorani.Add(new Restoran
            {
                ID = 11,
                RadijusDostave = 3,
                Naziv = "Restoran Seoski kutak",
                Adresa = "Slavonska avenija 23, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Slavonska avenija 23, Zagreb").Latitude, locationService.GetLatLongFromAddress("slavonska avenija 23, zagreb").Longitude)
            });

            context.Restorani.Add(new Restoran
            {
                ID = 12,
                RadijusDostave = 3,
                Naziv = "Restoran Školjka",
                Adresa = "Ljubljanica 5, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ljubljanica 5, Zagreb").Latitude, locationService.GetLatLongFromAddress("ljubljanica 5, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 13,
                RadijusDostave = 7,
                Naziv = "Chez Marie",
                Adresa = "Zagrebacka ulica 156, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Zagrebacka ulica 156, Zagreb").Latitude, locationService.GetLatLongFromAddress("zagrebacka ulica 156, zagreb").Longitude)
            });
            
            context.Restorani.Add(new Restoran
            {
                ID = 14,
                RadijusDostave = 6,
                Naziv = "Fast food Tasty",
                Adresa = "Ilica 132, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ilica 132, Zagreb").Latitude, locationService.GetLatLongFromAddress("ilica 132, zagreb").Longitude)
            });
            
            context.Restorani.Add(new Restoran
            {
                ID = 15,
                RadijusDostave = 4,
                Naziv = "Wokwok",
                Adresa = "Jarun 43, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Jarun 43, Zagreb").Latitude, locationService.GetLatLongFromAddress("jarun 43, zagreb").Longitude)
            });
          
            context.Restorani.Add(new Restoran
            {
                ID = 16,
                RadijusDostave = 2,
                Naziv = "Restoran Ribica",
                Adresa = "Krapinska ulica 50, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Krapinska ulica 50, zagreb").Latitude, locationService.GetLatLongFromAddress("varazdinska ulica 50, zagreb").Longitude)
            });
            context.Restorani.Add(new Restoran
            {
                ID = 17,
                RadijusDostave = 3,
                Naziv = "Grill 'n' steak",
                Adresa = "Ilica 1, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ilica 1, Zagreb").Latitude, locationService.GetLatLongFromAddress("varazdinska ulica 50, zagreb").Longitude)
            });


            context.SaveChanges();


            //jela

            context.Jela.Add(new Jelo
            {
                    ID = 1,
                    Naziv_jelo = "Cevapi s lukom",
                    Cijena = 35,
                    RestoranID = 1
            });
            context.Jela.Add(new Jelo
            {
                    ID = 2,
                    Naziv_jelo = "Pizza margherita - mala",
                    Cijena = 24,
                    RestoranID = 1
            });
            context.Jela.Add(new Jelo
            {
                    ID = 3,
                    Naziv_jelo = "Pizza margherita - velika",
                    Cijena = 37,
                    RestoranID = 1
            });
            context.Jela.Add(new Jelo
            {
                    ID = 4,
                    Naziv_jelo = "Pizza capriciosa - mala",
                    Cijena = 26,
                    RestoranID = 2
            });
            context.Jela.Add(new Jelo
            {
                    ID = 5,
                    Naziv_jelo = "Pizza capriciosa - velika",
                    Cijena = 40,
                    RestoranID = 2
            });
            context.Jela.Add(new Jelo
            {
                    ID = 6,
                    Naziv_jelo = "Zagrebački odrezak",
                    Cijena = 45,
                    RestoranID = 2
            });
            context.Jela.Add(new Jelo
            {
                ID = 7,
                Naziv_jelo = "Cevapi s lukom",
                Cijena = 39,
                RestoranID = 3
            });
            context.Jela.Add(new Jelo
            {
                ID = 8,
                Naziv_jelo = "Lazanje s povrcem",
                Cijena = 24,
                RestoranID = 3
            });
            context.Jela.Add(new Jelo
            {
                ID = 9,
                Naziv_jelo = "Lazanje s mesom",
                Cijena = 37,
                RestoranID = 3
            });
            context.Jela.Add(new Jelo
            {
                ID = 10,
                Naziv_jelo = "Mesna plata - velika",
                Cijena = 67,
                RestoranID = 4
            });
            context.Jela.Add(new Jelo
            {
                ID = 11,
                Naziv_jelo = "Cevapi s lukom i ajvarom",
                Cijena = 36,
                RestoranID = 4
            });
            context.Jela.Add(new Jelo
            {
                ID = 12,
                Naziv_jelo = "Bečki odrezak s pomfritom",
                Cijena = 52,
                RestoranID = 4
            });
            context.Jela.Add(new Jelo
            {
                ID = 13,
                Naziv_jelo = "Pizza 4 quattro stagione",
                Cijena = 29,
                RestoranID = 5
            });
            context.Jela.Add(new Jelo
            {
                ID = 14,
                Naziv_jelo = "Pizza margherita - mala",
                Cijena = 24,
                RestoranID = 5
            });
            context.Jela.Add(new Jelo
            {
                ID = 15,
                Naziv_jelo = "Pizza margherita - velika",
                Cijena = 41,
                RestoranID = 5
            });
            context.Jela.Add(new Jelo
            {
                ID = 16,
                Naziv_jelo = "Palacinke s nutellom (2 kom)",
                Cijena = 19,
                RestoranID = 6
            });
            context.Jela.Add(new Jelo
            {
                ID = 17,
                Naziv_jelo = "Sladoledni kup",
                Cijena = 31,
                RestoranID = 6
            });
            context.Jela.Add(new Jelo
            {
                ID = 18,
                Naziv_jelo = "Sacher torta (kom)",
                Cijena = 17,
                RestoranID = 6
            });
            context.Jela.Add(new Jelo
            {
                ID = 19,
                Naziv_jelo = "Tjestenina bolognese",
                Cijena = 27,
                RestoranID = 7
            });
            context.Jela.Add(new Jelo
            {
                ID = 20,
                Naziv_jelo = "Tjestenina s povrcem",
                Cijena = 34,
                RestoranID = 7
            });
            context.Jela.Add(new Jelo
            {
                ID = 21,
                Naziv_jelo = "Pizza s tunom",
                Cijena = 31,
                RestoranID = 7
            });
            context.Jela.Add(new Jelo
            {
                ID = 22,
                Naziv_jelo = "Schwarzwald torta (kom)",
                Cijena = 20,
                RestoranID = 8
            });
            context.Jela.Add(new Jelo
            {
                ID = 23,
                Naziv_jelo = "Palacinke s pekmezom (2 kom)",
                Cijena = 16,
                RestoranID = 8
            });
            context.Jela.Add(new Jelo
            {
                ID = 24,
                Naziv_jelo = "Pita od jabuka (kom)",
                Cijena = 15,
                RestoranID = 8
            });
            context.Jela.Add(new Jelo
            {
                ID = 25,
                Naziv_jelo = "Cevapi s ajvarom - mali",
                Cijena = 35,
                RestoranID = 9
            });
            context.Jela.Add(new Jelo
            {
                ID = 26,
                Naziv_jelo = "Cevapi s ajvarom - veliki",
                Cijena = 45,
                RestoranID = 9
            });
            context.Jela.Add(new Jelo
            {
                ID = 27,
                Naziv_jelo = "Mijesana mesna plata",
                Cijena = 59,
                RestoranID = 9
            });
            context.Jela.Add(new Jelo
            {
                ID = 28,
                Naziv_jelo = "Pizza capriciosa",
                Cijena = 229,
                RestoranID = 10
            });
            context.Jela.Add(new Jelo
            {
                ID = 29,
                Naziv_jelo = "Pizza margerita - jumbo",
                Cijena = 60,
                RestoranID = 10
            });
            context.Jela.Add(new Jelo
            {
                ID = 30,
                Naziv_jelo = "Vegetarijanska pizza",
                Cijena = 33,
                RestoranID = 10
            });
            context.Jela.Add(new Jelo
            {
                ID = 31,
                Naziv_jelo = "Njoki s teletinom",
                Cijena = 40,
                RestoranID = 11
            });
            context.Jela.Add(new Jelo
            {
                ID = 32,
                Naziv_jelo = "Zapeceni grah s rebarcima",
                Cijena = 31,
                RestoranID = 11
            });
            context.Jela.Add(new Jelo
            {
                ID = 33,
                Naziv_jelo = "Strukli sa sirom (3 kom)",
                Cijena = 30,
                RestoranID = 11
            });
            context.Jela.Add(new Jelo
            {
                ID = 34,
                Naziv_jelo = "Jastog na bianco",
                Cijena = 65,
                RestoranID = 12
            });
            context.Jela.Add(new Jelo
            {
                ID = 35,
                Naziv_jelo = "Losos s prilogom",
                Cijena = 70,
                RestoranID = 12
            });
            context.Jela.Add(new Jelo
            {
                ID = 36,
                Naziv_jelo = "Peceni brancin s prilogom",
                Cijena = 55,
                RestoranID = 12
            });
            context.Jela.Add(new Jelo
            {
                ID = 37,
                Naziv_jelo = "Francuski puzevi",
                Cijena = 120,
                RestoranID = 13
            });
            context.Jela.Add(new Jelo
            {
                ID = 38,
                Naziv_jelo = "Tarte Bourdaloue",
                Cijena = 100,
                RestoranID = 13
            });
            context.Jela.Add(new Jelo
            {
                ID = 39,
                Naziv_jelo = "Coq au vin (Pijetao u vinu) ",
                Cijena = 155,
                RestoranID = 13
            });
            context.Jela.Add(new Jelo
            {
                ID = 40,
                Naziv_jelo = "Kebab - mala porcija",
                Cijena = 14,
                RestoranID = 14
            });
            context.Jela.Add(new Jelo
            {
                ID = 41,
                Naziv_jelo = "Kebab - velika porcija",
                Cijena = 21,
                RestoranID = 14
            });
            context.Jela.Add(new Jelo
            {
                ID = 42,
                Naziv_jelo = "Hotdog",
                Cijena = 17,
                RestoranID = 14
            });
            context.Jela.Add(new Jelo
            {
                ID = 43,
                Naziv_jelo = "Skampi s povrcem i rizom",
                Cijena = 35,
                RestoranID = 15
            });
            context.Jela.Add(new Jelo
            {
                ID = 44,
                Naziv_jelo = "Sushi",
                Cijena = 45,
                RestoranID = 15
            });
            context.Jela.Add(new Jelo
            {
                ID = 45,
                Naziv_jelo = "Riza u woku",
                Cijena = 35,
                RestoranID = 15
            });
            context.Jela.Add(new Jelo
            {
                ID = 46,
                Naziv_jelo = "Skampi s prilogom",
                Cijena = 60,
                RestoranID = 16
            });
            context.Jela.Add(new Jelo
            {
                ID = 47,
                Naziv_jelo = "Odrezak od tune",
                Cijena = 70,
                RestoranID = 16
            });
            context.Jela.Add(new Jelo
            {
                ID = 48,
                Naziv_jelo = "Hobotnica ispod peke",
                Cijena = 120,
                RestoranID = 16
            });
            context.Jela.Add(new Jelo
            {
                    ID = 49,
                    Naziv_jelo = "Cevapi s lukom i ajvarom",
                    Cijena = 35,
                    RestoranID = 17
            });
            context.Jela.Add(new Jelo
            {
                    ID = 50,
                    Naziv_jelo = "Mesna plata",
                    Cijena = 67,
                    RestoranID = 17
            });
            context.Jela.Add(new Jelo
            {
                    ID = 51,
                    Naziv_jelo = "Sis-cevapi",
                    Cijena = 37,
                    RestoranID = 17
            });
            context.Jela.Add(new Jelo
            {
                    ID = 52,
                    Naziv_jelo = "Pizza s plodovima mora",
                    Cijena = 26,
                    RestoranID = 1
            });
            context.Jela.Add(new Jelo
            {
                    ID = 53,
                    Naziv_jelo = "Kolac od limuna",
                    Cijena = 40,
                    RestoranID = 8
            });
            context.Jela.Add(new Jelo
            {
                    ID = 54,
                    Naziv_jelo = "Pizza s plodovima mora",
                    Cijena = 45,
                    RestoranID = 10
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