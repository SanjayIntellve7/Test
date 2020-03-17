using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSOPIconMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String IconName { get; set; }

        [DataMember()]
        public Byte[] Icon { get; set; }

        public tblSOPIconMasterDTO()
        {
        }

        public tblSOPIconMasterDTO(Int32 iD, String iconName, Byte[] icon)
        {
            this.ID = iD;
            this.IconName = iconName;
            this.Icon = icon;
        }
    }
}
