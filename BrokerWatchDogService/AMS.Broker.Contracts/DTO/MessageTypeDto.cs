//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/05/27 - 12:21:42
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
    public partial class MessageTypeDto
    {
        [DataMember()]
        public String Name { get; set; }

        [DataMember]
        public Int32 MessageTypeID { get; set; }

        public MessageTypeDto()
        {
        }

        public MessageTypeDto(String name, Int32 messageTypeID)
        {
            this.Name = name;
            this.MessageTypeID = messageTypeID;
        }
    }
}