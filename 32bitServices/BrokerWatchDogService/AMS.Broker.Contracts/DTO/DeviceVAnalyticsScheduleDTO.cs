//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/10 - 15:32:15
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class DeviceVAnalyticsScheduleDTO 
    {
        [DataMember()]
        public Int32 DevSchID { get; set; }

        [DataMember()]
        public Int64 DeviceID { get; set; }

        [DataMember()]
        public Boolean DevSchEnb { get; set; }

        [DataMember()]
        public Int32 nDay { get; set; }

        [DataMember()]
        public Int32 nHrs { get; set; }

        public DeviceVAnalyticsScheduleDTO()
        {
        }

        public DeviceVAnalyticsScheduleDTO(Int32 devSchID, Int64 deviceID, Boolean devSchEnb, Int32 nDay, Int32 nHrs)
        {
			this.DevSchID = devSchID;
			this.DeviceID = deviceID;
			this.DevSchEnb = devSchEnb;
			this.nDay = nDay;
			this.nHrs = nHrs;
        }
    }
}