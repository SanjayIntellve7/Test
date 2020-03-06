﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class GroupResponseData
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public message message { get; set; }
        [DataMember ]
        public response response { get; set; }
    }

}
