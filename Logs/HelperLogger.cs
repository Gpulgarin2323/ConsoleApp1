using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Logs
{
    class HelperLogger
    {
        public void HelperSaveLogger(string Message, int TypeMessage, int OptionOfSave)
        {
            switch (OptionOfSave)
            {
                case 1:
                    try
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                        {
                            con.Open();
                            var query = ("INSERT INTO Log VALUES('" + Message + "', " + TypeMessage.ToString() + ")");
                            SqlCommand comando = new SqlCommand(query, con);
                            comando.CommandType = CommandType.Text;
                            comando.ExecuteNonQuery();
                        }

                        switch (TypeMessage)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                case 2:
                    try
                    {
                        string l = string.Empty;
                        string date = "LogFiles" + DateTime.Now.ToShortDateString().Replace("/", "") + ".txt";

                        if (!File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"] + date))
                        {
                            File.Create(ConfigurationManager.AppSettings["LogFileDirectory"] + date);
                        }

                        l = l + DateTime.Now.ToShortDateString() + Message;
                        File.WriteAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + date, l);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                default:
                    try
                    {
                        string l = string.Empty;
                        string date = "LogFiles" + DateTime.Now.ToShortDateString().Replace("/", "") + ".txt";

                        if (!File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"] + date))
                        {
                            File.Create(ConfigurationManager.AppSettings["LogFileDirectory"] + date);
                        }

                        l = l + DateTime.Now.ToShortDateString() + Message;
                        File.WriteAllText(ConfigurationManager.AppSettings["LogFileDirectory"] + date, l);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
            }
        }
    }
}
