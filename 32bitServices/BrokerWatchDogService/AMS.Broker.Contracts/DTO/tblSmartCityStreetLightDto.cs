//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/04/18 - 17:20:55
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
    public partial class tblSmartCityStreetLightDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Double> Lat { get; set; }

        [DataMember()]
        public Nullable<Double> Long_ { get; set; }

        public tblSmartCityStreetLightDTO()
        {
        }

        public tblSmartCityStreetLightDTO(Int32 iD, Nullable<Double> lat, Nullable<Double> long_)
        {
			this.ID = iD;
			this.Lat = lat;
			this.Long_ = long_;
        }
    }
}