using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblNotificationmsgDto
    {

         [DataMember()]
        public Int32 NotificationID { get; set; }

        [DataMember()]
        public String Stationfrm { get; set; }

        [DataMember()]
        public String Stationfrmip { get; set; }

        [DataMember()]
        public String Stationto { get; set; }

        [DataMember()]
        public String Stationtoip { get; set; }

        [DataMember()]
        public String Notificationmsg { get; set; }

        [DataMember()]
        public Nullable<DateTime> NotificationDate { get; set; }

        [DataMember()]
        public Nullable<Boolean> Readstatus { get; set; }

        public tblNotificationmsgDto()
        {
        }

        public tblNotificationmsgDto(Int32 notificationID, String stationfrm, String stationfrmip, String stationto, String stationtoip, String notificationmsg, Nullable<DateTime> notificationDate, Nullable<Boolean> readstatus)
        {
			this.NotificationID = notificationID;
			this.Stationfrm = stationfrm;
			this.Stationfrmip = stationfrmip;
			this.Stationto = stationto;
			this.Stationtoip = stationtoip;
			this.Notificationmsg = notificationmsg;
			this.NotificationDate = notificationDate;
			this.Readstatus = readstatus;
        }
    }
}
