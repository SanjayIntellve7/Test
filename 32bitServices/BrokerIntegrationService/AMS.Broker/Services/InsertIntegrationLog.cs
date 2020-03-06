using AMS.Broker.IntegrationService.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.IntegrationService.Services
{
    class InsertIntegrationLog
    {
        private static bool IsFileCreated = false;
        public static void AddProcessLogIntegration(string _msg)
        {

            try
            {
                if (IsFileCreated == false)
                {
                    IsFileCreated = true;
                    string _folderName = Directory.GetCurrentDirectory() + "\\IntegrationLog";
                    string prefex = "IntegrationLog_";
                    TwTwSystemLogs.SetLogFile(logDir: _folderName, prefix: prefex, extension: "txt", writeText: true);
                }
                TwTwSystemLogs.Info(_msg);
            }
            catch (Exception ex)
            {
                TwTwSystemLogs.Error("Error : " + ex.Message);
            }
            //try
            //{
            //    string _folderName = Directory.GetCurrentDirectory() + "\\IntegrationLog";
            //    if (!Directory.Exists(_folderName))
            //        Directory.CreateDirectory(_folderName);

            //    string _fileName = _folderName + "\\IntegrationLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            //    if (!File.Exists(_fileName))
            //    {
            //        using (StreamWriter sw = File.CreateText(_fileName))
            //        {
            //            sw.WriteLine(DateTime.Now.ToString() + "  " + _msg);
            //            sw.Close();
            //        }
            //    }
            //    else
            //    {
            //        using (StreamWriter sw = File.AppendText(_fileName))
            //        {
            //            sw.WriteLine(DateTime.Now.ToString() + "  " + _msg);
            //            sw.Close();

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}
