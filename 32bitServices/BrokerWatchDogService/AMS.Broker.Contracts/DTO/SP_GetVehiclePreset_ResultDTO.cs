using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetVehiclePreset_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> ID { get; set; }

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
        public String RegisterStatus { get; set; }

        [DataMember()]
        public String StrdateTime { get; set; }

        public SP_GetVehiclePreset_ResultDTO()
        {
        }

        public SP_GetVehiclePreset_ResultDTO(Nullable<Int32> iD, String name, String recNum, Nullable<DateTime> dateTime, String direction, String accessStatus, String nPImagePath, String registerStatus, String strdateTime)
        {
            this.ID = iD;
            this.Name = name;
            this.RecNum = recNum;
            this.DateTime = dateTime;
            this.Direction = direction;
            this.AccessStatus = accessStatus;
            this.NPImagePath = nPImagePath;
            this.RegisterStatus = registerStatus;
            this.StrdateTime = strdateTime;
        }
    }
}
