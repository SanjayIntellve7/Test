﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(Info)), KnownType(typeof(DeviceDto)), Serializable]
    public class SPSearch_ResultDto
    {
        [DataMember]
        public Nullable<int> AlertID { get; set; }

        [DataMember]
        public string Addresses { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string AlertOwner { get; set; }

        [DataMember]
        public Nullable<System.DateTime> DataDateTime { get; set; }

        [DataMember]
        public Nullable<int> SiteID { get; set; }

        [DataMember]
        public string SiteName { get; set; }

        [DataMember]
        public Nullable<int> DeviceID { get; set; }

        [DataMember]
        public string DeviceName { get; set; }

        [DataMember]
        public string DeviceDesc { get; set; }

        [DataMember]
        public string DType { get; set; }

        [DataMember]
        public string LocationDescription { get; set; }

        [DataMember]
        public Nullable<int> IncidentReportID { get; set; }

        [DataMember]
        public string IOwner { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public Nullable<System.DateTime> ICreateDate { get; set; }

        [DataMember]
        public string SearchType { get; set; }
    }
}
