﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2018/08/22 - 21:55:28
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblONTMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> OLTID { get; set; }

        [DataMember()]
        public String ONTName { get; set; }

        [DataMember()]
        public String ONTStatus { get; set; }

        [DataMember()]
        public Nullable<DateTime> LastUpdateDatetime { get; set; }

        public tblONTMasterDTO()
        {
        }

        public tblONTMasterDTO(Int32 iD, Nullable<Int32> oLTID, String oNTName, String oNTStatus, Nullable<DateTime> lastUpdateDatetime)
        {
            this.ID = iD;
            this.OLTID = oLTID;
            this.ONTName = oNTName;
            this.ONTStatus = oNTStatus;
            this.LastUpdateDatetime = lastUpdateDatetime;
        }
    }
}