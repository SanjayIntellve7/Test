using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSOPActionMasterDTO
    {
        [DataMember()]
        public Int32 ActionId { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Boolean IsAllowAuto { get; set; }

         [DataMember()]
        public Boolean IsRepeatable { get; set; }

        public tblSOPActionMasterDTO()
        {
        }

        public tblSOPActionMasterDTO(Int32 actionId, String name, String description, Boolean isAllowAuto, Boolean isRepeatable)
        {
            this.ActionId = actionId;
            this.Name = name;
            this.Description = description;
            this.IsAllowAuto = isAllowAuto;
            this.IsRepeatable = isRepeatable;
        }
    }
}
