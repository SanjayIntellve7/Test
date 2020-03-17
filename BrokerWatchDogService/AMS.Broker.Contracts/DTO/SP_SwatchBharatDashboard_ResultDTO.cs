using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_SwatchBharatDashboard_ResultDTO
    {
        [DataMember()]
        public String CityName { get; set; }

        [DataMember()]
        public Int32 CampaignCOunt { get; set; }

        public SP_SwatchBharatDashboard_ResultDTO()
        {
        }

        public SP_SwatchBharatDashboard_ResultDTO(String cityName, Int32 campaignCOunt)
        {
            this.CityName = cityName;
            this.CampaignCOunt = campaignCOunt;
        }
    }
}
