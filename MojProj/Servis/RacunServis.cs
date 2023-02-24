/***********************************************************************
 * Module:  RacunKontroler.cs
 * Purpose: Definition of the Class Kontrola.RacunKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Repo;
using Model;

namespace Servis
{
    public class RacunServis
   {

        private RacunRepo _racunRepo = new RacunRepo();


        public Model.Racun kreiranjeRacuna(Model.Racun racun)
        {


            List<Racun> racuni = _racunRepo.dobavljanjeSvega();

            if (racuni is null)
            {
                Racun kreiraniRacun = _racunRepo.kreiranje(racun);

                return kreiraniRacun;
            }
            else
            {
                foreach (Racun racunLoop in racuni)
                {
                    if (racun.Equals(racunLoop))
                    {
                        return null;
                    }
                }
                Racun kreiraniRacun = _racunRepo.kreiranje(racun);

                return kreiraniRacun;
            }

        }

        public List<Model.Racun> prikazSvihracuna()
        {
            List<Racun> racuni = _racunRepo.dobavljanjeSvega();
            return racuni;
        }

        public List<Model.Racun> prikazSvihRacunaPoApotekaru(String sifraApotekara)
        {
            List<Racun> racuni = _racunRepo.dobavljanjeRacunPoApotekaru(sifraApotekara);
            return racuni;
        }






    }
}