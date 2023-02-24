using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDijagram.Exeption
{
    public class RacunExeption
    {


        public void kreiranjeExeption()
        {
            Console.WriteLine("Racun sa unetom sifrom vec postoji!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void prikazExeption()
        {
            Console.WriteLine("Ne posoji ni jedan racun!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void prikazPoApotekaruExeption()
        {
            Console.WriteLine("Izabrani apotekar nije izdao ni jedan racun!!!");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        
    }
}
