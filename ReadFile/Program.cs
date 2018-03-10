using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] directories)
        {
            string[] fileDirectories = null;
            if (directories != null && directories.Any())
            {
                fileDirectories = directories;
            }
            else
            {
                fileDirectories = Console.ReadLine()?.Split(' ');
            }

            var fileHandler = new FileHandler(fileDirectories);
            fileHandler.Start();
            fileHandler.WriteDictionaryData();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
