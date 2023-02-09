using System;
using Gebal.UITools;

namespace ksiazkaTelefoniczna
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Konfiguruj(new string[] { " Dodaj kontakt", " Spis kontaktów"," Ostatno wybierane"," Ulubione kontakty", " Wyszukaj", " Usun kontakt", " Wyjscie" });
            KsiazkaTelefoniczna ksiazkaTelefoniczna = new KsiazkaTelefoniczna(LoadAndSafe.loadAll());
            Ulubione ulubione = new Ulubione();

            /*ksiazkaTelefoniczna.dodajKontakt("Ania", "234");
            Kontakt kontakt = new KontaktPHONE("MRD", "468");
            LoadAndSafe.safe(kontakt);
            ksiazkaTelefoniczna.dodajKontakt(kontakt);
            ksiazkaTelefoniczna.dodajKontakt("Ola", "456");
       
            ksiazkaTelefoniczna.dodajKontakt("Marek", "789");
            ksiazkaTelefoniczna.dodajKontakt("Jan", "147");
            ksiazkaTelefoniczna.dodajKontakt("Mama", "258");
            ksiazkaTelefoniczna.dodajKontakt("Tata", "369");
            ksiazkaTelefoniczna.dodajKontakt("i Ja", "159");*/
          
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
                      
                        ksiazkaTelefoniczna.wyswietlWszystkie();
                        break;

                    case 2:
                        ksiazkaTelefoniczna.ostatnioWybierane();
                        break;
                    case 3:
                        ulubione.wyswietlWszystkie();
                        break;

                    case 4:
                        ksiazkaTelefoniczna.wyszukaj();
                        break;

                    case 5:
                        ksiazkaTelefoniczna.usunKontakt();
                        break;

                    case -1:
                    case 6:
                        ksiazkaTelefoniczna.exit();
                        break;

                    default:

                        break;
                }

            } while (!(zadanie == -1 || zadanie == 6));
        }
    }
}
///PRZEJRZEĆ JESZCZE PLIK TODO
///pomyśl czy usunąć Twoje opisy relacji
///odkomentować dzwonienie