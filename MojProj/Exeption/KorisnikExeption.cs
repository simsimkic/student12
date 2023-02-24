using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDijagram.Exeption
{
    public class KorisnikExeption
    {

        public void prijavljivanjeExeption()
        {
            Console.WriteLine("Uneli ste pogresan username ili sifru!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void prikazKorisnikaExeption()
        {
            Console.WriteLine("Ne postoji ni jedan korisnik te ih nije moguce prikazati!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void registracijaKorisnikaExeption()
        {
            Console.WriteLine("Korisnik sa ovim usernamom vec postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void prikazKorisnikaSortiranjeExeption()
        {
            Console.WriteLine("Uneli ste pogresan broj za tip sortiranja!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void jmbgExeption()
        {
            Console.WriteLine("JMBG NIJE VALIDAN!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }



    }
}
