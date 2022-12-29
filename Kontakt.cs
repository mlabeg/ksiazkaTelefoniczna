using Gebal.UITools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ksiazkaTelefoniczna
{
    class KsiazkaTelefoniczna
    {
        List<Kontakt> kontaktList=new List<Kontakt>();

        public void podajKontakt()
        {
            int numer;
            string nazwa;

            do
            {
                Console.WriteLine("Podaj nazwe: ");
                nazwa = Console.ReadLine();
            }while(!regexNazwa(nazwa));
            
            do
            {
                Console.Write("Podaj numer telefonu: ");
                numer = int.Parse(Console.ReadLine());
            } while (!regexNumer(numer));
            
            kontaktList.Add(new Kontakt(nazwa, numer));
        }
        public bool regexNazwa(string nazwa)
        {
            Regex regexNazwa = new Regex(@"(\w){3,}");
            if (!regexNazwa.IsMatch(nazwa)){
                Console.WriteLine("Nieprawidlowa nazwa.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool regexNumer(int numer)
        {
            Regex regexNumer = new Regex(@"(\d){9,12}");
            if (!regexNumer.IsMatch(numer.ToString()))
            {
                Console.WriteLine("Nieprawidlowy numer.");
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public void dodajKontakt(string nazwa, int numer)
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
            wyswietlKontakty(kontaktList);

        }
        /// <summary>
        /// TODO:
        /// rozbudowanie metody wyswietlWszystkieKontakty() o "edytuj", "usun", anuluj
        /// </summary>
        /// <returns></returns>
        private int menuKontaktow()
            //zastanawiam się czy jest możliwość, żeby menuKkontaktow() wywoływać tylko raz, nie za każdym razem jak wywołamy jakąś nadrzędną fukcję
                //żeby była to "właściwość klasy", a nie danej funkcji
        {
            string [] kontakty=new string[] { };//!!
            ///TODO:
            ///tu wyrzuca błąd - odwołanie się poza zakres tablicy
            ///rozważyć użycie StringBuildera
            for(int i=0;i<kontaktList.Count;i++)
            {
                kontakty[i] = kontaktList[i].ToString();
            }

            Menu kontaktow = new Menu();
            kontaktow.Konfiguruj(kontakty);
            return kontaktow.Wyswietl();
        }

        public void wyswietlPoNumerze(int numer)
        {
            bool czyJest = false;
            foreach(Kontakt kontakt in kontaktList)
            {
                if (kontakt.numer == numer)
                {
                    wyswietlKontakt(kontakt);
                    czyJest = true;
                }
            }
            if(!czyJest)
            {
                Console.WriteLine("Nie znaleziono w bazie!");
            }
        }
        public void poNumerze()
        {
            Console.Write("Podaj numer: ");
            int numer = int.Parse(Console.ReadLine());
            var kontakt=kontaktList.FirstOrDefault(e=>e.numer==numer);
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
            string szukanaFraza=Console.ReadLine();
             var pasujaceKontakty=kontaktList.Where(e=>e.nazwa.Contains(szukanaFraza)).ToList();
            
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
        internal void usunKontakt()
        {
           usun(menuKontaktow());

        }

        internal void usun(int wybor)
        {
            kontaktList.Remove(kontaktList[wybor]);
        }
    }
    class Kontakt
    {
        string Nazwa;
        int Numer;

        internal string nazwa { get { return Nazwa; } }
        internal int numer { get { return Numer; } }

        internal Kontakt(string nazwa, int numer)
        {
            Nazwa= nazwa;
            Numer= numer;
        }

    }
    
}
