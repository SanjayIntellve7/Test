using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetPanelTrackingStatusDto
    {
        [DataMember()]
        public String BranchID { get; set; }

        [DataMember()]
        public String BranchName { get; set; }

        [DataMember()]
        public String DeviceName { get; set; }

        [DataMember()]
        public String Zone { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public String EventReceivedFrom { get; set; }

        [DataMember()]
        public String EventTo { get; set; }

        [DataMember()]
        public Nullable<DateTime> EventDateTime { get; set; }

        [DataMember()]
        public Nullable<DateTime> ReceivedDateTime { get; set; }

        [DataMember()]
        public String ReceivedPacket { get; set; }

        [DataMember()]
        public String SentPacket { get; set; }

        [DataMember()]
        public Nullable<Int32> Type_No { get; set; }

        [DataMember()]
        public String EventDescription { get; set; }

        public SP_GetPanelTrackingStatusDto()
        {
        }

        public SP_GetPanelTrackingStatusDto(String branchID, String branchName, String deviceName, String zone, String iPAddress, String eventReceivedFrom, String eventTo, Nullable<DateTime> eventDateTime, Nullable<DateTime> receivedDateTime, String receivedPacket, String sentPacket, Nullable<Int32> type_No, String eventDescription)
        {
            this.BranchID = branchID;
            this.BranchName = branchName;
            this.DeviceName = deviceName;
            this.Zone = zone;
            this.IPAddress = iPAddress;
            this.EventReceivedFrom = eventReceivedFrom;
            this.EventTo = eventTo;
            this.EventDateTime = eventDateTime;
            this.ReceivedDateTime = receivedDateTime;
            this.ReceivedPacket = receivedPacket;
            this.SentPacket = sentPacket;
            this.Type_No = type_No;
            this.EventDescription = eventDescription;
        }
    }
}
