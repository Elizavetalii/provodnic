using Menu;
using provodnic;
using System.IO;

class Program
{
    public int maxLenght = 0;

    static void Main()
    {

        string currentPath = "";
        int width = 120;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("{0,65}", "Этот компьютер");
            Console.WriteLine(new string('-', width) + "\n");

            currentPath = Explorer.DisplayDrives();

            while (true)
            {
                Console.Clear();
                string header = "Каталоги диска " + currentPath;
                if (currentPath.Length > 3)
                {
                    header = "Каталог " + new FileInfo(currentPath).Name;
                }
                Console.WriteLine("{0,50}", header);
                Console.WriteLine(new string('-', width)
                    + "\n{0,-55} {1,10} {2,25}",
                                centeredString("Имя", 55),
                                "Расширение",
                                "Дата создания"
                                );
               
                currentPath = Explorer.DisplayDirectoryContents(currentPath);

                if (currentPath.Length == 0) break;
                
            }
        }
    }

    public static string centeredString(string s, int width)
    {
        if (s.Length >= width)
        {
            return s;
        }

        int leftPadding = (width - s.Length) / 2;
        int rightPadding = width - s.Length - leftPadding;

        return new string(' ', leftPadding) + s + new string(' ', rightPadding);
    }
}