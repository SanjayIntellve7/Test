using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetANPRNonOCRDetails_ResultDTO
    {
        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public Nullable<DateTime> DateTime { get; set; }

        [DataMember()]
        public String RecNum { get; set; }

        [DataMember()]
        public String Direction { get; set; }

        [DataMember()]
        public String NPImagePath { get; set; }

        [DataMember()]
        public String StrDateTime { get; set; }

        public SP_GetANPRNonOCRDetails_ResultDTO()
        {
        }

        public SP_GetANPRNonOCRDetails_ResultDTO(String name, Nullable<DateTime> dateTime, String recNum, String direction, String nPImagePath, String _strDateTime)
        {
            this.Name = name;
            this.DateTime = dateTime;
            this.RecNum = recNum;
            this.Direction = direction;
            this.NPImagePath = nPImagePath;
            this.StrDateTime = _strDateTime;
        }
    }
}
