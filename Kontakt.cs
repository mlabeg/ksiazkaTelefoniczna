﻿using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ksiazkaTelefoniczna
{
    class Kontakt: IComparable<Kontakt>
    {
        protected string _nazwa;
        protected string _numer;
        int LicznikPolaczen;

        [JsonProperty]
        protected string Nazawa
        {
            get { return _nazwa; }
            set { _nazwa = value; }
        }

        [JsonProperty]
        protected string Numer
        {
            get { return _numer; }
            set { _numer = value; }
        }

        /// <summary>
        /// Specjalnie zwraca na odwrót, użyłem tej metody w klasu Ulubione, gdzie zależało mi
        /// na odwróceniu kolejności (wyświetlenie najczęsciej się pojawiających na górze)/// </summary>
        /// <param name="kontakt"></param>
        /// <returns></returns>
        public int CompareTo(Kontakt kontakt)
        {
            if (this.licznikPolaczen < kontakt.licznikPolaczen)
                return 1;
            else if (this.licznikPolaczen > kontakt.licznikPolaczen)
                return -1;
            else
                return 0;
        }

        internal string nazwa { get { return _nazwa; } }
        internal string numer { get { return _numer; } }

        public int licznikPolaczen { get => LicznikPolaczen; }

        internal Kontakt() { }

        internal Kontakt(string nazwa, string numer)
        {
            _nazwa = nazwa;
            _numer = numer;
            LicznikPolaczen = 0;
        }

        protected bool regexNazwa(string nazwa)
        {
            Regex regexNazwa = new Regex(@"(\w){3,}");
            if (!regexNazwa.IsMatch(nazwa))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool regexNumer(string numer)
        {
            Regex regexNumer = new Regex(@"(\d){9}");
            if (!regexNumer.IsMatch(numer))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public virtual bool dodajKontakt()
        {
            StringBuilder[] dane = new StringBuilder[2];
            for (int i = 0; i < 2; i++)
            {
                dane[i] = new StringBuilder();
            }
            return edytuj(dane);
            
        }
        public virtual bool edytujKontakt() {

            StringBuilder[] dane = new StringBuilder[2];
            dane[0] = new StringBuilder(this._nazwa);
            dane[1] = new StringBuilder(this._numer);
         
            return edytuj(dane);
        }

        public virtual void wyswietl()
        {
            Console.Clear();
            int wiersz = 0;
            Console.Write("Nazwa: ");
            Console.SetCursorPosition(10, wiersz++);
            Console.WriteLine($"{_nazwa}    ");

            Console.WriteLine("Numer: ");
            Console.SetCursorPosition(10, wiersz++);
            Console.WriteLine($"{_numer}  ");
            Console.ReadKey();
        }

        protected virtual bool edytuj(StringBuilder[] dane)
        {
            int wybor = 0;
            bool regexCheckNazwa = true;
            bool regexCheckNumer = true;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine("Nazwa: ");
                Console.WriteLine("Numer: ");

                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(15, i);
                    Console.WriteLine(dane[i].ToString());
                }

                if (!regexCheckNazwa)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nieprawidłowa nazwa.");
                }
                if (!regexCheckNumer)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nieprawidłowy numer telefonu.");

                }

                Console.SetCursorPosition(dane[wybor].Length + 15, wybor);
                Console.Write("|");

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) break;
                else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.Tab)
                {
                    wybor = (wybor + 1) % 2;
                }
                else
                {
                    StringBuilder currentStringBuilder = dane[wybor];

                    if (key.Key == ConsoleKey.Backspace && currentStringBuilder.Length > 0)
                    {
                        currentStringBuilder.Remove(currentStringBuilder.Length - 1, 1);
                    }
                    else if (key.Key != ConsoleKey.Enter)
                    {
                        currentStringBuilder.Append(key.KeyChar);
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (!(regexNazwa(dane[0].ToString())))
                    {
                        regexCheckNazwa = false;
                    }
                    else
                    {
                        regexCheckNazwa = true;
                    }
                    if (!(regexNumer(dane[1].ToString())))
                    {
                        regexCheckNumer = false;
                    }
                    else
                    {
                        regexCheckNumer = true;
                    }
                }
            } while (!(key.Key == ConsoleKey.Enter && regexCheckNazwa && regexCheckNumer));

            if (dane.Length != 0 && key.Key != ConsoleKey.Escape)
            {
                this._nazwa = dane[0].ToString();
                this._numer = dane[1].ToString();
                return true;
            }
            return false;
        }
        internal virtual void zadzwon()
        {
            LicznikPolaczen++;
            Console.Clear();
            Console.WriteLine($"Dzwonię do {nazwa}");
            Console.WriteLine(numer);

            /* for (int i = 0; i < 3; i++)
             {
                 Console.SetCursorPosition(0, 4);
                 Console.WriteLine("             ");
                 Console.SetCursorPosition(0, 4);
                 Thread.Sleep(1000);
                 Console.WriteLine("DRYŃ, DRYŃ");
                 Thread.Sleep(1000);
             }*/
            Console.WriteLine("dzwonie");  
                Console.ReadKey();
                       
        }
        
        public static bool operator <(Kontakt a, Kontakt b) { 
            return string.Compare(a._nazwa, b._nazwa) < 0;
        }
        public static bool operator >(Kontakt a, Kontakt b)
        {
            return string.Compare(a._nazwa, b._nazwa) > 0;
        }
    }

}
    
    
 