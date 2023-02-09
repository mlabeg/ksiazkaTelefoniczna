using Newtonsoft.Json;
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
        string _drugieImie;
        string _firma;
        string _numerSluzbowy;

        [JsonProperty]
        private string DrugieImie
        {
            get { return _drugieImie; }
            set { _drugieImie = value; }
        }
        [JsonProperty]
        private string Firma
        {
            get { return _firma; }
            set { _firma = value; }
        }
        [JsonProperty]
        private string NumerSluzbowy
        {
            get { return _numerSluzbowy; }
            set { _numerSluzbowy = value; }
        }


        internal KontaktPHONE() { }
        internal KontaktPHONE(string nazwa, string numer) : base(nazwa, numer) { }

        internal string drugieImie { get { return _drugieImie; } }
        internal string firma { get { return _firma; } }
        
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
            StringBuilder[] dane = new StringBuilder[8];

            dane[0] = new StringBuilder(this._nazwa);
            dane[1] = new StringBuilder(this._imie);
            dane[2] = new StringBuilder(this._drugieImie);
            dane[3] = new StringBuilder(this._nazwisko);
            dane[4] = new StringBuilder(this._numer);
            dane[5] = new StringBuilder(this._email);
            dane[6] = new StringBuilder(this._firma);
            dane[7] = new StringBuilder(this._numerSluzbowy);

            return(edytuj(dane));
        }

        protected override bool edytuj(StringBuilder[] dane)
        {
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

                for (int i = 0; i < 8; i++)
                {
                    Console.SetCursorPosition(20, i);
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

                Console.SetCursorPosition(dane[wybor].Length + 20, wybor);
                Console.Write("|");

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
                this._nazwa = dane[0].ToString();
                this._imie = dane[1].ToString();
                this._drugieImie = dane[2].ToString();
                this._nazwisko = dane[3].ToString();
                this._numer = dane[4].ToString();
                this._email = dane[5].ToString();
                this._firma = dane[6].ToString();
                this._numerSluzbowy = dane[7].ToString();
                return true;
            }
            return false;
        }

        public override void wyswietl()
        {
            Console.Clear();
            int wiersz = 0;
            Console.Write("Nazwa: ");
            Console.SetCursorPosition(20, wiersz++);
            Console.WriteLine($"{_nazwa}    ");

            if ( _imie!=null && _imie.Length != 0)
            {
                Console.WriteLine("Imię: ");
                Console.SetCursorPosition(20, wiersz++);
                Console.WriteLine($"{_imie}   ");
            }
            if (_drugieImie!=null && _drugieImie.Length != 0)
            {
                Console.WriteLine("Drugie imię: ");
                Console.SetCursorPosition(20, wiersz++);
                Console.WriteLine($"{_drugieImie}   ");
            }

            if (_nazwisko != null && _nazwisko.Length != 0)
            {
                Console.WriteLine("Nazwisko: ");
                Console.SetCursorPosition(20, wiersz++);
                Console.WriteLine($"{_nazwisko}   ");
            }

            Console.WriteLine("Numer: ");
            Console.SetCursorPosition(20, wiersz++);
            Console.WriteLine($"{_numer}  ");

            if (_email != null)
            {
                Console.WriteLine("Email: ");
                Console.SetCursorPosition(20, wiersz++);
                Console.WriteLine($"{_email}  ");
            }

            if (_firma != null)
            {
                Console.WriteLine("Firma: ");
                Console.SetCursorPosition(20, wiersz++);
                Console.WriteLine($"{_firma}  ");
            }

            if (_numerSluzbowy != null && _numerSluzbowy.Length != 0)
            {
                Console.WriteLine("Numer służbowy: ");
                Console.SetCursorPosition(20, wiersz++);
                Console.WriteLine($"{_numerSluzbowy}  ");
            }

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