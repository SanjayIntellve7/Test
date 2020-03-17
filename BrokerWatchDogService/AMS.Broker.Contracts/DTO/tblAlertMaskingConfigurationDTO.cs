using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblAlertMaskingConfigurationDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<DateTime> FromDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> ToDate { get; set; }

        [DataMember()]
        public String EntityName { get; set; }

        [DataMember()]
        public Nullable<Int32> EntityID { get; set; }

        [DataMember()]
        public String Reserve { get; set; }

        public tblAlertMaskingConfigurationDTO()
        {
        }

        public tblAlertMaskingConfigurationDTO(Int32 iD, Nullable<DateTime> fromDate, Nullable<DateTime> toDate, String entityName, Nullable<Int32> entityID, String reserve)
        {
            this.ID = iD;
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.EntityName = entityName;
            this.EntityID = entityID;
            this.Reserve = reserve;
        }
    }
}
