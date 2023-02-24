/***********************************************************************
 * Module:  RacunKontroler.cs
 * Purpose: Definition of the Class Kontrola.RacunKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Newtonsoft.Json;

namespace Repo
{
   public class RacunRepo
   {
      public List<Model.Racun> dobavljanjeRacunPoApotekaru(String apotekar)
      {
            string putanjaFile = @"..\..\Racun.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            int validacijaPostojanjaRacuna = 0;
            string apotekarLower;

            List<Racun> racuni = JsonConvert.DeserializeObject<List<Racun>>(json);
            List<Racun> racuniOdApotekara = new List<Racun>();
            

            foreach (Racun racun in racuni)
            {
                apotekarLower = racun.Apotekar.ToLower();
                if (apotekarLower == apotekar.ToLower())
                {
                    validacijaPostojanjaRacuna = 1;
                    racuniOdApotekara.Add(racun);


                }
            }
            if (validacijaPostojanjaRacuna == 0)
                return null;
            else
                return racuniOdApotekara;
        }
      
      public  Model.Racun kreiranje(Model.Racun racun)
      {
            string putanjaFile = @"..\..\Racun.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                String json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Racun> racuni = JsonConvert.DeserializeObject<List<Racun>>(json);
                racuni.Add(racun);

                json = JsonConvert.SerializeObject(racuni);
                File.Create(putanjaFile).Close();

                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();

            }
            else
            {
                List<Racun> racuni = new List<Racun>();
                racuni.Add(racun);

                File.Create(putanjaFile).Close();

                string json = JsonConvert.SerializeObject(racuni);
                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();


            }

            return racun;
        }
      
      public  Model.Racun izmena(Model.Racun racun)
      {
            string putanjaFile = @"..\..\Racun.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            List<Racun> racuni = JsonConvert.DeserializeObject<List<Racun>>(json);

            int validacijaPostojanjaLekaZaIzmenu = 0;

            for (int brojac = 0; brojac < racuni.Count; brojac++)
            {
                if (racun.Equals(racuni[brojac]))
                {
                    racuni.Remove(racuni[brojac]);
                    racuni.Insert(brojac, racun);

                    validacijaPostojanjaLekaZaIzmenu = 1;
                }
            }


            json = JsonConvert.SerializeObject(racuni);
            File.Create(putanjaFile).Close();

            TextWriter upisano = new StreamWriter(putanjaFile);
            upisano.Write(json);
            upisano.Close();


            if (validacijaPostojanjaLekaZaIzmenu == 0)
                return null;
            else
                return racun;
        }
      
      public  List<Model.Racun> dobavljanjeSvega()
      {
            string putanjaFile = @"..\..\Racun.txt";


            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                string json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Racun> racuni = JsonConvert.DeserializeObject<List<Racun>>(json);

                return racuni;
            }
            else
                return null;
            
        }
   
   }
}