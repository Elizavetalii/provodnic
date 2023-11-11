using Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Dop5;

namespace provodnic
{
    public class Explorer
    {

        public static string DisplayDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                string driveName = drive.Name;

                string driveInfo = "";
                if (drive.IsReady)
                {
                    driveInfo = string.Format(" {0} ГБ свободно из {1} ГБ",
                        drive.TotalFreeSpace / (1024 * 1024 * 1024),
                        drive.TotalSize / (1024 * 1024 * 1024));

                }
                Console.WriteLine("  " + driveName + driveInfo);
            }
            Strelochka patharrow = new Strelochka(drives.Length);
            int position = Strelochka.Show(patharrow, false);
            if (position < 0)
            {
                Environment.Exit(1);
            }

            string newpath = drives[position].Name;
            return newpath;
        }

        public static string DisplayDirectoryContents(string path)
        {
            string[] newMenu =
            {
                "F1- Создать файл",
                "F2- Создать папку",
                "F3- Удалить"
            };
            int width = 120;
            int indexnewMenu = 0;
            string newpath = "";
            string linenewMenu = "";
            if (Directory.Exists(path))
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    if (indexnewMenu < 3)
                    {
                        linenewMenu = newMenu[indexnewMenu];
                    }
                    else if (indexnewMenu == 3)
                    {
                        linenewMenu = new string('-', 17);
                    }
                    else
                    {
                        linenewMenu = "";
                    }

                    Console.WriteLine("{0,-55} {1,-10} {2,25} {3,-17}",
                        "  " + Path.GetFileName(dir),
                        "",
                        Directory.GetCreationTime(dir) + "  |" ,
                        linenewMenu);
                    indexnewMenu++;

                }
                    

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    if (indexnewMenu < 3)
                    {
                        linenewMenu = newMenu[indexnewMenu];
                    }
                    else if (indexnewMenu == 3)
                    {
                        linenewMenu = new string('-', 17);
                    }
                    else
                    {
                        linenewMenu = "";
                    }
                    
                    Console.WriteLine("{0,-55} {1,-10} {2,25} {3,-17}",
                        "  " + Path.GetFileNameWithoutExtension(file),
                        Path.GetExtension(file),
                        File.GetCreationTime(file) + "  |" ,
                        linenewMenu);
                    indexnewMenu++; 
                }

                Console.WriteLine("\nEscape - вернуться назад  \nEnter - выбрать папку / файл");              
              
                Console.WriteLine(new string('-', width) + "\n");

                Strelochka patharrow = new Strelochka(dirs.Length + files.Length);
                int position = Strelochka.Show(patharrow);



                if (position == -1)
                {
                    if (path.Length == 3)
                    {
                        newpath = "";
                    }
                    else
                    {
                        newpath = Directory.GetParent(path)?.FullName;
                    }
                }
                else if (position > dirs.Length - 1)
                {
                    position = position - dirs.Length;
                    newpath = files[position];
                }

                else if (position == -11)
                {
                    KeyActions.AddFile();
                    Thread.Sleep(5000);
                    newpath = path;
                }
                else if (position == -12)
                {
                    KeyActions.AddDirectory();
                    Thread.Sleep(5000);
                    newpath = path;
                }
                else if (position == -13)
                {
                    KeyActions.DeleteItem();
                    Thread.Sleep(5000);
                    newpath = path;
                }
                else
                {
                    newpath = dirs[position];
                }
                return newpath;
            }

            else
            {
                RunFile(path);
                return path.Substring(0, path.LastIndexOf("\\"));
            }

        }

        public static void RunFile(string filePath)
        {
            if (File.Exists(filePath) == true)
            {
                Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
            }

            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
    }
}
