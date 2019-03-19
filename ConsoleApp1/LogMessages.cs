using System;
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

            HelperLog helperLog = new HelperLog();
            helperLog.LogDatabase(messagebool, error, warning, message, option);

            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}
