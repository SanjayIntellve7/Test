using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{   
    public class EmployeeAttendence
    {
        public List<Attendance> attendance { get; set; }
    }

    public class Attendance
    {
        public string AttendanceDate { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string InTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string OutTime { get; set; }
        public string WardNo { get; set; }
    }
}
