using System;
using System.ServiceProcess;
using AMS.Broker.WatchDogService.DataStore;
using AMS.Broker.WatchDogService.Helpers;
using AMS.Broker.WatchDogService.Services;
using NLog;
using Microsoft.Practices.Unity;
using AMS.Broker.Contracts.Services;
using AMS.Broker.WatchDogService.Services.ServicesImplementations;
using System.Configuration;
using System.Configuration.Install;
using System.ServiceModel;
using System.IO;
using System.Xml.Serialization;
//using BioCom;  //trupti30sept15
using System.Collections.Generic;
using AMS.Broker.Contracts.DTO;
using AutoMapper;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Net.NetworkInformation;
using System.ServiceModel.Channels;


namespace AMS.Broker.WatchDogService
{
    public class BrokerService : ServiceBase
    {
        public static IUnityContainer Container;

        public ServiceHost serviceHost = null;
        public BrokerMembershipProvider brokerMemProvider;  //amit 18052017

        public BrokerService()
        {
            this.ServiceName = "BrokerWatchDogService";

            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);

            Console.WriteLine(" In Broker inside BrokerWatchDogService");

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            Container = new UnityContainer();

            Container.RegisterInstance<IUnityContainer>(Container);

            Container = Microsoft.Practices.Unity.Configuration.UnityContainerExtensions.LoadConfiguration(Container);

            //Container.RegisterType<IAlertsService,Alertser>();

            Container.RegisterInstance<Logger>(LogManager.GetCurrentClassLogger());

            InitializeBrokerProvider(); //amit 18052017
        }

        public void InitializeBrokerProvider()  //amit 18052017
        {
            try
            {
                brokerMemProvider = new BrokerMembershipProvider();
                System.Web.Security.SqlMembershipProvider ObjSqlMembershipProvider = new System.Web.Security.SqlMembershipProvider();
                System.Web.Security.SqlRoleProvider ObjSqlRoleProvider = new System.Web.Security.SqlRoleProvider();
                System.Collections.Specialized.NameValueCollection ObjNameValueCollRole = new System.Collections.Specialized.NameValueCollection();
                System.Collections.Specialized.NameValueCollection ObjNameValueCollMembership = new System.Collections.Specialized.NameValueCollection();
                System.Web.Security.MembershipCreateStatus enMembershipCreateStatus;
                ObjNameValueCollMembership.Add("connectionStringName", "SqlMembershipConn");
                ObjNameValueCollMembership.Add("applicationName", "AMS.Broker.WatchDogService");
                //these items are assumed to be Default and dont care..Should be given a look later stage.
                ObjNameValueCollMembership.Add("enablePasswordRetrieval", "false");
                ObjNameValueCollMembership.Add("enablePasswordReset", "false");
                ObjNameValueCollMembership.Add("requiresQuestionAndAnswer", "false");
                ObjNameValueCollMembership.Add("requiresUniqueEmail", "false");
                ObjNameValueCollMembership.Add("passwordFormat", "Hashed");
                ObjNameValueCollMembership.Add("maxInvalidPasswordAttempts", "5");
                ObjNameValueCollMembership.Add("minRequiredPasswordLength", "1");
                ObjNameValueCollMembership.Add("minRequiredNonalphanumericCharacters", "0");
                ObjNameValueCollMembership.Add("passwordAttemptWindow", "10");
                ObjNameValueCollMembership.Add("passwordStrengthRegularExpression", "");
                // ObjSqlMembershipProvider.Initialize("AspNetSqlMembershipProvider", ObjNameValueCollMembership);
                //System.Web.Security.MembershipUser user = ObjSqlMembershipProvider.CreateUser("admin,"password","emaiol@g.com");
                //hard coded the Provider Name,This function just need one that is present. I tried other names and it throws error. I found this using Reflector ..all the rest are take care by the above
                //name value pairs
                brokerMemProvider.Initialize("BrokerMembershipProvider", ObjNameValueCollMembership);
            }
            catch (Exception ex)
            {
            }
        }
        public void StartInConsole(string[] args)
        {
            this.OnStart(args);
        }

        public void StopInConsole()
        {
            this.OnStop();
        }

