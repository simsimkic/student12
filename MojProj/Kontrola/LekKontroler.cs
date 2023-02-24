/***********************************************************************
 * Module:  LekKontroler.cs
 * Purpose: Definition of the Class Kontrola.LekKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Servis;
using ClassDijagram.Exeption;

namespace Kontrola
{
   public class LekKontroler
   {

        private LekServis _lekServis = new LekServis();
        private LekExeption _lekExeption = new LekExeption();

        public List<Model.Lek> prikazSvihLekova(int nacinSortiranja)
        {

            if (nacinSortiranja > 3 || nacinSortiranja < 0)
            {
                _lekExeption.prikazLekovaSortiranjeExeption();
                return null;
            }
            else
            {
                List<Lek> lekovi = _lekServis.prikazSvihLekova(nacinSortiranja);

                if (lekovi is null)
                {
                    _lekExeption.prikazLekovaExeption();
                    return null;
                }
                else
                    return lekovi;

            }
            


        }

        public Model.Lek dobaviLekPoSifri(String sifra)
        {
            Lek lek = _lekServis.dobaviLekPoSifri(sifra);

            if (lek is null)
            {
                _lekExeption.lekPoSifriExeption();
                return null;
            }
            else
                return lek;
            
        }

        public Model.Lek dodavanjeLeka(Model.Lek lek)
        {
            Lek dodatiLek = _lekServis.dodavanjeLeka(lek);

            if (dodatiLek is null)
            {
                _lekExeption.dodavanjeLekaExeption();
                return null;
            }
            else
                return dodatiLek;
        }

        public Model.Lek izmenaLeka(Model.Lek lek)
        {
            Lek izmenjenLek = _lekServis.izmenaLeka(lek);

            if (izmenjenLek is null)
            {
                _lekExeption.izmenaLekaExeption();
                return null;

            }
            else
                return izmenjenLek;
            
        }

        public bool brisanjeLeka(String sifraLeka)
        {
            bool provera = _lekServis.brisanjeLeka(sifraLeka);

            if (provera == false)
            {
                _lekExeption.brisanjeExeption();
                return false;
            }
            else
                return true;
        }


       
        

        public Boolean dodajLekUKorpu(Dictionary<string, int> korpa, int kolicina, Lek lek)
        {
            bool provera = _lekServis.dodajLekUKorpu(korpa, kolicina, lek);

            if (provera == false)
            {
                if (lek.Obrisan == true)
                {
                    _lekExeption.dodajUKorpuLekObrisan();
                    return false;
                }
                else
                {
                    _lekExeption.dodajUKorpuLekMoraNaRecept();
                    return false;
                }
            }
            else
                return true;


            
        }

        public void dodajLekSaRecepta(Dictionary<string, int> korpa, Recept recept)
        {
            _lekServis.dodajLekSaRecepta(korpa,recept);
            
        }

        public bool prikazKorpe(Dictionary<string, int> korpa)
        {
            bool provera = _lekServis.prikazKorpe(korpa);
            if (provera == false)
            {
                _lekExeption.prikazKorpeExeption();
                return false;
            }
            else
                return true;

        }

        public void potvrdiProdaju(Dictionary<string, int> korpa, string apotekar)
        {
            _lekServis.potvrdiProdaju(korpa, apotekar);
            
        }
       



        public List<Model.Lek> dobaviLekPoImenu(String imeLeka)
        {
            List<Lek> lekovi = _lekServis.dobaviLekPoImenu(imeLeka);

            if (lekovi is null)
            {
                _lekExeption.lekPoImenuExeption();
                return null;
            }
            else return lekovi;
            
        }

        public List<Model.Lek> dobaviLekPoImenuZaIzvestaj(String imeLeka)
        {
            List<Lek> lekovi = _lekServis.dobaviLekPoImenuZaIzvestaj(imeLeka);

            if (lekovi is null)
            {
                _lekExeption.lekPoImenuExeption();
                return null;
            }
            else return lekovi;
        }

        public List<Model.Lek> dobaviLekPoProizvodjacu(String proizvodjac)
        {
            List<Lek> lekovi = _lekServis.dobaviLekPoProizvodjacu(proizvodjac);

            if (lekovi is null)
            {
                _lekExeption.lekPoProizvodjacuExeption();
                return null;
            }
            else return lekovi;
        }

        public List<Model.Lek> dobaviLekPoCeni(float minCena, float maxCena)
        {
            List<Lek> lekovi = _lekServis.dobaviLekPoCeni(minCena,maxCena);

            if (lekovi is null)
            {
                _lekExeption.lekPoCeniExeption();
                return null;
            }
            else return lekovi;
        }






    }
}