﻿using Gebal.UITools;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ksiazkaTelefoniczna
{
     class Kontakt
    {
        protected string Nazwa;
        protected string Numer;

        internal string nazwa { get { return Nazwa; } }
        internal string numer { get { return Numer; } }

        internal Kontakt() { }

        internal Kontakt(string nazwa, string numer)
        {
            Nazwa= nazwa;
            Numer= numer;
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
            Regex regexNumer = new Regex(@"(\d){9}");
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

        public virtual bool dodajKontakt()
        {
            StringBuilder[] dane = new StringBuilder[5];
            for (int i = 0; i < 5; i++)
            {
                dane[i] = new StringBuilder();
            }

            // Set the initial cursor position
            //Console.SetCursorPosition(0, 15);

            // Index of the current string being edited
            int wybor = 0;
            ConsoleKeyInfo key;
            do
            {
                // Clear the console and print the current dane
                Console.Clear();
                Console.WriteLine("Nazwa: ");
                Console.WriteLine("Numer: ");

                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(15, i);
                    Console.WriteLine(dane[i].ToString());
                }

                // wyświetlanie kursora, sprawdź czy wgl jest potrzebne
                Console.SetCursorPosition(dane[wybor].Length + 15, wybor);
                Console.Write("|");

                // Wait for the user to press a key
                key = Console.ReadKey(true);

                // Handle the arrow keys
                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    wybor = (wybor + 1) % 2;
                }
                else
                {
                    // Get the current string being edited
                    StringBuilder currentStringBuilder = dane[wybor];

                    // Handle backspace key
                    if (key.Key == ConsoleKey.Backspace && currentStringBuilder.Length > 0)
                    {
                        currentStringBuilder.Remove(currentStringBuilder.Length - 1, 1);
                    }
                    // Handle other keys
                    else if (key.Key != ConsoleKey.Enter)
                    {
                        currentStringBuilder.Append(key.KeyChar);
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            if (dane.Length != 0)
            {
                this.Nazwa = dane[0].ToString();
                this.Numer = dane[1].ToString();
                return true;
            }
            return false;
        }

        public  virtual void wyswietl()
        {
            Console.WriteLine($"{Nazwa}");
            Console.WriteLine($"{Numer}");
        }
    }
    class KontaktREMOTE:  Kontakt
    {
        protected string Imie, Nazwisko;
        protected string Email;
        internal KontaktREMOTE(){ }

        KontaktREMOTE(string nazwa, string imie,string nazwisko, string numer, string email):base(nazwa,numer)
        {
            Imie=imie;
            Nazwisko=nazwisko;
            Email=email;
        }
       internal string imie { get; set; }
       internal string nazwisko { get; set; }
       //private string nazwisko { set;}
       internal string email { get; set; }
        public override bool dodajKontakt()
        {
            StringBuilder[] dane = new StringBuilder[5];
            for (int i = 0; i < 5; i++)
            {
                dane[i] = new StringBuilder();
            }

            // Index of the current string being edited
            int wybor = 0;
            ConsoleKeyInfo key;
            do
            {
                // Clear the console and print the current dane
                Console.Clear();
                Console.WriteLine("Nazwa: ");
                Console.WriteLine("Imie: ");
                Console.WriteLine("Nazwisko: ");
                Console.WriteLine("Numer: ");
                Console.WriteLine("Email: ");

                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(15, i);

                    Console.WriteLine(dane[i].ToString());
                }

                //jest potrzebne
                Console.SetCursorPosition(dane[wybor].Length + 15, wybor);
                Console.Write("|");

                // Wait for the user to press a key
                key = Console.ReadKey(true);

                // Handle the arrow keys
                if (key.Key == ConsoleKey.UpArrow)
                {
                    wybor = (wybor + 4) % 5;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    wybor = (wybor + 1) % 5;
                }
                // Handle other keys
                else
                {
                    // Get the current string being edited
                    StringBuilder currentStringBuilder = dane[wybor];

                    // Handle backspace key
                    if (key.Key == ConsoleKey.Backspace && currentStringBuilder.Length > 0)
                    {
                        currentStringBuilder.Remove(currentStringBuilder.Length - 1, 1);
                    }
                    // Handle other keys
                    else if (key.Key != ConsoleKey.Enter)
                    {
                        currentStringBuilder.Append(key.KeyChar);
                    }
                }
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

            if (dane.Length != 0&& key.Key != ConsoleKey.Escape)
            {
                this.Nazwa = dane[0].ToString();
                this.Imie = dane[1].ToString();
                this.Nazwisko = dane[2].ToString();
                this.Numer = dane[3].ToString();
                this.Email = dane[4].ToString();
                return true;
            }
            return false;
        }

        public override void wyswietl()
        {
            Console.WriteLine($"{Nazwa}    ");
            if (Imie != null) Console.WriteLine($"{Imie}   ");
            if (Nazwisko != null) Console.WriteLine($"{Nazwisko}   ");
            Console.WriteLine($"{Numer}  ");
            if (Email != null) Console.WriteLine($"{Email}  ");
            
        }

    }


    class KontaktPHONE: KontaktREMOTE
    {
        string DrugieImie;
        string Firma;
        string NumerSluzbowy;
        //DateTime Urodziny;

        internal KontaktPHONE(){}

        internal string drugieImie { get;}
        internal string firma { get;}
        //internal string urodziny { get { return Urodziny.ToString(); } }

        string numerSluzbowy { get { return NumerSluzbowy; } }

        public override bool dodajKontakt()
        {
            StringBuilder[] dane = new StringBuilder[8];
            for (int i = 0; i < 8; i++)
            {
                dane[i] = new StringBuilder();
            }

            // Index of the current string being edited
            int wybor = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("Nazwa: ");
                Console.WriteLine("Imie: ");
                Console.WriteLine("Drugie imie: ");
                Console.WriteLine("Nazwisko: ");
                Console.WriteLine("Numer: ");
                Console.WriteLine("Email: ");
                Console.WriteLine("Firma: ");
                Console.WriteLine("Numer służbowy: ");
                //Console.WriteLine("Data urodzin: ");


                for (int i = 0; i < 8; i++)
                {
                    Console.SetCursorPosition(20, i);
                    Console.WriteLine(dane[i].ToString());
                }

                // wyświetlanie kursora, nie wygląda zbyt ładnie ale jest potrzebne
                Console.SetCursorPosition(dane[wybor].Length + 20, wybor);
                Console.Write("|");

                // Wait for the user to press a key
                key = Console.ReadKey(true);

                // Handle the arrow keys
                if (key.Key == ConsoleKey.UpArrow)
                {
                    wybor = (wybor + 7) % 8;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    wybor = (wybor + 1) % 8;
                }
                // Handle other keys
                else
                {
                    // Get the current string being edited
                    StringBuilder currentStringBuilder = dane[wybor];

                    // Handle backspace key
                    if (key.Key == ConsoleKey.Backspace && currentStringBuilder.Length > 0)
                    {
                        currentStringBuilder.Remove(currentStringBuilder.Length - 1, 1);
                    }
                    // Handle other keys
                    else if (key.Key != ConsoleKey.Enter)
                    {
                        currentStringBuilder.Append(key.KeyChar);
                    }
                }
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

            if (dane.Length != 0 && key.Key != ConsoleKey.Escape)
            {
                this.Nazwa = dane[0].ToString();
                this.Imie = dane[1].ToString();
                this.DrugieImie = dane[2].ToString();
                this.Nazwisko = dane[3].ToString();
                this.Numer = dane[4].ToString();
                this.Email = dane[5].ToString();
                this.Firma = dane[6].ToString();
                this.NumerSluzbowy = dane[7].ToString();
                //this.Urodziny = new DateTime(dane[7].ToString());
                return true;
            }
            return false;
        }
        public override void wyswietl()
        {
            Console.WriteLine($"{Nazwa}    ");
            if (Imie != null) Console.WriteLine($"{Imie}   ");
            if (DrugieImie != null) Console.WriteLine($"{DrugieImie}   ");
            if (Nazwisko != null) Console.WriteLine($"{Nazwisko}   ");
            Console.WriteLine($"{Numer}  ");
            if (Email != null) Console.WriteLine($"{Email}  ");
            if (Firma != null) Console.WriteLine($"{Firma}   ");
            if (NumerSluzbowy != null) Console.WriteLine($"{NumerSluzbowy}   ");
        }
    }
    
}
