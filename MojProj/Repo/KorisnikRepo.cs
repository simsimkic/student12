/***********************************************************************
 * Module:  KorisnikKontroler.cs
 * Purpose: Definition of the Class Kontrola.KorisnikKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Newtonsoft.Json;


namespace Repo
{
   public class KorisnikRepo
   {
      public  Model.Korisnik dobijanjeKorisnikaPoLozinkiIImenu(String username, String pass)
      {
            string putanjaFile = @"..\..\Korisnik.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            List<Korisnik> korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json);

            int index = 0;
            

            for (int brojac=0;brojac<korisnici.Count;brojac++)
            {
                if(korisnici[brojac].Pass==pass && korisnici[brojac].Username==username)
                {
                    index = brojac;
                    return korisnici[index];
                }
            }


            return null;
            

         
      }
      
      public  Model.Korisnik izmena(Model.Korisnik korisnik)
      {
            string putanjaFile = @"..\..\Korisnik.txt";

            TextReader ucitano = new StreamReader(putanjaFile);
            string json = ucitano.ReadToEnd();
            ucitano.Close();

            List<Korisnik> korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json);
            int validacijaPostojanjaKorisnika = 0;
            for (int brojac = 0; brojac < korisnici.Count; brojac++)
            {
                if(korisnik.Equals(korisnici[brojac]))
                {
                    korisnici.Remove(korisnici[brojac]);
                    korisnici.Insert(brojac, korisnik);
                    validacijaPostojanjaKorisnika = 1;
                }
            }


            json = JsonConvert.SerializeObject(korisnici);
            File.Create(putanjaFile).Close();

            TextWriter upisano = new StreamWriter(putanjaFile);
            upisano.Write(json);
            upisano.Close();

            if (validacijaPostojanjaKorisnika == 0)
            {
                return null;
            }
            else
            {
                return korisnik;
            }

            
      }
      
      public  List<Model.Korisnik> dobavljanjeSvega()
      {



            string putanjaFile = @"..\..\Korisnik.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                string json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Korisnik> korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json);

                return korisnici;
            }
            else
                return null;

            

            
      }
      
      public  Model.Korisnik kreiranje(Model.Korisnik korisnik)
      {
            string putanjaFile = @"..\..\Korisnik.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                String json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Korisnik> korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(json);
                korisnici.Add(korisnik);

                json = JsonConvert.SerializeObject(korisnici);
                File.Create(putanjaFile).Close();

                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();

            }   
            else
            {
                List<Korisnik> korisnici = new List<Korisnik>();
                korisnici.Add(korisnik);

                File.Create(putanjaFile).Close();

                string json = JsonConvert.SerializeObject(korisnici);
                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();


            }
            
         return korisnik;
      }

        

         

        
   
   }
}