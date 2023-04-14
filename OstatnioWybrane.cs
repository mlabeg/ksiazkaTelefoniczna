using Gebal.UITools;
using System;
using System.Collections.Generic;

namespace ksiazkaTelefoniczna
{
    internal class OstatnioWybrane
    {
        List<Polaczenie> ostatnioWybrane=new List<Polaczenie>(5);
        Menu menuOW = new Menu();
        public bool czyPuste()
        {
            if (ostatnioWybrane.Count > 0) { return false; }
            else return true;
        }
        public void dodajPolaczenie(Kontakt kontakt)
        {
            if (ostatnioWybrane.Count >= 10) ostatnioWybrane.RemoveAt(0);
            
            ostatnioWybrane.Add(new Polaczenie(kontakt));
          

        }
        public void menuOstatnioWybrane()
        {
            List<string> kontakty = new List<string>();
            for (int i = ostatnioWybrane.Count-1; i >=0 ; i--)
            {
                kontakty.Add(ostatnioWybrane[i].KontaktNazwa.PadRight(10) + " " 
                    + ostatnioWybrane[i].KontaktNumer.PadRight(15)+" "
                    + ostatnioWybrane[i].date2str());
            }
            
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
                    Console.Write("Zadzwoń".PadRight(8).PadLeft(9));
                    Console.ResetColor();
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        ostatnioWybrane[ostatnioWybrane.Count-wiersz-1].Kontakt.zadzwon();
                        dodajPolaczenie(ostatnioWybrane[ostatnioWybrane.Count - wiersz-1].Kontakt);
                        break;
                    }
                    else
                    {
                        key = new ConsoleKeyInfo();
                    }
                    
                }
                else
                    break;
            } while (key.Key != ConsoleKey.Escape);
             
        }
       
    }
}
