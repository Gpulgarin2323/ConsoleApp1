using Logs;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            SaveLog.LogMessage("prueba nueva", 1, 1);
            Console.ReadKey();
        }
    }
}

