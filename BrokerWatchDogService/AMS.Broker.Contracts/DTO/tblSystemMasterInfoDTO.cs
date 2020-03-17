using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSystemMasterInfoDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String MasterData { get; set; }

        [DataMember()]
        public String MasterDataDescription { get; set; }

        public tblSystemMasterInfoDTO()
        {
        }

        public tblSystemMasterInfoDTO(Int32 iD, String masterData, String masterDataDescription)
        {
            this.ID = iD;
            this.MasterData = masterData;
            this.MasterDataDescription = masterDataDescription;
        }
    }
}
