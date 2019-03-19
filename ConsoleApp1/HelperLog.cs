using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ConsoleApp1
{
    class HelperLog
    {
        public void LogDatabase(bool messagebool, bool error, bool warning, string message, int option)
        {
            switch (option)
            {
                case 1:
                    int t = 0;
                    if (messagebool)
                    {
                        t = 1;
                    }
                    if (error)
                    {
                        t = 2;
                    }
                    if (warning)
                    {
                        t = 3;
                    }

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                    {
                        con.Open();
                        var query = ("Insert into Log Values('" + message + "', " + t.ToString() + ")");
                        SqlCommand comando = new SqlCommand(query, con);
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    if (error)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (warning)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (messagebool)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;

                case 2:
                    string l = string.Empty;
                    string date = "LogFiles" + DateTime.Now.ToShortDateString().Replace("/", "") + ".txt";

                    if (!File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"] + date))
                    {
                        File.Create(ConfigurationManager.AppSettings["LogFileDirectory"] + date);
                    }
                    if (error)
                    {
                        l = l + DateTime.Now.ToShortDateString() + message;
                    }
                    if (warning)
                    {
                        l = l + DateTime.Now.ToShortDateString() + message;
                    }
                    if (messagebool)
                    {
                        l = l + DateTime.Now.ToShortDateString() + message;
                    }
                    File.WriteAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + date, l);
                    break;
            } 
        }
    }
}



