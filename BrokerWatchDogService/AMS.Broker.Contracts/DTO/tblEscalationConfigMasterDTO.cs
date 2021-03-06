﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2019/11/13 - 15:03:48
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
    public partial class tblEscalationConfigMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String EscalationConfigName { get; set; }

        [DataMember()]
        public String EscalationConfigDescription { get; set; }

        [DataMember()]
        public Nullable<Boolean> IsEnable { get; set; }

        [DataMember()]
        public List<Int32> tblEscalationConfigDetails_ID { get; set; }

        [DataMember()]
        public List<Int32> tblEscalationMatrixInfo_ID { get; set; }

        [DataMember()]
        public List<tblEscalationConfigDetailsDTO> tblEscalationConfigDetailsList { get; set; }

        [DataMember()]
        public List<tblEscalationMatrixInfoDTO> tblEscalationMatrixInfoList { get; set; }

        public tblEscalationConfigMasterDTO()
        {
        }

        public tblEscalationConfigMasterDTO(Int32 iD, String escalationConfigName, String escalationConfigDescription, Nullable<Boolean> isEnable, List<Int32> tblEscalationConfigDetails_ID, List<Int32> tblEscalationMatrixInfo_ID, List<tblEscalationConfigDetailsDTO> tblEscalationConfigDetailsList, List<tblEscalationMatrixInfoDTO> tblEscalationMatrixInfoList)
        {
            this.ID = iD;
            this.EscalationConfigName = escalationConfigName;
            this.EscalationConfigDescription = escalationConfigDescription;
            this.IsEnable = isEnable;
            this.tblEscalationConfigDetails_ID = tblEscalationConfigDetails_ID;
            this.tblEscalationMatrixInfo_ID = tblEscalationMatrixInfo_ID;
            this.tblEscalationConfigDetailsList = tblEscalationConfigDetailsList;
            this.tblEscalationMatrixInfoList = tblEscalationMatrixInfoList;
        }
    }
}
