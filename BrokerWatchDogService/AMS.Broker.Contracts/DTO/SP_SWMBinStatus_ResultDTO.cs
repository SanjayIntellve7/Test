using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SWMBinStatus_ResultDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String BinID { get; set; }

        [DataMember()]
        public String BinType { get; set; }

        [DataMember()]
        public String BinColor { get; set; }

        [DataMember()]
        public Nullable<Double> Capacity { get; set; }

        [DataMember()]
        public Nullable<Double> Lat { get; set; }

        [DataMember()]
        public Nullable<Double> Long_ { get; set; }

        [DataMember()]
        public String RFID { get; set; }

        [DataMember()]
        public String SensorID { get; set; }

        [DataMember()]
        public Nullable<Int32> Thresholdlimit { get; set; }

        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public String BinAddress { get; set; }

        [DataMember()]
        public String DeviceStatusType { get; set; }

        [DataMember()]
        public Nullable<Int32> DSStatus { get; set; }

        [DataMember()]
        public String DeviceStatus { get; set; }

        [DataMember()]
        public String DeviceStatusColour { get; set; }

        [DataMember()]
        public Nullable<DateTime> StatusDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> BT1ID { get; set; }

        [DataMember()]
        public String VehicleNo { get; set; }

        [DataMember()]
        public Nullable<DateTime> CleanedDateTime { get; set; }

        [DataMember()]
        public Nullable<Int32> FilledLevel { get; set; }

        [DataMember()]
        public Nullable<DateTime> TXDataTime { get; set; }

        [DataMember()]
        public Nullable<int> FilledLevelStatus { get; set; }

        [DataMember()]
        public string FilledLevelStatusLabel { get; set; }

        [DataMember()]
        public string FilledLevelStatusColour { get; set; }

         public SP_SWMBinStatus_ResultDTO()
         {
         }

         public SP_SWMBinStatus_ResultDTO(Int32 iD, String binID, String binType, String binColor, Nullable<Double> capacity, Nullable<Double> lat, Nullable<Double> long_, String rFID, String sensorID, Nullable<Int32> thresholdlimit, String wardNo, String binAddress, String deviceStatusType, Nullable<Int32> dSStatus, String deviceStatus, String deviceStatusColour, Nullable<DateTime> statusDateTime, Nullable<Int32> bT1ID, String vehicleNo, Nullable<DateTime> cleanedDateTime, Nullable<Int32> filledLevel, Nullable<DateTime> tXDataTime, Nullable<int> filledLevelStatus, string filledLevelStatusLabel, string filledLevelStatusColour)
        {
            this.ID = iD;
            this.BinID = binID;
            this.BinType = binType;
            this.BinColor = binColor;
            this.Capacity = capacity;
            this.Lat = lat;
            this.Long_ = long_;
            this.RFID = rFID;
            this.SensorID = sensorID;
            this.Thresholdlimit = thresholdlimit;
            this.WardNo = wardNo;
            this.BinAddress = binAddress;
            this.DeviceStatusType = deviceStatusType;
            this.DSStatus = dSStatus;
            this.DeviceStatus = deviceStatus;
            this.DeviceStatusColour = deviceStatusColour;
            this.StatusDateTime = statusDateTime;
            this.BT1ID = bT1ID;
            this.VehicleNo = vehicleNo;
            this.CleanedDateTime = cleanedDateTime;
            this.FilledLevel = filledLevel;
            this.TXDataTime = tXDataTime;
            this.FilledLevelStatus = filledLevelStatus;
            this.FilledLevelStatusLabel = filledLevelStatusLabel;
            this.FilledLevelStatusColour = filledLevelStatusColour;
        }
    }
}
