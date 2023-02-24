/***********************************************************************
 * Module:  Racun.cs
 * Purpose: Definition of the Class Model.Racun
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
   public class Racun
   {
      private int sifra;
      private String apotekar;
      private DateTime datum;
      private Dictionary<String, int> lekovi;
      private float ukupnoCena;

        public Racun()
        {

        }

        [JsonConstructor]
        public Racun(int sifra, string apotekar, DateTime datum, Dictionary<String, int> lekovi, float ukupnoCena)
        {
            this.Sifra = sifra;
            this.Apotekar = apotekar;
            this.Datum = datum;
            this.Lekovi = lekovi;
            this.UkupnoCena = ukupnoCena;
        }

        public int Sifra { get; set; }
        public string Apotekar { get; set; }
        public DateTime Datum { get; set; }
        public Dictionary<string, int> Lekovi { get; set; }
        public float UkupnoCena { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Racun racun &&
                Sifra == racun.Sifra;
        }
    }
}