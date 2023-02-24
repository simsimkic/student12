using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.ComponentModel;
using Repo;
using Servis;
using Kontrola;
using ClassDijagram;
using ConsoleTables;

namespace ClassDijagram
{
    class Mainn
    {


        static public void Main()
        {
            KorisnikKontroler _korisnikKontroler = new KorisnikKontroler();
            LekKontroler _lekKontroler = new LekKontroler();
            RacunKontroler _racunKontroler = new RacunKontroler();
            ReceptKontroler _receptKontroler = new ReceptKontroler();
            Mainn _main = new Mainn();
            ConsoleTable _consoleTable = new ConsoleTable();


            string ulogovaniKorisnik;
            int caseSwitch;
            int brojPokusaja = 0;



            do
            {

                Console.WriteLine("********************************************************************************");
                Console.WriteLine("DOBRODOSLI U BALKANSKU BONICU");
                Console.WriteLine("");
                Console.WriteLine("1. LOGOVANJE");
                Console.WriteLine("999. IZLAZ IZ PROGRAMA");
                Console.WriteLine("");
                Console.WriteLine("UPRAVLJATE APLIKACIJOM TAKO STO UKUCATE NEKI OD REDNIH BROJEVA KOJI VIDITE IZNAD I KLIKNETE ENTER");
                Console.WriteLine("");

                string help = Console.ReadLine();
                Console.WriteLine("");
                if (!String.IsNullOrEmpty(help))
                {
                    while (!Int32.TryParse(help, out caseSwitch))
                    {
                        Console.WriteLine("MORATE UNETI BROJ");
                        Console.WriteLine("");
                        Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                        help = Console.ReadLine();

                    }
                }
                else
                    caseSwitch = default;

                switch (caseSwitch)
                {
                    case 1:
                        
                        Console.Write("UNESITE SVOJ USERNAME:     ");
                        string username = Console.ReadLine();
                        Console.Write("UNESITE SVOJ PASSWORD:     ");
                        string pass = ReadPassword();
                        Console.WriteLine("");
                        Korisnik korisnik = _korisnikKontroler.prijavljivanje(username, pass);
                        if (korisnik is null)
                        {
                            brojPokusaja++;
                            if(brojPokusaja==3)
                            {
                                caseSwitch = 999;
                            }
                            break;
                        }
                            
                        else if (korisnik.TipKorisnika == TIPkorisnika.ADMINISTRATOR)
                        {
                            _main.AdminView();
                            brojPokusaja = 0;
                            break;
                        }
                        else if (korisnik.TipKorisnika == TIPkorisnika.APOTEKAR)
                        {
                            brojPokusaja = 0;
                            _main.ApotekarView(korisnik);
                            break;
                        }
                        else
                        {
                            brojPokusaja = 0;
                            _main.LekarView(korisnik);
                            break;
                        }


                    default:
                        Console.WriteLine("NISTE UNELI DOBAR BROJ");
                        Console.WriteLine("");
                        break;
                }

            } while (caseSwitch != 999);
        }

        public void AdminView()/////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
                               /////////////////////////////////////////////////////////////////////////////
        {

            KorisnikKontroler _korisnikKontroler = new KorisnikKontroler();
            LekKontroler _lekKontroler = new LekKontroler();
            RacunKontroler _racunKontroler = new RacunKontroler();
            ReceptKontroler _receptKontroler = new ReceptKontroler();
            Mainn _main = new Mainn();


            
            int caseSwitch;
            int caseSwitch5;
            int caseSwitch10;



            do
            {

                Console.WriteLine("********************************************************************************");
                Console.WriteLine("ULOGOVANI STE KAO ADMINISTRATOR");
                Console.WriteLine("");
                Console.WriteLine("1. REGISTRACIJA NOVIH KORISNIKA");
                Console.WriteLine("2. PRIKAZ SVIH KORISNIKA");
                Console.WriteLine("3. KREIRAJ IZVESTAJ");
                Console.WriteLine("4. PREGLED SVIH LEKOVA");
                Console.WriteLine("5. PRETRAGA LEKOVA");
                Console.WriteLine("6. DODAVANJE NOVOG LEKA");
                Console.WriteLine("7. IZMENA POSTOJECEG LEKA");
                Console.WriteLine("8. BRISANJE LEKA");
                Console.WriteLine("9. PRIKAZ SVIH RECEPATA");
                Console.WriteLine("10. PRETRAGA RECEPATA");
                Console.WriteLine("999. IZLOGUJ SE");
                Console.WriteLine("");
                Console.WriteLine("UPRAVLJATE APLIKACIJOM TAKO STO UKUCATE NEKI OD REDNIH BROJEVA KOJI VIDITE IZNAD I KLIKNETE ENTER");
                Console.WriteLine("");

                

                string help = Console.ReadLine();                
                Console.WriteLine("");
                if (!String.IsNullOrEmpty(help))
                {
                    while (!Int32.TryParse(help, out caseSwitch))
                    {
                        Console.WriteLine("MORATE UNETI BROJ");
                        Console.WriteLine("");
                        Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                        help = Console.ReadLine();

                    }                    
                }
                else
                    caseSwitch = default;

                switch (caseSwitch)
                {
                    case 1://////////////////////////////////////////   REGISTRACIJA   /////////////////////////////////////////////////////////////////////////////////////////
                        Korisnik korisnik = new Korisnik();
                        Console.Write("UNESITE IME NOVOG KORISNIKA:     ");
                        korisnik.Ime = Console.ReadLine();
                        Console.Write("UNESITE PREZIME NOVOG KORISNIKA:     ");
                        korisnik.Prezime = Console.ReadLine();
                        Console.Write("UNESITE USERNAME NOVOG KORISNIKA:     ");
                        string korisnikUsername=Console.ReadLine();
                        if(String.IsNullOrEmpty(korisnikUsername))
                        {
                            Console.WriteLine();
                            Console.WriteLine("USERNAME NE MOZE DA BUDE PRAZNO POLJE!!!");
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            korisnik.Username = korisnikUsername;
                        }
                        
                        

                        Console.Write("UNESITE PASSWORD NOVOG KORISNIKA:     ");
                        korisnik.Pass = Console.ReadLine();
                        Console.Write("UNESITE TIP NOVOG KORISNIKA:     ");
                        string helpp = Console.ReadLine();
                        Console.WriteLine("");
                        if (helpp.ToLower() == "apotekar" || helpp.ToLower() == "lekar")
                        {
                            korisnik.TipKorisnika = (TIPkorisnika)Enum.Parse(typeof(TIPkorisnika), helpp, true);
                            korisnik = _korisnikKontroler.registracijaKorisnika(korisnik);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("UNELI STE POGRESAN TIP KORISNIKA (NIJE MOGUCE REGISTROVATI ADMINISTRATORA)");
                            Console.WriteLine("");
                            break;
                        }
                    case 2:// ///////////////////////////   PRIKAZ KORISNIKA   /////////////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("IZABERITE NACIN SORTIRANJA");
                        Console.WriteLine("");
                        Console.WriteLine("0. SORTIRANJE PO IMENU");
                        Console.WriteLine("1. SORTIRANJE PO PREZIMENU");
                        Console.WriteLine("2. SORTIRANJE PO TIPU KORISNIKA");

                        string help1 = Console.ReadLine();
                        int tipSortiranjaKorisnik;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help1, out tipSortiranjaKorisnik))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help1 = Console.ReadLine();

                        }

                        List<Korisnik> prikazKorisnika = _korisnikKontroler.prikaziSveKorisnike(tipSortiranjaKorisnik);
                        if (prikazKorisnika is null)
                        {
                            break;
                        }
                        else
                        {
                            _main.icrtajTabeluKorisnik(prikazKorisnika);
                            Console.Write("KADA ZAVRSITE PREGLED KORISNIKA ZA NASTAVAK PRITISNITE ENTER");
                            Console.ReadLine();
                            break;

                        }
                    case 3://////////////////////////  IZVESTAJ  ///////////////////////////////////////////////
                        Console.WriteLine("IZABERITE VRSTU IZVESTAJA");
                        Console.WriteLine("");
                        Console.WriteLine("1. IZVESTAJ O UKUPNOJ PRODAJI LEKOVA");
                        Console.WriteLine("2. IZVESTAJ O UKUPNOJ PRODAJI LEKOVA ODABRANOG PROIZVODJACA");
                        Console.WriteLine("3. IZVESTAJ O UKUPNOJ PRODAJI LEKOVA KOJE JE ODABRANI LEKAR PRODAO");


