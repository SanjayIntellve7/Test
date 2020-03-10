using CustomLogContracts;
using NLog;
using System;

namespace CustomLoggerService
{
    public class LogManager : ILoggerManager
    {
        private static ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        public LogManager()
        {
        }
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(string message)
        {
            logger.Error(message);
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
