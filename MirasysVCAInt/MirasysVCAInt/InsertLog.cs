using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirasysVCAInt
{
   
    public static class InsertLog
    {
        private static bool IsFileCreated = false;
        public static void AddLog(string _msg)
        {
            try
            {
                if (IsFileCreated == false)
                {
                    IsFileCreated = true;
                    string _folderName = Directory.GetCurrentDirectory() + "\\Logs";
                    string prefex = "Log_";
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
            //    string _dir = Directory.GetCurrentDirectory() + "\\TransactionLogs";
            //    if (!Directory.Exists(_dir))
            //        Directory.CreateDirectory(_dir);

            //    string _fileName = _dir + "\\TransactionLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            //    if (!File.Exists(_fileName))
            //    {
            //        using (StreamWriter sw = File.CreateText(_fileName))
            //        {
            //            sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff") + "  " + _msg);
            //            sw.Close();
            //        }
            //    }
            //    else
            //    {
            //        using (StreamWriter sw = File.AppendText(_fileName))
            //        {
            //            sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff") + "  " + _msg);
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
