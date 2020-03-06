using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetANPRTransactionDetails_ResultDTO
    {
        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String RecNum { get; set; }

        [DataMember()]
        public Nullable<DateTime> DateTime { get; set; }

        [DataMember()]
        public String Direction { get; set; }

        [DataMember()]
        public String AccessStatus { get; set; }

        [DataMember()]
        public String NPImagePath { get; set; }

        [DataMember()]
        public Int64 DeviceId { get; set; }

        [DataMember()]
        public String ANPRDeviceID { get; set; }

        [DataMember()]
        public String RegisterStatus { get; set; }

        [DataMember()]
        public String StrDateTime { get; set; }


        public SP_GetANPRTransactionDetails_ResultDTO()
        {
        }

        public SP_GetANPRTransactionDetails_ResultDTO(String name, String recNum, Nullable<DateTime> dateTime, String direction, String accessStatus, String nPImagePath, Int64 deviceId, String aNPRDeviceID, String registerStatus, String strDateTime)
        {
            this.Name = name;
            this.RecNum = recNum;
            this.DateTime = dateTime;
            this.Direction = direction;
            this.AccessStatus = accessStatus;
            this.NPImagePath = nPImagePath;
            this.DeviceId = deviceId;
            this.ANPRDeviceID = aNPRDeviceID;
            this.RegisterStatus = registerStatus;
            this.StrDateTime = strDateTime;
        }
    }
}
