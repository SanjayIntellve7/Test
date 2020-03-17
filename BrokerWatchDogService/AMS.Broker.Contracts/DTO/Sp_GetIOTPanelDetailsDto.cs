using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class Sp_GetIOTPanelDetails_ResultDTO
    {
        [DataMember()]
        public String PanelName { get; set; }

        [DataMember()]
        public String DeviceID { get; set; }

        [DataMember()]
        public String Location { get; set; }

        [DataMember()]
        public Nullable<DateTime> TxDateTime { get; set; }

        public Sp_GetIOTPanelDetails_ResultDTO()
        {
        }

        public Sp_GetIOTPanelDetails_ResultDTO(String panelName, String deviceID, String location, Nullable<DateTime> txDateTime)
        {
            this.PanelName = panelName;
            this.DeviceID = deviceID;
            this.Location = location;
            this.TxDateTime = txDateTime;
        }
    }
}
