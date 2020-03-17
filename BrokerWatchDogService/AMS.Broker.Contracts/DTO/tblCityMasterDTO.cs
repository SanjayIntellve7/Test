using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblCityMasterDTO
    {
        [DataMember()]
        public Int32 CityID { get; set; }

        [DataMember()]
        public Nullable<Int32> StateMasterID { get; set; }

        [DataMember()]
        public String CityName { get; set; }

        [DataMember()]
        public String Description { get; set; }

        public tblCityMasterDTO()
        {
        }

        public tblCityMasterDTO(Int32 cityID, Nullable<Int32> stateMasterID, String cityName, String description)
        {
            this.CityID = cityID;
            this.StateMasterID = stateMasterID;
            this.CityName = cityName;
            this.Description = description;
        }
    }
}
