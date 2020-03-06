using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;


namespace AMS.Broker.Contracts.Services
{
    [ServiceContract(Namespace = "http://2020.AMS")]
    public interface IVideoAnalyticsManagerService
    {
        [OperationContract(Name = "GetCapabilities")]
        IEnumerable<string> GetCapabilities(Guid cameraId);

        [OperationContract(Name = "StartAnalytics")]
        bool StartAnalytics(int cameraId, string version);

        [OperationContract(Name = "StopAnalytics")]
        bool StopAnalytics(int cameraId, string version);

        [OperationContract(Name = "GetStatus")]
        string GetStatus(int cameraId, string version);  //Todo Status enum should be defined

        [OperationContract(Name = "ConsumeEvent")]
        int ConsumeEvent(string message);

        [OperationContract(Name = "GetVideoAnalyticsCollection")]
        IEnumerable<VideoAnalyticsParameters> GetVideoAnalyticsCollection(string strNvr);

        [OperationContract(Name = "GetTest")]
        string GetTest(int cameraId);
            
    }
}
