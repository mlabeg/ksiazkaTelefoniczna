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
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Konfiguruj(new string[] { " Dodaj kontakt", " Spis kontaktów"," Ostatno wybierane"," Ulubione", " Wyszukaj po nazwie", " Wyszukaj po numerze", " Usun kontakt", " Wyjscie" });
            KsiazkaTelefoniczna ksiazkaTelefoniczna = new KsiazkaTelefoniczna();
             ksiazkaTelefoniczna.dodajKontakt("Ania", "234");
            Kontakt kontakt = new KontaktPHONE("mordo", "468");
            ksiazkaTelefoniczna.dodajViaConsole(kontakt);
            ksiazkaTelefoniczna.dodajKontakt("Ola", "456");
       
             /*ksiazkaTelefoniczna.dodajKontakt("Marek", "789");
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
                      
                        ksiazkaTelefoniczna.wyswietlWszystkieKontakty();
                        break;

                    case 2:
                        ksiazkaTelefoniczna.ostatnioWybierane();
                        break;
                    case 3:
                        ksiazkaTelefoniczna.ulubioneKontakty();
                        break;

                    case 4:
                        ksiazkaTelefoniczna.poNazwie();
                        break;

                    case 5:
                        ksiazkaTelefoniczna.poNumerze();
                        break;

                    case 6:
                        ksiazkaTelefoniczna.usunKontakt();
                        break;

                    case -1:
                    case 7:
                        ksiazkaTelefoniczna.exit();
                        break;

                    default:

                        break;
                }

            } while (!(zadanie == -1 || zadanie == 7));
        }
    }
}

///TODO:
///poprawić alorytm działania klasy ulubione (LYNQ?)
///scal poNazwie & poNumerze => wyszukaj() @Program
///sprawić, żeby strzałki lewo/prawo w wpsywaniu/edytowaniu kontaktu nic nie robiły
///	"Enkapsulacja klasy - definiowanie publicznego interfejsu klasy"    <- może sprawdź to w nagraniach


///TODO2:
///wyszukiwanie kontaktów w czasie wpisywania kolejnych cyfr - poNumerze()
///zapisywanie i odczyt z pliku
///opcja "zadzwoń" bezpośrednio w menu -> dzwoni i zapisuje numer w historii


/// TODO3:
///pole urodziny w KontaktyURZADZENIE
////wyświetlanie kto ma dzisiaj urodziny pod głównym menu
///"USTAWIENIA" gdzie możn zmienić jak wyswietać "wyświetlanie wszystkich kotaktów" t
////tj. "po imieniu"/"po nazwisku"...
///@Menu można dodać tu sprawdzanie najdłuższej nazwy kontaktu i wyświetlenie tego menu odpowiednio dalej
///@szczegoly.konfiguruj()@szczegoly()@KsiazkaTelefoniczna.cs(204) można czytać, 
//////jakiej klasy jest zmienna i dla SIM nie wyświetlać "Wyswietl pelne dane"




///POPRAWKI:
///polskie znaki w całym projekcie
///usun funkcje, ktrych nie używasz 
///narysować graf UML
///ustaw odpowiedni rozmiar okna, tak, żeby widzieć "zadzwoń" w ostatnioWybierane
///
///




//tak napisać funkcję zadzwoń(), żeby używała obiektu innego kontaktu??
////wg wykładu 7. (8. zjazd)  ??? pomyśl czy to wgl ma sens i czy już tego nie zrobiłeś??


///DECYZJE:
///dodaj() @KsiazkaTelefoniczna czy nie ładniej byłoby gdyby w końcowych if-ach wywoływać funkcję dodajViaConsole()?
//////na 100% byłoby to wywołanie dynamiczne
