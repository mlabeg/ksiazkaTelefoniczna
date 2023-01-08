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

        public void podajKontakt()
        {
            string numer;
            string nazwa;

            do
            {
                Console.WriteLine("Podaj nazwe: ");
                nazwa = Console.ReadLine();
            } while (!regexNazwa(nazwa));

            do
            {
                Console.Write("Podaj numer telefonu: ");
                numer = Console.ReadLine();
            } while (!regexNumer(numer));

            kontaktList.Add(new Kontakt(nazwa, numer));
            Console.WriteLine($"Pomyslnie dodano kontakt {nazwa}");
        }
        private bool regexNazwa(string nazwa)
        {
            Regex regexNazwa = new Regex(@"(\w){3,}");
            if (!regexNazwa.IsMatch(nazwa))
            {
                Console.WriteLine("Nieprawidlowa nazwa.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool regexNumer(string numer)
        {
            Regex regexNumer = new Regex(@"(\d){9,12}");
            if (!regexNumer.IsMatch(numer))
            {
                Console.WriteLine("Nieprawidlowy numer.");
                return false;
            }
            else
            {
                return true;
            }

        }

        public void dodaj()
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

                    case 0:
                        nowy= new Kontakt();
                    if (nowy.dodajKontakt())
                    {
                        kontaktList.Add(nowy);
                    }
                                            
                        break;
                    case 1:
                    nowy = new KontaktREMOTE();
                    if (nowy.dodajKontakt())
                    {
                        kontaktList.Add(nowy);
                    }
                    break;
                    case 2:
                    nowy = new KontaktPHONE();
                    if (nowy.dodajKontakt())
                    {
                        kontaktList.Add(nowy);
                    }
                    break;
                    default:
                        break;
                 }
           

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
            //wyswietlKontakty(kontaktList);
            menuKontaktow();

        }
        /// <summary>
        /// TODO:
        /// rozbudowanie metody wyswietlWszystkieKontakty() o "zadzwoń" "wyświeet szczegóły"
        /// "edytuj", "usun", anuluj
        /// </summary>
        /// <returns></returns>
        private int menuKontaktow()
        //zastanawiam się czy jest możliwość, żeby menuKkontaktow() wywoływać tylko raz, nie za każdym razem jak wywołamy jakąś nadrzędną fukcję
        //żeby była to "właściwość klasy", a nie danej funkcji //<- właśnie wydaje mi się, że nie, bo o to chodzi w menu, że trzeba je wywołać za każdym razem
        ///
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

        public void wyswietlPoNumerze(string numer)
        {
            bool czyJest = false;
            foreach (Kontakt kontakt in kontaktList)
            {
                if (kontakt.numer == numer)
                {
                    wyswietlKontakt(kontakt);
                    czyJest = true;
                }
            }
            if (!czyJest)
            {
                Console.WriteLine("Nie znaleziono w bazie!");
            }
        }
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
                //Console.WriteLine($"Kontakt: {kontakt.nazwa}, {kontakt.numer}")  ;

            }
        }
        /// <summary>
        /// TODO:
        /// można pobawić się w wyszukiwanie kontaktów w czasie wpisywania kolejnych cyfr
        /// nie wiem tylko jak wyjść z takiej...    -> Console.ReadKey()==Key.DownArrow;...
        /// </summary>
        /*public void numerze()
        {
            char znak;
            string szukanyNumer;
            Console.Write("Podaj numer: ");
            do
            {
                znak = Console.Read();
            } while (znak != 0);
            
        }*/

        public void poNazwie()
        {
            Console.Write("Podaj szukany kontakt: ");
            string szukanaFraza = Console.ReadLine();
            var pasujaceKontakty = kontaktList.Where(e => e.nazwa.Contains(szukanaFraza)).ToList();

            wyswietlKontakty(pasujaceKontakty);
        }


        public void wyswietlPoNazwie(string nazwa)
        {
            bool czyJest = false;
            foreach (Kontakt kontakt in kontaktList)
            {
                if (kontakt.nazwa == nazwa)
                {
                    Console.WriteLine(kontakt.numer + " " + kontakt.nazwa);
                    czyJest = true;
                }
            }
            if (!czyJest)
            {
                Console.WriteLine("Nie znaleziono w bazie!");
            }
        }

        public void exit()
        {
            Console.Clear();
        }

        /*internal void ()
        {
            usun(menuKontaktow());

        }*/

        internal void usunKontakt()
        {
            int wybor = menuKontaktow();
            if (wybor != -1)
            {
                kontaktList.Remove(kontaktList[wybor]);
            }
           
        }
    }
}
