using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblInterfaceSubRadarMasterDTO
    {
     

        [DataMember()]
        public Int32 ID { get; set; }       

         [DataMember()]
        public Nullable<int> AlarmPanelTypeID { get; set; }

        [DataMember()]
        public String ServerUserName { get; set; }

        [DataMember()]
        public Nullable<int> RadarServerPort { get; set; }

        [DataMember()]
        public String RadarServerIP { get; set; }

        [DataMember()]
        public String ServerPassword { get; set; }

        [DataMember()]
        public String ServerBaseURL { get; set; }

       

        public tblInterfaceSubRadarMasterDTO()
        {
        }

        public tblInterfaceSubRadarMasterDTO(Int32 iD, Nullable<int> AlarmPanelTypeID, String ServerUserName, Nullable<int> RadarServerPort, String RadarServerIP, String ServerPassword, String ServerBaseURL)
        {
            this.ID = iD;
            this.AlarmPanelTypeID = AlarmPanelTypeID;
            this.ServerUserName = ServerUserName;
            this.RadarServerPort = RadarServerPort;
            this.RadarServerIP = RadarServerIP;
            this.ServerPassword = ServerPassword;
            this.ServerBaseURL = ServerBaseURL;
        }
    }
}
