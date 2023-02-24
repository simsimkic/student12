/***********************************************************************
 * Module:  LekKontroler.cs
 * Purpose: Definition of the Class Kontrola.LekKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repo;
using System.Linq;
using ConsoleTables;

namespace Servis
{
   public class LekServis
   {

        public LekRepo _lekRepo = new LekRepo();
        public RacunServis _racunServis = new RacunServis();

        public List<Model.Lek> prikazSvihLekova(int nacinSortiranja)
        {
            List<Lek> lekovi = _lekRepo.dobavljanjeSvega();
            List<Lek> lekoviSorted = new List<Lek>();

            if(lekovi is null)
                return null;
            else
            {
                if (nacinSortiranja == 0)
                {
                    lekoviSorted = lekovi.OrderBy(lek => lek.Ime).ToList();
                    return lekoviSorted;
                }
                else if (nacinSortiranja == 1)
                {
                    lekoviSorted = lekovi.OrderBy(lek => lek.Proizvodjac).ToList();
                    return lekoviSorted;
                }
                else
                {
                    lekoviSorted = lekovi.OrderBy(lek => lek.Cena).ToList();
                    return lekoviSorted;
                }
            }
        }

        public Model.Lek dobaviLekPoSifri(String sifra)
        {
            Lek lek = _lekRepo.dobaviLekPoSifri(sifra);
            return lek;
        }

        public Model.Lek dodavanjeLeka(Model.Lek lek)
        {
            List<Lek> lekovi = _lekRepo.dobavljanjeSvega();

            if (lekovi is null)
            {
                Lek kreiraniLek = _lekRepo.kreiranjeLek(lek);

                return kreiraniLek;
            }
            else
            {
                foreach (Lek lekLoop in lekovi)
                {
                    if (lek.Equals(lekLoop))
                    {
                        return null;
                    }
                }
                Lek kreiraniLek = _lekRepo.kreiranjeLek(lek);

                return kreiraniLek;
            }
        }

        public Model.Lek izmenaLeka(Model.Lek lek)
        {
            Lek lekk = _lekRepo.izmenaLek(lek);
            return lekk;
        }

        public bool brisanjeLeka(String sifraLeka)
        {
            bool provera=_lekRepo.brisanjeLek(sifraLeka);
            return provera;
        }
        
        
        public Boolean dodajLekUKorpu(Dictionary<string,int> korpa,int kolicina,Lek lek)
        {
            if (lek.Obrisan == true)
                return false;
            else if (lek.Recept == true)
                return false;
            else
            {
                if(korpa.ContainsKey(lek.Ime))
                {
                    korpa[lek.Ime] += kolicina;
                    return true;
                }
                else
                {
                    korpa[lek.Ime] = kolicina;
                    return true;
                }
                
            }
                
            
        }
        
        public void dodajLekSaRecepta(Dictionary<string, int> korpa,Recept recept)
        {
            foreach(KeyValuePair<string, int> pair in recept.Lekovi)
            {
                if(korpa.ContainsKey(pair.Key))
                {
                    korpa[pair.Key] += pair.Value;
                    
                }
                else
                {
                    korpa.Add(pair.Key, pair.Value);
                    
                }
                
            }
            
            
        }
      
        public bool prikazKorpe(Dictionary<string, int> korpa)
        {
            int provera = korpa.Count;
            if (provera == 0)
                return false;
            else
            {
                var table = new ConsoleTable("IME LEKA", "KOLICINA LEKA");
                for (int i = 0; i < korpa.Count; i++)
                {
                    table.AddRow(korpa.Keys.ElementAt(i), korpa[korpa.Keys.ElementAt(i)]);
                }
                table.Write();
                Console.WriteLine();

                float ukupnaCena = 0;
                foreach (KeyValuePair<string, int> pair in korpa)
                {
                    List<Lek> lekovi = _lekRepo.dobaviLekPoImenu(pair.Key);
                    foreach(Lek lek in lekovi)
                    {
                        ukupnaCena += lek.Cena * pair.Value;
                    }
                }

                Console.Write("UKUPNA CENA SVIH ARTIKALA JE:     ");
                Console.WriteLine(ukupnaCena);
                return true;



            }
        }
    
        public void potvrdiProdaju(Dictionary<string, int> korpa,string apotekar)
        {
            List<Racun> racuni = _racunServis.prikazSvihracuna();
            Racun racun = new Racun();
            if (racuni is null)
                racun.Sifra = 1;
            else
                racun.Sifra = racuni.Last().Sifra + 1;
            
            racun.Apotekar = apotekar;
            racun.Datum = DateTime.Now;
            racun.Lekovi = korpa;
            

            float ukupnaCena = 0;
            foreach (KeyValuePair<string, int> pair in korpa)
            {
                List<Lek> lekovi = _lekRepo.dobaviLekPoImenu(pair.Key);
                foreach (Lek lek in lekovi)
                {
                    ukupnaCena += lek.Cena * pair.Value;
                }
            }
            racun.UkupnoCena = ukupnaCena;
            Racun provera= _racunServis.kreiranjeRacuna(racun);
            
        }

        public List<Model.Lek> dobaviLekPoImenu(String imeLeka)
        {
            List<Lek> lekovi = _lekRepo.dobaviLekPoImenu(imeLeka);
            return lekovi;
        }

        public List<Model.Lek> dobaviLekPoImenuZaIzvestaj(String imeLeka)
        {
            List<Lek> lekovi = _lekRepo.dobaviLekPoImenuZaIzvestaj(imeLeka);
            return lekovi;
        }

        public List<Model.Lek> dobaviLekPoProizvodjacu(String proizvodjac)
        {
            List<Lek> lekovi = _lekRepo.dobaviLekPoProizvodjacu(proizvodjac);
            return lekovi;
        }

        public List<Model.Lek> dobaviLekPoCeni(float minCena, float maxCena)
        {
            List<Lek> lekovi = _lekRepo.dobaviLekPoCeni(minCena, maxCena);
            return lekovi;
        }








    }
}