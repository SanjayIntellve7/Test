using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPidsAlertPresetAssocaitionDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Int32 DeviceID { get; set; }

        [DataMember()]
        public Int32 PTZCameraID { get; set; }

        [DataMember()]
        public Double StartDistance { get; set; }

        [DataMember()]
        public Double EndDistance { get; set; }

        [DataMember()]
        public Int32 PresetNo { get; set; }

        [DataMember()]
        public String IPAddress { get; set; }

        [DataMember()]
        public int Port { get; set; }

        [DataMember()]
        public String Username { get; set; }

        [DataMember()]
        public String Password { get; set; }
        [DataMember()]
        public Guid GUID { get; set; }

        public tblPidsAlertPresetAssocaitionDTO()
        {
        }

        public tblPidsAlertPresetAssocaitionDTO(Int32 iD, Int32 deviceID, Int32 pTZCameraID, Double startDistance, Double endDistance, Int32 presetNo, string ip, Int32 port, string username, string pwd, Guid guid)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.PTZCameraID = pTZCameraID;
            this.StartDistance = startDistance;
            this.EndDistance = endDistance;
            this.PresetNo = presetNo;
            this.IPAddress = ip;
            this.Port = port;
            this.Username = username;
            this.Password = pwd;
            this.GUID = guid;
        }
    }
}
