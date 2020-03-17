using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract(Namespace = "http://2020.AMS")]
    public interface IVideoAnalyticsManagerIntegrationService
    {
        [OperationContract(Name = "GetCapabilities")]
        IEnumerable<string> GetCapabilities(Guid cameraId);

        [OperationContract(Name = "StartAnalytics")]
        bool StartAnalytics(int cameraId, string version, string authToken);

        [OperationContract(Name = "StopAnalytics")]
        bool StopAnalytics(int cameraId, string version, string authToken);

        [OperationContract(Name = "GetStatus")]
        string GetStatus(int cameraId, string version, string authToken);  //Todo Status enum should be defined
       

        [OperationContract(Name = "GetTest")]
        string GetTest(int cameraId);

        [OperationContract]
        bool Test();

        //[OperationContract]
        //string TestCommunication();
    }
}
