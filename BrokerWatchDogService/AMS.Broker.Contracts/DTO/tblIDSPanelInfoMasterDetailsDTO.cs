using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIDSPanelInfoMasterDetailsDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String PanelUsername { get; set; }

        [DataMember()]
        public String PanelPassword { get; set; }

        [DataMember()]
        public String PanelIP { get; set; }

        [DataMember()]
        public String Port { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteID { get; set; }

        [DataMember()]
        public String BranchID { get; set; }

        [DataMember()]
        public SiteDto SiteDetails { get; set; }

        [DataMember()]
        public DeviceDto DeviceDetails { get; set; }

        [DataMember()]
        public tblPanelMasterDTO PanelTypeDetails { get; set; }

        //[DataMember()]
        //public SiteDto BranchName { get; set; }

        //[DataMember()]
        //public DeviceDto DeviceID { get; set; }

        //[DataMember()]
        //public tblPanelMasterDTO PanelTypeName { get; set; }

        [DataMember()]
        public Nullable<Int32> PanelTypeID { get; set; }

        [DataMember()]
        public String Partition { get; set; }

        [DataMember()]
        public String ZoneNumber { get; set; }
    }
}
