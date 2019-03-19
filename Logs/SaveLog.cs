using System;
namespace Logs
{
    public class SaveLog
    {
        public static void LogMessage(string Message, int TypeMessage, int OptionOfSave)
        {
            HelperLogger logger = new HelperLogger();
            logger.HelperSaveLogger(Message, TypeMessage, OptionOfSave);
        }
    }
}
