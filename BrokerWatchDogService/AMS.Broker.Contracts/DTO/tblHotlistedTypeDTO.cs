using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblHotlistedTypeDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String HotlistCatId { get; set; }

        [DataMember()]
        public String HotlistCatName { get; set; }

        public tblHotlistedTypeDTO()
        {
        }

        public tblHotlistedTypeDTO(Int32 iD, String hotlistCatId, String hotlistCatName)
        {
            this.ID = iD;
            this.HotlistCatId = hotlistCatId;
            this.HotlistCatName = hotlistCatName;
        }
    }
}
