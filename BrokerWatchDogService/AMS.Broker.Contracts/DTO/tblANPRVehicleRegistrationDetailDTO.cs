using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblANPRVehicleRegistrationDetailDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string strRecNum { get; set; }
        [DataMember]
        public string strVehType { get; set; }
        [DataMember]
        public string strVehColor { get; set; }
        [DataMember]
        public string strVehAccessStatus { get; set; }
        [DataMember]
        public string strDriName { get; set; }
        [DataMember]
        public string strContactNo { get; set; }
        [DataMember]
        public string strCompanyName { get; set; }

        [DataMember]
        public string strAnprserverIP { get; set; }

        [DataMember]
        public string strAnprserverPort { get; set; }

        [DataMember]
        public string strANPRType { get; set; }

    }
}
