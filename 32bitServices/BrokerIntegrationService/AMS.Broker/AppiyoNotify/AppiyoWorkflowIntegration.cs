using AMS.Broker.Contracts.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.IntegrationService.AppiyoNotify
{
    class AppiyoWorkflowIntegration
    {
        private string authToken = null;
        private string timeStamp = null;
        private string ackProcessId = "dedcaf5b-9550-47bb-97b2-623cd40d62cd";

        private string userName = "santosh.lamane@2020Imaging.com";
        private string password = "@zicom.com";

        private string projectId = "f168e0044ed711e4a9bb0050569ccb08";//"9eab43004f9211e49946bc305bdda218";
        private string workflowId = "4475953a4ed811e4a9bb0050569ccb08";//"b8160bfe4f9211e49946bc305bdda218";

        private string alertProcessId = "b160b684-d776-427d-98ba-a43ee53ea284";

        private string URL = "https://www.appiyo.com"; //"http://182.74.73.102"; //"https://www.appiyo.com";
        private string loginURL = "https://www.appiyo.com/account/login";//"http://182.74.73.102/account/login";
        // private string workflowURL = "https://www.appiyo.com/ProcessStore/d/workflows/5c0ab6c1-70c9-4a10-a15a-4ebc9e9b8665/execute";
        private string workflowURL = "https://www.appiyo.com/d/workflows/b8160bfe4f9211e49946bc305bdda218/execute?projectId=9eab43004f9211e49946bc305bdda218";//"http://182.74.73.102/d/workflows/b8160bfe4f9211e49946bc305bdda218/execute?projectId=9eab43004f9211e49946bc305bdda218";

        public bool AppiyoLogin()
        {
            try
            {
                var content = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", userName), 
                    new KeyValuePair<string, string>("password", password)                
                 };

                var requestParams = new FormUrlEncodedContent(content);

                var cookieJar = new CookieContainer();

                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieJar,
                    UseCookies = true,
                    UseDefaultCredentials = false
                };
                HttpClient client = new HttpClient(handler);
                HttpResponseMessage response = client.PostAsync(new Uri(loginURL), requestParams).Result;
                response.EnsureSuccessStatusCode();
                var responseCookies = cookieJar.GetCookies(new Uri(loginURL));

                foreach (Cookie cookie in responseCookies)
                {
                    string cookieName = cookie.Name;

                    if (cookieName.Equals("authentication-token"))
                    {
                        authToken = "authentication-token=" + cookie.Value;
                    }
                    if (cookieName.Equals("time-stamp"))
                    {
                        timeStamp = "time-stamp=" + cookie.Value;
                    }
                }
                string responseBody = response.Content.ReadAsStringAsync().Result;
                return authToken.Equals("");
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }


        public string executeAlertWorkflowProcess(string deviceName,string alertID, string message)
        {
            try
            {
                string path = "https://www.appiyo.com/d/workflows/b8160bfe4f9211e49946bc305bdda218/execute?projectId=9eab43004f9211e49946bc305bdda218";
                CookieContainer cookieStore = new CookieContainer();
                cookieStore.SetCookies(new Uri(path), authToken);
                Dictionary<string, string> alertDictionary = new Dictionary<string, string>();

                int[] arrayesc=new int[1];
                int[] custarray = new int[1];
                //user id json array
                MeonMembers meonmem = new MeonMembers();
                  var MeoncustList = GetCustomerList();

                //  meonmem.custID = "301";
                  if (MeoncustList != null)
                  {
                      if (MeoncustList.Count > 0)
                      {
                          custarray = new int[MeoncustList.Count];
                          int i = 0;

                          foreach (var meoncust in MeoncustList)
                          {
                              custarray[i] = Int32.Parse(meoncust.CustomerID);
                              i++;
                          }
                      }
                      else
                      {
                          custarray[0] = 0;
                      }
                  }
                  else
                  {
                      custarray[0] = 0;
                  }
                //escallation userid json arrtt

                EscMeonMembers MeonEscCustObj = new EscMeonMembers();
                var MeonEscCustList = GetEscallateCustomerList();
                if (MeonEscCustList != null)
                {
                    if (MeonEscCustList.Count > 0)
                    {
                        arrayesc = new int[MeonEscCustList.Count];
                        int j = 0;

                        foreach (var meonesccust in MeonEscCustList)
                        {
                            arrayesc[j] = Int32.Parse(meonesccust.CustomerID);
                            j++;
                        }
                    }
                    else
                    {
                        arrayesc[0] = 0;
                    }
                }
                else
                {
                    arrayesc[0] = 0;
                }

                //AMS.Broker.IntegrationService.Services.MeonCloudService meonObj = new AMS.Broker.IntegrationService.Services.MeonCloudService();   //trupti to change calling of service because of broker distribution
                //string meonAuthToken = meonObj.login(Storage.MeonUsername, Storage.MeonPassword);//trupti to change calling of service because of broker distribution

                Alertdetails Obj = new Alertdetails();
                Obj.id = alertID;
                Obj.alertId = alertID;
                Obj.severity = "Medium";
                Obj.device = "" + deviceName;
                Obj.message = message;
                Obj.mailId = "amit.pawar@2020imagings.com";
                Obj.escalationMailId = "mitpawar@gmails.com";
                Obj.toGroupId = "544dd6e658bd6c48191ceca9";// "5454b3f3c00df250d08080c8";
                Obj.toUser = "7738249297";
                //Obj.mocAuthToken = meonAuthToken.Substring(meonAuthToken.IndexOf("=") + 1);//trupti to change calling of service because of broker distribution
                Obj.userIds = custarray;
                Obj.escalationUserIds = arrayesc;
               // string strData = JsonSerializer<Alertdetails>(Obj);
                

                Alertdetails1 Obj1 = new Alertdetails1();
                Obj1.processId = alertProcessId;
                Obj1.ProcessVariables = Obj;
                Obj1.workflowId = workflowId;
                Obj1.projectId = projectId;
                
                                                                          
                
               // List<tblMeonMembersDTO> MeonEscCustList = new List<tblMeonMembersDTO>();                             
               
                            
             //   string meonUserIDs = JsonSerializer<MeonMember>(MeonCustObj);//JsonConvert.SerializeObject(MeonUser, Formatting.Indented);

             //   string EscMeonUserIDs = JsonSerializer<MeonMember>(MeonEscCustObj);

                string strData1 = JsonSerializer<Alertdetails1>(Obj1);

                var content = new List<KeyValuePair<string, string>>
                {
                     new KeyValuePair<string, string>("id", alertProcessId), 
                     new KeyValuePair<string, string>("processVariables", strData1.ToString()),
                   //  new KeyValuePair<string, string>("userIds", meonUserIDs.ToString()),
                   //  new KeyValuePair<string, string>("escalationUserIds", EscMeonUserIDs.ToString()),
                   //  new KeyValuePair<string, string>("mocAuthToken", AuthToken)
                };

                HttpContent requestParams = new FormUrlEncodedContent(content);
                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieStore,
                    UseCookies = true,
                    UseDefaultCredentials = false
                };

                HttpClient client = new HttpClient(handler);

                HttpResponseMessage httpMethod = client.PutAsync(new Uri(path), requestParams).Result;
                string responseFromServer = httpMethod.Content.ReadAsStringAsync().Result;
                if (responseFromServer.Contains("status"))
                {
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        
        //amit 22 sept 15
        public List<tblMeonMembersDTO> GetCustomerList()
        {
            List<tblMeonMembersDTO> _list = new List<tblMeonMembersDTO>();
            try
            {
                using (var ctx = new AMS.Broker.IntegrationService.DataStore.CentralDBEntities())
                {
                    var Meoncustlist = from dc in ctx.tblMeonMembers
                                       select dc;

                    var meoncustdata = Meoncustlist.ToArray();
                    if (meoncustdata.Count() > 0)
                    {

                        _list = meoncustdata.Select(AutoMapper.Mapper.Map<tblMeonMembersDTO>).ToList();
                        return _list;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        //amit 22 sept 15
        public List<tblMeonMembersDTO> GetEscallateCustomerList()
        {
            List<tblMeonMembersDTO> _list = new List<tblMeonMembersDTO>();
            try
            {
                using (var ctx = new AMS.Broker.IntegrationService.DataStore.CentralDBEntities())
                {
                    var Meoncustlist = from dc in ctx.tblMeonMembers
                                       where dc.EscallationMember==1
                                       select dc;

                    var meoncustdata = Meoncustlist.ToArray();
                    if (meoncustdata.Count() > 0)
                    {

                        _list = meoncustdata.Select(AutoMapper.Mapper.Map<tblMeonMembersDTO>).ToList();
                        return _list;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public string executeCloseWorkflow(string alertID, string message)
        {
            try
            {
                string path = "https://www.appiyo.com/d/workflows/b8160bfe4f9211e49946bc305bdda218/execute?projectId=9eab43004f9211e49946bc305bdda218";
                CookieContainer cookieStore = new CookieContainer();
                cookieStore.SetCookies(new Uri(path), authToken);
                Dictionary<string, string> alertDictionary = new Dictionary<string, string>();
                
                //    Obj.severity = "Medium";
                //  Obj.device = "D1";
                // Obj.message = message;
                //Obj.mailId = "amit.pawar@2020imaging.com";
                ///Obj.escalationMailId = "mitpawar@gmail.com";
                ///Obj.toGroupId = "5454b3f3c00df250d08080c8";
                //Obj.toUser = "7738249297";
                //
             /*   int[] arrayesc = new int[1];
                int[] custarray = new int[1];
                //user id json array
                MeonMembers meonmem = new MeonMembers();
                var MeoncustList = GetCustomerList();

                //  meonmem.custID = "301";
                if (MeoncustList != null)
                {
                    if (MeoncustList.Count > 0)
                    {
                        custarray = new int[MeoncustList.Count];
                        int i = 0;

                        foreach (var meoncust in MeoncustList)
                        {
                            custarray[i] = Int32.Parse(meoncust.CustomerID);
                            i++;
                        }
                    }
                    else
                    {
                        custarray[0] = 0;
                    }
                }
                else
                {
                    custarray[0] = 0;
                }
                //escallation userid json arrtt

                EscMeonMembers MeonEscCustObj = new EscMeonMembers();
                var MeonEscCustList = GetEscallateCustomerList();
                if (MeonEscCustList != null)
                {
                    if (MeonEscCustList.Count > 0)
                    {
                        arrayesc = new int[MeonEscCustList.Count];
                        int j = 0;

                        foreach (var meonesccust in MeonEscCustList)
                        {
                            arrayesc[j] = Int32.Parse(meonesccust.CustomerID);
                            j++;
                        }
                    }
                    else
                    {
                        arrayesc[0] = 0;
                    }
                }
                else
                {
                    arrayesc[0] = 0;
                }

                AMS.Broker.IntegrationService.Services.MeonCloudService meonObj = new AMS.Broker.IntegrationService.Services.MeonCloudService();
                string AuthToken = meonObj.login(Storage.MeonUsername, Storage.MeonPassword);
                */
                //
                Alertdetails Obj = new Alertdetails();
                Obj.alertId = alertID;
             //   Obj.userIds = custarray;
             //   Obj.escalationUserIds = arrayesc;

                string strData = JsonSerializer<Alertdetails>(Obj);
                Alertdetails1 Obj1 = new Alertdetails1();
                Obj1.processId = ackProcessId;
                Obj1.ProcessVariables = Obj;
                Obj1.workflowId = workflowId;
                Obj1.projectId = projectId;
               

                string strData1 = JsonSerializer<Alertdetails1>(Obj1);

              
                var content = new List<KeyValuePair<string, string>>
                {
                     new KeyValuePair<string, string>("id", ackProcessId), 
                     new KeyValuePair<string, string>("processVariables", strData1.ToString()),
                     
                };


                HttpContent requestParams = new FormUrlEncodedContent(content);
                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieStore,
                    UseCookies = true,
                    UseDefaultCredentials = false
                };

                HttpClient client = new HttpClient(handler);
                HttpResponseMessage httpMethod = client.PutAsync(new Uri(path), requestParams).Result;
                string responseFromServer = httpMethod.Content.ReadAsStringAsync().Result;
                if (responseFromServer.Contains("Status"))
                {
                }

            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
               
    }

    //amit 22 sept 15
    public class MeonMember
    {
        public string customerID { get; set; }
    }
}

