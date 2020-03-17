using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIDSPanelSubsystemMasterDetailsDTO
    {

        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public tblIDSPanelSubsystemTypeMasterDTO SubsystemTypeData { get; set; }

        [DataMember()]
        public tblPanelMasterDTO PanelTypeData { get; set; }

        [DataMember()]
        public Nullable<Int32> NoofPartitions { get; set; }

        [DataMember()]
        public String PartitionValues { get; set; }

        public tblIDSPanelSubsystemMasterDetailsDTO()
        {
        }

        public tblIDSPanelSubsystemMasterDetailsDTO(Int32 iD, tblPanelMasterDTO panelTypeMaster, tblIDSPanelSubsystemTypeMasterDTO SubsystemType, Nullable<Int32> noofPartitions, String partitionValues)
        {
            this.ID = iD;
            this.PanelTypeData = panelTypeMaster;
            this.SubsystemTypeData = SubsystemType;
            this.NoofPartitions = noofPartitions;
            this.PartitionValues = partitionValues;
        }
    }
}
