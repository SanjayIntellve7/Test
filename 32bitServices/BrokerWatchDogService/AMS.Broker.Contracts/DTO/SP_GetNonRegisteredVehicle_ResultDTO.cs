using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetNonRegisteredVehicle_ResultDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String RecNum { get; set; }

        [DataMember()]
        public String VehicleType { get; set; }

        [DataMember()]
        public Nullable<Int32> VehicleColour { get; set; }

        [DataMember()]
        public String VehiclePrevelege { get; set; }

        [DataMember()]
        public Nullable<Int32> DriverName { get; set; }

        [DataMember()]
        public Nullable<Int32> ContactNo { get; set; }

        [DataMember()]
        public Nullable<Int32> Companyname { get; set; }

        [DataMember()]
        public String LicenseNumber { get; set; }

        public SP_GetNonRegisteredVehicle_ResultDTO()
        {
        }

        public SP_GetNonRegisteredVehicle_ResultDTO(Int32 iD, String recNum, String vehicleType, Nullable<Int32> vehicleColour, String vehiclePrevelege, Nullable<Int32> driverName, Nullable<Int32> contactNo, Nullable<Int32> companyname, String licenseNumber)
        {
            this.ID = iD;
            this.RecNum = recNum;
            this.VehicleType = vehicleType;
            this.VehicleColour = vehicleColour;
            this.VehiclePrevelege = vehiclePrevelege;
            this.DriverName = driverName;
            this.ContactNo = contactNo;
            this.Companyname = companyname;
            this.LicenseNumber = licenseNumber;
        }
    }
}
