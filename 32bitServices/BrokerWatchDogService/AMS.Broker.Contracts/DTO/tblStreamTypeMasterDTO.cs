﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class tblStreamTypeMasterDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string StreamType { get; set; }

    }
}