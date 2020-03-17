using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{

    [DataContract()]
    public partial class SP_AllInterfaceDeviceStatus_ResultDTO
    {
        [DataMember()]
        public Int32 SSiteID { get; set; }

        [DataMember()]
        public String SName { get; set; }

        [DataMember()]
        public Nullable<Int32> ARSiteID { get; set; }

        [DataMember()]
        public String ARName { get; set; }

        [DataMember()]
        public Nullable<Int32> FLSiteID { get; set; }

        [DataMember()]
        public String FLName { get; set; }

        [DataMember()]
        public Nullable<Int32> ZSiteID { get; set; }

        [DataMember()]
        public String ZName { get; set; }

        [DataMember()]
        public Nullable<Int32> ACountDeviceID { get; set; }

        [DataMember()]
        public Int32 IInterfaceID { get; set; }

        [DataMember()]
        public String InterfaceName { get; set; }

        [DataMember()]
        public String InterfaceSubType { get; set; }

        [DataMember()]
        public Int64 DDeviceID { get; set; }

        [DataMember()]
        public String DDName { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public Double Lat { get; set; }

        [DataMember()]
        public Double Long_ { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceStatus { get; set; }

        [DataMember()]
        public Nullable<Int32> DeviceStatus { get; set; }

        public SP_AllInterfaceDeviceStatus_ResultDTO()
        {
        }

        public SP_AllInterfaceDeviceStatus_ResultDTO(Int32 sSiteID, String sName, Nullable<Int32> aRSiteID, String aRName, Nullable<Int32> fLSiteID, String fLName, Nullable<Int32> zSiteID, String zName, Nullable<Int32> aCountDeviceID, Int32 iInterfaceID, String interfaceName, String interfaceSubType, Int64 dDeviceID, String dDName, String externalId, Double lat, Double long_, Nullable<Int32> interfaceStatus, Nullable<Int32> deviceStatus)
        {
            this.SSiteID = sSiteID;
            this.SName = sName;
            this.ARSiteID = aRSiteID;
            this.ARName = aRName;
            this.FLSiteID = fLSiteID;
            this.FLName = fLName;
            this.ZSiteID = zSiteID;
            this.ZName = zName;
            this.ACountDeviceID = aCountDeviceID;
            this.IInterfaceID = iInterfaceID;
            this.InterfaceName = interfaceName;
            this.InterfaceSubType = interfaceSubType;
            this.DDeviceID = dDeviceID;
            this.DDName = dDName;
            this.ExternalId = externalId;
            this.Lat = lat;
            this.Long_ = long_;
            this.InterfaceStatus = interfaceStatus;
            this.DeviceStatus = deviceStatus;
        }
    }

}
