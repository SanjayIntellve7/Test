//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/06/15 - 19:33:03
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
    public partial class tbldevicefeatureDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String FeatureName { get; set; }

        public tbldevicefeatureDTO()
        {
        }

        public tbldevicefeatureDTO(Int32 iD, String featureName)
        {
			this.ID = iD;
			this.FeatureName = featureName;
        }
    }
}
