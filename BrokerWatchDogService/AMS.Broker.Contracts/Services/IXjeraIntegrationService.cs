using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IXjeraIntegrationService
    {
        [OperationContract]
        void XjeraConsumePayload(Stream payload);//  RootXjiraObject
        [OperationContract]
        string XjeraConsumeEvent(RootXjiraObject payload);//  RootXjiraObject

        [OperationContract]
        void PushXJiraEventsDataToHpUiOT();//string strEvent, string strEventTime, string strDeviceName, string strDevIpAddress);
    }

    //
    public class RootXjiraObject
    {
        public string Func { get; set; }
        public int Type { get; set; }
        public string ContentType { get; set; }
        public string VideoType { get; set; }
        public string VideoName { get; set; }
        public string StatisticTime { get; set; }
        public string ROI { get; set; }
        public string Total { get; set; }
        public string Data { get; set; }
        public string Image { get; set; }
        public string Server { get; set; }
        public RootEventObject _RootEventObject { get; set; }
        public RootLineCountObject _RootLineCountObject { get; set; }
        public RootAreaCountObject _RootAreaCountObject { get; set; }
        public RootPassCountObject _RootPassCountObject { get; set; }
    }
    //    
    public class RootEventObject//event
    {
        public List<Datum> data { get; set; }
    }
    public class Datum//for events
    {
        public string eventName { get; set; }
        public long timestamp { get; set; }//event date time 
        public long startTime { get; set; }
        public string tsUnix { get; set; }
        public List<string> count { get; set; }
        public List<string> imgpath { get; set; }
        public List<string> videopath { get; set; }
    }
    //for line count
    public class RootLineCountObject//linecount
    {
        public List<Datumlinecount> data { get; set; }
    }
    public class Datumlinecount//for line count
    {
        public string timestamp { get; set; }//event date time 
        public long startTime { get; set; }
        public long tsUnix { get; set; }
        public int count { get; set; }//number of count
        public string type { get; set; }//“P” means Positive Direction, “N” means Negative Direction, “T” means both of positive and negative
        public List<string> imgpath { get; set; }
    }
    //
    //for area count
    public class RootAreaCountObject//area count
    {
        public List<DatumAreacount> data { get; set; }
    }
    public class DatumAreacount//for area count
    {
        public string timestamp { get; set; }//event date time 
        public long startTime { get; set; }
        public long tsUnix { get; set; }
        public int count { get; set; }//number of count
        public string type { get; set; }//AreaCount       
        public int waittime { get; set; }
        public int forecastcount { get; set; }
        public int forecastwaitttime { get; set; }
    }
    //
    //for pass count
    public class RootPassCountObject//pass count
    {
        public List<DatumPasscount> data { get; set; }
    }
    public class DatumPasscount//for pass count
    {
        public string timestamp { get; set; }//pass date time 
        public long startTime { get; set; }
        public long tsUnix { get; set; }
        public int count { get; set; }//number of count
        public string type { get; set; }//PassCount    
    }
}
