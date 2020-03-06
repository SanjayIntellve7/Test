using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblVehicleMasterDataDto
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Vehicle_RegistrationNumber { get; set; }

        [DataMember()]
        public String DriverName { get; set; }

        [DataMember()]
        public String DriverPhoneNumber { get; set; }

        [DataMember()]
        public String Reserv1 { get; set; }

        [DataMember()]
        public String Reserv2 { get; set; }

        [DataMember()]
        public String Reserv3 { get; set; }

        public tblVehicleMasterDataDto()
        {
        }

        public tblVehicleMasterDataDto(Int32 iD, String vehicle_RegistrationNumber, String driverName, String driverPhoneNumber, String reserv1, String reserv2, String reserv3)
        {
            this.ID = iD;
            this.Vehicle_RegistrationNumber = vehicle_RegistrationNumber;
            this.DriverName = driverName;
            this.DriverPhoneNumber = driverPhoneNumber;
            this.Reserv1 = reserv1;
            this.Reserv2 = reserv2;
            this.Reserv3 = reserv3;
        }
    }
}
