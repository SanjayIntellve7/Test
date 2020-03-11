using AMS.Broker.TwTwFFTAdapterService.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.TwTwFFTAdapterService.Services
{
    class InsertFFTAdapterOperationLog
    {
        private static bool IsFileCreated = false;
        public static void AddProcessLogFFTAdapterOperation(string _msg)
        {
            try
            {
                if (IsFileCreated == false)
                {
                    IsFileCreated = true;
                    string _folderName = Directory.GetCurrentDirectory() + "\\FFTAdapterOperationLogs";
                    string prefex = "FFTAdapterOperationLog_";
                    TwTwSystemLogs.SetLogFile(logDir: _folderName, prefix: prefex, extension: "txt", writeText: true);
                }
                TwTwSystemLogs.Info(_msg);
            }
            catch (Exception ex)
            {
                TwTwSystemLogs.Error("Error : " + ex.Message);
            }
        }
    }
}
