using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class AppiyoLoginData
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public message message { get; set; }
        [DataMember]
        public response response { get; set; }
    }

    [DataContract]
    public class message
    {
        [DataMember(Name = "message")]
        public string _message { get; set; }
        [DataMember]
        public string code { get; set; }
    }

    [DataContract]
    public class response
    {
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public string uId { get; set; }
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public List<tags> tags { get; set; }

        [DataMember]
        public string cId { get; set; }

        [DataMember]
        public string Cid { get; set; }

        [DataMember]
        public List<customers> customers { get; set; }
    }
}
