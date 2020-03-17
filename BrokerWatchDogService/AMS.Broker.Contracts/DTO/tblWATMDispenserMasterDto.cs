using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblWATMDispenserMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Int32 WATMMasterID { get; set; }

        [DataMember()]
        public String DispenserID { get; set; }

        [DataMember()]
        public Nullable<Int32> DispenserStatus { get; set; }

        [DataMember()]
        public Nullable<DateTime> StatusDateTime { get; set; }

        public tblWATMDispenserMasterDTO()
        {
        }

        public tblWATMDispenserMasterDTO(Int32 iD, Int32 wATMMasterID, String dispenserID, Nullable<Int32> dispenserStatus, Nullable<DateTime> statusDateTime)
        {
            this.ID = iD;
            this.WATMMasterID = wATMMasterID;
            this.DispenserID = dispenserID;
            this.DispenserStatus = dispenserStatus;
            this.StatusDateTime = statusDateTime;
        }
    }
}
