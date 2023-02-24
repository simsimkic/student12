using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDijagram.Exeption
{
    public class ReceptEception
    {
        public void prikazRECEPTASortiranjeExeption()
        {
            Console.WriteLine("Uneli ste pogresan broj za nacin sortiranja");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void prikazExeption()
        {
            Console.WriteLine("Ne posoji ni jedan recept!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void kreiranjeExeption()
        {
            Console.WriteLine("Recept sa unetom sifrom vec postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void sifraExeption()
        {
            Console.WriteLine("Recept sa trazenom sifrom ne posoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void lekarExeption()
        {
            Console.WriteLine("Recept izdat od strane zeljenog lekara ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void jmbgExeption()
        {
            Console.WriteLine("Recept sa trazenim jmbgom pacijenta ne postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void lekExeption()
        {
            Console.WriteLine("Ni jedan recept ne sadrzi trazeni lek!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
