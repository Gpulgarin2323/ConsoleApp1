using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace ConsoleApp1
{
    class LogMessages
    {
        public static void LogMessage(string message, bool messagebool, bool warning, bool error, int option)
        {
            JobLogger logger = new JobLogger(true, true, true, messagebool, warning, error);

            message.Trim();
            if (message == null || message.Length == 0)
            {
                return;
            }

            if (!logger._logToConsole && !logger._logToFile && !logger.LogToDatabase)
            {
                throw new Exception("Invalid configuration");
            }

            if ((!logger._logError && !logger._logMessage && !logger._logWarning) || (!messagebool && !warning && !error))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }

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
            File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + date, l);

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
            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}
