using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ITrackingDevicesTxnService
    {
        [OperationContract]
        string GetTrackingData();

        [OperationContract]
        string PushTrackingData(string lattitude, string longitude);

        [OperationContract]
        string GeoFenceOverSpeedAlert(string vehicleNumber, string speed);

        [OperationContract]
        string GeoFenceEntryExitAlert(string vehicleNumber, string geofenceStatus);

        [OperationContract]
        bool GPSExitAlert(string data); // jatin 12102018

        [OperationContract]
        bool GPSBatteryLowAlert(string data); // jatin 12102018
    }

    //
    [DataContract]
    public class rootvehicleStatuslist
    {
        [DataMember]
        public List<VehicleStatuslist> vehicleStatuslist { get; set; }
    }
   
    [DataContract]
    public class VehicleStatuslist
    {
         [DataMember]
        public string Veh_reg { get; set; }
         [DataMember]
        public string Updated { get; set; }
         [DataMember]
        public string Location { get; set; }
         [DataMember]
        public string Latitude { get; set; }
         [DataMember]
        public string Longitude { get; set; }
         [DataMember]
        public string Speed { get; set; }
    }

    //
}
