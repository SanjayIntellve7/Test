using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblStandardSOPMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String AccountId { get; set; }

        [DataMember()]
        public String SiteId { get; set; }

        [DataMember()]
        public String AreaId { get; set; }

        [DataMember()]
        public String FloorId { get; set; }

        [DataMember()]
        public String ZoneId { get; set; }

        [DataMember()]
        public String DeviceType { get; set; }

        [DataMember()]
        public String Device { get; set; }

        [DataMember()]
        public String EventGroup { get; set; }

        [DataMember()]
        public String EventCode { get; set; }

        [DataMember()]
        public bool? ISDisable { get; set; }

        public tblStandardSOPMasterDTO()
        {
        }

        public tblStandardSOPMasterDTO(Int32 iD, String name, String accountId, String siteId, String areaId, String floorId, String zoneId, String deviceType, String device, String eventGroup, String eventCode, bool iSDisable)
        {
            this.ID = iD;
            this.Name = name;
            this.AccountId = accountId;
            this.SiteId = siteId;
            this.AreaId = areaId;
            this.FloorId = floorId;
            this.ZoneId = zoneId;
            this.DeviceType = deviceType;
            this.Device = device;
            this.EventGroup = eventGroup;
            this.EventCode = eventCode;
            this.ISDisable = iSDisable;
        }
    }
}
