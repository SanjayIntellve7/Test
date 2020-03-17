using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblBacnetObjectDeviceDetailsDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_TYPE_NAME { get; set; }

        [DataMember()]
        public Nullable<Int32> BACNET_OBJECT_TYPE_VALUE { get; set; }

        [DataMember()]
        public Nullable<Int64> BACNET_OBJECT_IDENTIFIER { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_NAME { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_DESCRIPTION { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_DEVICE_TYPE { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_DATATYPE { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_RESRV1 { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_RESRV2 { get; set; }

        [DataMember()]
        public String BACNET_OBJECT_XML { get; set; }

        [DataMember()]
        public Nullable<Int64> DeviceID { get; set; }

        [DataMember()]
        public Nullable<Int64> PanelID { get; set; }

        [DataMember()]
        public Nullable<Int32> AlertStatus { get; set; }

        public tblBacnetObjectDeviceDetailsDTO()
        {
        }

        public tblBacnetObjectDeviceDetailsDTO(Int64 iD, String bACNET_OBJECT_TYPE_NAME, Nullable<Int32> bACNET_OBJECT_TYPE_VALUE, Nullable<Int64> bACNET_OBJECT_IDENTIFIER, String bACNET_OBJECT_NAME, String bACNET_OBJECT_DESCRIPTION, String bACNET_OBJECT_DEVICE_TYPE, String bACNET_OBJECT_DATATYPE, String bACNET_OBJECT_RESRV1, String bACNET_OBJECT_RESRV2, String bACNET_OBJECT_XML, Nullable<Int64> deviceID, Nullable<Int64> panelID, Nullable<Int32> alertStatus)
        {
            this.ID = iD;
            this.BACNET_OBJECT_TYPE_NAME = bACNET_OBJECT_TYPE_NAME;
            this.BACNET_OBJECT_TYPE_VALUE = bACNET_OBJECT_TYPE_VALUE;
            this.BACNET_OBJECT_IDENTIFIER = bACNET_OBJECT_IDENTIFIER;
            this.BACNET_OBJECT_NAME = bACNET_OBJECT_NAME;
            this.BACNET_OBJECT_DESCRIPTION = bACNET_OBJECT_DESCRIPTION;
            this.BACNET_OBJECT_DEVICE_TYPE = bACNET_OBJECT_DEVICE_TYPE;
            this.BACNET_OBJECT_DATATYPE = bACNET_OBJECT_DATATYPE;
            this.BACNET_OBJECT_RESRV1 = bACNET_OBJECT_RESRV1;
            this.BACNET_OBJECT_RESRV2 = bACNET_OBJECT_RESRV2;
            this.BACNET_OBJECT_XML = bACNET_OBJECT_XML;
            this.DeviceID = deviceID;
            this.PanelID = panelID;
            this.AlertStatus = alertStatus;
        }
    }
}
