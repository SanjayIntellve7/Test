//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2018/01/12 - 20:45:47
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
    public partial class tblBinThresholdDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Int64 BinIMEINumber { get; set; }

        [DataMember()]
        public Nullable<Decimal> BinHeight { get; set; }

        [DataMember()]
        public Nullable<Decimal> Binfillthreshold { get; set; }

        public tblBinThresholdDTO()
        {
        }

        public tblBinThresholdDTO(Int32 iD, Int64 binIMEINumber, Nullable<Decimal> binHeight, Nullable<Decimal> binfillthreshold)
        {
			this.ID = iD;
			this.BinIMEINumber = binIMEINumber;
			this.BinHeight = binHeight;
			this.Binfillthreshold = binfillthreshold;
        }
    }
}