/***********************************************************************
 * Module:  Lek.cs
 * Purpose: Definition of the Class Model.Lek
 ***********************************************************************/

using System;
using Newtonsoft.Json;

namespace Model
{
   public class Lek
   {

        private String ime;
        private String proizvodjac;
        private String sifra;
        private float cena;
        private Boolean recept;
        private Boolean obrisan = false;




        public Lek()
        {

        }

        [JsonConstructor]
        public Lek(bool obrisan, float cena, bool recept, string proizvodjac, string sifra, string ime)
        {
            this.Ime = ime;
            this.Proizvodjac = proizvodjac;
            this.Sifra = sifra;
            this.Cena = cena;
            this.Recept = recept;
            this.Obrisan = obrisan;

        }


        public string Ime { get; set; }
        public string Proizvodjac { get; set; }
        public string Sifra { get; set; }
        public float Cena { get; set; }
        public bool Recept { get; set; }
        public bool Obrisan { get; set; }
        
        
        
        


        public override bool Equals(object obj)
        {
            return obj is Lek lek &&
                Sifra==lek.Sifra;
        }
    }
}