using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblEscalationMatrixContactDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> LevelID { get; set; }

        [DataMember()]
        public String ContactName { get; set; }

        [DataMember()]
        public String ContactNumber { get; set; }

        [DataMember()]
        public String ContactEmailID { get; set; }

        [DataMember()]
        public Nullable<Boolean> SendSMS { get; set; }

        [DataMember()]
        public Nullable<Boolean> SendEmail { get; set; }

        [DataMember()]
        public Nullable<Boolean> SendMobiltNotification { get; set; }

        [DataMember()]
        public String Reserve1 { get; set; }

        [DataMember()]
        public String Reserve2 { get; set; }

        [DataMember()]
        public String Reserve3 { get; set; }

        [DataMember()]
        public String EntityType { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteID { get; set; }

        public tblEscalationMatrixContactDTO()
        {
        }

        public tblEscalationMatrixContactDTO(Int32 iD, Nullable<Int32> levelID, String contactName, String contactNumber, String contactEmailID, Nullable<Boolean> sendSMS, Nullable<Boolean> sendEmail, Nullable<Boolean> sendMobiltNotification, String reserve1, String reserve2, String reserve3, String entityType, Nullable<Int32> siteID)
        {
            this.ID = iD;
            this.LevelID = levelID;
            this.ContactName = contactName;
            this.ContactNumber = contactNumber;
            this.ContactEmailID = contactEmailID;
            this.SendSMS = sendSMS;
            this.SendEmail = sendEmail;
            this.SendMobiltNotification = sendMobiltNotification;
            this.Reserve1 = reserve1;
            this.Reserve2 = reserve2;
            this.Reserve3 = reserve3;
            this.EntityType = entityType;
            this.SiteID = siteID;
        }
    }
}
