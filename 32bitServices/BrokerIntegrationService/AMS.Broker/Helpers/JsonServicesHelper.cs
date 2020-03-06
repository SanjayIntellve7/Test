using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.IntegrationService.Helpers
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

        public static bool PostFile<T>(string serviceName, string method, string name, Guid authToken, T graph)
        {
            var requestString = GetSerivcePath(serviceName, method).Replace("?&", "?");
            var jsonCode = SerializeObject<T>(graph);
            using (var client = new WebClient())
            {
                return
                    Deserialize<bool>(JsonServicesHelper.RemoveJsonpSyntax(
                        client.DownloadString(requestString + "&" + "authToken=" + authToken + "&" + name + "=" +
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
                    var strRetVal = client.DownloadString(requestString);
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

        public static string GetJsonResponse(string serviceName, string method, bool awaitable, params string[] parameters)
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
            if (serviceName == "CameraControlService")
            {
                string ServerPath = null;

                if (serviceName == "CameraControlService")
                {
                    if (Storage.WorkingMode == "primary")
                    {
                        ServerPath = "https://" + Storage.IntegrationServiceEndpoint + ":6530";
                    }
                    else
                    {
                        ServerPath = "https://" + Storage.SecondaryIntegrationServiceEndpoint + ":6530";
                    }
                }

                return String.Format(
                    "{0}/{1}/{2}?{3}&callback=service",
                   ServerPath.Trim('/'),
                    serviceName,
                    method,
                    String.Join("&", parameters)
                );
            }
            else if (serviceName == "AcsAdapterService")//
            {

                string ServerPath = null;

                if (serviceName == "AcsAdapterService")
                    ServerPath = "https://" + Storage.ACSAdapterIpAddress + ":6530";

                return String.Format(
                    "{0}/{1}/{2}?{3}&callback=service",
                   ServerPath.Trim('/'),
                    serviceName,
                    method,
                    String.Join("&", parameters)
                );
            }
            else if (serviceName == "ControllerCallBackCommService")//AcsAdapterService
            {

                string ServerPath = null;

                if (serviceName == "ControllerCallBackCommService")
                {
                    if (Storage.WorkingMode == "primary")
                    {
                        ServerPath = "https://" + Storage.IntegrationServiceEndpoint + ":6530";
                    }
                    else
                    {
                        ServerPath = "https://" + Storage.SecondaryIntegrationServiceEndpoint + ":6530";
                    }
                }

                return String.Format(
                    "{0}/{1}/{2}?{3}&callback=service",
                   ServerPath.Trim('/'),
                    serviceName,
                    method,
                    String.Join("&", parameters)
                );
            }
            else if (serviceName == "FFTAdapterService")
            {

                string ServerPath = null;

                if (serviceName == "FFTAdapterService")
                    ServerPath = "https://" + Storage.FFTAdapterIpAddress + ":6530";

                return String.Format(
                    "{0}/{1}/{2}?{3}&callback=service",
                   ServerPath.Trim('/'),
                    serviceName,
                    method,
                    String.Join("&", parameters)
                );
            }
            else
            {

                return String.Format(
                    "{0}/{1}/{2}?{3}&callback=service",
                    ConfigurationManager.AppSettings["JsonServiceHost"].Trim('/'),
                    serviceName,
                    method,
                    String.Join("&", parameters)
                );
            }
            return null;
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
}
