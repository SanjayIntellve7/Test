﻿//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2018/01/09 - 12:22:32
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
    public partial class tblPrimarySecondaryServerMappingDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceID { get; set; }

        [DataMember()]
        public String PrimaryServerIP { get; set; }

        [DataMember()]
        public Nullable<Int32> PrimaryServerPort { get; set; }

        [DataMember()]
        public String PrimaryServerUserName { get; set; }

        [DataMember()]
        public String PrimaryServerPassword { get; set; }

        [DataMember()]
        public String PrimaryServerURL { get; set; }

        [DataMember()]
        public String SecondaryServerIP { get; set; }

        [DataMember()]
        public Nullable<Int32> SecondaryServerPort { get; set; }

        [DataMember()]
        public String SecondaryServerUserName { get; set; }

        [DataMember()]
        public String SecondaryServerPassword { get; set; }

        [DataMember()]
        public String SecondaryServerURL { get; set; }

        public tblPrimarySecondaryServerMappingDTO()
        {
        }

        public tblPrimarySecondaryServerMappingDTO(Int32 iD, Nullable<Int32> interfaceID, String primaryServerIP, Nullable<Int32> primaryServerPort, String primaryServerUserName, String primaryServerPassword, String primaryServerURL, String secondaryServerIP, Nullable<Int32> secondaryServerPort, String secondaryServerUserName, String secondaryServerPassword, String secondaryServerURL)
        {
            this.ID = iD;
            this.InterfaceID = interfaceID;
            this.PrimaryServerIP = primaryServerIP;
            this.PrimaryServerPort = primaryServerPort;
            this.PrimaryServerUserName = primaryServerUserName;
            this.PrimaryServerPassword = primaryServerPassword;
            this.PrimaryServerURL = primaryServerURL;
            this.SecondaryServerIP = secondaryServerIP;
            this.SecondaryServerPort = secondaryServerPort;
            this.SecondaryServerUserName = secondaryServerUserName;
            this.SecondaryServerPassword = secondaryServerPassword;
            this.SecondaryServerURL = secondaryServerURL;
        }
    }
}
