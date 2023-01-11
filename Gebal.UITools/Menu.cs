using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gebal.UITools
{
    public class Menu
    {
        private String[] elementy;
        List<string> elementyList = new List<string>();//spr czy potrzebne
        private int najdluzszyElement = 0;
        /// <summary>
        /// (to właśnie wyświetli w podpowiedzi do obiektu elementyMenu)
        /// Konfiguruje elementy menu. Przyjmuje tylko 20 elementów
        /// </summary>
        /// <param name="elementyMenu">Tablica elementow</param>
        public void Konfiguruj(string[] elementyMenu)
        {
            if (elementyMenu.Length <= 100)
            {
                elementy = elementyMenu;
                for (int i = 0; i < elementy.Length; i++)
                {
                    if (elementyMenu[i].Length > najdluzszyElement)
                    {
                        najdluzszyElement = elementyMenu[i].Length;
                    }
                }
            }
            else
            {
                elementy = new string[0];
            }
        }
        public void Konfiguruj(List<string> kontakty)
        {
            if (kontakty.Count <= 100)
            {
                elementy=kontakty.ToArray();   
                for (int i = 0; i < elementy.Length; i++)
                {
                    if (kontakty[i].Length > najdluzszyElement)
                    {
                        najdluzszyElement = kontakty[i].Length;
                    }
                }
            }
            else
            {
                elementy = new string[0];
            }
            
        }
        public int Wyswietl()
        {
            Console.Clear();
            int wybrany = 0;
            if (elementy != null)
            {
                ConsoleKeyInfo keyInfo;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                do
                {
                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < elementy.Length; i++)
                    {
                        if (i == wybrany)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        Console.WriteLine(elementy[i].PadRight(najdluzszyElement + 2));
                    }


                    keyInfo = Console.ReadKey();

                    if ((keyInfo.Key == ConsoleKey.UpArrow && wybrany == 0) || keyInfo.Key == ConsoleKey.End)
                    {
                        wybrany = elementy.Length - 1;
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow && wybrany > 0)
                    {
                        wybrany--;
                    }
                    else if ((keyInfo.Key == ConsoleKey.DownArrow && wybrany == elementy.Length - 1) || keyInfo.Key == ConsoleKey.Home)
                    {
                        wybrany = 0;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        wybrany++;
                    }
                   else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        wybrany = -1;
                    }
                                      
                } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);
            }
            Console.ResetColor();
            return wybrany;
        }

        public int Wyswietl(int wiersz)
        {
            int wybrany = 0;
            if (elementy != null)
            {
                ConsoleKeyInfo keyInfo;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                do
                {
                    
                    ///TODO:
                    ///można dodać tu sprawdzanie najdłuższej nazwy kontaktu i wyświetlenie tego menu odpowiednio dalej
                    for (int i = 0; i < elementy.Length; i++)
                    {
                        if (i == wybrany)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        Console.SetCursorPosition(25, wiersz+i);
                        Console.WriteLine(elementy[i].PadRight(najdluzszyElement + 2));
                    }


                    keyInfo = Console.ReadKey();

                    if ((keyInfo.Key == ConsoleKey.UpArrow && wybrany == 0) || keyInfo.Key == ConsoleKey.End)
                    {
                        wybrany = elementy.Length - 1;
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow && wybrany > 0)
                    {
                        wybrany--;
                    }
                    else if ((keyInfo.Key == ConsoleKey.DownArrow && wybrany == elementy.Length - 1) || keyInfo.Key == ConsoleKey.Home)
                    {
                        wybrany = 0;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        wybrany++;
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        wybrany = -1;
                    }

                } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);
            }
            Console.ResetColor();
            return wybrany;
        }
    }
}
