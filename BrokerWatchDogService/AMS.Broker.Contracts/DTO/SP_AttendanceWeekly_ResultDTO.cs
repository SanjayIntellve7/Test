using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_AttendanceWeekly_ResultDTO
    {
        [DataMember()]
        public String WeekDay { get; set; }

        [DataMember()]
        public Nullable<DateTime> TXDate { get; set; }

        [DataMember()]
        public Nullable<Int32> AttendanceCount { get; set; }
      
        [DataMember()]
        public Int32 AttendanceStatus { get; set; }

        public SP_AttendanceWeekly_ResultDTO()
        {
        }

        public SP_AttendanceWeekly_ResultDTO(String weekDay, Nullable<DateTime> tXDate, Nullable<Int32> attendanceCount, Int32 attendanceStatus)
        {
            this.WeekDay = weekDay;
            this.TXDate = tXDate;
            this.AttendanceCount = attendanceCount;
            this.AttendanceStatus = attendanceStatus;
        }
    }
}
