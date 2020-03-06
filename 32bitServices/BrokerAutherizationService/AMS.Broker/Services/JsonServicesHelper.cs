using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.AutherizationService.Services
{
    public static class JsonServicesHelper
    {
         public static void PostFile<T>(string serviceName, string method, string name, T graph)
        {
            var requestString = GetSerivcePath(serviceName, method).Replace("?&", "?");
            var jsonCode = SerializeObject<T>(graph);
            using (var client = new WebClient())
            {
                var response = client.DownloadString(requestString + "&" + name + "=" + Uri.EscapeDataString(jsonCode));
            }
        }

        public static async Task<string> PostFile<T>(string serviceName, string method, string name, T graph, bool async)
        {
            var requestString = GetSerivcePath(serviceName, method).Replace("?&", "?");
            var jsonCode = SerializeObject<T>(graph);
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(requestString + "&" + name + "=" + Uri.EscapeDataString(jsonCode));
            }
        }

        public static async Task<string> PostFile<T>(string serviceName, string method, string name, T graph, bool async,string AuthToken)
        {
            var requestString = GetSerivcePathWithAuth(serviceName, method, AuthToken).Replace("?&", "?");
            var jsonCode = SerializeObject<T>(graph);
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(requestString + "&" + name + "=" + Uri.EscapeDataString(jsonCode));
            }
        }


        public static bool PostFile<T>(string serviceName, string method, string name, Guid authToken, T graph)
        {
            var requestString = GetSerivcePath(serviceName, method).Replace("?&", "?");
            var jsonCode = SerializeObject<T>(graph);
            using (var client = new WebClient())
            {
                return
                    Deserialize<bool>(JsonServicesHelper.RemoveJsonpSyntax(
                        client.DownloadString(requestString + "&" +"authToken=" + authToken + "&" + name + "=" +
                                              jsonCode)));
            }
        }

        public static string GetResponse<T>(string serviceName, string method, string name, T graph)
        {
            var requestString = GetSerivcePath(serviceName, method).Replace("?&", "?");
            var jsonCode = SerializeObject<T>(graph);
            using (var client = new WebClient())
            {
                return client.DownloadString(requestString + "&" + name + "=" + jsonCode);
            }
        }       

        public static IEnumerable<T> GetObjectsCollection<T>(string serviceName, string method, params string[] parameters)
        {
            return GetObject<IEnumerable<T>>(serviceName, method, parameters);
        }

        public static string GetJsonResponse(string serviceName, string method, params string[] parameters)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var requestString = GetSerivcePath(serviceName, method, parameters);
                    if (serviceName == "GeoTrackingService")
                    {
                        requestString = requestString.Replace("https", "http");
                        requestString = requestString.Replace("6530", "4530");
                    }
                    var strRetVal=client.DownloadString(requestString);
                    return strRetVal;
                }
            }           
            catch (Exception ex) 
            {
            }

            return null;
        }

        public static async Task<string> GetAsyncJsonResponse(string serviceName, string method, params string[] parameters)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (var client = new WebClient())
                    {
                        var requestString = GetSerivcePath(serviceName, method, parameters);
                        return client.DownloadString(requestString);
                    }
                });
        }

        public static string GetJsonResponse(string serviceName, string method,  bool awaitable, params string[] parameters)
        {
            using (var client = new WebClient())
            {
                var requestString = GetSerivcePath(serviceName, method, parameters);
                return client.DownloadString(requestString);
            }
        }

        public static T Deserialize<T>(string json)
        {
            if (String.IsNullOrWhiteSpace(json))
                return default(T);

            var serializer = new DataContractJsonSerializer(typeof(T));

            var fixedJson = json.Replace(":,", ":\"\",");
     
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(fixedJson)))
                return (T)serializer.ReadObject(stream);
        }

        public static string SerializeObject<T>(T graph)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            string jsonCode;

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, graph);
                jsonCode = Encoding.Default.GetString(ms.ToArray());
            }
            return jsonCode;
        }

        public static T GetObject<T>(string serviceName, string method, bool awaitable, params string[] parameters)
        {
            var json = GetJsonResponse(serviceName, method, true, parameters);
            json = JsonServicesHelper.RemoveJsonpSyntax(json);
            return Deserialize<T>(json);
        }

        public static T GetObject<T>(string serviceName, string method, params string[] parameters)
        {
            var json = GetJsonResponse(serviceName, method, parameters);
            json = JsonServicesHelper.RemoveJsonpSyntax(json);
            if (json == null)
                return default(T);
            return Deserialize<T>(json);
        }

        public static string GetSerivcePath(string serviceName, string method, params string[] parameters)
        {

            string ServerPath = null;
            ServerIpConfigurationModel _ServerConfigModel = null;
            foreach (var _param in parameters)
            {              
                if (_param.Contains("authToken=") || _param.Contains("AuthToken="))
                {
                    var _ParamVal = _param.Split('=');
                    Guid _authTok = new Guid(_ParamVal[1]);
                    //var ConfigList = AuthenticationService.ServerIpConfigurationList.Where(x=>x.AuthToken==_authTok).FirstOrDefault();
                    //if (ConfigList != null)
                    //{
                    //    _ServerConfigModel = ConfigList;
                    //}
                }
            }

            ServerPath = "https://" + Storage.GetOperationServiceEndpoint + ":6530";
          //  ServerPath = ConfigurationManager.AppSettings["JsonServiceHost"];
            
            return String.Format(
                "{0}/{1}/{2}?{3}&callback=service",
                ServerPath.Trim('/'),
                serviceName,
                method,
                String.Join("&", parameters)
            );
        }

        public static string GetSerivcePathWithAuth(string serviceName, string method,string AuthToken, params string[] parameters)
        {

            string ServerPath = null;
            ServerIpConfigurationModel _ServerConfigModel = null;



            //Guid _authTok = new Guid(AuthToken);
            //        var ConfigList = AuthenticationService.ServerIpConfigurationList.Where(x => x.AuthToken == _authTok).FirstOrDefault();
            //        if (ConfigList != null)
            //        {
            //            _ServerConfigModel = ConfigList;
            //        }
               
           
            if (_ServerConfigModel != null)
            {
                if (serviceName == "GatewayService" || serviceName == "CameraStatusService")
                {
                    ServerPath = "https://" + _ServerConfigModel.WatchDogServiceIp + ":6530";
                }
                else if (serviceName == "StationServiceCommunication" || serviceName == "StationsService" || serviceName == "WebStation")
                {
                    ServerPath = "https://" + _ServerConfigModel.CommunicationServiceIp + ":6530";
                }
                else if (serviceName == "Directory" || serviceName == "AuthService")
                {
                    ServerPath = "https://" + _ServerConfigModel.AutherizationServiceIp + ":6530";
                }
                else if (serviceName == "AlertsSetOperationService" || serviceName == "IncidentReportSetOperationService" || serviceName == "IncidentReportSetOperationServiceWeb" || serviceName == "ZoneSetOperation" ||
                    serviceName == "ControllerSetOperation" || serviceName == "AccountsSetOperationService" || serviceName == "SitesSetOperationService" || serviceName == "SystemSetOperationService"
                    || serviceName == "UsersSetOperationService" || serviceName == "SecuritySetOperationService")
                {
                    ServerPath = "https://" + _ServerConfigModel.SetOperationServiceIp + ":6530";
                }
                else if (serviceName == "DashBoardService" || serviceName == "Harness" || serviceName == "ZoneGetOperation" || serviceName == "ControllerGetOperation" || serviceName == "AlertsGetOperationService" ||
                    serviceName == "AccountsGetOperationService" || serviceName == "SitesGetOperationService" || serviceName == "SystemGetOperationService" || serviceName == "LookupService" || serviceName == "UsersGetOperationService" ||
                    serviceName == "SecurityGetOperationService" || serviceName == "IncidentReportGetOperationService" || serviceName == "IncidentReportGetOperationServiceWeb")
                {
                    ServerPath = "https://" + _ServerConfigModel.GetOperationServiceIp + ":6530";
                }
                else if (serviceName == "GeneralPurposeService" || serviceName == "AlertsCreationService" || serviceName == "StreamInsightService" || serviceName == "StreamInsightAlertService" || serviceName == "VideoAnalyticsManagerService" ||
                    serviceName == "ACSTransactionService" || serviceName == "EdgeBaseAnalyticsService" || serviceName == "ANPRService" || serviceName == "MatrixControllerTransactionService" || serviceName == "_2020SNMPTrapService" ||
                    serviceName == "_2020IODeviceService" || serviceName == "ModbusCommunicationService" || serviceName == "NvrAlarmConsumerService" || serviceName == "KronosService")
                {
                    ServerPath = "https://" + _ServerConfigModel.TransactionServiceIp + ":6530";
                }
                else if (serviceName == "VideoAnalyticsManagerIntegrationService" || serviceName == "ACSIntegrationService" || serviceName == "MatrixControllerService")
                {
                    ServerPath = "https://" + _ServerConfigModel.IntegrationServiceIp + ":6530";
                }
                else //trupti 15122016
                {
                    if (serviceName != "GatewayService")
                    { }
                    ServerPath = ConfigurationManager.AppSettings["JsonServiceHost"];
                }
            }
            else //trupti 15122016
            {
                if (serviceName != "GatewayService")
                { }
                ServerPath = ConfigurationManager.AppSettings["JsonServiceHost"];
            }
            return String.Format(
                "{0}/{1}/{2}?{3}&callback=service",
                ServerPath.Trim('/'),
                serviceName,
                method,
                String.Join("&", parameters)
            );
        }

        internal static string RemoveJsonpSyntax(string json)
        {
            
            var trimedJson = json;
            if (json != null)
            {
                try
                {
                    if (json.StartsWith("service"))
                        trimedJson = trimedJson.Substring(8, json.Length - 10).Replace("\"\"", "");
                   
                    return trimedJson;
                }
                catch (Exception ex)
                { 
                  
                }
            }
            return null;
        }
    }

    public class ServerIpConfigurationModel
    {
        public string WatchDogServiceIp { get; set; }
        public string CommunicationServiceIp { get; set; }
        public string AutherizationServiceIp { get; set; }
        public string GetOperationServiceIp { get; set; }
        public string SetOperationServiceIp { get; set; }
        public string IntegrationServiceIp { get; set; }
        public string TransactionServiceIp { get; set; }
        public Guid AuthToken { get; set; }
        public string RoleName { get; set; }
        public long UserSiteID { get; set; }
        public GenericIdentity AuthenticatedUser { get; set; }
        public string ServerName { get; set; }
    }
}
