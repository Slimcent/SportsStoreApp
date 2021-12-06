namespace SportsStore.LoggerService.Interfaces
{
   public  interface ILoggerMessage
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
