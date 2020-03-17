using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblBarcoPerspectiveDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Nullable<DateTime> DateTime { get; set; }

        public tblBarcoPerspectiveDTO()
        {
        }

        public tblBarcoPerspectiveDTO(Int64 iD, String name, String description, Nullable<DateTime> dateTime)
        {
            this.ID = iD;
            this.Name = name;
            this.Description = description;
            this.DateTime = dateTime;
        }
    }
}
