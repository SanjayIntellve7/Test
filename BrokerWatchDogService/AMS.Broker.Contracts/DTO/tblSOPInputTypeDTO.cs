//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/03/07 - 16:12:01
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
    public partial class tblSOPInputTypeDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String SOPInput { get; set; }

        public tblSOPInputTypeDTO()
        {
        }

        public tblSOPInputTypeDTO(Int32 iD, String sOPInput)
        {
			this.ID = iD;
			this.SOPInput = sOPInput;
        }
    }
}