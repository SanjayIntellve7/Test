using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_ITMSChallanKPI_ResultDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String ChallanId { get; set; }

        [DataMember()]
        public String VehicleNo { get; set; }

        [DataMember()]
        public Nullable<DateTime> ChallanDate { get; set; }

        [DataMember()]
        public String JunctionName { get; set; }

        [DataMember()]
        public String OwnerName { get; set; }

        [DataMember()]
        public String OwnerAddress { get; set; }

        [DataMember()]
        public String Mobile { get; set; }

        [DataMember()]
        public String ViolationType { get; set; }

        [DataMember()]
        public String EqpId { get; set; }

        [DataMember()]
        public String VehicleColor { get; set; }

        [DataMember()]
        public String MakeModel { get; set; }

        [DataMember()]
        public String ChallanAmount { get; set; }

        [DataMember()]
        public String PaymentStatus { get; set; }

        [DataMember()]
        public String ImageFileName { get; set; }

        [DataMember()]
        public String ImageFileName1 { get; set; }

        [DataMember()]
        public String ImageFileName2 { get; set; }

        [DataMember()]
        public String ImageFileName3 { get; set; }

        [DataMember()]
        public String ChallanType { get; set; }

        public SP_ITMSChallanKPI_ResultDTO()
        {
        }

        public SP_ITMSChallanKPI_ResultDTO(Int64 iD, String challanId, String vehicleNo, Nullable<DateTime> challanDate, String junctionName, String ownerName, String ownerAddress, String mobile, String violationType, String eqpId, String vehicleColor, String makeModel, String challanAmount, String paymentStatus, String imageFileName, String imageFileName1, String imageFileName2, String imageFileName3, String challanType)
        {
            this.ID = iD;
            this.ChallanId = challanId;
            this.VehicleNo = vehicleNo;
            this.ChallanDate = challanDate;
            this.JunctionName = junctionName;
            this.OwnerName = ownerName;
            this.OwnerAddress = ownerAddress;
            this.Mobile = mobile;
            this.ViolationType = violationType;
            this.EqpId = eqpId;
            this.VehicleColor = vehicleColor;
            this.MakeModel = makeModel;
            this.ChallanAmount = challanAmount;
            this.PaymentStatus = paymentStatus;
            this.ImageFileName = imageFileName;
            this.ImageFileName1 = imageFileName1;
            this.ImageFileName2 = imageFileName2;
            this.ImageFileName3 = imageFileName3;
            this.ChallanType = challanType;
        }
    }
}
