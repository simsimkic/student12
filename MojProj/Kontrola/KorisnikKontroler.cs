/***********************************************************************
 * Module:  KorisnikKontroler.cs
 * Purpose: Definition of the Class Kontrola.KorisnikKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Servis;
using ClassDijagram.Exeption;

namespace Kontrola
{
   public class KorisnikKontroler
   {


        public KorisnikServis _korisnikServis = new KorisnikServis();
        public KorisnikExeption _korisnikExeption = new KorisnikExeption();


        public Model.Korisnik prijavljivanje(String username, String pass)
        {

            Korisnik korisnik = _korisnikServis.prijavljivanje(username, pass);

            if (korisnik is null)
            {
                _korisnikExeption.prijavljivanjeExeption();
                return null;
            }
            else
                return korisnik;




        }

        public List<Model.Korisnik> prikaziSveKorisnike(int nacinSortiranja)
        {
            if(nacinSortiranja >3 || nacinSortiranja<0)
            {
                _korisnikExeption.prikazKorisnikaSortiranjeExeption();
                return null;
            }
            else
            {
                List<Korisnik> korisnici = _korisnikServis.prikaziSveKorisnike(nacinSortiranja);

                if (korisnici is null)
                {
                    _korisnikExeption.prikazKorisnikaExeption();
                    return null;
                }
                else
                {
                    return korisnici;
                }

            }
            
                
            
        }


        
        public void kreiranjeIzvestaja(int tipIzvestaja)
        {
            // TODO: implement
        }

        public Model.Korisnik registracijaKorisnika(Model.Korisnik korisnik)
        {
            Korisnik Regkorisnik = _korisnikServis.registracijaKorisnika(korisnik);

            if (Regkorisnik is null)
            {
                _korisnikExeption.registracijaKorisnikaExeption();
                return null;
            }
            else
                return Regkorisnik;
            
        }

        public Boolean ValidacijaJmbg(String jmbg)
        {
            bool proveraJmbg = _korisnikServis.ValidacijaJmbg(jmbg);
            if (proveraJmbg == true)
                return true;
            else
            {
                _korisnikExeption.jmbgExeption();
                return false;
            }

        }






    }
}