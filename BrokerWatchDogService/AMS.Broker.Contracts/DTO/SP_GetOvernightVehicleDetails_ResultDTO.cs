using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetOvernightVehicleDetails_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> Count { get; set; }

        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> U_Id { get; set; }

        [DataMember()]
        public String AppKey { get; set; }

        [DataMember()]
        public String CamName { get; set; }

        [DataMember()]
        public Nullable<Int32> No { get; set; }

        [DataMember()]
        public Byte[] LPImage { get; set; }

        [DataMember()]
        public String RecNum { get; set; }

        [DataMember()]
        public Nullable<DateTime> DateTime { get; set; }

        [DataMember()]
        public String Direction { get; set; }

        [DataMember()]
        public String RegName { get; set; }

        [DataMember()]
        public Byte[] DriverImage { get; set; }

        [DataMember()]
        public String ContactNum { get; set; }

        [DataMember()]
        public String AccessStatus { get; set; }

        [DataMember()]
        public String Validated { get; set; }

        [DataMember()]
        public Byte[] ExtractedLPImage { get; set; }

        [DataMember()]
        public String DriverImagePath { get; set; }

        [DataMember()]
        public String NPImagePath { get; set; }

        [DataMember()]
        public String VehicleType { get; set; }

        [DataMember()]
        public String VehicleMake { get; set; }

        [DataMember()]
        public String Confidence { get; set; }

        [DataMember()]
        public Nullable<Int32> AlertID { get; set; }

        [DataMember()]
        public String ANPRDeviceID { get; set; }

        [DataMember()]
        public String Location { get; set; }

        public SP_GetOvernightVehicleDetails_ResultDTO()
        {
        }

        public SP_GetOvernightVehicleDetails_ResultDTO(Nullable<Int32> count, Int32 iD, Nullable<Int32> u_Id, String appKey, String camName, Nullable<Int32> no, Byte[] lPImage, String recNum, Nullable<DateTime> dateTime, String direction, String regName, Byte[] driverImage, String contactNum, String accessStatus, String validated, Byte[] extractedLPImage, String driverImagePath, String nPImagePath, String vehicleType, String vehicleMake, String confidence, Nullable<Int32> alertID, String aNPRDeviceID, String location)
        {
            this.Count = count;
            this.ID = iD;
            this.U_Id = u_Id;
            this.AppKey = appKey;
            this.CamName = camName;
            this.No = no;
            this.LPImage = lPImage;
            this.RecNum = recNum;
            this.DateTime = dateTime;
            this.Direction = direction;
            this.RegName = regName;
            this.DriverImage = driverImage;
            this.ContactNum = contactNum;
            this.AccessStatus = accessStatus;
            this.Validated = validated;
            this.ExtractedLPImage = extractedLPImage;
            this.DriverImagePath = driverImagePath;
            this.NPImagePath = nPImagePath;
            this.VehicleType = vehicleType;
            this.VehicleMake = vehicleMake;
            this.Confidence = confidence;
            this.AlertID = alertID;
            this.ANPRDeviceID = aNPRDeviceID;
            this.Location = location;
        }
    }
}
