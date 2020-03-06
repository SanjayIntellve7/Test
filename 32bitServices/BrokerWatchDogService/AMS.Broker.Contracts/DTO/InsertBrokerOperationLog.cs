using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public static class InsertBrokerOperationLog //amit 14112016
    {
        public static void AddProcessLog(string _msg)
        {
            try
            {
                string _folderName = Directory.GetCurrentDirectory() + "\\TransactionLog";
                if (!Directory.Exists(_folderName))
                    Directory.CreateDirectory(_folderName);

                string _fileName = _folderName + "\\TransactionLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                if (!File.Exists(_fileName))
                {
                    using (StreamWriter sw = File.CreateText(_fileName))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + "  " + _msg);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(_fileName))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + "  " + _msg);
                        sw.Close();

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
