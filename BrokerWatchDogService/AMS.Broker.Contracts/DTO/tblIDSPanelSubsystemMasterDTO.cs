using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIDSPanelSubsystemMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> PanelTypeMasterID { get; set; }

        [DataMember()]
        public Nullable<Int32> SubsystemTypeID { get; set; }

        [DataMember()]
        public Nullable<Int32> NoofPartitions { get; set; }

        [DataMember()]
        public String PartitionValues { get; set; }

        public tblIDSPanelSubsystemMasterDTO()
        {
        }

        public tblIDSPanelSubsystemMasterDTO(Int32 iD, Nullable<Int32> panelTypeMasterID, Nullable<Int32> subsystemTypeID, Nullable<Int32> noofPartitions, String partitionValues)
        {
            this.ID = iD;
            this.PanelTypeMasterID = panelTypeMasterID;
            this.SubsystemTypeID = subsystemTypeID;
            this.NoofPartitions = noofPartitions;
            this.PartitionValues = partitionValues;
        }
    }
}
