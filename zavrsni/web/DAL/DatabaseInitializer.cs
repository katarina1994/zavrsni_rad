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
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Nova cesta 173, Zagreb").Latitude, locationService.GetLatLongFromAddress("nova cesta 173, zagreb").Longitude),
                Vrijeme_otvaranja = 11,
                Vrijeme_zatvaranja = 23
            });

            context.Restorani.Add(new Restoran
            {
                ID = 2,
                RadijusDostave = 6,
                Naziv = "Nokturno",
                Adresa = "Tkalciceva 11, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Tkalciceva 11, Zagreb").Latitude, locationService.GetLatLongFromAddress("tkalciceva 11, zagreb").Longitude),
                Vrijeme_otvaranja = 12,
                Vrijeme_zatvaranja = 23
            });

            context.Restorani.Add(new Restoran
            {
                ID = 3,
                RadijusDostave = 2,
                Naziv = "Restoran Mali Raj",
                Adresa = "Trg Stjepana Radica 6, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Trg Stjepana Radica 6, Zagreb").Latitude, locationService.GetLatLongFromAddress("stjepana radica 61, zagreb").Longitude),
                Vrijeme_otvaranja = 12,
                Vrijeme_zatvaranja = 19
            });

            context.Restorani.Add(new Restoran
            {
                ID = 4,
                RadijusDostave = 2,
                Naziv = "Grill House",
                Adresa = "Trg bana Josipa Jelacica 2, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Trg bana Josipa Jelacica 2, Zagreb").Latitude, locationService.GetLatLongFromAddress("bana josipa jelacica 2, zagreb").Longitude),
                Vrijeme_otvaranja = 10,
                Vrijeme_zatvaranja = 21
            });

            context.Restorani.Add(new Restoran
            {
                ID = 5,
                RadijusDostave = 3,
                Naziv = "Pizzeria Pegor",
                Adresa = "Ulica Marina Drzica 143, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ulica Marina Drzica 143, Zagreb").Latitude, locationService.GetLatLongFromAddress("marina drzica 143, zagreb").Longitude),
                Vrijeme_otvaranja = 15,
                Vrijeme_zatvaranja = 23
            });

            context.Restorani.Add(new Restoran
            {
                ID = 6,
                RadijusDostave = 4,
                Naziv = "Cookies",
                Adresa = "Avenija Dubrovnik 55, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Avenija Dubrovnik 55, Zagreb").Latitude, locationService.GetLatLongFromAddress("avenija dubrovnik 55, zagreb").Longitude),
                Vrijeme_otvaranja = 9,
                Vrijeme_zatvaranja = 21
            });

            context.Restorani.Add(new Restoran
            {
                ID = 7,
                RadijusDostave = 3,
                Naziv = "Italian Fantasy",
                Adresa = "Sveucilisna aleja 78, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Sveucilisna aleja 78, Zagreb").Latitude, locationService.GetLatLongFromAddress("sveucilisna aleja 78, zagreb").Longitude),
                Vrijeme_otvaranja = 12,
                Vrijeme_zatvaranja = 23
            });

            context.Restorani.Add(new Restoran
            {
                ID = 8,
                RadijusDostave = 6,
                Naziv = "Cakes and Cholcolate",
                Adresa = "Ulica grada Vukovara 100, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ulica grada Vukovara 100, Zagreb").Latitude, locationService.GetLatLongFromAddress("ulica grada vukovara 100, zagreb").Longitude),
                Vrijeme_otvaranja = 11,
                Vrijeme_zatvaranja = 20
            });

            context.Restorani.Add(new Restoran
            {
                ID = 9,
                RadijusDostave = 7,
                Naziv = "Steak House",
                Adresa = "Dalmatinska ulica 14, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Dalmatinska ulica 14, Zagreb").Latitude, locationService.GetLatLongFromAddress("dalmatinska ulica 4, zagreb").Longitude),
                Vrijeme_otvaranja = 14,
                Vrijeme_zatvaranja = 23
            });

            context.Restorani.Add(new Restoran
            {
                ID = 10,
                RadijusDostave = 4,
                Naziv = "Pizzeria Maslina",
                Adresa = "Ulica Marka Marulica 89, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ulica Marka Marulica 89, Zagreb").Latitude, locationService.GetLatLongFromAddress("ulica marka marulica 89, zagreb").Longitude),
                Vrijeme_otvaranja = 13,
                Vrijeme_zatvaranja = 22

            });

            context.Restorani.Add(new Restoran
            {
                ID = 11,
                RadijusDostave = 3,
                Naziv = "Restoran Seoski kutak",
                Adresa = "Slavonska avenija 23, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Slavonska avenija 23, Zagreb").Latitude, locationService.GetLatLongFromAddress("slavonska avenija 23, zagreb").Longitude),
                Vrijeme_otvaranja = 14,
                Vrijeme_zatvaranja = 23
            });

            context.Restorani.Add(new Restoran
            {
                ID = 12,
                RadijusDostave = 3,
                Naziv = "Restoran Školjka",
                Adresa = "Ljubljanica 5, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ljubljanica 5, Zagreb").Latitude, locationService.GetLatLongFromAddress("ljubljanica 5, zagreb").Longitude),
                Vrijeme_otvaranja = 15,
                Vrijeme_zatvaranja = 21
            });

            context.Restorani.Add(new Restoran
            {
                ID = 13,
                RadijusDostave = 7,
                Naziv = "Chez Marie",
                Adresa = "Zagrebacka ulica 156, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Zagrebacka ulica 156, Zagreb").Latitude, locationService.GetLatLongFromAddress("zagrebacka ulica 156, zagreb").Longitude),
                Vrijeme_otvaranja = 16,
                Vrijeme_zatvaranja = 23
            });

            context.Restorani.Add(new Restoran
            {
                ID = 14,
                RadijusDostave = 6,
                Naziv = "Fast food Tasty",
                Adresa = "Ilica 132, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ilica 132, Zagreb").Latitude, locationService.GetLatLongFromAddress("ilica 132, zagreb").Longitude),
                Vrijeme_otvaranja = 14,
                Vrijeme_zatvaranja = 21
            });

            context.Restorani.Add(new Restoran
            {
                ID = 15,
                RadijusDostave = 4,
                Naziv = "Wokwok",
                Adresa = "Jarun 43, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Jarun 43, Zagreb").Latitude, locationService.GetLatLongFromAddress("jarun 43, zagreb").Longitude),
                Vrijeme_otvaranja = 13,
                Vrijeme_zatvaranja = 22
            });

            context.Restorani.Add(new Restoran
            {
                ID = 16,
                RadijusDostave = 2,
                Naziv = "Restoran Ribica",
                Adresa = "Krapinska ulica 50, zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Krapinska ulica 50, zagreb").Latitude, locationService.GetLatLongFromAddress("varazdinska ulica 50, zagreb").Longitude),
                Vrijeme_otvaranja = 14,
                Vrijeme_zatvaranja = 23
            });
            context.Restorani.Add(new Restoran
            {
                ID = 17,
                RadijusDostave = 3,
                Naziv = "Grill 'n' steak",
                Adresa = "Ilica 1, Zagreb",
                Location = Restoran.CreatePoint(locationService.GetLatLongFromAddress("Ilica 1, Zagreb").Latitude, locationService.GetLatLongFromAddress("varazdinska ulica 50, zagreb").Longitude),
                Vrijeme_otvaranja = 12,
                Vrijeme_zatvaranja = 22
            });


            context.SaveChanges();



            //tipovi jela


            context.Tipovi.Add(new TipJela
            {
                ID = 1,
                Naziv_tipa = "Riblja jela"
            });
            context.Tipovi.Add(new TipJela
            {
                ID = 2,
                Naziv_tipa = "Mesna jela s prilogom"
            });
            context.Tipovi.Add(new TipJela
            {
                ID = 3,
                Naziv_tipa = "Vegetarijanska jela"
            });
            context.Tipovi.Add(new TipJela
            {
                ID = 4,
                Naziv_tipa = "Svjetska kuhinja"
            });
            context.Tipovi.Add(new TipJela
            {
                ID = 5,
                Naziv_tipa = "Slastice i kolači"
            });
            context.Tipovi.Add(new TipJela
            {
                ID = 6,
                Naziv_tipa = "Pizze"
            });
            context.Tipovi.Add(new TipJela
            {
                ID = 7,
                Naziv_tipa = "Domaća kuhinja"
            });
            context.Tipovi.Add(new TipJela
            {
                ID = 8,
                Naziv_tipa = "Brza hrana"
            });
            context.SaveChanges();


            //jela

            context.Jela.Add(new Jelo
            {
                ID = 1,
                Naziv_jelo = "Ćevapi s lukom",
                Cijena = 35,
                Kratki_opis = "Porcija 10 velikih ćevapa s lukom",
                RestoranID = 1,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 2,
                Naziv_jelo = "Pizza margherita",
                Cijena = 24,
                Kratki_opis = "Sir, šunka, rajčica, šampinjoni",
                RestoranID = 1,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 3,
                Naziv_jelo = "Pizza rikola i pršut",
                Cijena = 37,
                Kratki_opis = "Rajčica, sir, pršut, rukola",
                RestoranID = 1,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 4,
                Naziv_jelo = "Pizza capricciosa",
                Cijena = 26,
                Kratki_opis = "Šunka, sir, rajčica, šampinjoni, slanina",
                RestoranID = 2,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 5,
                Naziv_jelo = "Pizza 4 staggione",
                Cijena = 40,
                Kratki_opis = "Rajčica, sir, šunka, gljive, plodovi mora",
                RestoranID = 2,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 6,
                Naziv_jelo = "Zagrebački odrezak s prilogom",
                Cijena = 45,
                RestoranID = 2,
                Kratki_opis = "Pohane teleće šnicle punjene sirom i šunkom, prilog pire graška i krumpira",
                TipJelaID = 7

            });
            context.Jela.Add(new Jelo
            {
                ID = 7,
                Naziv_jelo = "Šiš ćevapi s lukom",
                Cijena = 39,
                Kratki_opis = "Porcija 12 šiš ćevapa s lukom",
                RestoranID = 3,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 8,
                Naziv_jelo = "Lazanje s povrcem i sirom",
                Cijena = 24,
                Kratki_opis = "Lazanje s patlidžanom, tikvicama, rajčicom, mozzarellom",
                RestoranID = 3,
                TipJelaID = 3

            });
            context.Jela.Add(new Jelo
            {
                ID = 9,
                Naziv_jelo = "Lazanje s mesom",
                Cijena = 37,
                Kratki_opis = "Lazanje s mljevenim mesom, rajčicom, sirom, kiselim vrhnjem",
                RestoranID = 3,
                TipJelaID = 2

            });
            context.Jela.Add(new Jelo
            {
                ID = 10,
                Naziv_jelo = "Mesna plata - velika",
                Cijena = 67,
                Kratki_opis = "Izbor različitih mesnih delicija: ćevapi, šiš ćevapi, teleće šnicle na žaru, svinjske šnicle na žaru, piletina na žaru",
                RestoranID = 4,
                TipJelaID = 2

            });
            context.Jela.Add(new Jelo
            {
                ID = 11,
                Naziv_jelo = "Ćevapi s lukom i ajvarom",
                Cijena = 36,
                Kratki_opis = "Porcija 10 velikih ćevapa s lukom i blago začinjenim ajvarom",
                RestoranID = 4,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 12,
                Naziv_jelo = "Bečki odrezak s pomfritom",
                Cijena = 52,
                Kratki_opis = "Pohani teleći odrezak, s prilogom pomfrit",
                RestoranID = 4,
                TipJelaID = 2

            });
            context.Jela.Add(new Jelo
            {
                ID = 13,
                Naziv_jelo = "Pizza 4 quattro stagione",
                Cijena = 29,
                Kratki_opis = "Rajčica, sir, šunka, gljive, plodovi mora",
                TipJelaID = 6,
                RestoranID = 5

            });
            context.Jela.Add(new Jelo
            {
                ID = 14,
                Naziv_jelo = "Pizza margherita - mala",
                Cijena = 24,
                Kratki_opis = "Sir, šunka rajčica, šampinjoni. Za 1 osobu",
                RestoranID = 5,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 15,
                Naziv_jelo = "Pizza margherita - velika",
                Cijena = 41,
                Kratki_opis = "Sir, šunka rajčica, šampinjoni, za 3 osobe",
                RestoranID = 5,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 16,
                Naziv_jelo = "Palačinke s nutellom (2 kom)",
                Cijena = 19,
                Kratki_opis = "Porcija 2 čokoladne palačinke punjene nutellom, s preljevom od čokolade",
                RestoranID = 6,
                TipJelaID = 5

            });
            context.Jela.Add(new Jelo
            {
                ID = 17,
                Naziv_jelo = "Sladoledni kup",
                Cijena = 31,
                Kratki_opis = "Porcija 5 kuglica sladoleda, razni okusi po želji",
                RestoranID = 6,
                TipJelaID = 5

            });
            context.Jela.Add(new Jelo
            {
                ID = 18,
                Naziv_jelo = "Sacher torta (kom)",
                Cijena = 17,
                Kratki_opis = "Jedna komad Sacher torte. Čokolada, pekmez od marelice, biskvit od kakaa",
                RestoranID = 6,
                TipJelaID = 5

            });
            context.Jela.Add(new Jelo
            {
                ID = 19,
                Naziv_jelo = "Tjestenina s mesnim okruglicama",
                Cijena = 27,
                Kratki_opis = "Domaći špageti, okruglice od mljevenog mesa, u umaku od rajčice i bosiljka",
                RestoranID = 7,
                TipJelaID = 7

            });
            context.Jela.Add(new Jelo
            {
                ID = 20,
                Naziv_jelo = "Tjestenina s povrćem",
                Cijena = 34,
                Kratki_opis = "Kratki rezanci u umaku od povrća: tikvice, patlidžan, paprika, rajčica",
                RestoranID = 7,
                TipJelaID = 3

            });
            context.Jela.Add(new Jelo
            {
                ID = 21,
                Naziv_jelo = "Pizza s tunom",
                Cijena = 31,
                Kratki_opis = "Sir mozazarella, rajčica, komadići tune, bosiljak",
                RestoranID = 7,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 22,
                Naziv_jelo = "Schwarzwald torta (kom)",
                Cijena = 20,
                Kratki_opis = "Komad Schwarzwald torte. Čokolada, višnje, čoko-biskvit",
                RestoranID = 8,
                TipJelaID = 5

            });
            context.Jela.Add(new Jelo
            {
                ID = 23,
                Naziv_jelo = "Palačinke s pekmezom (2 kom)",
                Cijena = 16,
                Kratki_opis = "Porcija 2 palačinke punjene domaćim pekmezom od miješanog voća, s preljevom od čokolade i šlagom",
                RestoranID = 8,
                TipJelaID = 5

            });
            context.Jela.Add(new Jelo
            {
                ID = 24,
                Naziv_jelo = "Pita od jabuka (kom)",
                Cijena = 15,
                Kratki_opis = "Komad domaće pite od jabuka. Biskvit od jaja, jabuke, cimet",
                RestoranID = 8,
                TipJelaID = 5

            });
            context.Jela.Add(new Jelo
            {
                ID = 25,
                Naziv_jelo = "Ćevapi s ajvarom - mali",
                Cijena = 35,
                Kratki_opis = "Mala porcija od 5 ćevapa s prilogom blagi ajvar",
                RestoranID = 9,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 26,
                Naziv_jelo = "Ćevapi s ajvarom - veliki",
                Cijena = 45,
                Kratki_opis = "Velika porcija od 10 ćevapa s prilogom blagi ajvar",
                RestoranID = 9,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 27,
                Naziv_jelo = "Miješana mesna plata",
                Cijena = 59,
                Kratki_opis = "Izbor različitih mesnih jela: ćevapi, šiš ćevapi, teleće šnicle na žaru, svinjske šnicle na žaru",
                RestoranID = 9,
                TipJelaID = 2

            });
            context.Jela.Add(new Jelo
            {
                ID = 28,
                Naziv_jelo = "Pizza capricciosa",
                Cijena = 29,
                Kratki_opis = "Šunka, sir, rajčica, šampinjoni, slanina",
                RestoranID = 10,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 29,
                Naziv_jelo = "Pizza margheritta",
                Cijena = 60,
                Kratki_opis = "Šunka, sir, rajčica, šampinjoni",
                RestoranID = 10,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 30,
                Naziv_jelo = "Vegetarijanska pizza",
                Cijena = 33,
                Kratki_opis = "Sir, rajčica, sezonsko povrće, gljive",
                RestoranID = 10,
                TipJelaID = 6

            });
            context.Jela.Add(new Jelo
            {
                ID = 31,
                Naziv_jelo = "Teletina s njokima",
                Cijena = 40,
                Kratki_opis = "Šnicli od teletine u umaku od rajčice, s domaćim njokima od krumpira",
                RestoranID = 11,
                TipJelaID = 2

            });
            context.Jela.Add(new Jelo
            {
                ID = 32,
                Naziv_jelo = "Zapečeni grah s rebarcima",
                Cijena = 31,
                Kratki_opis = "Pečena rebarca u BBQ umaku, grah zapečen s povrćem",
                RestoranID = 11,
                TipJelaID = 7

            });
            context.Jela.Add(new Jelo
            {
                ID = 33,
                Naziv_jelo = "Štrukli sa sirom (3 kom)",
                Cijena = 30,
                Kratki_opis = "Domaći zapečeni štrukli sa siromi vrhnjem, porcija od 3 komada",
                RestoranID = 11,
                TipJelaID = 7

            });
            context.Jela.Add(new Jelo
            {
                ID = 34,
                Naziv_jelo = "Jastog na bianco",
                Cijena = 65,
                Kratki_opis = "Kuhani jastog u umaku od vrhnja, s prilogom domaći rezanci",
                RestoranID = 12,
                TipJelaID = 1

            });
            context.Jela.Add(new Jelo
            {
                ID = 35,
                Naziv_jelo = "Losos s povrćem",
                Cijena = 70,
                Kratki_opis = "Carpaccio losos sa tikvicama i patlidžanom",
                RestoranID = 12,
                TipJelaID = 1

            });
            context.Jela.Add(new Jelo
            {
                ID = 36,
                Naziv_jelo = "Pečeni brancin s krumpirom",
                Cijena = 55,
                Kratki_opis = "Brancin sa žara, prilog krumpir s povrćem pečen na žaru",
                RestoranID = 12,
                TipJelaID = 1

            });
            context.Jela.Add(new Jelo
            {
                ID = 37,
                Naziv_jelo = "Francuski puževi",
                Cijena = 120,
                Kratki_opis = "Puževi pečeni s maslacom i češnjakom",
                RestoranID = 13,
                TipJelaID = 4

            });
            context.Jela.Add(new Jelo
            {
                ID = 38,
                Naziv_jelo = "Tarte Bourdaloue",
                Cijena = 100,
                Kratki_opis = "Pita od slatkog tijesta s nadjevom od badema i kruškom",
                RestoranID = 13,
                TipJelaID = 4

            });
            context.Jela.Add(new Jelo
            {
                ID = 39,
                Naziv_jelo = "Coq au vin (Pijetao u vinu) ",
                Cijena = 155,
                Kratki_opis = "Pijetao pečen u umaku od vina, s prilogom krumpir i povrćem",
                RestoranID = 13,
                TipJelaID = 4

            });
            context.Jela.Add(new Jelo
            {
                ID = 40,
                Naziv_jelo = "Kebab - mala porcija",
                Cijena = 14,
                Kratki_opis = "Kebab od miješanog mesa, porcija 250g",
                RestoranID = 14,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 41,
                Naziv_jelo = "Kebab - velika porcija",
                Cijena = 21,
                Kratki_opis = "Kebab od miješanog mesa, porcija 500g",
                RestoranID = 14,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 42,
                Naziv_jelo = "Hotdog",
                Cijena = 17,
                Kratki_opis = "Pileća hrenovka u tijestu s prilozima po izboru",
                RestoranID = 14,
                TipJelaID = 8

            });
            context.Jela.Add(new Jelo
            {
                ID = 43,
                Naziv_jelo = "Škampi s rižom u japanskom umaku",
                Cijena = 35,
                Kratki_opis = "Kuhani škampi u umaku od wasabi paste i algi, s aldente kuhanom rižom",
                RestoranID = 15,
                TipJelaID = 4

            });
            context.Jela.Add(new Jelo
            {
                ID = 44,
                Naziv_jelo = "Sushi",
                Cijena = 45,
                Kratki_opis = "Nori alge, sirova duga bijela rotkva, luk, mrkva, riža, wasabi pasta",
                RestoranID = 15,
                TipJelaID = 4

            });
            context.Jela.Add(new Jelo
            {
                ID = 45,
                Naziv_jelo = "Riža u woku",
                Cijena = 35,
                Kratki_opis = "Duga riža kuhana s lukom, celerom, paprikom, brokulom, rajčicom u woku",
                RestoranID = 15,
                TipJelaID = 4

            });
            context.Jela.Add(new Jelo
            {
                ID = 46,
                Naziv_jelo = "Škampi s prilogom",
                Cijena = 60,
                Kratki_opis = "Škampi pod pekom, prilog zapečeni krumpir i mrkva",
                RestoranID = 16,
                TipJelaID = 1

            });
            context.Jela.Add(new Jelo
            {
                ID = 47,
                Naziv_jelo = "Odrezak od tune",
                Cijena = 70,
                Kratki_opis = "Odrezak od tune zapečen na naglo, s prilogom sezonsko povrće",
                RestoranID = 16,
                TipJelaID = 1

            });
            context.Jela.Add(new Jelo
            {
                ID = 48,
                Naziv_jelo = "Hobotnica ispod peke",
                Cijena = 120,
                Kratki_opis = "Svježa hobotnica ispod peke, prilog domaće povrće",
                RestoranID = 16,
                TipJelaID = 1

            });
            context.Jela.Add(new Jelo
            {
                ID = 49,
                Naziv_jelo = "Ćevapi s lukom i ajvarom",
                Cijena = 35,
                Kratki_opis = "Velika porcija od 10 ćevapa s prilogom blagi ajvar i lukom",
                RestoranID = 17,
                TipJelaID = 8


            });
            context.Jela.Add(new Jelo
            {
                ID = 50,
                Naziv_jelo = "Domaća plata",
                Cijena = 67,
                Kratki_opis = "Plata složena od različitih domaćih mesnih narezaka i sirovog povrća (pršut, kulen, slanina, dimljena šunka; paprika, rajčica, rotkvice)",
                RestoranID = 17,
                TipJelaID = 7
                
            });
            context.Jela.Add(new Jelo
            {
                ID = 51,
                Naziv_jelo = "Šiš-ćevapi",
                Cijena = 37,
                Kratki_opis = "Velika porcija od 12 šiš-ćevapa, s prilogom zapečeno sezonsko povrće",
                RestoranID = 17,
                TipJelaID = 8
                
            });
            context.Jela.Add(new Jelo
            {
                ID = 52,
                Naziv_jelo = "Pizza s plodovima mora",
                Cijena = 26,
                Kratki_opis = "Sir, rajčica, komadi tune, inćuni",
                RestoranID = 1,
                TipJelaID = 6
                
            });
            context.Jela.Add(new Jelo
            {
                ID = 53,
                Naziv_jelo = "Kolač od limuna",
                Cijena = 20,
                Kratki_opis = "Porcija - komad kolača, biskvit od jaja s kremom od limuna i šlaga",
                RestoranID = 8,
                TipJelaID = 5
                
            });
            context.Jela.Add(new Jelo
            {
                ID = 54,
                Naziv_jelo = "Pizza s plodovima mora",
                Cijena = 45,
                Kratki_opis = "Sir, rajčica, komadi tune, kozice, inćuni",
                RestoranID = 10,
                TipJelaID = 6
               
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
                OvlastID = 2,
                RestID = 0
        
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
                OvlastID = 1,
                RestID = 0
            };
            _userManager.Create(administrator, administrator.Password);

            // voditelj
            var voditelj1 = new Korisnik
            {
                UserName = "voditelj1",
                Password = "voditelj1",
                ConfirmPassword = "voditelj1",
                Ime = "vod_Naziv1",
                Prezime = "vod_prezNaziv1",
                OvlastID = 3,
                RestID = 1
            };
            _userManager.Create(voditelj1, voditelj1.Password);
            var voditelj2 = new Korisnik
            {
                UserName = "voditelj2",
                Password = "voditelj2",
                ConfirmPassword = "voditelj2",
                Ime = "vod_Naziv2",
                Prezime = "vod_prezNaziv2",
                OvlastID = 3,
                RestID = 2
            };
            _userManager.Create(voditelj2, voditelj2.Password);
            var voditelj3 = new Korisnik
            {
                UserName = "voditelj3",
                Password = "voditelj3",
                ConfirmPassword = "voditelj3",
                Ime = "vod_Naziv3",
                Prezime = "vod_prezNaziv3",
                OvlastID = 3,
                RestID = 3
            };
            _userManager.Create(voditelj3, voditelj3.Password);
            var voditelj4 = new Korisnik
            {
                UserName = "voditelj4",
                Password = "voditelj4",
                ConfirmPassword = "voditelj4",
                Ime = "vod_Naziv4",
                Prezime = "vod_prezNaziv4",
                OvlastID = 3,
                RestID = 4
            };
            _userManager.Create(voditelj4, voditelj4.Password);
            var voditelj5 = new Korisnik
            {
                UserName = "voditelj5",
                Password = "voditelj5",
                ConfirmPassword = "voditelj5",
                Ime = "vod_Naziv5",
                Prezime = "vod_prezNaziv5",
                OvlastID = 3,
                RestID = 5
            };
            _userManager.Create(voditelj5, voditelj5.Password);
            var voditelj6 = new Korisnik
            {
                UserName = "voditelj6",
                Password = "voditelj6",
                ConfirmPassword = "voditelj6",
                Ime = "vod_Naziv6",
                Prezime = "vod_prezNaziv6",
                OvlastID = 3,
                RestID = 6
            };
            _userManager.Create(voditelj6, voditelj6.Password);
            var voditelj7 = new Korisnik
            {
                UserName = "voditelj7",
                Password = "voditelj7",
                ConfirmPassword = "voditelj7",
                Ime = "vod_Naziv7",
                Prezime = "vod_prezNaziv7",
                OvlastID = 3,
                RestID = 7
            };
            _userManager.Create(voditelj7, voditelj7.Password);
            var voditelj8 = new Korisnik
            {
                UserName = "voditelj8",
                Password = "voditelj8",
                ConfirmPassword = "voditelj8",
                Ime = "vod_Naziv8",
                Prezime = "vod_prezNaziv8",
                OvlastID = 3,
                RestID = 8
            };
            _userManager.Create(voditelj8, voditelj8.Password);
            var voditelj9 = new Korisnik
            {
                UserName = "voditelj9",
                Password = "voditelj9",
                ConfirmPassword = "voditelj9",
                Ime = "vod_Naziv9",
                Prezime = "vod_prezNaziv9",
                OvlastID = 3,
                RestID = 9
            };
            _userManager.Create(voditelj9, voditelj9.Password);
            var voditelj10 = new Korisnik
            {
                UserName = "voditelj10",
                Password = "voditelj10",
                ConfirmPassword = "voditelj10",
                Ime = "vod_Naziv10",
                Prezime = "vod_prezNaziv10",
                OvlastID = 3,
                RestID = 10
            };
            _userManager.Create(voditelj10, voditelj10.Password);
            var voditelj11 = new Korisnik
            {
                UserName = "voditelj11",
                Password = "voditelj11",
                ConfirmPassword = "voditelj11",
                Ime = "vod_Naziv11",
                Prezime = "vod_prezNaziv11",
                OvlastID = 3,
                RestID = 11
            };
            _userManager.Create(voditelj11, voditelj11.Password);
            var voditelj12 = new Korisnik
            {
                UserName = "voditelj12",
                Password = "voditelj12",
                ConfirmPassword = "voditelj12",
                Ime = "vod_Naziv12",
                Prezime = "vod_prezNaziv12",
                OvlastID = 3,
                RestID = 12
            };
            _userManager.Create(voditelj12, voditelj12.Password);
            var voditelj13 = new Korisnik
            {
                UserName = "voditelj13",
                Password = "voditelj13",
                ConfirmPassword = "voditelj13",
                Ime = "vod_Naziv13",
                Prezime = "vod_prezNaziv13",
                OvlastID = 3,
                RestID = 13
            };
            _userManager.Create(voditelj13, voditelj13.Password);
            var voditelj14 = new Korisnik
            {
                UserName = "voditelj14",
                Password = "voditelj14",
                ConfirmPassword = "voditelj14",
                Ime = "vod_Naziv14",
                Prezime = "vod_prezNaziv14",
                OvlastID = 3,
                RestID = 14
            };
            _userManager.Create(voditelj14, voditelj14.Password);
            var voditelj15 = new Korisnik
            {
                UserName = "voditelj15",
                Password = "voditelj15",
                ConfirmPassword = "voditelj15",
                Ime = "vod_Naziv15",
                Prezime = "vod_prezNaziv15",
                OvlastID = 3,
                RestID = 15
            };
            _userManager.Create(voditelj15, voditelj15.Password);
            var voditelj16 = new Korisnik
            {
                UserName = "voditelj16",
                Password = "voditelj16",
                ConfirmPassword = "voditelj16",
                Ime = "vod_Naziv16",
                Prezime = "vod_prezNaziv16",
                OvlastID = 3,
                RestID = 16
            };
            _userManager.Create(voditelj16, voditelj16.Password);
            var voditelj17 = new Korisnik
            {
                UserName = "voditelj17",
                Password = "voditelj17",
                ConfirmPassword = "voditelj17",
                Ime = "vod_Naziv17",
                Prezime = "vod_prezNaziv17",
                OvlastID = 3,
                RestID = 17
            };
            _userManager.Create(voditelj17, voditelj17.Password);

        }
    }
}