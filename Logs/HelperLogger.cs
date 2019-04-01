using Logs.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Logs
{
   public class HelperLogger
    {
        public enum MessageType { Message = 1, Warning = 2, Error = 3 }
        private const string MessageException = "Invalid configuration";
        private const string MessageExceptionError = "Error or Warning or Message must be specified";

        public static void HelperSaveLogger(string Message, int TypeMessage, int OptionOfSave = 1)
        {

            var log = new Models.Logs();
            Message.Trim();
            if (Message == null || Message.Length == 0)
            {
                return;
            }
            switch (OptionOfSave)
            {
                case 1:
                    try
                    {
                        using (var Context = new AppDbContext())
                        {
                            log.Message = Message;
                            log.TypeMessage = TypeMessage.ToString();
                            log.Date = DateTime.Now.Date;

                            Context.Logs.Add(log);
                            Context.SaveChanges();
                        }

                        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
                        //{
                        //    con.Open();
                        //    string query = "INSERT INTO Log VALUES('" + Message + "', " + TypeMessage.ToString() + ")";
                        //    SqlCommand comando = new SqlCommand(query, con)
                        //    {
                        //        CommandType = CommandType.Text
                        //    };
                        //    comando.ExecuteNonQuery();
                        //}
                       

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
                            default:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(MessageException);
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
                            File.Create(ConfigurationManager.AppSettings["LogFileDirectory"] + date).Close();
                        }

                        l =  DateTime.Now.ToShortDateString()+ " " + Message + " " + TypeMessage;
                        StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["LogFileDirectory"] + date,true);
                        sw.WriteLine(l);
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(MessageException);
                    }
                    break;
                default:
                    Console.WriteLine(MessageException);
                    break;
            }
        }
    }
}