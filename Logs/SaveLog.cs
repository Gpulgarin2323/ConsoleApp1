namespace Logs
{
    public class SaveLog
    {
        public static void LogMessage(string Message, int TypeMessage, int OptionOfSave)
        {
            HelperLogger.HelperSaveLogger(Message, TypeMessage, OptionOfSave);
        }
    }
}