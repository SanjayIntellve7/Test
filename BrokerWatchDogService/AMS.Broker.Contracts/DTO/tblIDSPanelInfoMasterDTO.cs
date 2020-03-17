using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIDSPanelInfoMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String PanelUsername { get; set; }

        [DataMember()]
        public String PanelPassword { get; set; }

        [DataMember()]
        public String PanelIP { get; set; }

        [DataMember()]
        public String Port { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteID { get; set; }

        [DataMember()]
        public String BranchID { get; set; }

        [DataMember()]
        public String BranchName { get; set; }

        [DataMember()]
        public Nullable<Int64> DeviceID { get; set; }

        [DataMember()]
        public String PanelTypeName { get; set; }

        [DataMember()]
        public Nullable<Int32> PanelTypeID { get; set; }

        [DataMember()]
        public String Partition { get; set; }

        [DataMember()]
        public String ZoneNumber { get; set; }

        public tblIDSPanelInfoMasterDTO()
        {
        }

        public tblIDSPanelInfoMasterDTO(Int32 iD, String panelUsername, String panelPassword, String panelIP, String port, Nullable<Int32> siteID, String branchID, String branchName, Nullable<Int64> deviceID, String panelTypeName, Nullable<Int32> panelTypeID, String partition, String zoneNumber)
        {
            this.ID = iD;
            this.PanelUsername = panelUsername;
            this.PanelPassword = panelPassword;
            this.PanelIP = panelIP;
            this.Port = port;
            this.SiteID = siteID;
            this.BranchID = branchID;
            this.BranchName = branchName;
            this.DeviceID = deviceID;
            this.PanelTypeName = panelTypeName;
            this.PanelTypeID = panelTypeID;
            this.Partition = partition;
            this.ZoneNumber = zoneNumber;
        }
    }
}