        public bool CheckCertificate()
        {
            try
            {
                System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly); // Dont forget. otherwise u will get an exception.
                X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindBySubjectName, "2020ImagingLtd", true);
                if (certs.Count > 0)
                {
                    // Certificate is found.
                    return true;
                }
                else
                {
                    return false;
                    // No Certificate found by that subject name.

                }
            }
            catch (Exception ex)
            { }
            return false;
        }

        public static string Decrypt(string encryptedText)
        {
            string PasswordHash = "P@@Sw0rd";
            string SaltKey = "S@LT&KEY";
            string VIKey = "@1B2c3D4e5F6g7H8";
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        private static void DecryptFile(string outputFile, string inputFile, string skey)
        {
            try
            {

                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);



                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // failed to decrypt file
            }
        }

        bool ValidateAuthToken(string authToken)
        {
            try
            {
                string Message = "ControllergetopService ValidateAuthToken() authToken:" + authToken;
                InsertBrokerOperationLog.AddProcessLog(Message);

                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(endpoint.Address);
                System.Net.IPAddress _reqIp = ConverttoIP(authToken);

                if (ip.ToString() == _reqIp.ToString())
                {
                    return true;
                }
                else
                { return true; }

            }
            catch (Exception ex)
            {
                string Message = "ControllergetopService ValidateAuthToken() Exception:" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
            }

            return true;
        }
        private System.Net.IPAddress ConverttoIP(string AuthToken)
        {
            try
            {
                var _firstPair = AuthToken.Substring(24, 3);
                var _secondPair = AuthToken.Substring(27, 3);
                var _thirdPair = AuthToken.Substring(30, 3);
                var _fourthPair = AuthToken.Substring(33, 3);
                string IPaddr = _firstPair + "." + _secondPair + "." + _thirdPair + "." + _fourthPair;
                var convertaddress = System.Text.RegularExpressions.Regex.Replace(IPaddr, "0*([0-9]+)", "${1}");
                var address = System.Net.IPAddress.Parse(convertaddress);
                return address;
            }
            catch (Exception ex)
            {
                _logger.Info("------------------------------------");
                _logger.Info("ConverttoIP exception AuthToken" + AuthToken);
                string Message = "ControllergetopService ConverttoIP() Exception:" + ex.Message;
                InsertBrokerOperationLog.AddProcessLog(Message);
                return null;
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
             
                bool IsStartBroker = false;
                if (Storage.IsLicenceCheck == "1")
                {
                    //Identifier.Contains("_Mobile") || !actstation.Identifier.Contains("_DashBoard")
                    var RootDir = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    RootDir = RootDir.Replace("AMS.Broker.WatchDogService.exe", "");
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
                                    DecryptFile(outpath, inpath, key);
                                    string ReadFileDt = System.IO.File.ReadAllText(outpath);

                                    var SecondDecryptData = Decrypt(ReadFileDt);
                                    File.Delete(inpath);
                                    File.Delete(outpath);
                                    var ReqData = SecondDecryptData.Split(',');
                                    if (ReqData.Count() == 9) // jatin 07112017 // jatin 08112017
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
                                        DateTime _dateVal = DateTime.Parse(epoch2string(int.Parse(ToDate)));

                                        if (ActivationGUID == SuccessGUID)
                                        {
                                            if (McName == MachineName && MacAddr == MAcAddress && DateTime.Now <= _dateVal)    // jatin 08112017
                                            {
                                                IsStartBroker = true;
                                            }
                                            else
                                            {
                                                IsStartBroker = false;
                                                _logger.Info("Error while validating license, Please contact 2020imaging");
                                                InsertBrokerOperationLog.AddProcessLog("Error while validating license, Please contact 2020imaging");//jatin
                                            }
                                        }
                                        else
                                        {
                                            IsStartBroker = false;
                                            _logger.Info("Error while validating license, Please contact 2020imaging");
                                            InsertBrokerOperationLog.AddProcessLog("Error while validating license, Please contact 2020imaging");//jatin
                                        }
                                    }
                                    else
                                    {
                                        IsStartBroker = false;
                                        _logger.Info("Error while validating license, Please contact 2020imaging");
                                        InsertBrokerOperationLog.AddProcessLog("Error while validating license, Please contact 2020imaging");//jatin
                                    }


                                }
                                catch (Exception ex)
                                {
                                    _logger.Info("Exception while validating license" + ex.Message);
                                    InsertBrokerOperationLog.AddProcessLog("Exception while validating license" + ex.Message);//jatin
                                }
                            }
                            else
                            {
                                IsStartBroker = false;
                                _logger.Info("Error while validating license, Please contact 2020imaging");
                                InsertBrokerOperationLog.AddProcessLog("Error while validating license, Please contact 2020imaging");//jatin
                            }
                        }//
                        else
                        {
                            IsStartBroker = false;
                            _logger.Info("Licence file not found");
                            InsertBrokerOperationLog.AddProcessLog("Licence file not found");//jatin
                        }
                    }
                    else
                    {
                        IsStartBroker = false;
                        _logger.Info("Licence Directory:" + RootDir + " :Not found");
                        InsertBrokerOperationLog.AddProcessLog("Licence Directory:" + RootDir + " :Not found");//jatin
                    }
                }
                else
                {
                    IsStartBroker = true;
                }
                if (IsStartBroker == true)
                {
                    if (CheckCertificate() == false)
                    {
                        _logger.Info("BrokerWatchDogService OnStart() : " + "Kindly install valid certificate from 2020Imaging!");
                        Environment.Exit(1);
                    }

                    System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);

                    SSLValidator.OverrideValidation(); //it is for https //trupti250216

                    IUnityContainer container = new UnityContainer();

                    container.RegisterInstance<IUnityContainer>(container);

                    container = Microsoft.Practices.Unity.Configuration.UnityContainerExtensions.LoadConfiguration(container);


                    //BrokerService.Container.RegisterInstance<IStationsService>(new StationsServiceImpl());    


                    GatewayService.Initialise();

                    //var AlertCreationServ = AlertsCreationService.Initialise(stationService, bizTalkHelper);



                    //IEnumerable<DeviceDto> DeviceCollection = controllerService.GetDevicesCollection(authCode);
                    //controllerService.GetDevicesCollectionMob(authCode);


                    //CreateXamlFile(DeviceCollection); //for updating camera status

                    var _IcameraStatus = CameraStatusService.Initialise();
                    //_IcameraStatus.StartCameraStatusTimer();
                    
                    base.OnStart(args);
                }
            }
            catch (Exception e)
            {
                _logger.Info("BrokerService OnStart() Exception:" + e.Message);
                ExceptionHandler(e);
            }
        }


        public static string epoch2string(int epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToString();
        }

        public void CreateXamlFile(IEnumerable<DeviceDto> _deviceCollection)
        {
            try
            {
                if (!Directory.Exists(Storage.DeviceListPath))
                    Directory.CreateDirectory(Storage.DeviceListPath);

                foreach (var Dev in _deviceCollection)
                {
                    if (Dev is NvrCameraDto)
                    {
                        var _cam = Dev as NvrCameraDto;
                        string Fpath = Storage.DeviceListPath + "\\" + _cam.CameraGUID + ".xaml";
                        Fpath = Fpath.Replace("\r", string.Empty);
                        Fpath = Fpath.Replace("\n", string.Empty);
                        try
                        {
                            if (File.Exists(Fpath))
                            {
                                File.Delete(Fpath);
                            }

                            //File.Create(Fpath);

                            using (var writer = new System.IO.StreamWriter(Fpath))
                            {
                                var serializer = new XmlSerializer(_cam.GetType());
                                serializer.Serialize(writer, _cam);
                                writer.Flush();

                            }
                        }
                        catch (Exception ex)
                        { _logger.Info("BrokerService CreateXamlFile() Exception:" + ex.Message); }


                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info("BrokerService CreateXamlFile() Exception:" + ex.Message);
            }
        }


        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }

            //_deviceManager.Stop();
            base.OnStop();
        }
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (e.ExceptionObject as Exception);

            ExceptionHandler(exception);
        }

        private void ExceptionHandler(Exception exception)
        {
            if (exception != null)
                _logger.Fatal(exception.Message);
        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
    }

    public static class SSLValidator
    {

        private static System.Net.Security.RemoteCertificateValidationCallback _orgCallback;

        private static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool result = false;

            if (certificate.Subject.Contains("2020ImagingLtd") || certificate.Subject.Contains("cloudinary.com"))
            {
                return true;
            }
            // MessageBox.Show("Kindly install valid certificate from 2020Imaging!");

            Environment.Exit(1);
            return result;
        }

        public static void OverrideValidation()
        {
            _orgCallback = ServicePointManager.ServerCertificateValidationCallback;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(OnValidateCertificate);
            ServicePointManager.Expect100Continue = true;
        }


        public static void RestoreValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = _orgCallback;
        }
    }

}