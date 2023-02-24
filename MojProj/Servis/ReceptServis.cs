/***********************************************************************
 * Module:  ReceptKontroler.cs
 * Purpose: Definition of the Class Kontrola.ReceptKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repo;
using System.Linq;

namespace Servis
{
   public class ReceptServis
   {

        public Repo.ReceptRepo _receptRepo = new ReceptRepo();


        public bool receptiPostoje()
        {
            bool postoji = _receptRepo.receptiPostoje();
            return postoji;
        }


        public List<Model.Recept> prikazRecepata(int nacinSortiranja)
      {
            List<Recept> recepti = _receptRepo.dobavljanjeSvega();
            List<Recept> receptiSorted = new List<Recept>();

            if (recepti is null)
                return null;
            else
            {
                if (nacinSortiranja == 0)
                {
                    receptiSorted = recepti.OrderBy(rec => rec.Sifra).ToList();
                    return receptiSorted;
                }
                else if (nacinSortiranja == 1)
                {
                    receptiSorted = recepti.OrderBy(rec => rec.Lekar).ToList();
                    return receptiSorted;
                }
                else
                {
                    receptiSorted = recepti.OrderBy(rec => rec.Datum).ToList();
                    return receptiSorted;
                }
            }
      }
      
      public Model.Recept kreiranjeRecepta(Model.Recept recept)
      {
            List<Recept> recepti = _receptRepo.dobavljanjeSvega();

            if (recepti is null)
            {
                Recept kreiraniRecept = _receptRepo.kreiranje(recept);

                return kreiraniRecept;
            }
            else
            {
                foreach (Recept receptLoop in recepti)
                {
                    if (recept.Equals(receptLoop))
                    {
                        return null;
                    }
                }
                Recept kreiraniRecept = _receptRepo.kreiranje(recept);

                return kreiraniRecept;
            }
        }
      
      public Model.Recept dobaviReceptPoSifri(int sifra)
      {
            Recept recept = _receptRepo.dobaviReceptPoSifri(sifra);
            return recept;
      }
      
      public List<Model.Recept> dobavireceptpoLekaru(String lekar)
      {
            List<Recept> recepti = _receptRepo.dobavireceptpoLekaru(lekar);
            return recepti;
      }
      
      public List<Model.Recept> dobaviReceptPoJmbg(String jmbg)
      {
            List<Recept> recepti = _receptRepo.dobaviReceptPoJmbg(jmbg);
            return recepti;
        }
      
      public List<Model.Recept> dobaviReceptPoLeku(String lek)
      {
            List<Recept> recepti = _receptRepo.dobaviReceptPoLeku(lek);
            return recepti;
        }
   
      
   
   }
}