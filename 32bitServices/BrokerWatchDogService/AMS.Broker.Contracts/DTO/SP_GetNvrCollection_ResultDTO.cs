//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/06/19 - 18:56:09
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
    public partial class SP_GetNvrCollection_ResultDTO
    {
        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Nullable<Int32> DvrNvrTypeId { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceId { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public Int64 NvrId { get; set; }

        [DataMember()]
        public String NvrUrl { get; set; }

        [DataMember()]
        public String Username { get; set; }

        [DataMember()]
        public String Password { get; set; }

        [DataMember()]
        public Nullable<Int32> Port { get; set; }

        public SP_GetNvrCollection_ResultDTO()
        {
        }

        public SP_GetNvrCollection_ResultDTO(String description, Nullable<Int32> dvrNvrTypeId, Nullable<Int32> interfaceId, String iPAddress, Int64 nvrId, String nvrUrl, String username, String password, Nullable<Int32> port)
        {
			this.Description = description;
			this.DvrNvrTypeId = dvrNvrTypeId;
			this.InterfaceId = interfaceId;
			this.IPAddress = iPAddress;
			this.NvrId = nvrId;
			this.NvrUrl = nvrUrl;
			this.Username = username;
			this.Password = password;
			this.Port = port;
        }
    }
}
