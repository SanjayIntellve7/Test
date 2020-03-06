using AMS.Broker.AutherizationService.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.AutherizationService.Services
{
    class InsertAuthLog // jatin 09102017
    {
        private static bool IsFileCreated = false;
        public static void AddProcessLogAuth(string _msg)
        {
            try
            {
                if (IsFileCreated == false)
                {
                    IsFileCreated = true;
                    string _folderName = Directory.GetCurrentDirectory() + "\\AuthorizationLog";
                    string prefex = "AuthorizationLog_";
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
            //    string _folderName = Directory.GetCurrentDirectory() + "\\AuthorizationLog";
            //    if (!Directory.Exists(_folderName))
            //        Directory.CreateDirectory(_folderName);

            //    string _fileName = _folderName + "\\AuthorizationLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

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
