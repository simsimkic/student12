/***********************************************************************
 * Module:  Recept.cs
 * Purpose: Definition of the Class Model.Recept
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
   public class Recept
   {
      private int sifra;
      private Dictionary<String,int> lekovi;
      private DateTime datum;
      private String jmbgPacijenta;
      private String lekar;

        public Recept(Dictionary<string, int> lekovi)
        {
            this.Lekovi = lekovi;
        }

        [JsonConstructor]
        public Recept(int sifra, Dictionary<string, int> lekovi, DateTime datum, string jmbgPacijenta, string lekar)
        {
            this.Sifra = sifra;
            this.Lekovi = lekovi;
            this.Datum = datum;
            this.JmbgPacijenta = jmbgPacijenta;
            this.Lekar = lekar;
        }

        public int Sifra { get; set; }
        public Dictionary<string, int> Lekovi { get; set; }
        public DateTime Datum { get; set; }
        public string JmbgPacijenta { get; set; }
        public string Lekar { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Recept recept &&
                Sifra == recept.Sifra;
        }
    }
}