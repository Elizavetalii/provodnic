using Dop5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class Strelochka
    {
        public int MaxStrelochka { get; set; }
        public Strelochka(int maxStrelochka) => MaxStrelochka = maxStrelochka;

        public static int Show(Strelochka patharrow, bool Folders = true)
        {
            int minPosition = 0;
            int maxPosition = 0;
            
            if (patharrow.MaxStrelochka > 0)
            {
                minPosition = 3;
                maxPosition = minPosition + patharrow.MaxStrelochka - 1;
            }
            int position = minPosition;
            ConsoleKeyInfo key;

            while (true)
            {
                Console.SetCursorPosition(0, position);
                if (maxPosition > minPosition)
                {
                    Console.WriteLine("->");
                }

                key = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow)
                
                    if (position != minPosition)
                        position--;
                    else
                        position = maxPosition;
                else if (key.Key == ConsoleKey.DownArrow)
                    if (position != maxPosition)
                        position++;
                    else
                        position = minPosition;
                else if (key.Key == ConsoleKey.Enter)
                    break;
                else if (key.Key == ConsoleKey.Escape)
                {
                    position = minPosition - 1;
                    break;
                }

                if (key.Key == ConsoleKey.F1)
                {
                    return -11;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    return -12;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    return -13;
                }
            }
            Console.Clear();
            return position - minPosition;
        }
    }
}
