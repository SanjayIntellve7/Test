//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/08/21 - 17:23:21
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
    public partial class tblCameraStatusDto
    {
        [DataMember()]
        public Int32 CameraStatusID { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceID { get; set; }

        [DataMember()]
        public Nullable<Boolean> Status { get; set; }

        [DataMember()]
        public String Remarks { get; set; }

        public tblCameraStatusDto()
        {
        }

        public tblCameraStatusDto(Int32 cameraStatusID, Nullable<Int32> deviceID, Nullable<Boolean> status, String remarks)
        {
			this.CameraStatusID = cameraStatusID;
			this.DeviceID = deviceID;
			this.Status = status;
			this.Remarks = remarks;
        }
    }
}
