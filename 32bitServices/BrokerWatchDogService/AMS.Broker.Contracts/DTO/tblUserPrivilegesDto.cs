//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/02/10 - 12:00:50
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
    public partial class tblUserPrivilegesDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String UserID { get; set; }

        [DataMember()]
        public Nullable<Int32> AccountID { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteID { get; set; }

        [DataMember()]
        public Nullable<Int32> AreaID { get; set; }

        [DataMember()]
        public Nullable<Int32> FloorID { get; set; }

        [DataMember()]
        public Nullable<Int32> ZoneID { get; set; }
                
        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }
        
        public tblUserPrivilegesDTO()
        {
        }

        public tblUserPrivilegesDTO(Int32 iD, String userID, Nullable<Int32> accountID, Nullable<Int32> siteID, Nullable<Int32> areaID, Nullable<Int32> floorID, Nullable<Int32> zoneID, Nullable<Int32> deviceID)
        {
			this.ID = iD;
			this.UserID = userID;
			this.AccountID = accountID;
			this.SiteID = siteID;
			this.AreaID = areaID;
			this.FloorID = floorID;
			this.ZoneID = zoneID;
            this.DeviceID = deviceID;
        }
    }
}
