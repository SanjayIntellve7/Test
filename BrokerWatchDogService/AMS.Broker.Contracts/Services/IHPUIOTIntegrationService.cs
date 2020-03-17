using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IHPUIOTIntegrationService
    {
        [OperationContract]
        string ConsumeSOSPayload(HPUiOTRootObject payload);

        [OperationContract]
        string ConsumeVehicleTrackPayload(HPUiOTRootObject payload);

        [OperationContract]
        string ConsumeWasteMgmtPayload(Stream payload);//WastePayload conwaste

        [OperationContract]
        string ConsumeEnvironmentPayload(Stream payload); //EnvPayload conenv

    }
    [DataContract]
    public class DeviceUIoT
    {
        [DataMember]
        public string manufacturer { get; set; }
        [DataMember]
        public string modelId { get; set; }
        [DataMember]
        public string deviceId { get; set; }
    }
    [DataContract]
    public class gpsInformation
    {
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string time { get; set; }
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double longitude { get; set; }
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public int direction { get; set; }
    }
    [DataContract]
    public class trackerStatus
    {
        [DataMember]
        public string emergency { get; set; }
        [DataMember]
        public string accelaration { get; set; }
        [DataMember]
        public string speeding { get; set; }
        [DataMember]
        public string gpsFailure { get; set; }
        [DataMember]
        public string lowPower { get; set; }
        [DataMember]
        public string powerFailure { get; set; }
        [DataMember]
        public string crashAlarm { get; set; }
        [DataMember]
        public string geoFenceBreach { get; set; }
        [DataMember]
        public string towAlarm { get; set; }
        [DataMember]
        public string powerCut { get; set; }
    }
    [DataContract]
    public class packageData
    {
        [DataMember]
        public gpsInformation gpsInformation { get; set; }
        [DataMember]
        public int batteryPercentage { get; set; }
        [DataMember]
        public trackerStatus trackerStatus { get; set; }
    }
    [DataContract]
    public class TrackerNotification
    {
        [DataMember]
        public string notificationType { get; set; }
        [DataMember]
        public int packageItem { get; set; }
        [DataMember]
        public IList<packageData> packageData { get; set; }
    }
    [DataContract]
    public class DeviceDataUIoT
    {
        // [DataMember(Name = "Tracker Information")]//Tracker Information
        [DataMember]
        public TrackerNotification TrackerNotification { get; set; }
    }
    [DataContract]
    public class con
    {
        [DataMember(Name = "device")]
        public DeviceUIoT device { get; set; }
        [DataMember]
        public string messageType { get; set; }
        [DataMember(Name = "deviceData")]
        public DeviceDataUIoT deviceData { get; set; }
        [DataMember]
        public IList<int> rawPayload { get; set; }
    }
    //for vehicle traking
    [DataContract]
    public class CustomInfo
    {
        [DataMember]
        public int GPSSatelliteUsed { get; set; }
        [DataMember]
        public string GPSAltitude { get; set; }
        [DataMember]
        public string Ignition { get; set; }
        [DataMember]
        public string GSMSignalQuality { get; set; }
        [DataMember]
        public string MainPowerVoltage { get; set; }
        [DataMember(Name = "GPS speed (km/h)")]
        public string GPSspeed { get; set; }
        [DataMember]
        public string BackupBatteryVoltage { get; set; }
        [DataMember(Name = "Battery current (mA)")]
        public string Batterycurrent { get; set; }
    }
    [DataContract]
    public class NotificationRecord
    {
        [DataMember]
        public string GPSDateTime { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Heading { get; set; }
        [DataMember]
        public int GPS_VSSSpeed { get; set; }
        [DataMember]
        public CustomInfo CustomInfo { get; set; }
    }
    [DataContract]
    public class Notification
    {
        [DataMember]
        public int noOfRecords { get; set; }
        [DataMember]
        public IList<NotificationRecord> notificationRecords { get; set; }
    }
    [DataContract]
    public class DeviceDataVT
    {
        [DataMember]
        public Notification notification { get; set; }
    }
    [DataContract]
    public class convt
    {
        [DataMember(Name = "device")]
        public DeviceUIoT device { get; set; }
        [DataMember]
        public string messageType { get; set; }
        [DataMember(Name = "deviceData")]
        public DeviceDataVT deviceData { get; set; }
        [DataMember]
        public IList<int> rawPayload { get; set; }
    }

    //
    [DataContract]
    public class m2mcin
    {
        [DataMember]
        public int ty { get; set; }
        [DataMember]
        public string ri { get; set; }
        [DataMember]
        public string pi { get; set; }
        [DataMember]
        public string ct { get; set; }
        [DataMember]
        public string lt { get; set; }
        [DataMember]
        public string rn { get; set; }
        [DataMember]
        public string et { get; set; }
        [DataMember]
        public int st { get; set; }
        [DataMember]
        public string cr { get; set; }
        [DataMember]
        public string cnf { get; set; }
        [DataMember]
        public int cs { get; set; }
        [DataMember]
        public string con { get; set; }
    }

    [DataContract]
    public class rep
    {
        [DataMember]
        public m2mcin m2mcin { get; set; }
    }

    [DataContract]
    public class Om
    {
        [DataMember]
        public int op { get; set; }
        [DataMember]
        public string org { get; set; }
    }

    [DataContract]
    public class Nev
    {
        [DataMember]
        public string rep { get; set; }
        [DataMember]
        public Om om { get; set; }
        [DataMember]
        public int net { get; set; }
    }

    [DataContract]
    public class m2msgn
    {
        [DataMember]
        public Nev nev { get; set; }
        [DataMember]
        public bool vrq { get; set; }
        [DataMember]
        public string sur { get; set; }
        [DataMember]
        public string cr { get; set; }
    }

    [DataContract]
    public class HPUiOTRootObject
    {
        [DataMember(Name = "m2m:sgn")]
        public m2msgn m2msgn { get; set; }
    }
    //smart Waste
    [DataContract]
    public class WastePayload
    {
        [DataMember(Name = "m2m:cin")]       
        public m2mcin m2mcin { get; set; }
    }
    [DataContract]
    public class conwaste
    {
        [DataMember(Name = "device")]
        public DeviceUIoT device { get; set; }
        [DataMember]
        public string messageType { get; set; }
        [DataMember(Name = "payload")]
        public payloadwaste payloadenv { get; set; }      
    }
    [DataContract]
    public class payloadwaste
    {
        [DataMember(Name = "mmi_eventdetail")]
        public IList<mmi_eventdetail> mmi_eventdetail { get; set; }
    }
    [DataContract]
    public class mmi_eventdetail
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public int accountId { get; set; }
        [DataMember]
        public int deviceId { get; set; }
        [DataMember]
        public IList<int> entityId { get; set; }
        [DataMember]
        public string uniqueId { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public long timestamp { get; set; }
        [DataMember]
        public long insertTime { get; set; }
        [DataMember]
        public double longitude { get; set; }
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double heading { get; set; }
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public double numberOfSatellites { get; set; }
        [DataMember]
        public double digitalInput1 { get; set; }
        [DataMember]
        public double digitalInput3 { get; set; }
        [DataMember]
        public double fuelLevel { get; set; }
        [DataMember]
        public double gsmlevel { get; set; }
        [DataMember]
        public double locationSource { get; set; }
        [DataMember]
        public bool valid { get; set; }
        [DataMember]
        public bool gpsFix { get; set; }
        [DataMember]
        public bool indianBox { get; set; }
        [DataMember]
        public bool validGPS { get; set; }
        [DataMember]
        public bool accOff { get; set; }
        [DataMember]
        public double heatSinkTemp { get; set; }
        [DataMember]
        public int ac { get; set; }
        [DataMember(Name = "processFlags")]
        public processFlagswaste processFlags { get; set; }
        [DataMember]
        public string movementStatus { get; set; }        
    }
    [DataContract]
    public class processFlagswaste
    {
        [DataMember]
        public bool history { get; set; }
    }
    //
    //smart environment
    [DataContract]
    public class EnvPayload
    {
        [DataMember(Name = "m2m:cin")]
        public m2mcin m2mcin { get; set; }
    }
    [DataContract]
    public class conenv
    {
        [DataMember(Name = "topic")]
        public string topic { get; set; }
        [DataMember]
        public string uniqueId { get; set; }
        [DataMember]
        public string uniqueIdType { get; set; }
        [DataMember(Name = "payload")]
        public string payloadenv { get; set; }
    }
    [DataContract]
    public class payloadenv
    {
        [DataMember(Name = "d")]
        public denv d { get; set; }
    }
    [DataContract]
    public class denv
    {
        [DataMember]
        public double g3 { get; set; }
        [DataMember]
        public double g2 { get; set; }
        [DataMember]
        public double g5 { get; set; }
        [DataMember]
        public double g7 { get; set; }
        [DataMember]
        public double g8 { get; set; }
        [DataMember]
        public double hum { get; set; }
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lon { get; set; }
        [DataMember]
        public double p1 { get; set; }
        [DataMember]
        public double p2 { get; set; }
        [DataMember]
        public long t { get; set; }
        [DataMember]
        public double temp { get; set; }
        [DataMember]
        public double wd { get; set; }
        [DataMember]
        public double ws { get; set; }
    }
    //
}
