using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ksiazkaTelefoniczna
{
    internal class KontaktPHONE:KontaktREMOTE
    {
        string DrugieImie;
        string Firma;
        string NumerSluzbowy;
        //DateTime Urodziny;

        internal KontaktPHONE() { }
        internal KontaktPHONE(string nazwa, string numer) : base(nazwa, numer) { }

        internal string drugieImie { get; }
        internal string firma { get; }
        //internal string urodziny { get { return Urodziny.ToString(); } }

        string numerSluzbowy { get; }

        public override bool dodajKontakt()
        {
            StringBuilder[] dane = new StringBuilder[8];
            for (int i = 0; i < 8; i++)
            {
                dane[i] = new StringBuilder();
            }

            return (edytuj(dane));
        }
        public override bool edytujKontakt()
        {
            StringBuilder[] dane = new StringBuilder[7];

            dane[0] = new StringBuilder(this.nazwa);
            dane[1] = new StringBuilder(this.imie);
            dane[2] = new StringBuilder(this.drugieImie);
            dane[3] = new StringBuilder(this.nazwisko);
            dane[4] = new StringBuilder(this.numer);
            dane[5] = new StringBuilder(this.email);
            dane[6] = new StringBuilder(this.firma);
            dane[7] = new StringBuilder(this.numerSluzbowy);

            return(edytuj(dane));
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

                ///TEST CASE:
                ///nie wszystkie pola w klasie są wypełnione

                for (int i = 0; i < 8; i++)
                {
                    Console.SetCursorPosition(20, i);
                    Console.WriteLine(dane[i].ToString());
                    //tu wyrzuca błąd 
                        //wygląda jakby do funkcji przekazywał tylko dane z kontakt
                            //sprawdź czy przy tworzeniu kokntaktu nie dodała Ci się same pola klasy bazowej
                            //bo zmieniałeś konstruktor, żeby dodawać obiekty z main()
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

                // wyświetlanie kursora, nie wygląda zbyt ładnie ale jest potrzebne
                Console.SetCursorPosition(dane[wybor].Length + 20, wybor);
                Console.Write("|");

                // Wait for the user to press a key
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) break;
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    wybor = (wybor + 7) % 8;
                }
                else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.Tab)
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
                    if (!(regexNumer(dane[4].ToString())))
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
            Console.Clear();
            Console.WriteLine($"{Nazwa}    ");
            if (Imie != null) Console.WriteLine($"{Imie}   ");
            if (DrugieImie != null) Console.WriteLine($"{DrugieImie}   ");
            if (Nazwisko != null) Console.WriteLine($"{Nazwisko}   ");
            Console.WriteLine($"{Numer}  ");
            if (Email != null) Console.WriteLine($"{Email}  ");
            if (Firma != null) Console.WriteLine($"{Firma}   ");
            if (NumerSluzbowy != null) Console.WriteLine($"{NumerSluzbowy}   ");
            Console.ReadKey();
        }
        internal override void zadzwon()
        {
            base.zadzwon();
            Console.Clear();

            string[] rozmowa = new string[] { "- Halo?",
                "- Sorry stary, nie mogę gadać, robie projekt na JiPP!",
                "- Ale to ty dzwonisz.",
                "- Narazie!"};

            for (int i = 0; i < rozmowa.Length; i++)
            {
                foreach (var character in rozmowa[i])
                {
                    Console.Write(character);
                    Thread.Sleep(30);
                }
                if (i == 0)
                {
                    string sciezka = "C:/Users/enix/source/repos/ksiazkaTelefoniczna/otydzwonisz.jpg";
                    Process.Start(sciezka);
                }
                Thread.Sleep(500);
                Console.WriteLine();
            }
        }
    }
}

