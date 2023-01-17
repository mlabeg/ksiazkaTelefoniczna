using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiazkaTelefoniczna
{
    class KontaktREMOTE : Kontakt
    {
        protected string Imie, Nazwisko;
        protected string Email;
        internal KontaktREMOTE() { }
        internal KontaktREMOTE(string nazwa, string numer) : base(nazwa, numer) { }

        KontaktREMOTE(string nazwa, string imie, string nazwisko, string numer, string email) : base(nazwa, numer)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
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
            return (edytuj(dane));

        }
        public override bool edytujKontakt()
        {
            StringBuilder[] dane = new StringBuilder[5];

            dane[0] = new StringBuilder(this.Nazwa);
            dane[1] = new StringBuilder(this.Imie);
            dane[2] = new StringBuilder(this.Nazwisko);
            dane[3] = new StringBuilder(this.Numer);
            dane[4] = new StringBuilder(this.Email);

            return (edytuj(dane));
        }
        protected override bool edytuj(StringBuilder[] dane)
        {
            // Index of the current string being edited
            int wybor = 0;
            bool regexCheckNazwa = true;
            bool regexCheckNumer = true;
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
                    if (dane[i]!=null)
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

                //jest potrzebne
                Console.SetCursorPosition(dane[wybor].Length + 15, wybor);
                Console.Write("|");

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) break;
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    wybor = (wybor + 4) % 5;
                }
                else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.Tab)
                {
                    wybor = (wybor + 1) % 5;
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
                    if (!(regexNumer(dane[3].ToString())))
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
            Console.Clear();
            int wiersz = 0;
            Console.Write("Nazwa: ");
            Console.SetCursorPosition(15, wiersz++);
            Console.WriteLine($"{Nazwa}    ");

            if (Imie.Length != 0)
            {
                Console.WriteLine("Imie: ");
                Console.SetCursorPosition(15, wiersz++);
                Console.WriteLine($"{Imie}   ");
            }
            
            if (Nazwisko.Length != 0)
            {
                Console.WriteLine("Nazwisko: ");
                Console.SetCursorPosition(15, wiersz++);
                Console.WriteLine($"{Nazwisko}   ");
            }

            Console.WriteLine("Numer: ");
            Console.SetCursorPosition(15, wiersz++);
            Console.WriteLine($"{Numer}  ");

            if (Email != null)
            {
                Console.WriteLine("Email: ");
                Console.SetCursorPosition(15, wiersz++);
                Console.WriteLine($"{Email}  ");
            }

            Console.ReadKey();

        }

    }
}
