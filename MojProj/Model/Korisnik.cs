/***********************************************************************
 * Module:  Korisnik.cs
 * Purpose: Definition of the Class Model.Korisnik
 ***********************************************************************/

using System;
using Newtonsoft.Json;

namespace Model
{
   public class Korisnik
   {

        private String ime;
        private String prezime;
        private String username;
        private String pass;
        private TIPkorisnika tipKorisnika;






        public Korisnik()
        {

        }

        [JsonConstructor]
        public Korisnik (string username, string pass, string prezime, string ime, TIPkorisnika tipKorisnika)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Pass = pass;
            this.TipKorisnika = tipKorisnika;
        }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Username { get; set; }

        public string Pass { get; set; }

        public TIPkorisnika TipKorisnika { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Korisnik korisnik &&
                Username == korisnik.Username;
        }


    }
}