using Gebal.UITools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ksiazkaTelefoniczna
{
    class KsiazkaTelefoniczna:listaTel
    {
        public int liczbaKontaktów = 0;//potrzebne do asocjacji
        public KsiazkaTelefoniczna() : base() { }
                       
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
            kontaktList.Add(new Kontakt(nazwa, numer));
            Console.WriteLine($"Pomyslnie dodano kontakt {nazwa}");
           
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
                    Console.WriteLine($"Kontakt: {kontakt.nazwa}, {kontakt.numer}");
                }
                Console.ReadKey();
            }

        }

        protected override int menuKontaktow()
        {
            List<string> kontakty = new List<string>();
            for (int i = 0; i < kontaktList.Count; i++)
            {
                kontakty.Add(kontaktList[i].nazwa.ToString() + " " + kontaktList[i].numer.ToString());
            }

            kontaktow.Konfiguruj(kontakty);
            return kontaktow.Wyswietl();
        }

        public void wyszukaj()
        {
            Console.Write("Wyszukaj: ");
            string szukanaFraza = Console.ReadLine();
            var pasujaceKontakty = kontaktList.Where(e => e.nazwa.Contains(szukanaFraza)|| e.numer.Contains(szukanaFraza)).ToList();

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

        internal void ulubioneKontakty()
        {
            ulubione.wyswietlWszystkie();
        }
        public override void wyswietlWszystkie()
        {
            if (kontaktList.Count != 0)
            {
                szczegoly(menuKontaktow(),kontaktList);
            }
            else
            {
                Console.WriteLine("Brak pozycji do wyswietlenia!");
                Console.ReadKey();
            }
        }
    }
}
