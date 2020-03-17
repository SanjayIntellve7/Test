using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSWMAttendenceMasterDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String TotalEmployee { get; set; }

        [DataMember()]
        public String TotalPresent { get; set; }

        [DataMember()]
        public String TotalAbsent { get; set; }

        [DataMember()]
        public String WardNo { get; set; }

        [DataMember()]
        public Nullable<DateTime> AttendenceDate { get; set; }

        public tblSWMAttendenceMasterDTO()
        {
        }

        public tblSWMAttendenceMasterDTO(Int64 iD, String totalEmployee, String totalPresent, String totalAbsent, String wardNo, Nullable<DateTime> attendenceDate)
        {
            this.ID = iD;
            this.TotalEmployee = totalEmployee;
            this.TotalPresent = totalPresent;
            this.TotalAbsent = totalAbsent;
            this.WardNo = wardNo;
            this.AttendenceDate = attendenceDate;
        }
    }
}
