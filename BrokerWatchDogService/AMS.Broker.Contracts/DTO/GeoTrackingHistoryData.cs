using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class GeoTrackingHistoryData
    {
        [DataMember]
        public string datetime { get; set; }//

        [DataMember]
        public string startdate { get; set; }//

        [DataMember]
        public string enddate { get; set; }//

        [DataMember]
        public double latitude { get; set; }//

        [DataMember]
        public double longitude { get; set; }//

        [DataMember]
        public string heading { get; set; }//

        [DataMember]
        public string speed { get; set; }//

        [DataMember]
        public string location { get; set; }//

        [DataMember]
        public string status { get; set; }//

        [DataMember]
        public string battery { get; set; }//

        [DataMember]
        public asset asset { get; set; }//

        [DataMember]
        public int eventno { get; set; }//

        [DataMember]
        public string eventname { get; set; }//

        [DataMember]
        public string legend { get; set; }//

        [DataMember]
        public string remark { get; set; }//

        [DataMember]
        public string remarkdate { get; set; }//

        [DataMember]
        public string tripname { get; set; }//

        [DataMember]
        public string distance { get; set; }//

        [DataMember]
        public string user { get; set; }//

        [DataMember()]
        public Guid SystemId { get; set; }
    }
}

