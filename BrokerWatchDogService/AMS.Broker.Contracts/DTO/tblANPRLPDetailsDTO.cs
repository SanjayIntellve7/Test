using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblANPRLPDetailsDTO
    {
        [DataMember()]
        public int ID { get; set; }
        [DataMember()]
        public string strDeviceUID { get; set; }
        [DataMember()]
        public string strIP { get; set; }
        [DataMember()]
        public string strName { get; set; }
        [DataMember()]
        public string strPassword { get; set; }
        [DataMember()]
        public string strLocation { get; set; }
        [DataMember()]
        public string strHttps_Port { get; set; }
        [DataMember()]
        public string strSsh_Port { get; set; }
        [DataMember()]
        public string strStatus { get; set; }
        [DataMember()]
        public Nullable<int> InterfaceID { get; set; }

    }
}