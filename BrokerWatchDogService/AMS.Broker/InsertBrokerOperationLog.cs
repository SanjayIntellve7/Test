using AMS.Broker.Contracts.Logs;
using AMS.Broker.WatchDogService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker
{
    public static class InsertBrokerOperationLog //amit 14112016
    {
        private static bool IsFileCreated = false;

        public static void AddProcessLog(string _msg)
        {
            try
            {
                var IsLogEnable = Storage.IsLogEnable;// 
                if (_msg.ToLower().Contains("exception"))//
                {
                    if (IsFileCreated == false)
                    {
                        IsFileCreated = true;
                        string _folderName = Directory.GetCurrentDirectory() + "\\WatchDogLogs";
                        string prefex = "WatchDogLog_";
                        TwTwSystemLogs.SetLogFile(logDir: _folderName, prefix: prefex, extension: "txt", writeText: true);
                    }
                    TwTwSystemLogs.Info(_msg);
                }
                else
                {
                    if (IsLogEnable == "1")//komal 13082018 for  it is enable & disable logs in log file .
                    {
                        if (IsFileCreated == false)
                        {
                            IsFileCreated = true;
                            string _folderName = Directory.GetCurrentDirectory() + "\\WatchDogLogs";
                            string prefex = "WatchDogLog_";
                            TwTwSystemLogs.SetLogFile(logDir: _folderName, prefix: prefex, extension: "txt", writeText: true);
                        }
                        TwTwSystemLogs.Info(_msg);
                    }
                }
            }
            catch (Exception ex)
            {
                TwTwSystemLogs.Error("Error : " + ex.Message);
            }
          
        }
    }
}
