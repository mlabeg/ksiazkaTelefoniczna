using Gebal.UITools;
using System;
using System.Collections.Generic;

namespace ksiazkaTelefoniczna
{
    internal class OstatnioWybrane
    {
        List<Polaczenie> ostatnioWybrane=new List<Polaczenie>(20);
        public bool czyPuste()
        {
            if (ostatnioWybrane.Count > 0) { return false; }
            else return true;
        }
        public void dodajPolaczenie(Kontakt kontakt)
        {
            if (ostatnioWybrane.Count >= 20) ostatnioWybrane.RemoveAt(0);
            
            ostatnioWybrane.Add(new Polaczenie(kontakt));
          

        }
        public void menuOstatnioWybrane()
       // możliwe, że będzie można to ulepszyć/ rozbić na 2 metody
        {
            List<string> kontakty = new List<string>();
            for (int i = ostatnioWybrane.Count-1; i >=0 ; i--)
            {
                kontakty.Add(ostatnioWybrane[i].KontaktNazwa.PadRight(10) + " " 
                    + ostatnioWybrane[i].KontaktNumer.PadRight(15)+" "
                    + ostatnioWybrane[i].date2str());
            }//możne wpadniesz na pomył jak to zrobić, żeby w jednej lini wyświetlał 
                //nazwę i numer a w drugiej datę

            Menu menuOW = new Menu();
            menuOW.Konfiguruj(kontakty);
            int wiersz;
            ConsoleKeyInfo key;
            do
            {
                wiersz = menuOW.Wyswietl();
                if (wiersz >= 0)
                {
                    Console.SetCursorPosition(49, wiersz);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("Zadzwoń".PadRight(8).PadLeft(9));//sprawdzić w jakim kolorze się wyświeli
                    Console.ResetColor();
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        ostatnioWybrane[wiersz].Kontakt.zadzwon();
                        dodajPolaczenie(ostatnioWybrane[wiersz].Kontakt);
                        break;
                    }
                    else
                    {
                        key = new ConsoleKeyInfo();
                    }
                    
                }
                else
                    
                break;
                //Console.ResetColor();
            } while (key.Key != ConsoleKey.Escape);
             
        }
       
    }
}