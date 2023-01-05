using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gebal.UITools;//oprócz dodania tego tutaj należy również dodać to w zakładce "odwołania" w drzewie projektu


namespace ksiazkaTelefoniczna
{
    internal class Program
    {
        static void M11ain(string[] args)
        {
            KontaktREMOTE tmp= new KontaktREMOTE();
            tmp.dodajKontakt();
        }
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Konfiguruj(new string[] { " Dodaj kontakt", " Wyswietl wszystkie kontakty", " Wyszukaj po nazwie", " Wyszukaj po numerze", " Usun kontakt", " Wyjscie" });
            KsiazkaTelefoniczna ksiazkaTelefoniczna = new KsiazkaTelefoniczna();
             ksiazkaTelefoniczna.dodajKontakt("Ania", "234");
             ksiazkaTelefoniczna.dodajKontakt("Ola", "456");
             ksiazkaTelefoniczna.dodajKontakt("Marek", "789");
              ksiazkaTelefoniczna.dodajKontakt("Jan", "147");
              ksiazkaTelefoniczna.dodajKontakt("Mama", "258");
              ksiazkaTelefoniczna.dodajKontakt("Tata", "369");
              ksiazkaTelefoniczna.dodajKontakt("i Ja", "159");
          
            int zadanie;
            do
            {

                Console.Clear();
                zadanie = menu.Wyswietl();


                switch (zadanie)
                {
                    case 0:
                        ksiazkaTelefoniczna.dodaj();
                        break;

                    case 1:
                        ksiazkaTelefoniczna.wyswietlWszystkieKontakty();
                        break;

                    case 2:
                        ksiazkaTelefoniczna.poNazwie();

                        break;

                    case 3:
                        ksiazkaTelefoniczna.poNumerze();


                        break;

                    case 4:
                        ksiazkaTelefoniczna.usunKontakt();
                        break;

                    case -1:
                    case 5:
                        ksiazkaTelefoniczna.exit();
                        break;

                    default:

                        break;
                }

            } while (!(zadanie == -1 || zadanie == 5));
        }
    }
}

///TODO:
///zapisywanie i odczyt z pliku
///funkcja zadzwoń 
///lista posoortowana wg "najczęściej wybierane"
///
// zostwiam ten projekt na luźniejsze czasy
