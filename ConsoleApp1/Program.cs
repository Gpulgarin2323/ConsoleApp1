using System;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleApp1
{
    public class Program
    {
        
        static void Main(string[] args)
        {
           var option = DisplayMenu.DisplayMenus();
           LogMessages.LogMessage("prueba1",true,true,false, option);
        }
    }
}

