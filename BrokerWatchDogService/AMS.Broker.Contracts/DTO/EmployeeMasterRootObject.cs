using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class EmployeeMasterRootObject
    {
        public List<EmployeeMaster> employeeMasters { get; set; }
        public string Status { get; set; }
    }

    public class EmployeeMaster
    {
        public string AadharNo { get; set; }
        public string Address { get; set; }
        public string AgencyName { get; set; }
        public string CategoryOfWork { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string EmpType { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PhoneNo { get; set; }
        public string Section { get; set; }
        public string ShiftType { get; set; }
        public string WardNo { get; set; }
    }


}
