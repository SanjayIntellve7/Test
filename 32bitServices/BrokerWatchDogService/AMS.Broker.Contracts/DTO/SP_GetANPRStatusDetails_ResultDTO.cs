using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SP_GetANPRStatusDetails_ResultDTO
    {
        [DataMember]
        public Nullable<int> TotalCount { get; set; }
        [DataMember]
        public Nullable<int> TotalRegisteredVehicleCount { get; set; }
        [DataMember]
        public Nullable<int> TotalNonRegisteredVehicleCount { get; set; }
        [DataMember]
        public int RegStatus { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public Nullable<int> U_Id { get; set; }
        [DataMember]
        public string AppKey { get; set; }
        [DataMember]
        public string CamName { get; set; }
        [DataMember]
        public Nullable<int> No { get; set; }
        [DataMember]
        public byte[] LPImage { get; set; }
        [DataMember]
        public string RecNum { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateTime { get; set; }
        [DataMember]
        public string Direction { get; set; }
        [DataMember]
        public string RegName { get; set; }
        [DataMember]
        public byte[] DriverImage { get; set; }
        [DataMember]
        public string ContactNum { get; set; }
        [DataMember]
        public string AccessStatus { get; set; }
        [DataMember]
        public string Validated { get; set; }
        [DataMember]
        public byte[] ExtractedLPImage { get; set; }
        [DataMember]
        public string DriverImagePath { get; set; }
        [DataMember]
        public string NPImagePath { get; set; }
        [DataMember]
        public string VehicleType { get; set; }
        [DataMember]
        public string VehicleMake { get; set; }
        [DataMember]
        public string Confidence { get; set; }
        [DataMember]
        public Nullable<int> AlertID { get; set; }
        [DataMember]
        public string ANPRDeviceID { get; set; }
        [DataMember]
        public string Location { get; set; }
    }
}
