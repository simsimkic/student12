/***********************************************************************
 * Module:  LekKontroler.cs
 * Purpose: Definition of the Class Kontrola.LekKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Newtonsoft.Json;

namespace Repo
{
   public class LekRepo
   {
      public  Model.Lek dobaviLekPoSifri(String sifra)
      {
            

            List<Lek> lekevi = dobavljanjeSvega();

            if (lekevi is null)
                return null;
            else
            {
                foreach (Lek lek in lekevi)
                {
                    if (lek.Sifra == sifra)
                    {

                        return lek;


                    }
                }
                return null;
            }
            
      }
      
      public  Model.Lek izmenaLek(Model.Lek lek)
      {
            string putanjaFile = @"..\..\Lek.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                string json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Lek> lekevi = JsonConvert.DeserializeObject<List<Lek>>(json);

                int validacijaPostojanjaLekaZaIzmenu = 0;

                for (int brojac = 0; brojac < lekevi.Count; brojac++)
                {
                    if (lek.Equals(lekevi[brojac]))
                    {
                        if (!String.IsNullOrEmpty(lek.Ime))
                            lekevi[brojac].Ime = lek.Ime;
                        if (!String.IsNullOrEmpty(lek.Proizvodjac))
                            lekevi[brojac].Proizvodjac = lek.Proizvodjac;
                        if (lek.Cena!=0)
                            lekevi[brojac].Cena = lek.Cena;
                        lekevi[brojac].Recept = lek.Recept;

                        

                        validacijaPostojanjaLekaZaIzmenu = 1;
                    }
                }


                json = JsonConvert.SerializeObject(lekevi);
                File.Create(putanjaFile).Close();

                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();


                if (validacijaPostojanjaLekaZaIzmenu == 0)
                    return null;
                else
                    return lek;

            }
            else
                return null;

                
            
        }
      
      public  bool brisanjeLek(String sifraLeka)
      {
            string putanjaFile = @"..\..\Lek.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                string json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Lek> lekevi = JsonConvert.DeserializeObject<List<Lek>>(json);

                int validacijaPostojanjaLeka = 0;

                foreach (Lek lek in lekevi)
                {
                    if (lek.Sifra == sifraLeka && lek.Obrisan == false)
                    {

                        lek.Obrisan = true;
                        validacijaPostojanjaLeka = 1;
                    }

                }

                json = JsonConvert.SerializeObject(lekevi);
                File.Create(putanjaFile).Close();

                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();

                if (validacijaPostojanjaLeka == 0)
                    return false;
                else
                    return true;

            }
            else
                return false;
                


        }
      
      public  List<Model.Lek> dobaviLekPoImenu(String imeLeka)
      {
            

            int validacijaPostojanjaLekovaSaImenom = 0;
            string imeLekaLower;

            List<Lek> lekevi = dobavljanjeSvega();
            List<Lek> lekoviSaImenom = new List<Lek>();

            if (lekevi is null)
                return null;
            else
            {
                foreach (Lek lek in lekevi)
                {
                    imeLekaLower = lek.Ime.ToLower();
                    if (imeLekaLower.Contains(imeLeka.ToLower()))
                    {
                        validacijaPostojanjaLekovaSaImenom = 1;
                        lekoviSaImenom.Add(lek);


                    }
                }
                if (validacijaPostojanjaLekovaSaImenom == 0)
                    return null;
                else
                    return lekoviSaImenom;
            }
            
        }

        public List<Model.Lek> dobaviLekPoImenuZaIzvestaj(String imeLeka)
        {


            int validacijaPostojanjaLekovaSaImenom = 0;
            string imeLekaLower;

            List<Lek> lekevi = dobavljanjeSvega();
            List<Lek> lekoviSaImenom = new List<Lek>();

            if (lekevi is null)
                return null;
            else
            {
                foreach (Lek lek in lekevi)
                {
                    imeLekaLower = lek.Ime.ToLower();
                    if (imeLekaLower==imeLeka.ToLower())
                    {
                        validacijaPostojanjaLekovaSaImenom = 1;
                        lekoviSaImenom.Add(lek);


                    }
                }
                if (validacijaPostojanjaLekovaSaImenom == 0)
                    return null;
                else
                    return lekoviSaImenom;
            }

        }

        public  List<Model.Lek> dobaviLekPoProizvodjacu(String proizvodjac)
      {
            

            int validacijaPostojanjaLekovaSaImenom = 0;

            List<Lek> lekevi = dobavljanjeSvega();

            List<Lek> lekoviSaProizvodjacem = new List<Lek>();
            string proizvodjacLower;

            if (lekevi is null)
                return null;
            else
            {
                foreach (Lek lek in lekevi)
                {
                    proizvodjacLower = lek.Proizvodjac.ToLower();
                    if (proizvodjacLower.Contains(proizvodjac.ToLower()))
                    {
                        validacijaPostojanjaLekovaSaImenom = 1;
                        lekoviSaProizvodjacem.Add(lek);


                    }
                }
                if (validacijaPostojanjaLekovaSaImenom == 0)
                    return null;
                else
                    return lekoviSaProizvodjacem;
            }
            
        }
      
      public  List<Model.Lek> dobaviLekPoCeni(float minCena, float maxCena)
      {
            

            List<Lek> lekoviUOpsegu = new List<Lek>();
            List<Lek> lekevi = dobavljanjeSvega();

            int validacijaPostojanjaLekaUOpsegu = 0;
            if (lekevi is null)
                return null;
            else
            {
                foreach (Lek lek in lekevi)
                {
                    if (lek.Cena <= maxCena && lek.Cena >= minCena)
                    {

                        lekoviUOpsegu.Add(lek);
                        validacijaPostojanjaLekaUOpsegu = 1;
                    }
                }

                if (validacijaPostojanjaLekaUOpsegu == 0)
                    return null;
                else
                    return lekoviUOpsegu;
            }
            

        }
      
      public  Model.Lek kreiranjeLek(Model.Lek lek)
      {
            string putanjaFile = @"..\..\Lek.txt";

            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                String json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Lek> lekevi = JsonConvert.DeserializeObject<List<Lek>>(json);
                lekevi.Add(lek);

                json = JsonConvert.SerializeObject(lekevi);
                File.Create(putanjaFile).Close();

                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();

            }
            else
            {
                List<Lek> lekevi = new List<Lek>();
                lekevi.Add(lek);

                File.Create(putanjaFile).Close();

                string json = JsonConvert.SerializeObject(lekevi);
                TextWriter upisano = new StreamWriter(putanjaFile);
                upisano.Write(json);
                upisano.Close();


            }

            return lek;
            
      }
      
      public  List<Model.Lek> dobavljanjeSvega()
      {
            string putanjaFile = @"..\..\Lek.txt";


            if (File.Exists(putanjaFile))
            {
                TextReader ucitano = new StreamReader(putanjaFile);
                string json = ucitano.ReadToEnd();
                ucitano.Close();

                List<Lek> lekevi = JsonConvert.DeserializeObject<List<Lek>>(json);

                return lekevi;

            }
            else
                return null;
            
            
      }
   
   }
}