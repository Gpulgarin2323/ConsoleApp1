using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Logs
{
    class HelperLogger
    {
        public void HelperSaveLogger(string Message, int TypeMessage, int OptionOfSave = 1)
        {
            Message.Trim();
            if (Message == null || Message.Length == 0)
            {
                return;
            }
            if (TypeMessage == 0)
            {
                throw new Exception("Error or Warning or Message must be specified");
            }
            switch (OptionOfSave)
            {

                case 1:
                    try
                    {
                        var appSettings = ConfigurationManager.AppSettings;
                        var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
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
                    catch (Exception ex )
                    {
                        throw new Exception("Invalid configuration");
                    }
                    finally
                    {
                        Console.WriteLine(DateTime.Now.ToShortDateString() + Message);
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
                    catch (Exception ex )
                    {
                        throw new Exception("Invalid configuration");
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
                    catch (Exception ex)
                    {
                        throw new Exception("Invalid configuration");
                    }
                    break;
            }
        }
    }
}
