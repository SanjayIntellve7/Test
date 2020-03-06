using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AMS.Broker.IntegrationService
{
    internal static class Storage
    {
        //amit 16052017
        public static string GetConfigValue(string key)
        {
            try
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = ConfigFilePath + @"\Configuration.exe.config";
                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                var dummyValue = config.AppSettings.Settings[key].Value;
                return dummyValue;
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        public static string GetConnectionString(string key)
        {
            try
            {
                //
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = ConfigFilePath + @"\Configuration.exe.config";
                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                var dummyValue = config.ConnectionStrings.ConnectionStrings[key].ConnectionString;//AppSettings.Settings[key].Value;
                return dummyValue;
            }
            catch (Exception ex)
            {
            }
            return "";
        }

        //amit 16052017
        public static String CentralDBEntitiesString
        {
            get { return GetConnectionString("CentralDBEntities"); }//ConfigurationManager.AppSettings["RhinoSecurity.ConnectionString"]; }
        }// 
        //amit 16052017
        public static String RhinoConnectionString
        {
            get { return GetConfigValue("RhinoSecurity.ConnectionString"); }//ConfigurationManager.AppSettings["RhinoSecurity.ConnectionString"]; }
        }
        //amit 16052017
        public static String ConfigFilePath  //read from this config file
        {
            get { return ConfigurationManager.AppSettings["ConfigFilePath"]; }
        }

        //amit 06072017
        public static String IsLicenceCheck
        {
            get { return GetConfigValue("IsLicenceCheck"); }
        }

        public static String Domain
        {
            get { return GetConfigValue("LdapDomain"); }//ConfigurationManager.AppSettings["LdapDomain"]; }
        }//= "uicentric.local.fail";

        public static String Container
        {
            get { return GetConfigValue("LdapContainer"); }//ConfigurationManager.AppSettings["LdapContainer"]; }
        }

        public static string User
        {
            get { return GetConfigValue("LdapUser"); }//ConfigurationManager.AppSettings["LdapUser"]; }
        }

        public static string Password
        {
            get { return GetConfigValue("LdapPassword"); }//ConfigurationManager.AppSettings["LdapPassword"]; }
        }

        public static string Context
        {
            get { return GetConfigValue("LdapContext"); }//ConfigurationManager.AppSettings["LdapContext"]; }
        }

        public static int AlarmGeneratorPeriod
        {
            get { return int.Parse(GetConfigValue("AlarmGeneratorPeriod")); }//ConfigurationManager.AppSettings["AlarmGeneratorPeriod"]); }
        }

        public static int CameraStatusTimeSec
        {
            get { return int.Parse(GetConfigValue("CameraStatusTimeSec")); }////ConfigurationManager.AppSettings["CameraStatusTimeSec"]); }
        }

        public static int GeoFenceTimerMin
        {
            get { return int.Parse(GetConfigValue("GeoFenceTimerMin")); }//ConfigurationManager.AppSettings["GeoFenceTimerMin"]); }
        }


        public static int PingStationMinuteTimer
        {
            get { return int.Parse(GetConfigValue("PingStationMinuteTimer")); }//ConfigurationManager.AppSettings["PingStationMinuteTimer"]); }
        }

        public static string VideoRepository
        {
            get { return GetConfigValue("VideoRepository"); }//ConfigurationManager.AppSettings["VideoRepository"]; }
        }

        public static string MeonServerIP
        {
            get { return GetConfigValue("MeonServerIP"); }//ConfigurationManager.AppSettings["MeonServerIP"]; }
        }

        public static string MeonUsername
        {
            get { return GetConfigValue("MeonUsername"); }//ConfigurationManager.AppSettings["MeonUsername"]; }
        }

        public static string MeonPassword
        {
            get { return GetConfigValue("MeonPassword"); }//ConfigurationManager.AppSettings["MeonPassword"]; }
        }

        public static string BrokerPublicIP
        {
            get { return GetConfigValue("BrokerPublicIP"); }//ConfigurationManager.AppSettings["BrokerPublicIP"]; }
        }

        public static string ImageRepository
        {
            get { return GetConfigValue("ImageRepository"); }//ConfigurationManager.AppSettings["ImageRepository"]; }
        }

        public static string RolesContainerName
        {
            get { return GetConfigValue("RolesContainerName"); }//ConfigurationManager.AppSettings["RolesContainerName"]; }
        }

        public static string IsAnalyticServer
        {
            get { return GetConfigValue("IsAnalyticServer"); }//ConfigurationManager.AppSettings["IsAnalyticServer"]; }
        }

        public static string AnalyticServerIP
        {
            get { return GetConfigValue("AnalyticServerIP"); }//ConfigurationManager.AppSettings["AnalyticServerIP"]; }
        }

        public static string ANPRServer
        {
            get { return GetConfigValue("ANPRServer"); }//ConfigurationManager.AppSettings["ANPRServer"]; }
        }

        public static string DeviceListPath
        {
            get { return GetConfigValue("DeviceListPath"); }//ConfigurationManager.AppSettings["DeviceListPath"]; }
        }


        public static string ANPRUsername
        {
            get { return GetConfigValue("ANPRUsername"); }//ConfigurationManager.AppSettings["ANPRUsername"]; }
        }

        public static string ANPRPassword
        {
            get { return GetConfigValue("ANPRPassword"); }//ConfigurationManager.AppSettings["ANPRPassword"]; }
        }

        public static string ANPRDB
        {
            get { return GetConfigValue("ANPRDB"); }//ConfigurationManager.AppSettings["ANPRDB"]; }
        }

        public static string DBClientServer
        {
            get { return GetConfigValue("DBClientServer"); }//ConfigurationManager.AppSettings["DBClientServer"]; }
        }

        public static string DBClientUsername
        {
            get { return GetConfigValue("DBClientUsername"); }//ConfigurationManager.AppSettings["DBClientUsername"]; }
        }

        public static string DBClientPassword
        {
            get { return GetConfigValue("DBClientPassword"); }//ConfigurationManager.AppSettings["DBClientPassword"]; }
        }

        public static string DBClientDB
        {
            get { return GetConfigValue("DBClientDB"); }//ConfigurationManager.AppSettings["DBClientDB"]; }
        }

        public static string ISANPRIntegration
        {
            get { return GetConfigValue("ISANPRIntegration"); }//ConfigurationManager.AppSettings["ISANPRIntegration"]; }
        }

        public static string IsCloudServer
        {
            get { return GetConfigValue("IsCloudServer"); }//ConfigurationManager.AppSettings["IsCloudServer"]; }
        }


        public static string AlertMediaTicket
        {
            get { return GetConfigValue("AlertMediaTicket"); }//ConfigurationManager.AppSettings["AlertMediaTicket"]; }
        }

        public static string ISExportEnable
        {
            get { return GetConfigValue("ISExportEnable"); }//ConfigurationManager.AppSettings["ISExportEnable"]; }
        }

        public static string IISVideoRepository
        {
            get { return GetConfigValue("IISVideoRepository"); }//ConfigurationManager.AppSettings["IISVideoRepository"]; }
        }

        public static string IISImageRepository
        {
            get { return GetConfigValue("IISImageRepository"); }//ConfigurationManager.AppSettings["IISImageRepository"]; }
        }

        public static string EdgeAnalyticsRefreshTimeMin
        {
            get { return GetConfigValue("EdgeAnalyticsRefreshTimeMin"); }//ConfigurationManager.AppSettings["EdgeAnalyticsRefreshTimeMin"]; }
        }

        public static int IsMobNotficationEnb
        {
            get { return int.Parse(GetConfigValue("IsMobNotficationEnb")); }//ConfigurationManager.AppSettings["IsMobNotficationEnb"]); }
        }

        //trupti150216
        public static string SMTPPass
        {
            get { return GetConfigValue("SMTPPass"); }//ConfigurationManager.AppSettings["SMTPPass"]; }
        }

        public static string SMTPUser
        {
            get { return GetConfigValue("SMTPUser"); }//ConfigurationManager.AppSettings["SMTPUser"]; }
        }


        public static string SMTPPort
        {
            get { return GetConfigValue("SMTPPort"); }//ConfigurationManager.AppSettings["SMTPPort"]; }
        }

        public static string SMTPServer
        {
            get { return GetConfigValue("SMTPServer"); }//ConfigurationManager.AppSettings["SMTPServer"]; }
        }

        public static string EmailDisplayName
        {
            get { return GetConfigValue("EmailDisplayName"); }//ConfigurationManager.AppSettings["EmailDisplayName"]; }
        }

        public static string EmailSubject
        {
            get { return GetConfigValue("EmailSubject"); }//ConfigurationManager.AppSettings["EmailSubject"]; }
        }
        public static string AdminUserID
        {
            get { return GetConfigValue("AdminUserID"); }//ConfigurationManager.AppSettings["AdminUserID"]; }
        }
        public static string ToEmainId
        {
            get { return GetConfigValue("ToEmainId"); }//ConfigurationManager.AppSettings["ToEmainId"]; }
        }
        public static string CCEmailId
        {
            get { return GetConfigValue("CCEmailId"); }//ConfigurationManager.AppSettings["CCEmailId"]; }
        }
        public static string BCCEmailID
        {
            get { return GetConfigValue("BCCEmailID"); }//ConfigurationManager.AppSettings["BCCEmailID"]; }
        }
        public static string FromEmainId
        {
            get { return GetConfigValue("FromEmainId"); }//ConfigurationManager.AppSettings["FromEmainId"]; }
        }
        public static string SendEmailFlag  //trupti230216
        {
            get { return GetConfigValue("SendEmailFlag"); }//ConfigurationManager.AppSettings["SendEmailFlag"]; }
        }


        public static string IsUpgradeDB  //amit 28 March 16
        {
            get { return GetConfigValue("IsUpgradeDB"); }//ConfigurationManager.AppSettings["IsUpgradeDB"]; }
        }

        //

        public static string IsEdgeBase  //trupti290216
        {
            get { return GetConfigValue("IsEdgeBase"); }//ConfigurationManager.AppSettings["IsEdgeBase"]; }
        }


        public static string MatrixServer
        {
            get { return GetConfigValue("MatrixServer"); }//ConfigurationManager.AppSettings["MatrixServer"]; }
        }


        public static string MatrixUsername
        {
            get { return GetConfigValue("MatrixUsername"); }//ConfigurationManager.AppSettings["MatrixUsername"]; }
        }

        public static string MatrixPassword
        {
            get { return GetConfigValue("MatrixPassword"); }//ConfigurationManager.AppSettings["MatrixPassword"]; }
        }

        public static string MatrixDB
        {
            get { return GetConfigValue("MatrixDB"); }//ConfigurationManager.AppSettings["MatrixDB"]; }
        }

        public static string ISMatrixIntegration
        {
            get { return GetConfigValue("ISMatrixIntegration"); }//ConfigurationManager.AppSettings["ISMatrixIntegration"]; }
        }
        public static string ISClimateControlIntegration
        {
            get { return GetConfigValue("ISClimateControlIntegration"); }//ConfigurationManager.AppSettings["ISClimateControlIntegration"]; }
        }

        public static string ClimateControlURL
        {
            get { return GetConfigValue("ClimateControlURL"); }//ConfigurationManager.AppSettings["ClimateControlURL"]; }
        }

        public static string ClimateControlCurrentThreadTimer
        {
            get { return GetConfigValue("ClimateControlCurrentThreadTimer"); }//ConfigurationManager.AppSettings["ClimateControlCurrentThreadTimer"]; }
        }

        public static string ClimateControlCurrentDataThreadTimer
        {
            get { return GetConfigValue("ClimateControlCurrentDataThreadTimer"); }//ConfigurationManager.AppSettings["ClimateControlCurrentDataThreadTimer"]; }
        }
        public static string PreviousInsertedCurrentDataTimer
        {
            get { return GetConfigValue("PreviousInsertedCurrentDataTimer"); }//ConfigurationManager.AppSettings["PreviousInsertedCurrentDataTimer"]; }
        }

        public static string IsLogEnable
        {
            get { return GetConfigValue("IsLogEnable"); }//ConfigurationManager.AppSettings["IsLogEnable"]; }
        }

        public static string StationServiceEnpoint
        {
            get { return GetConfigValue("StationServiceEnpoint"); }//ConfigurationManager.AppSettings["StationServiceEnpoint"]; }
        }

        public static string IsUpdateCustomMap  //amit 28 March 16
        {
            get { return GetConfigValue("IsUpdateCustomMap"); }//ConfigurationManager.AppSettings["IsUpdateCustomMap"]; }
        }

        public static string UDPListenPort  //amit 28 March 16
        {
            get { return GetConfigValue("UDPListenPort"); }//ConfigurationManager.AppSettings["IsUpdateCustomMap"]; }
        }
        //UDPListenPort
        public static string FFTAdapterIpAddress
        {
            get { return GetConfigValue("FFTAdapterIpAddress"); }//ConfigurationManager.AppSettings["ImageRepository"]; }
        }
        public static string ACSAdapterIpAddress
        {
            get { return GetConfigValue("ACSAdapterIpAddress"); }//ConfigurationManager.AppSettings["ImageRepository"]; }
        }

        public static string WorkingMode
        {
            get { return GetConfigValue("WorkingMode"); }//ConfigurationManager.AppSettings["ImageRepository"]; }
        }

        public static string MobileOperationServiceEndpoint
        {
            get { return GetConfigValue("MobileOperationServiceEndpoint"); }//ConfigurationManager.AppSettings["MobileOperationServiceEndpoint"]; }
        }

        public static string WatchdogServiceEndpoint
        {
            get { return GetConfigValue("WatchdogServiceEndpoint"); }//ConfigurationManager.AppSettings["WatchdogServiceEndpoint"]; }
        }

        public static string SetOperationServiceEndpoint
        {
            get { return GetConfigValue("SetOperationServiceEndpoint"); }//ConfigurationManager.AppSettings["SetOperationServiceEndpoint"]; }
        }

        public static string TransactionServiceEndpoint
        {
            get { return GetConfigValue("TransactionServiceEndpoint"); }//ConfigurationManager.AppSettings["TransactionServiceEndpoint"]; }
        }

        public static string GetOperationServiceEndpoint
        {
            get { return GetConfigValue("GetOperationServiceEndpoint"); }//ConfigurationManager.AppSettings["GetOperationServiceEndpoint"]; }
        }

        public static string IntegrationServiceEndpoint
        {
            get { return GetConfigValue("IntegrationServiceEndpoint"); }//ConfigurationManager.AppSettings["IntegrationServiceEndpoint"]; }
        }

        public static string SecondaryWatchdogServiceEndpoint
        {
            get { return GetConfigValue("SecondaryWatchdogServiceEndpoint"); }//ConfigurationManager.AppSettings["IntegrationServiceEndpoint"]; }
        }
        public static string SecondaryStationServiceEnpoint
        {
            get { return GetConfigValue("SecondaryStationServiceEnpoint"); }//ConfigurationManager.AppSettings["IntegrationServiceEndpoint"]; }
        }
        public static string SecondarySetOperationServiceEndpoint
        {
            get { return GetConfigValue("SecondarySetOperationServiceEndpoint"); }//ConfigurationManager.AppSettings["IntegrationServiceEndpoint"]; }
        }
        public static string SecondaryGetOperationServiceEndpoint
        {
            get { return GetConfigValue("SecondaryGetOperationServiceEndpoint"); }//ConfigurationManager.AppSettings["IntegrationServiceEndpoint"]; }
        }
        public static string SecondaryTransactionServiceEndpoint
        {
            get { return GetConfigValue("SecondaryTransactionServiceEndpoint"); }//ConfigurationManager.AppSettings["IntegrationServiceEndpoint"]; }
        }
        public static string SecondaryIntegrationServiceEndpoint
        {
            get { return GetConfigValue("SecondaryIntegrationServiceEndpoint"); }//ConfigurationManager.AppSettings["IntegrationServiceEndpoint"]; }
        }
        public static string SecondaryMobileOperationServiceEndpoint
        {
            get { return GetConfigValue("SecondaryMobileOperationServiceEndpoint"); }
        }
    }
}
