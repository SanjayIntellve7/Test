using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblHotlistedCategoryDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String VehCatId { get; set; }

        [DataMember()]
        public String VehCatName { get; set; }

        public tblHotlistedCategoryDTO()
        {
        }

        public tblHotlistedCategoryDTO(Int32 iD, String vehCatId, String vehCatName)
        {
            this.ID = iD;
            this.VehCatId = vehCatId;
            this.VehCatName = vehCatName;
        }
    }
}