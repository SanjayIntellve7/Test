//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/04/18 - 17:19:50
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
    public partial class tblSmartCityStreetElecDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String ElecName { get; set; }

        [DataMember()]
        public Nullable<Double> Lat { get; set; }

        [DataMember()]
        public Nullable<Double> Long_ { get; set; }

        [DataMember()]
        public String ElecAddress { get; set; }

        [DataMember()]
        public String Telephone { get; set; }

        public tblSmartCityStreetElecDTO()
        {
        }

        public tblSmartCityStreetElecDTO(Int32 iD, String elecName, Nullable<Double> lat, Nullable<Double> long_, String elecAddress, String telephone)
        {
			this.ID = iD;
			this.ElecName = elecName;
			this.Lat = lat;
			this.Long_ = long_;
			this.ElecAddress = elecAddress;
			this.Telephone = telephone;
        }
    }
}
