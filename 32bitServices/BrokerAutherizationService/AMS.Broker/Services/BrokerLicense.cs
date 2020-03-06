using AMS.Broker.Contracts.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.Broker.AutherizationService.Services // jatin 08112017
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BrokerLicense : IBrokerLicense
    {
        BrokerLicense()
        {
            StartLicenseThread();
        }
        Thread LicenseThread;
        ~BrokerLicense()
        {
            if (LicenseThread != null)
                LicenseThread.Abort();
            LicenseThread = null;
        }

        internal static IBrokerLicense Initialise()
        {
            try
            {

                var service = new BrokerLicense();

                var controllerHost = new ServiceHost(service);

                foreach (var endpoint in controllerHost.Description.Endpoints)
                {
                    if (endpoint.Binding is WSHttpBinding)
                    {
                        (endpoint.Binding as WSHttpBinding).MaxReceivedMessageSize = Int32.MaxValue;
                        (endpoint.Binding as WSHttpBinding).MaxBufferPoolSize = Int32.MaxValue;
                    }
                }
                controllerHost.Open();
                // _logger.Info("BrokerLicenseService Service Started Successfully");

                // AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016

                return service;
            }
            catch (Exception ex)
            {
                // _logger.Info("BrokerLicenseService Initialise() Exception" + ex.Message);
            }

            return null;
        }

        public void CheckTempararyLicenseValidity()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        DateTime dt = new DateTime(2018, 4, 7, 23, 59, 59);//05092017
                        if (DateTime.Now <= dt)
                        {


                        }
                        else
                        {
                            InsertAuthLog.AddProcessLogAuth("Error while validating license, Please contact 2020imaging");
                            Process[] processes;
                            processes = Process.GetProcesses();
                            var procs = processes.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                                                         .OrderByDescending(x => x.ProcessName)
                                                         .ToList();
                            foreach (var process in procs)
                            {

                                if (process.ProcessName == "AMS.Broker.CommunicationService")
                                {
                                    process.Kill();
                                }
                                if (process.ProcessName == "AMS.Broker.GetOperationsService")
                                {
                                    process.Kill();
                                }
                                if (process.ProcessName == "AMS.Broker.IntegrationService")
                                {
                                    process.Kill();
                                }
                                if (process.ProcessName == "AMS.Broker.SetOperationService")
                                {
                                    process.Kill();
                                }
                                if (process.ProcessName == "AMS.Broker.TransactionService")
                                {
                                    process.Kill();
                                }
                                if (process.ProcessName == "AMS.Broker.WatchDogService")
                                {
                                    process.Kill();
                                }
                                if (process.ProcessName == "AMS.Broker.AutherizationService")
                                {
                                    process.Kill();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            { 
            }
        }

        public void CheckLicenseValidity()
        {
            while (true)
            {
                try
                {
                    bool IsStartBroker = false;
                    string islicence = Storage.IsLicenceCheck;

                    if (true)// Storage.IsLicenceCheck == "1")
                    {
                        //Identifier.Contains("_Mobile") || !actstation.Identifier.Contains("_DashBoard")
                        var RootDir = System.Reflection.Assembly.GetExecutingAssembly().Location;
                        RootDir = RootDir.Replace("AMS.Broker.AutherizationService.exe", "");
                        RootDir = RootDir + "2020License";
                        //RootDir=@"E:\Installshield\Broker\Release\2020License";
                        string OnlyfileName = null;
                        int length1 = 0;

                        if (Directory.Exists(RootDir))
                        {
                            string[] filePaths = Directory.GetFiles(RootDir, "*.lic", SearchOption.AllDirectories);
                            var directory = new DirectoryInfo(RootDir);
                            if (directory.GetFiles().Length > 0)
                            {
                                var MyFile = (from f in directory.GetFiles("*.lic", SearchOption.AllDirectories)
                                              orderby f.LastWriteTime descending
                                              select f).First();

                                string SuccessGUID = "425330e9-8c97-434a-a9af-7b63602ef05e";
                                string FailureGUID = "fd7f39ad-415d-4d18-b758-8ee6f1b83c7c";

                                string MachineName = Environment.MachineName;
                                string MAcAddress = null;
                                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                                String sMacAddress = string.Empty;
                                foreach (NetworkInterface adapter in nics)
                                {
                                    if (sMacAddress == String.Empty && adapter.GetPhysicalAddress().ToString() != "")// only return MAC Address from first card  
                                    {
                                        //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                                        MAcAddress = adapter.GetPhysicalAddress().ToString();
                                    }
                                }
                                if (filePaths.Count() > 0)
                                {

                                    string _fileName = MyFile.FullName;
                                    // length1 = _fileName.Length - RootDir.Length - 1;
                                    OnlyfileName = MyFile.Name;

                                    byte[] buffer;
                                    FileStream fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                                    try
                                    {
                                        int length = (int)fileStream.Length;  // get file length
                                        buffer = new byte[length];            // create buffer
                                        int count;                            // actual number of bytes read
                                        int sum = 0;                          // total number of bytes read

                                        // read until Read method returns 0 (end of the stream has been reached)
                                        while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                                            sum += count;  // sum is a buffer offset for next reading


                                        string LicTableId = null;
                                        string GUID = null;
                                        var InputData = OnlyfileName.Split('_');
                                        if (InputData != null)
                                        {
                                            LicTableId = InputData[0];
                                            GUID = InputData[1];
                                        }
                                        string key1 = "0000000000000000";
                                        var key = key1.Substring(LicTableId.Length, 16 - LicTableId.Length) + LicTableId;
                                        string outpath = RootDir + "//Output.txt";
                                        string inpath = RootDir + "//Input.txt";
                                        string bufferstring = System.Text.Encoding.Default.GetString(buffer);
                                        System.IO.File.WriteAllBytes(inpath, buffer);
                                        BrokerService.DecryptFile(outpath, inpath, key);
                                        string ReadFileDt = System.IO.File.ReadAllText(outpath);

                                        var SecondDecryptData = BrokerService.Decrypt(ReadFileDt);
                                        File.Delete(inpath);
                                        File.Delete(outpath);
                                        var ReqData = SecondDecryptData.Split(',');
                                        var e = ReqData.Count();
                                        if (ReqData.Count() == 9) // jatin 07112017
                                        {

                                            int LicTableID = int.Parse(ReqData[0].Replace("start13-", ""));
                                            var CustGUID = ReqData[1];
                                            var FromDate = ReqData[2];
                                            var ToDate = ReqData[3];
                                            var CustName = ReqData[4];
                                            // var regDate = ReqData[4];
                                            var siteConnections = ReqData[5];
                                            var McName = ReqData[6];
                                            var MacAddr = ReqData[7];
                                            var ActivationGUID = ReqData[8].Replace("-end13", "");
                                            DateTime _dateVal = DateTime.Parse(epoch2string(int.Parse(ToDate))); //new DateTime(2017, 10, 2, 00, 00, 00); //DateTime.Parse(ToDate);

                                            if (ActivationGUID == SuccessGUID)
                                            {
                                                if (McName == MachineName && MacAddr == MAcAddress && DateTime.Now <= _dateVal)
                                                {
                                                    IsStartBroker = true;

                                                }
                                                else
                                                {
                                                    IsStartBroker = false;
                                                    InsertAuthLog.AddProcessLogAuth("Error while validating license, Please contact 2020imaging");
                                                    Process[] processes;
                                                    processes = Process.GetProcesses();
                                                    var procs = processes.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                                                                                 .OrderByDescending(x => x.ProcessName)
                                                                                 .ToList();
                                                    foreach (var process in procs)
                                                    {

                                                        if (process.ProcessName == "AMS.Broker.CommunicationService")
                                                        {
                                                            process.Kill();
                                                        }
                                                        if (process.ProcessName == "AMS.Broker.GetOperationsService")
                                                        {
                                                            process.Kill();
                                                        }
                                                        if (process.ProcessName == "AMS.Broker.IntegrationService")
                                                        {
                                                            process.Kill();
                                                        }
                                                        if (process.ProcessName == "AMS.Broker.SetOperationService")
                                                        {
                                                            process.Kill();
                                                        }
                                                        if (process.ProcessName == "AMS.Broker.TransactionService")
                                                        {
                                                            process.Kill();
                                                        }
                                                        if (process.ProcessName == "AMS.Broker.WatchDogService")
                                                        {
                                                            process.Kill();
                                                        }
                                                        if (process.ProcessName == "AMS.Broker.AutherizationService")
                                                        {
                                                            process.Kill();
                                                        }

                                                    }

                                                }

                                            }
                                            else
                                            {
                                                IsStartBroker = false;
                                                InsertAuthLog.AddProcessLogAuth("Error while validating license, Please contact 2020imaging");
                                                Process[] processes;
                                                processes = Process.GetProcesses();
                                                var procs = processes.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                                                                             .OrderByDescending(x => x.ProcessName)
                                                                             .ToList();
                                                foreach (var process in procs)
                                                {

                                                    if (process.ProcessName == "AMS.Broker.CommunicationService")
                                                    {
                                                        process.Kill();
                                                    }
                                                    if (process.ProcessName == "AMS.Broker.GetOperationsService")
                                                    {
                                                        process.Kill();
                                                    }
                                                    if (process.ProcessName == "AMS.Broker.IntegrationService")
                                                    {
                                                        process.Kill();
                                                    }
                                                    if (process.ProcessName == "AMS.Broker.SetOperationService")
                                                    {
                                                        process.Kill();
                                                    }
                                                    if (process.ProcessName == "AMS.Broker.TransactionService")
                                                    {
                                                        process.Kill();
                                                    }
                                                    if (process.ProcessName == "AMS.Broker.WatchDogService")
                                                    {
                                                        process.Kill();
                                                    }
                                                    if (process.ProcessName == "AMS.Broker.AutherizationService")
                                                    {
                                                        process.Kill();
                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            IsStartBroker = false;
                                            InsertAuthLog.AddProcessLogAuth("Error while validating license, Please contact 2020imaging");
                                            Process[] processes;
                                            processes = Process.GetProcesses();
                                            var procs = processes.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                                                                         .OrderByDescending(x => x.ProcessName)
                                                                         .ToList();
                                            foreach (var process in procs)
                                            {

                                                if (process.ProcessName == "AMS.Broker.CommunicationService")
                                                {
                                                    process.Kill();
                                                }
                                                if (process.ProcessName == "AMS.Broker.GetOperationsService")
                                                {
                                                    process.Kill();
                                                }
                                                if (process.ProcessName == "AMS.Broker.IntegrationService")
                                                {
                                                    process.Kill();
                                                }
                                                if (process.ProcessName == "AMS.Broker.SetOperationService")
                                                {
                                                    process.Kill();
                                                }
                                                if (process.ProcessName == "AMS.Broker.TransactionService")
                                                {
                                                    process.Kill();
                                                }
                                                if (process.ProcessName == "AMS.Broker.WatchDogService")
                                                {
                                                    process.Kill();
                                                }
                                                if (process.ProcessName == "AMS.Broker.AutherizationService")
                                                {
                                                    process.Kill();
                                                }

                                            }
                                        }


                                    }
                                    catch (Exception ex)
                                    {
                                        InsertAuthLog.AddProcessLogAuth("Exception while validating license" + ex.Message);
                                        Process[] processes;
                                        processes = Process.GetProcesses();
                                        var procs = processes.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                                                                     .OrderByDescending(x => x.ProcessName)
                                                                     .ToList();
                                        foreach (var process in procs)
                                        {

                                            if (process.ProcessName == "AMS.Broker.CommunicationService")
                                            {
                                                process.Kill();
                                            }
                                            if (process.ProcessName == "AMS.Broker.GetOperationsService")
                                            {
                                                process.Kill();
                                            }
                                            if (process.ProcessName == "AMS.Broker.IntegrationService")
                                            {
                                                process.Kill();
                                            }
                                            if (process.ProcessName == "AMS.Broker.SetOperationService")
                                            {
                                                process.Kill();
                                            }
                                            if (process.ProcessName == "AMS.Broker.TransactionService")
                                            {
                                                process.Kill();
                                            }
                                            if (process.ProcessName == "AMS.Broker.WatchDogService")
                                            {
                                                process.Kill();
                                            }
                                            if (process.ProcessName == "AMS.Broker.AutherizationService")
                                            {
                                                process.Kill();
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    IsStartBroker = false;
                                    InsertAuthLog.AddProcessLogAuth("Error while validating license, Please contact 2020imaging");
                                    Process[] processes;
                                    processes = Process.GetProcesses();
                                    var procs = processes.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                                                                 .OrderByDescending(x => x.ProcessName)
                                                                 .ToList();
                                    foreach (var process in procs)
                                    {

                                        if (process.ProcessName == "AMS.Broker.CommunicationService")
                                        {
                                            process.Kill();
                                        }
                                        if (process.ProcessName == "AMS.Broker.GetOperationsService")
                                        {
                                            process.Kill();
                                        }
                                        if (process.ProcessName == "AMS.Broker.IntegrationService")
                                        {
                                            process.Kill();
                                        }
                                        if (process.ProcessName == "AMS.Broker.SetOperationService")
                                        {
                                            process.Kill();
                                        }
                                        if (process.ProcessName == "AMS.Broker.TransactionService")
                                        {
                                            process.Kill();
                                        }
                                        if (process.ProcessName == "AMS.Broker.WatchDogService")
                                        {
                                            process.Kill();
                                        }
                                        if (process.ProcessName == "AMS.Broker.AutherizationService")
                                        {
                                            process.Kill();
                                        }

                                    }
                                }
                            }//
                            else
                            {
                                IsStartBroker = false;
                                InsertAuthLog.AddProcessLogAuth("License file not found");
                                Process[] processes;
                                processes = Process.GetProcesses();
                                var procs = processes.Where(x => x.SessionId == Process.GetCurrentProcess().SessionId)
                                                             .OrderByDescending(x => x.ProcessName)
                                                             .ToList();
                                foreach (var process in procs)
                                {

                                    if (process.ProcessName == "AMS.Broker.CommunicationService")
                                    {
                                        process.Kill();
                                    }
                                    if (process.ProcessName == "AMS.Broker.GetOperationsService")
                                    {
                                        process.Kill();
                                    }
                                    if (process.ProcessName == "AMS.Broker.IntegrationService")
                                    {
                                        process.Kill();
                                    }
                                    if (process.ProcessName == "AMS.Broker.SetOperationService")
                                    {
                                        process.Kill();
                                    }
                                    if (process.ProcessName == "AMS.Broker.TransactionService")
                                    {
                                        process.Kill();
                                    }
                                    if (process.ProcessName == "AMS.Broker.WatchDogService")
                                    {
                                        process.Kill();
                                    }
                                    if (process.ProcessName == "AMS.Broker.AutherizationService")
                                    {
                                        process.Kill();
                                    }

                                }
                            }
                        }
                        else
                        {
                            IsStartBroker = false;
                            InsertAuthLog.AddProcessLogAuth("Licence Directory:" + RootDir + " :Not found");
                        }
                    }
                    else
                    {
                        IsStartBroker = true;
                    }
                    new ManualResetEvent(false).WaitOne(10000); // jatin 2709
                }
                catch (Exception ex) { }

            }
        }
        public static string epoch2string(int epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToString();
        }

        public bool StartLicenseThread()
        {
            try
            {
                LicenseThread = new Thread(new ThreadStart(CheckTempararyLicenseValidity));//CheckLicenseValidity));
                LicenseThread.IsBackground = true;
                LicenseThread.Start();
            }
            catch (Exception ex)
            {
                InsertAuthLog.AddProcessLogAuth("BrokerLicense StartLiceseThread() Exception" + ex.Message);
                return false;
            }
            finally
            {

            }
            return false;
        }
    }
}
