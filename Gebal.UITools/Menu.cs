﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gebal.UITools
{
    public class Menu
    {
        private String[] elementy;
        private int najdluzszyElement = 0;
        /// <summary>
        /// (to właśnie wyświetli w podpowiedzi do obiektu elementyMenu)
        /// Konfiguruje elementy menu. Przyjmuje tylko 20 elementów
        /// </summary>
        /// <param name="elementyMenu">Tablica elementow</param>
        public void Konfiguruj(string[] elementyMenu)
        {
            if (elementyMenu.Length <= 20)
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
        public int Wyswietl()
        {
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
                        // znaeźć najdluższy string i dodać tutaj ^
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
