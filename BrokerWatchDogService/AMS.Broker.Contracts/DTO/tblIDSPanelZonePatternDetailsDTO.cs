using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIDSPanelZonePatternDetailsDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public tblIDSPanelInfoMasterDTO IDSPanelInfoDetails { get; set; }

        [DataMember()]
        public String ZoneNumber { get; set; }

        [DataMember()]
        public tblIDSPanelZoneTypeMasterDTO ZoneType { get; set; }

        [DataMember()]
        public String Area { get; set; }

        [DataMember()]
        public String DeviceType { get; set; }

        public tblIDSPanelZonePatternDetailsDTO()
        {
        }

        public tblIDSPanelZonePatternDetailsDTO(Int32 iD, tblIDSPanelInfoMasterDTO iDSPanelInfo, String zoneNumber, tblIDSPanelZoneTypeMasterDTO ZoneType, String area, String deviceType)
        {
            this.ID = iD;
            this.IDSPanelInfoDetails = iDSPanelInfo;
            this.ZoneNumber = zoneNumber;
            this.ZoneType = ZoneType;
            this.Area = area;
            this.DeviceType = deviceType;
        }
    }
}
