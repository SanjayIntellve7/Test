using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;


namespace AMS.Broker.Contracts.Services
{
    [ServiceContract(Namespace = "http://2020.AMS")]
    public interface IVideoAnalyticsManagerService
    {        
        [OperationContract(Name = "ConsumeEvent")]
        int ConsumeEvent(string message);

        [OperationContract(Name = "GetVideoAnalyticsCollection")]
        IEnumerable<VideoAnalyticsParameters> GetVideoAnalyticsCollection(string strNvr);     

        [OperationContract]
        bool Test();

        //[OperationContract]
        //string TestCommunication();
    }
}
