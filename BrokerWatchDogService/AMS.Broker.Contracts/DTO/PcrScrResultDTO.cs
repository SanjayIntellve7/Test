using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class PcrScrResultDTO
    {
        [DataMember()]
        public bool IsChecked { get; set; }

        [DataMember()]
        public bool IsEnabled { get; set; }

        [DataMember()]
        public string pcrGUID { get; set; }

        [DataMember()]
        public string pcrCamIP { get; set; }

        [DataMember()]
        public string pcrCamName { get; set; }

        [DataMember()]
        public string scrGUID { get; set; }

        [DataMember()]
        public string scrCamIP { get; set; }

        [DataMember()]
        public string scrCamName { get; set; }
    }
}
