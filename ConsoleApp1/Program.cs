using System;
using System.Collections.Generic;
using System.Configuration;
using Logs;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
           var option = DisplayMenu.DisplayMenus();
           //LogMessages.LogMessage("prueba1",true,true,false, option);
            SaveLog.LogMessage("prueba nueva",3,1);
            Console.ReadKey();
        }
    }
}

