using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetANPRTransactionInfo_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> TotalCount { get; set; }

        [DataMember()]
        public String Direction { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String RegisterStatus { get; set; }

        public SP_GetANPRTransactionInfo_ResultDTO()
        {
        }

        public SP_GetANPRTransactionInfo_ResultDTO(Nullable<Int32> totalCount, String direction, Nullable<Int32> deviceID, String name, String registerStatus)
        {
            this.TotalCount = totalCount;
            this.Direction = direction;
            this.DeviceID = deviceID;
            this.Name = name;
            this.RegisterStatus = registerStatus;
        }
    }
}
