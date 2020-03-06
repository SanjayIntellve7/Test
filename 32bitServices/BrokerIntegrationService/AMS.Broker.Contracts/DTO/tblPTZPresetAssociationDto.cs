using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPTZPresetAssociationDto
    {
      [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public Nullable<Int64> DevId { get; set; }

        [DataMember()]
        public Nullable<Int64> PTZCamId { get; set; }

        [DataMember()]
        public Nullable<Int32> PresetNo { get; set; }

        [DataMember()]
        public String Remarks { get; set; }

        public tblPTZPresetAssociationDto()
        {
        }

        public tblPTZPresetAssociationDto(Int64 iD, Nullable<Int64> devId, Nullable<Int64> pTZCamId, Nullable<Int32> presetNo, String remarks)
        {
			this.ID = iD;
			this.DevId = devId;
			this.PTZCamId = pTZCamId;
			this.PresetNo = presetNo;
			this.Remarks = remarks;
        }
    }
}