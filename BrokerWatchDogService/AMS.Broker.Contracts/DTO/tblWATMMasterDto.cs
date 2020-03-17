using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblWATMMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Int32 DeviceID { get; set; }

        [DataMember()]
        public String WATMID { get; set; }

        [DataMember()]
        public Nullable<Int32> WATMStatus { get; set; }

        [DataMember()]
        public Nullable<DateTime> StatusDateTime { get; set; }

        public tblWATMMasterDTO()
        {
        }

        public tblWATMMasterDTO(Int32 iD, Int32 deviceID, String wATMID, Nullable<Int32> wATMStatus, Nullable<DateTime> statusDateTime)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.WATMID = wATMID;
            this.WATMStatus = wATMStatus;
            this.StatusDateTime = statusDateTime;
        }
    }
}
