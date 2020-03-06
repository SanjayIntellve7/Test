using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class asset
    {
        [DataMember]
        public string registrationno { get; set; }//

        [DataMember]
        public string assetname { get; set; }//

        [DataMember]
        public string assetid { get; set; }//int

        [DataMember]
        public string assetnumber { get; set; }//

        [DataMember]
        public string status { get; set; }//

        [DataMember]
        public string statusid { get; set; }//int

        [DataMember]
        public string assetmodel { get; set; }//

        [DataMember]
        public string activationduration { get; set; }//int

        [DataMember]
        public string activationdate { get; set; }//

        [DataMember]
        public string subscriptionexpiry { get; set; }//

        [DataMember]
        public string accountid { get; set; }//int

        [DataMember]
        public string devicemaster { get; set; }//

        [DataMember]
        public string devicemasterid { get; set; }//int

        [DataMember]
        public string assettypeid { get; set; }//int

        [DataMember]
        public string assetbrandid { get; set; }//int

        [DataMember]
        public string simprovider { get; set; }//

        [DataMember]
        public string simproviderid { get; set; }//int

        [DataMember]
        public string subscriptionid { get; set; }//int

        [DataMember]
        public string userName { get; set; }//

    }
}

