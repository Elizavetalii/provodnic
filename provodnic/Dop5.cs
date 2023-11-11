using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dop5
{
    public static  class KeyActions
    {
        public static void AddFile()
        {
            Console.SetCursorPosition(93, 8);
            Console.WriteLine("Укажите путь ");
            Console.SetCursorPosition(93, 9);
            string path = Console.ReadLine();

            if ((path != "") && (path.Contains("\\")) && (path.Contains(":")))
                
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                    Console.SetCursorPosition(93, 9);
                    Console.WriteLine("Файл был успешно создан.");
                    
                }       
            }
            else if (File.Exists(path))
            {
                Console.SetCursorPosition(93, 9);
                Console.WriteLine("Файл уже существует и не будет перезаписан.");
                
            }
            else
            {
                Console.SetCursorPosition(93, 9);
                Console.WriteLine("Неверный путь к файлу");
            }
        }

        public static void AddDirectory()
        {
            Console.SetCursorPosition(93, 8);
            Console.WriteLine("Укажите путь ");
            Console.SetCursorPosition(93, 9);
            string path = Console.ReadLine();
            if ((path != "") && (path.Contains("\\")) && (path.Contains(":")))
                {
                if (Directory.Exists(path))
                {
                    Console.SetCursorPosition(93, 9);
                    Console.WriteLine("Этот путь уже существует.");
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.SetCursorPosition(93, 9);
                Console.WriteLine("Папка успешно создана");
            
            }
            else
            {
                Console.SetCursorPosition(93, 9);
                Console.WriteLine("Неверный путь к папке");
            }

        }

        public static void DeleteItem()
        {
            Console.SetCursorPosition(93, 8);
            Console.WriteLine("Укажите путь ");
            Console.SetCursorPosition(93, 9);
            string path = Console.ReadLine();
           
            if ((path != "") && (path.Contains("\\")) && (path.Contains(":")) && (!path.Contains("С:")) && (!path.Contains("с:")))
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.SetCursorPosition(93, 9);
                    Console.WriteLine("Успешно удалено!"); 
                }
                else if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    Console.SetCursorPosition(93, 9);
                    Console.WriteLine("Успешно удалено!");
                }
                else
                {
                    Console.SetCursorPosition(93, 9);
                    Console.WriteLine("Путь не найден");
                }
            }
            else
            {
                Console.SetCursorPosition(93, 9);
                Console.WriteLine("Неверный путь или системный диск С");
            }
        }
    }
}
