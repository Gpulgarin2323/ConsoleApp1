using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DisplayMenu
    {
        static public int DisplayMenus()
        {
            Console.WriteLine("selections how you want to save the log");
            Console.WriteLine();
            Console.WriteLine("1. text file");
            Console.WriteLine("2. console and/or the database");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
