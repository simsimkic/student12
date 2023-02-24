/***********************************************************************
 * Module:  KorisnikKontroler.cs
 * Purpose: Definition of the Class Kontrola.KorisnikKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Repo;
using Model;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace Servis
{

    
   public class KorisnikServis
   {


        private KorisnikRepo _korisnikRepo = new KorisnikRepo();

        public Model.Korisnik prijavljivanje(String username, String pass)
        {
            Korisnik korisnik = _korisnikRepo.dobijanjeKorisnikaPoLozinkiIImenu(username, pass);            
                return korisnik;

        }

        public List<Model.Korisnik> prikaziSveKorisnike(int nacinSortiranja)
        {
            List<Korisnik> korisnici = _korisnikRepo.dobavljanjeSvega();
            List<Korisnik> korisniciSorted = new List<Korisnik>();

            if(korisnici is null)
                return null;
            else
            {
                if(nacinSortiranja==0)
                {
                    korisniciSorted= korisnici.OrderBy(kor => kor.Ime).ToList();
                    return korisniciSorted;
                }
                else if (nacinSortiranja == 1)
                {
                    korisniciSorted = korisnici.OrderBy(kor => kor.Prezime).ToList();
                    return korisniciSorted;
                }
                else
                {
                    korisniciSorted = korisnici.OrderBy(kor => kor.TipKorisnika).ToList();
                    return korisniciSorted;
                }

                
            }
        }

        ////////////////////// IZVESTAJ TREBA ODRADITI   ///////////////////////////////////////
        public void kreiranjeIzvestaja(int tipIzvestaja)
        {
            string putanjaFile = @"..\..\Racun.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                string json = ucitano.ReadToEnd();
                ucitano.Close();

                int validacijaPostojanjaRacuna = 0;

                List<Racun> racuni = JsonConvert.DeserializeObject<List<Racun>>(json);
            }
            else
                Console.WriteLine("Do sada ne postoji ni jedna prodaja te nije moguce napraviti izvestaj!!!");
            
        }

        public Model.Korisnik registracijaKorisnika(Model.Korisnik korisnik)
        {



            List<Korisnik> korisnici = _korisnikRepo.dobavljanjeSvega();

            if(korisnici is null)
            {
                Korisnik kreiraniKorisnik = _korisnikRepo.kreiranje(korisnik);

                return kreiraniKorisnik;
            }
            else
            {
                foreach (Korisnik korisnikLoop in korisnici)
                {
                    if (korisnik.Equals(korisnikLoop))
                    {
                        return null;
                    }
                }
                Korisnik kreiraniKorisnik = _korisnikRepo.kreiranje(korisnik);

                return kreiraniKorisnik;
            }
            

        }

   
            public Boolean ValidacijaJmbg(String jmbg)
            {
                foreach(char c in jmbg)
                {
                    if (!char.IsDigit(c))
                        return false;
            }
                if (jmbg.Length != 13)
                    return false;
                else
                    return true;
            }


        }
}