using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public class SocialMediaAlertDTO
    {
        [DataMember()]
        public String recordidrecordid { get; set; }

        [DataMember()]
        public String created_at { get; set; }

        [DataMember()]
        public String screen_name { get; set; }

        [DataMember()]
        public String userid { get; set; }

        [DataMember()]
        public String status { get; set; }

        [DataMember()]
        public String link { get; set; }

        [DataMember()]
        public String sentiment { get; set; }

        [DataMember()]
        public String gender { get; set; }

        [DataMember()]
        public String source { get; set; }

        [DataMember()]
        public String location { get; set; }

        public SocialMediaAlertDTO()
        {
        }
    }
}