                        string help3 = Console.ReadLine();
                        int tipIzvestaja;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help3, out tipIzvestaja) || !(tipIzvestaja==1 || tipIzvestaja == 2 || tipIzvestaja == 3))
                        {
                            Console.WriteLine("MORATE UNETI BROJ 1, 2 ili 3");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help3 = Console.ReadLine();

                        }

                        List<Racun> racuni = _racunKontroler.prikazSvihracuna();
                        Dictionary<string, int> lekoviKolicina = new Dictionary<string, int>();
                        Dictionary<string, float> lekoviCena = new Dictionary<string, float>();

                        if (racuni is null)
                        {
                            break;
                        }
                        else
                        {
                            if(tipIzvestaja==1)
                            {
                                foreach(Racun racun in racuni)
                                {
                                    foreach(KeyValuePair<string,int> pair in racun.Lekovi)
                                    {
                                        List<Lek> lekoviIzvestaj = _lekKontroler.dobaviLekPoImenuZaIzvestaj(pair.Key);
                                        if (lekoviIzvestaj is null)
                                            break;
                                        else
                                        {
                                            foreach(Lek lek in lekoviIzvestaj)
                                            {
                                                if (lekoviKolicina.Keys.Contains(lek.Ime))
                                                {
                                                    lekoviKolicina[lek.Ime] += pair.Value;
                                                    lekoviCena[lek.Ime] += pair.Value * lek.Cena;
                                                }
                                                else
                                                {
                                                    lekoviKolicina.Add(pair.Key, pair.Value);
                                                    lekoviCena.Add(pair.Key, pair.Value * lek.Cena);
                                                    
                                                }

                                            }
                                            
                                        }
                                        
                                    }
                                }
                            }
                            else if(tipIzvestaja==2)
                            {
                                Console.WriteLine("UNESITE IME PROIZVODJACA     ");
                                string proizvodjac = Console.ReadLine();
                                Console.Write("");

                                if (racuni is null)
                                    break;
                                else
                                {
                                    foreach (Racun racun in racuni)
                                    {
                                        foreach (KeyValuePair<string, int> pair in racun.Lekovi)
                                        {
                                            List<Lek> lekoviIzvestaj = _lekKontroler.dobaviLekPoImenuZaIzvestaj(pair.Key);
                                            if (lekoviIzvestaj is null)
                                                break;
                                            else
                                            {
                                                foreach (Lek lek in lekoviIzvestaj)
                                                {
                                                    if(lek.Proizvodjac.ToLower()== proizvodjac.ToLower())
                                                    {
                                                        if (lekoviKolicina.Keys.Contains(lek.Ime))
                                                        {
                                                            lekoviKolicina[lek.Ime] += pair.Value;
                                                            lekoviCena[lek.Ime] += pair.Value * lek.Cena;
                                                        }
                                                        else
                                                        {
                                                            lekoviKolicina.Add(pair.Key, pair.Value);
                                                            lekoviCena.Add(pair.Key, pair.Value * lek.Cena);

                                                        }
                                                    }
                                                    

                                                }

                                            }
                                            
                                        }
                                    }

                                }

                                
                            }
                            else
                            {
                                Console.WriteLine("UNESITE SIFRU APOTEKARA     ");
                                string apotekar = Console.ReadLine();
                                Console.Write("");
                                racuni = _racunKontroler.prikazSvihRacunaPoApotekaru(apotekar);
                                if(racuni is null)
                                {
                                    break;
                                }
                                else
                                {
                                    foreach (Racun racun in racuni)
                                    {
                                        foreach (KeyValuePair<string, int> pair in racun.Lekovi)
                                        {
                                            List<Lek> lekoviIzvestaj = _lekKontroler.dobaviLekPoImenuZaIzvestaj(pair.Key);
                                            if (lekoviIzvestaj is null)
                                                break;
                                            else
                                            {
                                                foreach (Lek lek in lekoviIzvestaj)
                                                {
                                                    if (lekoviKolicina.Keys.Contains(lek.Ime))
                                                    {
                                                        lekoviKolicina[lek.Ime] += pair.Value;
                                                        lekoviCena[lek.Ime] += pair.Value * lek.Cena;
                                                    }
                                                    else
                                                    {
                                                        lekoviKolicina.Add(pair.Key, pair.Value);
                                                        lekoviCena.Add(pair.Key, pair.Value * lek.Cena);

                                                    }

                                                }

                                            }

                                        }
                                    }

                                }
                                
                            }

                            var table = new ConsoleTable("IME LEKA", "KOLICINA LEKA", "CENA LEKA");
                            for (int i = 0; i < lekoviKolicina.Count; i++)
                            {
                                 table.AddRow(lekoviKolicina.Keys.ElementAt(i), lekoviKolicina[lekoviKolicina.Keys.ElementAt(i)], lekoviCena[lekoviKolicina.Keys.ElementAt(i)]);
                            }
                            table.Write();
                            Console.WriteLine();
                            break;
                        }
                        






    
                    case 4:/// ////////////////////////////   PREGLED LEKOVA   ////////////////////////////////////////////////////////////////////////////////////////////////

                        Console.WriteLine("IZABERITE NACIN SORTIRANJA");
                        Console.WriteLine("");
                        Console.WriteLine("0. SORTIRANJE PO IMENU");
                        Console.WriteLine("1. SORTIRANJE PO PROIZVODJACU");
                        Console.WriteLine("2. SORTIRANJE PO CENI");

                        string help4 = Console.ReadLine();
                        int tipSortiranjaLek;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help4, out tipSortiranjaLek))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help4 = Console.ReadLine();

                        }
                        List<Lek> prikazLeka = _lekKontroler.prikazSvihLekova(tipSortiranjaLek);
                        if (prikazLeka is null)
                        {
                            break;
                        }
                        else
                        {
                            _main.icrtajTabeluLek(prikazLeka);
                            Console.Write("KADA ZAVRSITE PREGLED LEKOVA ZA NASTAVAK PRITISNITE ENTER");
                            Console.ReadLine();
                            break;

                        }
                    case 5:// /////////////////////////////   PRETRAGA LEKOVA   ///////////////////////////////////////////////////////////////////////////////////////////////
                        do
                        {
                            Console.WriteLine("IZABERITE NACIN PRETRAGE");
                            Console.WriteLine("");
                            Console.WriteLine("1. PRETRAGA PO SIFRI");
                            Console.WriteLine("2. PRETRAGA PO IMENU");
                            Console.WriteLine("3. PRETRAGA PO PROIZVODJACU");
                            Console.WriteLine("4. PRETRAGA PO OPSEGU CENE");
                            Console.WriteLine("999. PEKID PRETRAGE");
                            Console.WriteLine("");


                            string help111 = Console.ReadLine();
                            Console.WriteLine("");
                            if (!String.IsNullOrEmpty(help111))
                            {
                                while (!Int32.TryParse(help111, out caseSwitch5))
                                {
                                    Console.WriteLine("MORATE UNETI BROJ");
                                    Console.WriteLine("");
                                    Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                                    help111 = Console.ReadLine();

                                }
                            }
                            else                               
                                caseSwitch5 = default;

                            switch (caseSwitch5)
                            {
                                case 1:
                                    
                                    Console.Write("UNESITE SIFRU     ");
                                    string sifraLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    Lek lekSifra = _lekKontroler.dobaviLekPoSifri(sifraLekPretraga);
                                    List<Lek> lekSifraList = new List<Lek>();
                                    lekSifraList.Add(lekSifra);
                                    if (lekSifra is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluLek(lekSifraList);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }
                                        

                                case 2:
                                    Console.Write("UNESITE IME     ");
                                    string ImeLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Lek> lekIme = _lekKontroler.dobaviLekPoImenu(ImeLekPretraga);
                                    if (lekIme is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluLek(lekIme);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }
                                        

                                case 3:
                                    Console.Write("UNESITE IME PROIZVODJACA     ");
                                    string ProizLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Lek> lekPro = _lekKontroler.dobaviLekPoProizvodjacu(ProizLekPretraga);
                                    if (lekPro is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluLek(lekPro);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;

                                    }
                                        

                                case 4:
                                    Console.Write("UNESITE MINIMALNU CENU (MORA BITI BROJ)     ");
                                    string minLekPretragahelp = Console.ReadLine();
                                    float minLekPretraga;
                                    while(!float.TryParse(minLekPretragahelp, out minLekPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MINIMALNU CENU     ");
                                        minLekPretragahelp = Console.ReadLine();

                                    }                                    
                                    Console.WriteLine("");

                                    Console.Write("UNESITE MAXIMALNU CENU (MORA BITI BROJ)     ");
                                    string maxLekPretragahelp = Console.ReadLine();
                                    float maxLekPretraga;
                                    while (!float.TryParse(maxLekPretragahelp, out maxLekPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MAXIMALNU CENU     ");
                                        maxLekPretragahelp = Console.ReadLine();

                                    }
                                    Console.WriteLine("");

                                    

                                    List<Lek> cenaIme = _lekKontroler.dobaviLekPoCeni(minLekPretraga, maxLekPretraga);
                                    if (cenaIme is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluLek(cenaIme);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;

                                    }
                                default:
                                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                                    Console.WriteLine("");
                                    break;

                                case 999:
                                    Console.WriteLine("PREKINULI STE PRETRAGU");
                                    Console.WriteLine("");
                                    break;
                            }
                        } while (caseSwitch5 != 999);

                        break;


                    case 6:////////////////////////////////////// DODAJ LEK /////////////////////////////////////////////////////////////////////////////////////////////
                        Lek lekKreiraj = new Lek();

                        Console.Write("UNESITE IME NOVOG LEKA:     ");
                        lekKreiraj.Ime = Console.ReadLine();

                        Console.Write("UNESITE PROIZVODJACA NOVOG LEKA:     ");
                        lekKreiraj.Proizvodjac = Console.ReadLine();

                        Console.Write("UNESITE SIFRU NOVOG LEKA:     ");
                        lekKreiraj.Sifra = Console.ReadLine();
                        
                        Console.Write("UNESITE CENU NOVOG LEKA (MORA BITI BROJ):     ");
                        string cenahelp = Console.ReadLine();
                        float lekKreirajcena;
                        while (!float.TryParse(cenahelp, out lekKreirajcena))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE CENU NOVOG LEKA     ");
                            cenahelp = Console.ReadLine();

                        }
                        Console.WriteLine("");
                        lekKreiraj.Cena = lekKreirajcena;

                        Console.Write("DA LI JE POTREBAN RECEPT ZA OVAJ LEK? [y]/[n]:     ");
                        string lekKreirajHelp = Console.ReadLine();
                        
                        while (lekKreirajHelp !="y" && lekKreirajHelp !="n")
                        {
                            Console.WriteLine("POGRESNO DUGME!!!!");
                            lekKreirajHelp = Console.ReadLine();
                        }
                        if (lekKreirajHelp == "n")
                            lekKreiraj.Recept = false;
                        else
                            lekKreiraj.Recept = true;

                        
                            
                            Lek lekKreiran = _lekKontroler.dodavanjeLeka(lekKreiraj);
                            break;

                    case 7:////////////////////////////////////// IZMENI LEK ////////////////////////////////////////////////////////////////////////////
                        Lek lekIzmena = new Lek();
                        Console.WriteLine("U KOLIKO NE ZELITE DA IZMENITE POLJE UNESITE SAMO PRAZAN STRING");
                        Console.WriteLine("");

                        Console.Write("UNESITE SIFRU LEKA KOJI ZELITE DA MENJATE:     ");
                        lekIzmena.Sifra = Console.ReadLine();

                        Console.Write("UNESITE IME LEKA:     ");
                        lekIzmena.Ime = Console.ReadLine();

                        Console.Write("UNESITE PROIZVODJACA LEKA:     ");
                        lekIzmena.Proizvodjac = Console.ReadLine();   
                        
                        Console.Write("UNESITE CENU LEKA(MORA BITI BROJ):     ");

                        string cenahelpIzmena = Console.ReadLine();
                        float lekIzmenaCena;
                        if (String.IsNullOrEmpty(cenahelpIzmena))
                        {
                            lekIzmena.Cena = 0;
                        }
                        else
                        {
                            while (!float.TryParse(cenahelpIzmena, out lekIzmenaCena))
                            {

                                Console.WriteLine("MORATE UNETI BROJ ILI PRAZAN STING");
                                Console.WriteLine("");
                                Console.Write("UNESITE CENU LEKA     ");
                                cenahelpIzmena = Console.ReadLine();

                            }
                            Console.WriteLine("");
                            lekIzmena.Cena = lekIzmenaCena;
                        }

                        Console.Write("DA LI JE POTREBAN RECEPT ZA OVAJ LEK? [y]/[n]:     ");
                        string lekIzmenaHelp = Console.ReadLine();
                        while (lekIzmenaHelp != "y" && lekIzmenaHelp != "n")
                        {
                            Console.WriteLine("POGRESNO DUGME!!!!");
                            lekIzmenaHelp = Console.ReadLine();
                        }
                        if (lekIzmenaHelp == "n")
                            lekIzmena.Recept = false;
                        else
                            lekIzmena.Recept = true;
                        Console.WriteLine("");



                        Lek lekIzmenjen = _lekKontroler.izmenaLeka(lekIzmena);
                        break;

                    case 8:////////////////////////////////////// OBRISI LEK ////////////////////////////////////////////////////////////////////////////
                        Console.Write("UNESITE SIFRU LEKA KOJI ZELITE DA OBRISETE:     ");
                        bool proveraBrisanja = _lekKontroler.brisanjeLeka(Console.ReadLine());
                        Console.WriteLine("");
                        break;

                    case 9:////////////////////////////////////// PRIKAZ RECEPATA ////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("IZABERITE NACIN SORTIRANJA");
                        Console.WriteLine("");
                        Console.WriteLine("0. SORTIRANJE PO SIFRI");
                        Console.WriteLine("1. SORTIRANJE PO LEKARU");
                        Console.WriteLine("2. SORTIRANJE PO DATUMU");

                        string help9 = Console.ReadLine();
                        int tipSortiranjaRECEPT;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help9, out tipSortiranjaRECEPT))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help9 = Console.ReadLine();

                        }

                        List<Recept> prikazRecepata = _receptKontroler.prikazRecepata(tipSortiranjaRECEPT);
                        if (prikazRecepata is null)
                        {
                            break;
                        }
                        else
                        {
                            _main.icrtajTabeluRecepata(prikazRecepata);
                            Console.Write("KADA ZAVRSITE PREGLED KORISNIKA ZA NASTAVAK PRITISNITE ENTER");
                            Console.ReadLine();
                            break;

                        }
                    case 10:////////////////////////////////////// PRETRAGA RECEPATA ////////////////////////////////////////////////////////////////////////////
                        do
                        {
                            Console.WriteLine("IZABERITE NACIN PRETRAGE");
                            Console.WriteLine("");
                            Console.WriteLine("1. PRETRAGA PO SIFRI");
                            Console.WriteLine("2. PRETRAGA PO LEKARU");
                            Console.WriteLine("3. PRETRAGA PO JMBG-U PACIJENTA");
                            Console.WriteLine("4. PRETRAGA PO JEDNOM LEKU");
                            Console.WriteLine("999. PEKID PRETRAGE");
                            Console.WriteLine("");

                            string help11 = Console.ReadLine();
                            Console.WriteLine("");
                            if (!String.IsNullOrEmpty(help11))
                            {
                                while (!Int32.TryParse(help11, out caseSwitch10))
                                {
                                    Console.WriteLine("MORATE UNETI BROJ");
                                    Console.WriteLine("");
                                    Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                                    help11 = Console.ReadLine();

                                }
                            }
                            else                                
                                caseSwitch10 = default;

                            switch (caseSwitch10)
                            {
                                case 1:

                                    Console.Write("UNESITE SIFRU (MORA BITI BROJ)     ");
                                    string sifraReceptPretragaHelp = Console.ReadLine();
                                    int sifraReceptPretraga;
                                    while (!Int32.TryParse(sifraReceptPretragaHelp, out sifraReceptPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MINIMALNU CENU     ");
                                        sifraReceptPretragaHelp = Console.ReadLine();
                                    }
                                    Console.WriteLine("");

                                    Recept receptSifra = _receptKontroler.dobaviReceptPoSifri(sifraReceptPretraga);
                                    List<Recept> receptSifraLista = new List<Recept>();
                                    receptSifraLista.Add(receptSifra);
                                    if (receptSifra is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptSifraLista);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 2:
                                    Console.Write("UNESITE IME LEKARA     ");
                                    string lekarReceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Recept> receptLekar = _receptKontroler.dobavireceptpoLekaru(lekarReceptPretraga);
                                    if (receptLekar is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptLekar);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 3:
                                    Console.Write("UNESITE JMBG PACIJENTA     ");
                                    string jmbgreceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");
                                    while(!_korisnikKontroler.ValidacijaJmbg(jmbgreceptPretraga))
                                    {
                                        Console.WriteLine("");
                                        Console.Write("UNESITE JMBG PACIJENTA     ");
                                        jmbgreceptPretraga = Console.ReadLine();
                                    }

                                    List<Recept> receptJmbg = _receptKontroler.dobaviReceptPoJmbg(jmbgreceptPretraga);
                                    if (receptJmbg is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptJmbg);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;

                                    }


                                case 4:
                                    Console.Write("UNESITE IME LEKA     ");
                                    string lekReceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Recept> receptLek = _receptKontroler.dobaviReceptPoLeku(lekReceptPretraga);
                                    if (receptLek is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptLek);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }
                                default:
                                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                                    Console.WriteLine("");
                                    break;

                                case 999:
                                    Console.WriteLine("PREKINULI STE PRETRAGU");
                                    Console.WriteLine("");
                                    break;
                            }
                        } while (caseSwitch10 != 999);

                        break;









                    case 999:///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("IZLOGOVALI STE SE");
                        Console.WriteLine("");
                        break;
                    default:///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("NISTE UNELI DOBAR BROJ");
                        Console.WriteLine("");
                        break;
                }

            } while (caseSwitch != 999);
        }



        public void ApotekarView(Korisnik ulogovaniKorisnik)/////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
                                  /////////////////////////////////////////////////////////////////////////////
        {
            KorisnikKontroler _korisnikKontroler = new KorisnikKontroler();
            LekKontroler _lekKontroler = new LekKontroler();
            RacunKontroler _racunKontroler = new RacunKontroler();
            ReceptKontroler _receptKontroler = new ReceptKontroler();
            Mainn _main = new Mainn();

            int caseSwitch;
            int caseSwitch4;
            int caseSwitch5;
            int caseSwitch10;

            do
            {
                Console.WriteLine("********************************************************************************");
                Console.WriteLine("ULOGOVANI STE KAO APOTEKAR");
                Console.WriteLine("");
                
                Console.WriteLine("1. PREGLED SVIH LEKOVA");
                Console.WriteLine("2. PETRAGA LEKOVA");
                Console.WriteLine("3. DODAVANJE LEKOVA");
                Console.WriteLine("4. IZMENA LEKOVA");
                Console.WriteLine("5. BRISANJE LEKOVA");
                Console.WriteLine("6. PRODAJA LEKOVA");
                Console.WriteLine("7. PREGLED SVIH RECEPATA");
                Console.WriteLine("8. PRETRAGA RECEPATA");

                Console.WriteLine("999. IZLOGUJ SE");
                Console.WriteLine("");
                Console.WriteLine("UPRAVLJATE APLIKACIJOM TAKO STO UKUCATE NEKI OD REDNIH BROJEVA KOJI VIDITE IZNAD I KLIKNETE ENTER");
                Console.WriteLine("");


                string help = Console.ReadLine();
                Console.WriteLine("");
                if (!String.IsNullOrEmpty(help))
                {
                    while (!Int32.TryParse(help, out caseSwitch))
                    {
                        Console.WriteLine("MORATE UNETI BROJ");
                        Console.WriteLine("");
                        Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                        help = Console.ReadLine();

                    }
                }
                else
                    caseSwitch = default;

                switch (caseSwitch)
                {
                    case 1://///////////////////////////    PREGLED SVIH LEKOVA ///////////////////////

                        Console.WriteLine("IZABERITE NACIN SORTIRANJA");
                        Console.WriteLine("");
                        Console.WriteLine("0. SORTIRANJE PO IMENU");
                        Console.WriteLine("1. SORTIRANJE PO PROIZVODJACU");
                        Console.WriteLine("2. SORTIRANJE PO CENI");

                        string help4 = Console.ReadLine();
                        int tipSortiranjaLek;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help4, out tipSortiranjaLek))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help4 = Console.ReadLine();

                        }

                        List<Lek> prikazLeka = _lekKontroler.prikazSvihLekova(tipSortiranjaLek);
                        if (prikazLeka is null)
                        {
                            break;
                        }
                        else
                        {
                            List<Lek> lekoviBezObrisanih = new List<Lek>();
                            foreach (Lek lek in prikazLeka)
                            {
                                if (lek.Obrisan == false)
                                {
                                    lekoviBezObrisanih.Add(lek);
                                }
                            }

                            if (!lekoviBezObrisanih.Any())
                            {
                                Console.WriteLine("SVI LEKOVI SU OBRISANI");
                                Console.WriteLine("");
                                break;
                            }
                            else
                            {
                                _main.icrtajTabeluLek(lekoviBezObrisanih);
                                Console.Write("KADA ZAVRSITE PREGLED LEKOVA ZA NASTAVAK PRITISNITE ENTER");
                                Console.ReadLine();
                                break;
                            }


                        }
                    case 2:// /////////////////////////////   PRETRAGA LEKOVA   ///////////////////////////////////////////////////////////////////////////////////////////////
                        do
                        {
                            Console.WriteLine("IZABERITE NACIN PRETRAGE");
                            Console.WriteLine("");
                            Console.WriteLine("1. PRETRAGA PO SIFRI");
                            Console.WriteLine("2. PRETRAGA PO IMENU");
                            Console.WriteLine("3. PRETRAGA PO PROIZVODJACU");
                            Console.WriteLine("4. PRETRAGA PO OPSEGU CENE");
                            Console.WriteLine("999. PEKID PRETRAGE");
                            Console.WriteLine("");

                            string help1 = Console.ReadLine();
                            Console.WriteLine("");
                            if (!String.IsNullOrEmpty(help1))
                            {
                                while (!Int32.TryParse(help1, out caseSwitch5))
                                {
                                    Console.WriteLine("MORATE UNETI BROJ");
                                    Console.WriteLine("");
                                    Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                                    help1 = Console.ReadLine();

                                }
                            }
                            else
                                caseSwitch5 = default;

                            switch (caseSwitch5)
                            {
                                case 1:

                                    Console.Write("UNESITE SIFRU     ");
                                    string sifraLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");
                                    Lek lekSifra = _lekKontroler.dobaviLekPoSifri(sifraLekPretraga);
                                    List<Lek> lekSifraList = new List<Lek>();
                                    lekSifraList.Add(lekSifra);
                                    if (lekSifra is null)
                                    {
                                        break;
                                    }
                                    else if (lekSifra.Obrisan == true)
                                    {
                                        Console.WriteLine("TRAZENI LEK JE OBRISAN!!!");
                                        Console.WriteLine("");
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluLek(lekSifraList);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 2:
                                    Console.Write("UNESITE IME     ");
                                    string ImeLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Lek> lekIme = _lekKontroler.dobaviLekPoImenu(ImeLekPretraga);


                                    if (lekIme is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        List<Lek> lekoviBezObrisanih = new List<Lek>();
                                        foreach (Lek lek in lekIme)
                                        {
                                            if (lek.Obrisan == false)
                                            {
                                                lekoviBezObrisanih.Add(lek);
                                            }
                                        }

                                        if (!lekoviBezObrisanih.Any())
                                        {
                                            Console.WriteLine("SVI LEKOVI SA DATIM IMENOM SU OBRISANI");
                                            Console.WriteLine("");
                                            break;
                                        }
                                        else
                                        {
                                            _main.icrtajTabeluLek(lekoviBezObrisanih);
                                            Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                            Console.ReadLine();
                                            break;
                                        }


                                    }


                                case 3:
                                    Console.Write("UNESITE IME PROIZVODJACA     ");
                                    string ProizLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Lek> lekPro = _lekKontroler.dobaviLekPoProizvodjacu(ProizLekPretraga);
                                    if (lekPro is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        List<Lek> lekoviBezObrisanih = new List<Lek>();
                                        foreach (Lek lek in lekPro)
                                        {
                                            if (lek.Obrisan == false)
                                            {
                                                lekoviBezObrisanih.Add(lek);
                                            }
                                        }

                                        if (!lekoviBezObrisanih.Any())
                                        {
                                            Console.WriteLine("SVI LEKOVI OD DATOG PROIZVODJACA SU OBISANI");
                                            Console.WriteLine("");
                                            break;
                                        }
                                        else
                                        {
                                            _main.icrtajTabeluLek(lekoviBezObrisanih);
                                            Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                            Console.ReadLine();
                                            break;
                                        }




                                    }


                                case 4:
                                    Console.Write("UNESITE MINIMALNU CENU (MORA BITI BROJ)     ");
                                    string minLekPretragahelp = Console.ReadLine();
                                    float minLekPretraga;
                                    while (!float.TryParse(minLekPretragahelp, out minLekPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MINIMALNU CENU     ");
                                        minLekPretragahelp = Console.ReadLine();

                                    }
                                    Console.WriteLine("");

                                    Console.Write("UNESITE MAXIMALNU CENU (MORA BITI BROJ)     ");
                                    string maxLekPretragahelp = Console.ReadLine();
                                    float maxLekPretraga;
                                    while (!float.TryParse(maxLekPretragahelp, out maxLekPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MAXIMALNU CENU     ");
                                        maxLekPretragahelp = Console.ReadLine();

                                    }
                                    Console.WriteLine("");



                                    List<Lek> cenaIme = _lekKontroler.dobaviLekPoCeni(minLekPretraga, maxLekPretraga);
                                    if (cenaIme is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        List<Lek> lekoviBezObrisanih = new List<Lek>();
                                        foreach (Lek lek in cenaIme)
                                        {
                                            if (lek.Obrisan == false)
                                            {
                                                lekoviBezObrisanih.Add(lek);
                                            }
                                        }

                                        if (!lekoviBezObrisanih.Any())
                                        {
                                            Console.WriteLine("SVI LEKOVI U DATOM OPSEGU CENE SU OBRISANI");
                                            Console.WriteLine("");
                                            break;
                                        }
                                        else
                                        {
                                            _main.icrtajTabeluLek(lekoviBezObrisanih);
                                            Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                            Console.ReadLine();
                                            break;
                                        }

                                    }

                                default:
                                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                                    Console.WriteLine("");
                                    break;

                                case 999:
                                    Console.WriteLine("PREKINULI STE PRETRAGU");
                                    Console.WriteLine("");
                                    break;
                            }



                        } while (caseSwitch5 != 999);
                        break;

                    case 3:////////////////////////////////////// DODAJ LEK /////////////////////////////////////////////////////////////////////////////////////////////
                        Lek lekKreiraj = new Lek();

                        Console.Write("UNESITE IME NOVOG LEKA:     ");
                        lekKreiraj.Ime = Console.ReadLine();

                        Console.Write("UNESITE PROIZVODJACA NOVOG LEKA:     ");
                        lekKreiraj.Proizvodjac = Console.ReadLine();


                        Console.Write("UNESITE SIFRU NOVOG LEKA:     ");
                        string lekKreirajSifra = Console.ReadLine();
                        if (String.IsNullOrEmpty(lekKreirajSifra))
                        {
                            Console.WriteLine();
                            Console.WriteLine("SIFRA NE MOZE DA BUDE PRAZNO POLJE!!!");
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            lekKreiraj.Sifra = lekKreirajSifra;
                        }


                        Console.Write("UNESITE SIFRU NOVOG LEKA:     ");
                        lekKreiraj.Sifra = Console.ReadLine();



                        Console.Write("UNESITE CENU NOVOG LEKA (MORA BITI BROJ):     ");
                        string cenahelp = Console.ReadLine();
                        float lekKreirajcena;
                        while (!float.TryParse(cenahelp, out lekKreirajcena))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE CENU NOVOG LEKA     ");
                            cenahelp = Console.ReadLine();

                        }
                        Console.WriteLine("");
                        lekKreiraj.Cena = lekKreirajcena;

                        Console.Write("DA LI JE POTREBAN RECEPT ZA OVAJ LEK? [y]/[n]:     ");
                        string lekKreirajHelp = Console.ReadLine();

                        while (lekKreirajHelp != "y" && lekKreirajHelp != "n")
                        {
                            Console.WriteLine("POGRESNO DUGME!!!!");
                            lekKreirajHelp = Console.ReadLine();
                        }
                        if (lekKreirajHelp == "n")
                            lekKreiraj.Recept = false;
                        else
                            lekKreiraj.Recept = true;



                        Lek lekKreiran = _lekKontroler.dodavanjeLeka(lekKreiraj);
                        break;

                    case 4:////////////////////////////////////// IZMENI LEK ////////////////////////////////////////////////////////////////////////////
                        Lek lekIzmena = new Lek();
                        Console.WriteLine("U KOLIKO NE ZELITE DA IZMENITE POLJE UNESITE SAMO PRAZAN STRING");
                        Console.WriteLine("");

                        Console.Write("UNESITE SIFRU LEKA KOJI ZELITE DA MENJATE:     ");
                        lekIzmena.Sifra = Console.ReadLine();

                        Console.Write("UNESITE IME LEKA:     ");
                        lekIzmena.Ime = Console.ReadLine();

                        Console.Write("UNESITE PROIZVODJACA LEKA:     ");
                        lekIzmena.Proizvodjac = Console.ReadLine();

                        Console.Write("UNESITE CENU LEKA(MORA BITI BROJ):     ");

                        string cenahelpIzmena = Console.ReadLine();
                        float lekIzmenaCena;
                        if (String.IsNullOrEmpty(cenahelpIzmena))
                        {
                            lekIzmena.Cena = 0;
                        }
                        else
                        {
                            while (!float.TryParse(cenahelpIzmena, out lekIzmenaCena))
                            {

                                Console.WriteLine("MORATE UNETI BROJ ILI PRAZAN STING");
                                Console.WriteLine("");
                                Console.Write("UNESITE CENU LEKA     ");
                                cenahelpIzmena = Console.ReadLine();

                            }
                            Console.WriteLine("");
                            lekIzmena.Cena = lekIzmenaCena;
                        }

                        Console.Write("DA LI JE POTREBAN RECEPT ZA OVAJ LEK? [y]/[n]:     ");
                        string lekIzmenaHelp = Console.ReadLine();
                        while (lekIzmenaHelp != "y" && lekIzmenaHelp != "n")
                        {
                            Console.WriteLine("POGRESNO DUGME!!!!");
                            lekIzmenaHelp = Console.ReadLine();
                        }
                        if (lekIzmenaHelp == "n")
                            lekIzmena.Recept = false;
                        else
                            lekIzmena.Recept = true;
                        Console.WriteLine("");



                        Lek lekIzmenjen = _lekKontroler.izmenaLeka(lekIzmena);
                        break;

                    case 5:////////////////////////////////////// OBRISI LEK ////////////////////////////////////////////////////////////////////////////
                        Console.Write("UNESITE SIFRU LEKA KOJI ZELITE DA OBRISETE:     ");
                        bool proveraBrisanja = _lekKontroler.brisanjeLeka(Console.ReadLine());
                        Console.WriteLine("");
                        break;
                    case 6:////////////////////////////////////// PRODAJA ////////////////////////////////////////////////////////////////////////////
                        Dictionary<string, int> korpa = new Dictionary<string, int>();
                        do
                        {
                            Console.WriteLine("************************************************************************************************************************");
                            Console.WriteLine("PRODAJA");
                            Console.WriteLine("");

                            Console.WriteLine("1. DODAJ LEK UNOSOM SIFRE");
                            Console.WriteLine("2. DODAJ LEK SA RECEPTA");
                            Console.WriteLine("3. PREGLEDAJ KORPU");
                            Console.WriteLine("4. POTVRDI KUPOVINU");
                            Console.WriteLine("999. ODUSTANI");

                            string helpProdaja = Console.ReadLine();
                            Console.WriteLine("");
                            if (!String.IsNullOrEmpty(helpProdaja))
                            {
                                while (!Int32.TryParse(helpProdaja, out caseSwitch4))
                                {
                                    Console.WriteLine("MORATE UNETI BROJ");
                                    Console.WriteLine("");
                                    Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                                    helpProdaja = Console.ReadLine();

                                }
                            }
                            else
                                caseSwitch4 = default;

                            switch (caseSwitch4)
                            {
                                case 1:
                                    do
                                    {
                                        Console.Write("UNESI SIFRU LEKA:     ");
                                        string sifraProdaja = Console.ReadLine();

                                        Console.Write("UNESITE KOLICINU (MORA BITI BROJ):     ");
                                        string kolicinaProdajaHelp = Console.ReadLine();
                                        int kolicinaProdaja;
                                        while (!Int32.TryParse(kolicinaProdajaHelp, out kolicinaProdaja))
                                        {
                                            Console.WriteLine("MORATE UNETI BROJ");
                                            Console.WriteLine("");
                                            Console.Write("UNESITE KOLICINU     ");
                                            kolicinaProdajaHelp = Console.ReadLine();

                                        }
                                        Console.WriteLine("");

                                        Lek lekProdaja = _lekKontroler.dobaviLekPoSifri(sifraProdaja);
                                        if (lekProdaja is null)
                                            break;
                                        else
                                        {
                                            _lekKontroler.dodajLekUKorpu(korpa, kolicinaProdaja, lekProdaja);
                                            Console.WriteLine("DA LI ZELITE DA UNESETE JOS LEKOVA PO SIFRI? [y]/[n]");
                                        }

                                    } while (Console.ReadLine()=="y");
                                    break;

                                case 2:

                                    do
                                    {
                                        Console.Write("UNESITE SIFRU RECEPTA (MORA BITI BROJ):     ");
                                        string receptProdjaSifraHelp = Console.ReadLine();
                                        int receptProdjaSifra;
                                        while (!Int32.TryParse(receptProdjaSifraHelp, out receptProdjaSifra))
                                        {
                                            Console.WriteLine("MORATE UNETI BROJ");
                                            Console.WriteLine("");
                                            Console.Write("UNESITE KOLICINU     ");
                                            receptProdjaSifraHelp = Console.ReadLine();

                                        }
                                        Console.WriteLine("");

                                        Recept recept = _receptKontroler.dobaviReceptPoSifri(receptProdjaSifra);
                                        if(recept is null)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            _lekKontroler.dodajLekSaRecepta(korpa, recept);
                                            Console.WriteLine("DA LI ZELITE DA UNESETE JOS LEKOVA SA RECEPTA? [y]/[n]");

                                        }

                                        

                                    } while (Console.ReadLine() == "y");
                                    break;

                                case 3:
                                    _lekKontroler.prikazKorpe(korpa);
                                    break;


                                case 4:
                                    _lekKontroler.potvrdiProdaju(korpa, ulogovaniKorisnik.Username);
                                    caseSwitch4 = 999;
                                    break;






                                case 999:
                                    Console.WriteLine("PRODAJA JE ZAVRSENA");
                                    Console.WriteLine("");
                                    break;
                                default:
                                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                                    Console.WriteLine("");
                                    break;
                            }

                        } while (caseSwitch4 != 999);


                        break;

                    case 7:////////////////////////////////////// PRIKAZ RECEPATA ////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("IZABERITE NACIN SORTIRANJA");
                        Console.WriteLine("");
                        Console.WriteLine("0. SORTIRANJE PO SIFRI");
                        Console.WriteLine("1. SORTIRANJE PO LEKARU");
                        Console.WriteLine("2. SORTIRANJE PO DATUMU");

                        string help7 = Console.ReadLine();
                        int tipSortiranjaRECEPT;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help7, out tipSortiranjaRECEPT))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help7 = Console.ReadLine();

                        }
                        List<Recept> prikazRecepata = _receptKontroler.prikazRecepata(tipSortiranjaRECEPT);
                        if (prikazRecepata is null)
                        {
                            break;
                        }
                        else
                        {
                            _main.icrtajTabeluRecepata(prikazRecepata);
                            Console.Write("KADA ZAVRSITE PREGLED KORISNIKA ZA NASTAVAK PRITISNITE ENTER");
                            Console.ReadLine();
                            break;

                        }
                    case 8:////////////////////////////////////// PRETRAGA RECEPATA ////////////////////////////////////////////////////////////////////////////
                        do
                        {
                            Console.WriteLine("IZABERITE NACIN PRETRAGE");
                            Console.WriteLine("");
                            Console.WriteLine("1. PRETRAGA PO SIFRI");
                            Console.WriteLine("2. PRETRAGA PO LEKARU");
                            Console.WriteLine("3. PRETRAGA PO JMBG-U PACIJENTA");
                            Console.WriteLine("4. PRETRAGA PO JEDNOM LEKU");
                            Console.WriteLine("999. PEKID PRETRAGE");
                            Console.WriteLine("");

                            string help11 = Console.ReadLine();
                            Console.WriteLine("");
                            if (!String.IsNullOrEmpty(help11))
                            {
                                while (!Int32.TryParse(help11, out caseSwitch10))
                                {
                                    Console.WriteLine("MORATE UNETI BROJ");
                                    Console.WriteLine("");
                                    Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                                    help11 = Console.ReadLine();

                                }
                            }
                            else
                                caseSwitch10 = default;

                            switch (caseSwitch10)
                            {
                                case 1:

                                    Console.Write("UNESITE SIFRU (MORA BITI BROJ)     ");
                                    string sifraReceptPretragaHelp = Console.ReadLine();
                                    int sifraReceptPretraga;
                                    while (!Int32.TryParse(sifraReceptPretragaHelp, out sifraReceptPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MINIMALNU CENU     ");
                                        sifraReceptPretragaHelp = Console.ReadLine();
                                    }
                                    Console.WriteLine("");

                                    Recept receptSifra = _receptKontroler.dobaviReceptPoSifri(sifraReceptPretraga);
                                    List<Recept> receptSifraLista = new List<Recept>();
                                    receptSifraLista.Add(receptSifra);
                                    if (receptSifra is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptSifraLista);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 2:
                                    Console.Write("UNESITE IME LEKARA     ");
                                    string lekarReceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Recept> receptLekar = _receptKontroler.dobavireceptpoLekaru(lekarReceptPretraga);
                                    if (receptLekar is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptLekar);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 3:
                                    Console.Write("UNESITE JMBG PACIJENTA     ");
                                    string jmbgreceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");
                                    while (!_korisnikKontroler.ValidacijaJmbg(jmbgreceptPretraga))
                                    {
                                        Console.WriteLine("");
                                        Console.Write("UNESITE JMBG PACIJENTA     ");
                                        jmbgreceptPretraga = Console.ReadLine();
                                    }

                                    List<Recept> receptJmbg = _receptKontroler.dobaviReceptPoJmbg(jmbgreceptPretraga);
                                    if (receptJmbg is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptJmbg);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;

                                    }


                                case 4:
                                    Console.Write("UNESITE IME LEKA     ");
                                    string lekReceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Recept> receptLek = _receptKontroler.dobaviReceptPoLeku(lekReceptPretraga);
                                    if (receptLek is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptLek);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }
                                default:
                                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                                    Console.WriteLine("");
                                    break;

                                case 999:
                                    Console.WriteLine("PREKINULI STE PRETRAGU");
                                    Console.WriteLine("");
                                    break;
                            }
                        } while (caseSwitch10 != 999);

                        break;



                    case 999:///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("IZLOGOVALI STE SE");
                        Console.WriteLine("");
                        break;
                    default:///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("NISTE UNELI DOBAR BROJ");
                        Console.WriteLine("");
                        break;

                }

            } while (caseSwitch != 999);

        }

        public void LekarView(Korisnik ulogovaniKorisnik)/////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
                                                         /////////////////////////////////////////////////////////////////////////////
        {
            KorisnikKontroler _korisnikKontroler = new KorisnikKontroler();
            LekKontroler _lekKontroler = new LekKontroler();
            RacunKontroler _racunKontroler = new RacunKontroler();
            ReceptKontroler _receptKontroler = new ReceptKontroler();
            Mainn _main = new Mainn();

            int caseSwitch;
            int caseSwitch5;
            int caseSwitch10;



            do
            {

                Console.WriteLine("********************************************************************************");
                Console.WriteLine("ULOGOVANI STE KAO LEKAR");
                Console.WriteLine("");
                Console.WriteLine("1. KREIRANJE RECEPTA");
                Console.WriteLine("2. PREGLED SVIH LEKOVA");
                Console.WriteLine("3. PETRAGA LEKOVA");
                Console.WriteLine("4. PREGLED SVIH RECEPATA");
                Console.WriteLine("5. PRETRAGA RECEPATA");

                Console.WriteLine("999. IZLOGUJ SE");
                Console.WriteLine("");
                Console.WriteLine("UPRAVLJATE APLIKACIJOM TAKO STO UKUCATE NEKI OD REDNIH BROJEVA KOJI VIDITE IZNAD I KLIKNETE ENTER");
                Console.WriteLine("");



                string help = Console.ReadLine();
                Console.WriteLine("");
                if (!String.IsNullOrEmpty(help))
                {
                    while (!Int32.TryParse(help, out caseSwitch))
                    {
                        Console.WriteLine("MORATE UNETI BROJ");
                        Console.WriteLine("");
                        Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                        help = Console.ReadLine();

                    }
                }
                else
                    caseSwitch = default;

                switch (caseSwitch)
                {
                    case 1://///////////////////////////////////// KREIRANJE RECEPTA ///////////////////////////////////////////////////////////
                        Dictionary<String, int> lekovi = new Dictionary<String, int>();
                        Recept receptKreiran = new Recept(lekovi);

                        Console.Write("UNESITE JMBG PACIJENTA:     ");
                        string receptKreiranJmbgPacijentaHelp = Console.ReadLine();
                        Console.WriteLine("");
                        while (!_korisnikKontroler.ValidacijaJmbg(receptKreiranJmbgPacijentaHelp))
                        {
                            Console.WriteLine("");
                            Console.Write("UNESITE JMBG PACIJENTA     ");
                            receptKreiranJmbgPacijentaHelp = Console.ReadLine();
                        }
                        receptKreiran.JmbgPacijenta = receptKreiranJmbgPacijentaHelp;
 
                        Console.Write("UNESITE DATUM I VREME U FORMATU yyyy-mm-dd hh:mm:32.8     ");
                        string datumHelp = Console.ReadLine();
                        DateTime datum;
                        while(!DateTime.TryParse(datumHelp, out datum))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("UNELI STE DATUM POGRESNO");
                            Console.Write("UNESITE DATUM I VREME U FORMATU MM/DD/YYYY HH:MM:     ");
                            datumHelp = Console.ReadLine();
                            Console.WriteLine("");
                        }
                        receptKreiran.Datum = datum;



                        Console.WriteLine("UNESITE SPISAK LEKOVA:");
                        Console.WriteLine("");
                        string control;
                        do
                        {
                            string ime;
                            int kolicina;
                            string koliicnHelp;
                            int controlLek = 0;

                            List<Lek> lekoviProvera = _lekKontroler.prikazSvihLekova(0);
                            if(lekoviProvera is null)
                            {
                                break;
                            }
                            else
                            {
                                List<Lek> lekoviProveraNeObrisani = new List<Lek>();

                                foreach (Lek lek in lekoviProvera)
                                {
                                    if (lek.Obrisan == false)
                                    {
                                        lekoviProveraNeObrisani.Add(lek);
                                    }
                                }

                                Console.Write("IME LEKA:     ");
                                ime = Console.ReadLine();



                                foreach (Lek lek in lekoviProveraNeObrisani)
                                {
                                    if (ime == lek.Ime)
                                    {
                                        controlLek = 1;
                                    }
                                }

                                while (controlLek == 0)
                                {
                                    Console.WriteLine("UNELI STE LEK KOJI NE POSTOJI U SISTEMU ILI JE OBRISAN, PROBAJTE PONOVO!!!");
                                    Console.WriteLine("");
                                    Console.Write("IME LEKA:     ");
                                    ime = Console.ReadLine();



                                    foreach (Lek lek in lekoviProveraNeObrisani)
                                    {
                                        if (ime == lek.Ime)
                                        {
                                            controlLek = 1;
                                        }
                                    }

                                }

                            }
                             
                            



                            Console.Write("UNESITE KOLICINU (MORA BITI BROJ):     ");
                            koliicnHelp = Console.ReadLine();
                            while (!Int32.TryParse(koliicnHelp, out kolicina))
                            {
                                Console.WriteLine("MORATE UNETI BROJ");
                                Console.WriteLine("");
                                Console.Write("UNESITE KOLICINU     ");
                                koliicnHelp = Console.ReadLine();
                            }
                            receptKreiran.Lekovi.Add(ime, kolicina);

                            Console.Write("DA LI ZELITE DA UNESETE JOS LEKOVA? [y]/[n]     ");
                            control = Console.ReadLine();
                            Console.WriteLine("");

                        } while (control == "y");

                        receptKreiran.Lekar = ulogovaniKorisnik.Username;

                        
                        List<Recept> sviRecepti = _receptKontroler.prikazRecepata(0);
                        bool provera = _receptKontroler.receptiPostoje();
                        if (provera is false)
                            receptKreiran.Sifra = 1;
                        else
                            receptKreiran.Sifra = sviRecepti.Last().Sifra + 1;

                        Recept rec = _receptKontroler.kreiranjeRecepta(receptKreiran);
                        break;

                    case 2:/// ////////////////////////////   PREGLED LEKOVA   ////////////////////////////////////////////////////////////////////////////////////////////////

                        Console.WriteLine("IZABERITE NACIN SORTIRANJA");
                        Console.WriteLine("");
                        Console.WriteLine("0. SORTIRANJE PO IMENU");
                        Console.WriteLine("1. SORTIRANJE PO PROIZVODJACU");
                        Console.WriteLine("2. SORTIRANJE PO CENI");

                        string help4 = Console.ReadLine();
                        int tipSortiranjaLek;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help4, out tipSortiranjaLek))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help4 = Console.ReadLine();

                        }

                        List<Lek> prikazLeka = _lekKontroler.prikazSvihLekova(tipSortiranjaLek);
                        if (prikazLeka is null)
                        {
                            break;
                        }
                        else
                        {
                            List<Lek> lekoviBezObrisanih=new List<Lek>();
                            foreach(Lek lek in prikazLeka)
                            {
                                if(lek.Obrisan==false)
                                {
                                    lekoviBezObrisanih.Add(lek);
                                }
                            }

                            if(!lekoviBezObrisanih.Any())
                            {
                                Console.WriteLine("SVI LEKOVI SU OBRISANI");
                                Console.WriteLine("");
                                break;
                            }
                            else
                            {
                                _main.icrtajTabeluLek(lekoviBezObrisanih);
                                Console.Write("KADA ZAVRSITE PREGLED LEKOVA ZA NASTAVAK PRITISNITE ENTER");
                                Console.ReadLine();
                                break;
                            }
                            

                        }

                    case 3:// /////////////////////////////   PRETRAGA LEKOVA   ///////////////////////////////////////////////////////////////////////////////////////////////
                        do
                        {
                            Console.WriteLine("IZABERITE NACIN PRETRAGE");
                            Console.WriteLine("");
                            Console.WriteLine("1. PRETRAGA PO SIFRI");
                            Console.WriteLine("2. PRETRAGA PO IMENU");
                            Console.WriteLine("3. PRETRAGA PO PROIZVODJACU");
                            Console.WriteLine("4. PRETRAGA PO OPSEGU CENE");
                            Console.WriteLine("999. PEKID PRETRAGE");
                            Console.WriteLine("");

                            string help1 = Console.ReadLine();
                            Console.WriteLine("");
                            if (!String.IsNullOrEmpty(help1))
                            {
                                while (!Int32.TryParse(help1, out caseSwitch5))
                                {
                                    Console.WriteLine("MORATE UNETI BROJ");
                                    Console.WriteLine("");
                                    Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                                    help1 = Console.ReadLine();

                                }
                            }
                            else                                
                                caseSwitch5 = default;

                            switch (caseSwitch5)
                            {
                                case 1:

                                    Console.Write("UNESITE SIFRU     ");
                                    string sifraLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");
                                    Lek lekSifra = _lekKontroler.dobaviLekPoSifri(sifraLekPretraga);
                                    List<Lek> lekSifraList = new List<Lek>();
                                    lekSifraList.Add(lekSifra);
                                    if (lekSifra is null)
                                    {
                                        break;
                                    }
                                    else if(lekSifra.Obrisan==true)
                                    {
                                        Console.WriteLine("TRAZENI LEK JE OBRISAN!!!");
                                        Console.WriteLine("");
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluLek(lekSifraList);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 2:
                                    Console.Write("UNESITE IME     ");
                                    string ImeLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Lek> lekIme = _lekKontroler.dobaviLekPoImenu(ImeLekPretraga);


                                    if (lekIme is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        List<Lek> lekoviBezObrisanih = new List<Lek>();
                                        foreach (Lek lek in lekIme)
                                        {
                                            if (lek.Obrisan == false)
                                            {
                                                lekoviBezObrisanih.Add(lek);
                                            }
                                        }

                                        if (!lekoviBezObrisanih.Any())
                                        {
                                            Console.WriteLine("SVI LEKOVI SA DATIM IMENOM SU OBRISANI");
                                            Console.WriteLine("");
                                            break;
                                        }
                                        else
                                        {
                                            _main.icrtajTabeluLek(lekoviBezObrisanih);
                                            Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                            Console.ReadLine();
                                            break;
                                        }

                                        
                                    }


                                case 3:
                                    Console.Write("UNESITE IME PROIZVODJACA     ");
                                    string ProizLekPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Lek> lekPro = _lekKontroler.dobaviLekPoProizvodjacu(ProizLekPretraga);
                                    if (lekPro is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        List<Lek> lekoviBezObrisanih = new List<Lek>();
                                        foreach (Lek lek in lekPro)
                                        {
                                            if (lek.Obrisan == false)
                                            {
                                                lekoviBezObrisanih.Add(lek);
                                            }
                                        }

                                        if (!lekoviBezObrisanih.Any())
                                        {
                                            Console.WriteLine("SVI LEKOVI OD DATOG PROIZVODJACA SU OBISANI");
                                            Console.WriteLine("");
                                            break;
                                        }
                                        else
                                        {
                                            _main.icrtajTabeluLek(lekoviBezObrisanih);
                                            Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                            Console.ReadLine();
                                            break;
                                        }


                                            

                                    }


                                case 4:
                                    Console.Write("UNESITE MINIMALNU CENU (MORA BITI BROJ)     ");
                                    string minLekPretragahelp = Console.ReadLine();
                                    float minLekPretraga;
                                    while (!float.TryParse(minLekPretragahelp, out minLekPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MINIMALNU CENU     ");
                                        minLekPretragahelp = Console.ReadLine();

                                    }
                                    Console.WriteLine("");

                                    Console.Write("UNESITE MAXIMALNU CENU (MORA BITI BROJ)     ");
                                    string maxLekPretragahelp = Console.ReadLine();
                                    float maxLekPretraga;
                                    while (!float.TryParse(maxLekPretragahelp, out maxLekPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MAXIMALNU CENU     ");
                                        maxLekPretragahelp = Console.ReadLine();

                                    }
                                    Console.WriteLine("");



                                    List<Lek> cenaIme = _lekKontroler.dobaviLekPoCeni(minLekPretraga, maxLekPretraga);
                                    if (cenaIme is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        List<Lek> lekoviBezObrisanih = new List<Lek>();
                                        foreach (Lek lek in cenaIme)
                                        {
                                            if (lek.Obrisan == false)
                                            {
                                                lekoviBezObrisanih.Add(lek);
                                            }
                                        }

                                        if (!lekoviBezObrisanih.Any())
                                        {
                                            Console.WriteLine("SVI LEKOVI U DATOM OPSEGU CENE SU OBRISANI");
                                            Console.WriteLine("");
                                            break;
                                        }
                                        else
                                        {
                                            _main.icrtajTabeluLek(lekoviBezObrisanih);
                                            Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                            Console.ReadLine();
                                            break;
                                        }

                                    }

                                default:
                                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                                    Console.WriteLine("");
                                    break;

                                case 999:
                                    Console.WriteLine("PREKINULI STE PRETRAGU");
                                    Console.WriteLine("");
                                    break;
                            }
                        } while (caseSwitch5 != 999);

                        break;

                    case 4:////////////////////////////////////// PRIKAZ RECEPATA ////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("IZABERITE NACIN SORTIRANJA");
                        Console.WriteLine("");
                        Console.WriteLine("0. SORTIRANJE PO SIFRI");
                        Console.WriteLine("1. SORTIRANJE PO LEKARU");
                        Console.WriteLine("2. SORTIRANJE PO DATUMU");



                        string help7 = Console.ReadLine();
                        int tipSortiranjaRECEPT;
                        Console.WriteLine("");

                        while (!Int32.TryParse(help7, out tipSortiranjaRECEPT))
                        {
                            Console.WriteLine("MORATE UNETI BROJ");
                            Console.WriteLine("");
                            Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                            help7 = Console.ReadLine();

                        }

                        List<Recept> prikazRecepata = _receptKontroler.prikazRecepata(tipSortiranjaRECEPT);
                        if (prikazRecepata is null)
                        {
                            break;
                        }
                        else
                        {
                            _main.icrtajTabeluRecepata(prikazRecepata);
                            Console.Write("KADA ZAVRSITE PREGLED KORISNIKA ZA NASTAVAK PRITISNITE ENTER");
                            Console.ReadLine();
                            break;

                        }
                    case 5:////////////////////////////////////// PRETRAGA RECEPATA ////////////////////////////////////////////////////////////////////////////
                        do
                        {
                            Console.WriteLine("IZABERITE NACIN PRETRAGE");
                            Console.WriteLine("");
                            Console.WriteLine("1. PRETRAGA PO SIFRI");
                            Console.WriteLine("2. PRETRAGA PO LEKARU");
                            Console.WriteLine("3. PRETRAGA PO JMBG-U PACIJENTA");
                            Console.WriteLine("4. PRETRAGA PO JEDNOM LEKU");
                            Console.WriteLine("999. PEKID PRETRAGE");
                            Console.WriteLine("");

                            string help11 = Console.ReadLine();
                            Console.WriteLine("");
                            if (!String.IsNullOrEmpty(help11))
                            {
                                while (!Int32.TryParse(help11, out caseSwitch10))
                                {
                                    Console.WriteLine("MORATE UNETI BROJ");
                                    Console.WriteLine("");
                                    Console.Write("UNESITE BROJ OPCIJE KOJU ZELITE     ");
                                    help11 = Console.ReadLine();

                                }
                            }
                            else
                                caseSwitch10 = default;

                            switch (caseSwitch10)
                            {
                                case 1:

                                    Console.Write("UNESITE SIFRU (MORA BITI BROJ)     ");
                                    string sifraReceptPretragaHelp = Console.ReadLine();
                                    int sifraReceptPretraga;
                                    while (!Int32.TryParse(sifraReceptPretragaHelp, out sifraReceptPretraga))
                                    {
                                        Console.WriteLine("MORATE UNETI BROJ");
                                        Console.WriteLine("");
                                        Console.Write("UNESITE MINIMALNU CENU     ");
                                        sifraReceptPretragaHelp = Console.ReadLine();
                                    }                                            
                                    Console.WriteLine("");

                                    Recept receptSifra = _receptKontroler.dobaviReceptPoSifri(sifraReceptPretraga);
                                    List<Recept> receptSifraLista = new List<Recept>();
                                    receptSifraLista.Add(receptSifra);
                                    if (receptSifra is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptSifraLista);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 2:
                                    Console.Write("UNESITE IME LEKARA     ");
                                    string lekarReceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Recept> receptLekar = _receptKontroler.dobavireceptpoLekaru(lekarReceptPretraga);
                                    if (receptLekar is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptLekar);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }


                                case 3:
                                    Console.Write("UNESITE JMBG PACIJENTA     ");
                                    string jmbgreceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");
                                    while (!_korisnikKontroler.ValidacijaJmbg(jmbgreceptPretraga))
                                    {
                                        Console.WriteLine("");
                                        Console.Write("UNESITE JMBG PACIJENTA     ");
                                        jmbgreceptPretraga = Console.ReadLine();
                                    }

                                    List<Recept> receptJmbg = _receptKontroler.dobaviReceptPoJmbg(jmbgreceptPretraga);
                                    if (receptJmbg is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptJmbg);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;

                                    }


                                case 4:
                                    Console.Write("UNESITE IME LEKA     ");
                                    string lekReceptPretraga = Console.ReadLine();
                                    Console.WriteLine("");

                                    List<Recept> receptLek = _receptKontroler.dobaviReceptPoLeku(lekReceptPretraga);
                                    if (receptLek is null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        _main.icrtajTabeluRecepata(receptLek);
                                        Console.Write("KADA ZAVRSITE PREGLED VASE PRETRAGE PRITISNITE ENTER");
                                        Console.ReadLine();
                                        break;
                                    }
                                default:
                                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                                    Console.WriteLine("");
                                    break;

                                case 999:
                                    Console.WriteLine("PREKINULI STE PRETRAGU");
                                    Console.WriteLine("");
                                    break;
                            }
                        } while (caseSwitch10 != 999);

                        break;








                    case 999:///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("IZLOGOVALI STE SE");
                        Console.WriteLine("");
                        break;
                    default:///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine("NISTE UNELI DOBAR BROJ");
                        Console.WriteLine("");
                        break;
                }

            } while (caseSwitch != 999);
        }

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

        

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //ISCRTAVANJE TABELE


        public void icrtajTabeluKorisnik(List<Korisnik> args)
        {
            
            var table = new ConsoleTable("Ime", "Prezime", "Username","Tip Korisnika");
            foreach(Korisnik korisnik in args)
            {
                table.AddRow(korisnik.Ime, korisnik.Prezime, korisnik.Username, korisnik.TipKorisnika);
            }
            table.Write();
            Console.WriteLine();


            //ConsoleTable.From<Korisnik>(args).Write();
        }

        public void icrtajTabeluLek(List<Lek> args)
        {
            ConsoleTable.From<Lek>(args).Write();


        }

        public void icrtajTabeluRecepata(List<Recept> args)
        {
            
            foreach (Recept recept in args)
            {
                Console.WriteLine("************************************************************************************************************************");
                var table = new ConsoleTable("SIFRA", "LEKAR", "DATUM", "JMBG PACIJENTA");
                table.AddRow(recept.Sifra, recept.Lekar, recept.Datum, recept.JmbgPacijenta);                
                table.Write();
                Console.WriteLine();

                Console.WriteLine("          LEKOVI NA RECEPTU:");
                foreach (KeyValuePair<String, int> lek in recept.Lekovi)
                {
                    Console.WriteLine(lek);
                }
                Console.WriteLine("");
                Console.WriteLine("");

                /*
                Console.Write("SIFRA:                        ");
                Console.WriteLine(recept.Sifra);
                Console.Write("LEKAR:                        ");
                Console.WriteLine(recept.Lekar);
                Console.Write("DATUM:                        ");
                Console.WriteLine(recept.Datum);
                Console.Write("JMBG PACIJENTA:               ");
                Console.WriteLine(recept.JmbgPacijenta);
                Console.WriteLine("          LEKOVI NA RECEPTU:");
                foreach (KeyValuePair<String, int> lek in recept.Lekovi)
                {
                    Console.WriteLine(lek);
                }
                Console.WriteLine("");
                Console.WriteLine("");*/
            }

            


        }
    }
}
