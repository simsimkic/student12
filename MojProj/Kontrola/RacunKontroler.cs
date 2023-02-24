/***********************************************************************
 * Module:  RacunKontroler.cs
 * Purpose: Definition of the Class Kontrola.RacunKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using ClassDijagram.Exeption;
using Servis;

namespace Kontrola
{
   public class RacunKontroler
   {

        private RacunServis _racunServis = new RacunServis();
        private RacunExeption _racunExeption = new RacunExeption();




        public Model.Racun kreiranjeRacuna(Model.Racun racun)
      {
            Racun kreiraniracun = _racunServis.kreiranjeRacuna(racun);

            if (kreiraniracun is null)
            {
                _racunExeption.kreiranjeExeption();
                return null;
            }
            else
                return kreiraniracun;
      }
      
      public List<Model.Racun> prikazSvihracuna()
      {
            List<Racun> racuni = _racunServis.prikazSvihracuna();

            if (racuni is null)
            {
                _racunExeption.prikazExeption();
                return null;
            }
            else
                return racuni;
        }
      
      public List<Model.Racun> prikazSvihRacunaPoApotekaru(String sifraApotekara)
      {
            List<Racun> racuni = _racunServis.prikazSvihRacunaPoApotekaru(sifraApotekara);

            if (racuni is null)
            {
                _racunExeption.prikazPoApotekaruExeption();
                return null;
            }
            else
                return racuni;
        }
   
      
   
   }
}