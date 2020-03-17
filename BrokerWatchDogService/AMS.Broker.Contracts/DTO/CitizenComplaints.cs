using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class ComplaintHead
    {
        public string AcknowledgedDate { get; set; }
        public string AdminRemarks { get; set; }
        public string CloseDateTime { get; set; }
        public string ComplaintId { get; set; }
        public string ComplaintType { get; set; }
        public string FullName { get; set; }
        public string LastStatus { get; set; }
        public string Latitude { get; set; }
        public string Location { get; set; }
        public string Longitude { get; set; }
        public string RegisteredDateTime { get; set; }
        public string Status { get; set; }
        public string UserRemarks { get; set; }
        public string WardName { get; set; }
        public string WardNo { get; set; }
    }
    public class CitizenComplaints
    {
        public string Status { get; set; }
        public List<ComplaintHead> complaintHeads { get; set; }
    }
}
