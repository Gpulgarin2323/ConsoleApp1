using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class JobLogger
    {
        public bool _logToFile;
        public bool _logToConsole;
        public bool _logMessage;
        public bool _logWarning;
        public bool _logError;
        public bool  LogToDatabase;
        public bool _initialized;

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        {
            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;
             LogToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;
        }
    }
}
