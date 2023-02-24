/***********************************************************************
 * Module:  ReceptKontroler.cs
 * Purpose: Definition of the Class Kontrola.ReceptKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Newtonsoft.Json;




namespace Repo
{
   public class ReceptRepo
   {

        public bool receptiPostoje()
        {
            string putanjaFile = @"..\..\Recept.txt";

            if (File.Exists(putanjaFile))
                return true;
            else
                return false;
        }
      public Model.Recept dobaviReceptPoSifri(int sifra)
      {
            string putanjaFile = @"..\..\Recept.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            List<Recept> recepti = JsonConvert.DeserializeObject<List<Recept>>(json);


            foreach (Recept recept in recepti)
            {
                if (recept.Sifra == sifra)
                {

                    return recept;


                }
            }
            return null;
        }
      
      public List<Model.Recept> dobavireceptpoLekaru(String lekar)
      {
            string putanjaFile = @"..\..\Recept.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            int validacijaPostojanjaRecepta = 0;

            List<Recept> recepti = JsonConvert.DeserializeObject<List<Recept>>(json);

            List<Recept> receptiOdApotekara = new List<Recept>();
            string imeReceptaLower;

            foreach (Recept recept in recepti)
            {
                imeReceptaLower = recept.Lekar.ToLower();
                if (imeReceptaLower.Contains(lekar.ToLower()))
                {
                    validacijaPostojanjaRecepta = 1;
                    receptiOdApotekara.Add(recept);


                }
            }
            if (validacijaPostojanjaRecepta == 0)
                return null;
            else
                return receptiOdApotekara;
        }
      
      public List<Model.Recept> dobaviReceptPoJmbg(String jmbg)
      {
            string putanjaFile = @"..\..\Recept.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            int validacijaPostojanjaRecepta = 0;

            List<Recept> recepti = JsonConvert.DeserializeObject<List<Recept>>(json);

            List<Recept> receptiSaJmbg = new List<Recept>();
            

            foreach (Recept recept in recepti)
            {
                
                if (jmbg==recept.JmbgPacijenta)
                {
                    validacijaPostojanjaRecepta = 1;
                    receptiSaJmbg.Add(recept);


                }
            }
            if (validacijaPostojanjaRecepta == 0)
                return null;
            else
                return receptiSaJmbg;
        }
      
      public List<Model.Recept> dobaviReceptPoLeku(String lek)
      {
            string putanjaFile = @"..\..\Recept.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            int validacijaPostojanjaRecepta = 0;
            

            List<Recept> recepti = JsonConvert.DeserializeObject<List<Recept>>(json);

            List<Recept> receptiSaLekom = new List<Recept>();
            string imeLekaLower;

            foreach (Recept recept in recepti)
            {
                foreach (String kljuc in recept.Lekovi.Keys)
                {
                    imeLekaLower = kljuc.ToLower();
                    if(imeLekaLower.Contains(lek.ToLower()))
                    {
                        validacijaPostojanjaRecepta = 1;
                        
                        receptiSaLekom.Add(recept);

                    }
                }                                                   
            }
            if (validacijaPostojanjaRecepta == 0)
                return null;
            else
                return receptiSaLekom;
        }
      
      public Model.Recept izmena(Model.Recept recept)
      {
            string putanjaFile = @"..\..\Recept.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            List<Recept> recepti = JsonConvert.DeserializeObject<List<Recept>>(json);

            int validacijaPostojanRecepta = 0;

            for (int brojac = 0; brojac < recepti.Count; brojac++)
            {
                if (recept.Equals(recepti[brojac]))
                {
                    recepti.Remove(recepti[brojac]);
                    recepti.Insert(brojac, recept);

                    validacijaPostojanRecepta = 1;
                }
            }


            json = JsonConvert.SerializeObject(recepti);
            File.Create(putanjaFile).Close();

            TextWriter upisano = new StreamWriter(putanjaFile);
            upisano.Write(json);
            upisano.Close();


            if (validacijaPostojanRecepta == 0)
                return null;
            else
                return recept;
        }
      
      public Model.Recept kreiranje(Model.Recept recept)
      {
            string putanjaFile = @"..\..\Recept.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                String json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Recept> recepti = JsonConvert.DeserializeObject<List<Recept>>(json);
                recepti.Add(recept);

                json = JsonConvert.SerializeObject(recepti);
                File.Create(putanjaFile).Close();

                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();

            }
            else
            {
                List<Recept> recepti = new List<Recept>();
                recepti.Add(recept);

                File.Create(putanjaFile).Close();

                string json = JsonConvert.SerializeObject(recepti);
                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();


            }

            return recept;
        }
      
      public List<Model.Recept> dobavljanjeSvega()
      {
            string putanjaFile = @"..\..\Recept.txt";


            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                string json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Recept> recepti = JsonConvert.DeserializeObject<List<Recept>>(json);

                return recepti;

            }
            else
                return null;
            
        }
   
   }
}