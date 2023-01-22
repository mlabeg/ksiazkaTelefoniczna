using Gebal.UITools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ksiazkaTelefoniczna
{
    class KsiazkaTelefoniczna
    {
        List<Kontakt> kontaktList = new List<Kontakt>();
        OstatnioWybrane ostatnioWybrane = new OstatnioWybrane();
        List<Kontakt> ulubioneKontakty;
       
        public void dodaj()//tej funkcji używasz w Program
        {
            Kontakt nowy;
            Console.WriteLine("Gdzie zapiac kontakt? ");
            Menu menu = new Menu();
            menu.Konfiguruj(new string[] { "SIM", "REMOTE", "NA URZĄDZENIU" });

            int wybor;
            
                wybor = menu.Wyswietl();
                switch (wybor)
                {
                //to wszystko są wywołania statyczne, pomyśl o tym co zrobić żeby były dynamiczne
                    //sprawdź definicję wywołania statycznego/dynamicznego
                    case 0:
                        nowy= new Kontakt();
                    if (nowy.dodajKontakt())
                    {
                        kontaktList.Add(nowy);
                    }
                    else
                    {
                        Console.WriteLine("Nie udało się dodać kontaktu!");
                    }
                                            
                        break;
                    case 1:
                    nowy = new KontaktREMOTE();
                    if (nowy.dodajKontakt())
                    {
                        kontaktList.Add(nowy);
                    }
                    else
                    {
                        Console.WriteLine("Nie udało się dodać kontaktu!");
                    }
                    break;
                    case 2:
                    nowy = new KontaktPHONE();
                    if (nowy.dodajKontakt())
                    {
                        kontaktList.Add(nowy);
                    }
                    else
                    {
                        Console.WriteLine("Nie udało się dodać kontaktu!");
                    }
                    break;
                    default:
                        break;
                 }
            kontaktList.Sort((x,y)=>x.nazwa.CompareTo(y.nazwa));

        }

        public void dodajViaConsole(Kontakt kontakt)
        {
            kontaktList.Add(kontakt);
        }
        public void dodajKontakt(string nazwa, string numer)
        {

            if (true)/*regexNazwa(nazwa) & regexNumer(numer)*/
            {
                kontaktList.Add(new Kontakt(nazwa, numer));
                Console.WriteLine($"Pomyslnie dodano kontakt {nazwa}");
            }
            else
            {
                Console.WriteLine("Dodanie kontaktu nie powiodło się!");
                Console.ReadKey();
            }
        }

        void wyswietlKontakt(Kontakt kontakt)
        {
            Console.WriteLine($"Kontakt: {kontakt.nazwa}, {kontakt.numer}");
        }
        void wyswietlKontakty(List<Kontakt> kontakty)
        {
            if (kontakty.Count == 0)
            {
                Console.WriteLine("Brak dopasowań!");
            }
            else
            {
                foreach (Kontakt kontakt in kontakty)
                {
                    wyswietlKontakt(kontakt);
                }
                Console.ReadKey();
            }

        }

        public void wyswietlWszystkieKontakty()
        {
            if(kontaktList.Count != 0)
            {
                szczegoly(menuKontaktow());
            }
            else
            {
                Console.WriteLine("Brak pozycji do wyswietlenia!");
                Console.ReadKey();
            }
        }
        
        private int menuKontaktow()
            //nie ruszaj tej metody, jest używana równie przez metodę usun()
        //zastanawiam się czy jest możliwość, żeby menuKkontaktow() wywoływać tylko raz, nie za każdym razem jak wywołamy jakąś nadrzędną fukcję
        //żeby była to "właściwość klasy", a nie danej funkcji //<- właśnie wydaje mi się,
        ////że nie, bo o to chodzi w menu, że trzeba je wywołać za każdym razem
        {
            List<string> kontakty = new List<string>();
                for (int i = 0; i < kontaktList.Count; i++)
                {
                    kontakty.Add(kontaktList[i].nazwa.ToString() + " " + kontaktList[i].numer.ToString());

                }

                Menu kontaktow = new Menu();
                kontaktow.Konfiguruj(kontakty);
                return kontaktow.Wyswietl();
        }
                
        private void szczegoly(int wybrany)
        {
            Menu szczegoly=new Menu();
          
            szczegoly.Konfiguruj(new string[] { "Zadzwoń", "Wyswietl pelne dane", "Edytuj", "Usun" });
               
            int wyswietl=szczegoly.Wyswietl(wybrany);
            if (wyswietl >= 0)
            {
                switch (wyswietl)
                {
                    case 0:
                        //zadzwon(kontaktList[wybrany]);
                        kontaktList[wybrany].zadzwon();
                        ostatnioWybrane.dodajPolaczenie(kontaktList[wybrany]);
                        break;
                    case 1:
                        kontaktList[wybrany].wyswietl();
                        break;
                    case 2:
                        kontaktList[wybrany].edytujKontakt();
                        break;
                    case 3:
                        kontaktList.RemoveAt(wybrany);
                        break;
                    default:
                        break;
                }
            }

        }

       /* private void zadzwon(Kontakt kontakt)
        {
            kontakt.zadzwon();
            ostatnioWybrane.dodajPolaczenie(kontakt);
        }*/

        public void poNumerze()
        {
            Console.Write("Podaj numer: ");
            string numer = Console.ReadLine();
            var kontakt = kontaktList.FirstOrDefault(e => e.numer == numer);
            if (kontakt == null)
            {
                Console.WriteLine("Nie znaleziono kontaktu!");
            }
            else
            {
                wyswietlKontakt(kontakt);

            }
        }
        /// <summary>
        /// TODO:
        /// można pobawić się w wyszukiwanie kontaktów w czasie wpisywania kolejnych cyfr
        /// nie wiem tylko jak wyjść z takiej...    -> Console.ReadKey()==Key.DownArrow;...
        /// </summary>
        public void poNazwie()
        {
            Console.Write("Podaj szukany kontakt: ");
            string szukanaFraza = Console.ReadLine();
            var pasujaceKontakty = kontaktList.Where(e => e.nazwa.Contains(szukanaFraza)).ToList();

            wyswietlKontakty(pasujaceKontakty);
        }

        public void exit()
        {
            Console.Clear();
        }

        internal void usunKontakt()
        {
            if (kontaktList.Count != 0)
            {
                int wybor = menuKontaktow();
                if (wybor != -1)
                {
                    kontaktList.Remove(kontaktList[wybor]);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Brak kontaktów do usunięcia!");
                Console.ReadKey();
            }
            
           
        }

        internal void ostatnioWybierane()
        {
            if (!ostatnioWybrane.czyPuste()) ostatnioWybrane.menuOstatnioWybrane();
            else
            {
                Console.Clear();
                Console.WriteLine("Brak pozycji do wyświetlenia!");
                Console.ReadKey();
            }
        }

        internal void ulubione()
            //pomyśleć czy nie zrobić z tego klasy
        {
            throw new NotImplementedException();
        }
    }
}
