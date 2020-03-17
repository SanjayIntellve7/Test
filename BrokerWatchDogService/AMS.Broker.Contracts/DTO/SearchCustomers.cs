using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class SearchCustomers
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public message message { get; set; }
        [DataMember]
        public response response { get; set; }
    }


    [DataContract]
    public class customers
    {
        [DataMember]
        public string cId { set; get; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string photo { get; set; }
        [DataMember]
        public string desc { set; get; }
    }
}
