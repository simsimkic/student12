using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDijagram.Exeption
{
    public class LekExeption
    {


        public void prikazLekovaExeption()
        {
            Console.WriteLine("Ni jedan lek ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void lekPoSifriExeption()
        {
            Console.WriteLine("Lek sa zadatom sifrom ne postoji ili ni jedan lek ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void dodavanjeLekaExeption()
        {
            Console.WriteLine("Lek sa ovom sifrom vec postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void izmenaLekaExeption()
        {
            Console.WriteLine("Lek koji zelite da izmenite ne postoji ili ni jedan lek ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void brisanjeExeption()
        {
            Console.WriteLine("Lek koji zelite da obrisete je vec obrisan ili lek sa unetom sifrom ne postoji u sistemu!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void lekPoImenuExeption()
        {
            Console.WriteLine("Lek sa trazenim imenom ne postoji ili ni jedan lek ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void lekPoProizvodjacuExeption()
        {
            Console.WriteLine("Ne postoji ni jedan lek od trazenog proizvodjaca ili ni jedan lek ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void lekPoCeniExeption()
        {
            Console.WriteLine("Lek u datom opsegu cene ne posoji ili ni jedan lek ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void prikazLekovaSortiranjeExeption()
        {
            Console.WriteLine("Uneli ste pogresan broj za tip sortiranja!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void dodajUKorpuLekObrisan()
        {
            Console.WriteLine("Lek koji zelite da ubacite na recept je obrisan!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void dodajUKorpuLekMoraNaRecept()
        {
            Console.WriteLine("Lek koji zelite da ubacite na recept ne moze se kupiti bez recepta!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void prikazKorpeExeption()
        {
            Console.WriteLine("Korpa je prazna!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }


    }
}
