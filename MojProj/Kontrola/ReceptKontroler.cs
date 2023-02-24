/***********************************************************************
 * Module:  ReceptKontroler.cs
 * Purpose: Definition of the Class Kontrola.ReceptKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Servis;
using ClassDijagram.Exeption;

namespace Kontrola
{
   public class ReceptKontroler
   {

        public ReceptServis _receptServis = new ReceptServis();
        public ReceptEception _receptExeption = new ReceptEception();
        public LekKontroler _lekKontroler = new LekKontroler();



        public bool receptiPostoje()
        {
            bool postoji = _receptServis.receptiPostoje();
            return postoji;
        }



        public List<Model.Recept> prikazRecepata(int nacinSortiranja)
      {
            if (nacinSortiranja > 3 || nacinSortiranja < 0)
            {
                _receptExeption.prikazRECEPTASortiranjeExeption();
                return null;
            }
            else
            {
                List<Recept> recepti = _receptServis.prikazRecepata(nacinSortiranja);

                if (recepti is null)
                {
                    _receptExeption.prikazExeption();
                    return null;

                }
                else
                    return recepti;

            }
                
         
      }
      
      public Model.Recept kreiranjeRecepta(Model.Recept recept)
      {
            Recept kreiraniRecept = _receptServis.kreiranjeRecepta(recept);
                     
            if (kreiraniRecept is null)
            {
                _receptExeption.kreiranjeExeption();
                return null;

            }
            else
                return kreiraniRecept;
        }
      
      public Model.Recept dobaviReceptPoSifri(int sifra)
      {
            Recept recept = _receptServis.dobaviReceptPoSifri(sifra);

            if (recept is null)
            {
                _receptExeption.sifraExeption();
                return null;
            }
            else
                return recept;
        }
      
      public List<Model.Recept> dobavireceptpoLekaru(String lekar)
      {
            List<Recept> recepti = _receptServis.dobavireceptpoLekaru(lekar);

            if (recepti is null)
            {
                _receptExeption.lekarExeption();
                return null;
            }
            else
                return recepti;
        }
      
      public List<Model.Recept> dobaviReceptPoJmbg(String jmbg)
      {
            List<Recept> recepti = _receptServis.dobaviReceptPoJmbg(jmbg);

            if (recepti is null)
            {
                _receptExeption.jmbgExeption();
                return null;
            }
            else
                return recepti;
        }
      
      public List<Model.Recept> dobaviReceptPoLeku(String lek)
      {
            List<Recept> recepti = _receptServis.dobaviReceptPoLeku(lek);

            if (recepti is null)
            {
                _receptExeption.lekExeption();
                return null;
            }
            else
                return recepti;
        }
   
      
   
   }
}