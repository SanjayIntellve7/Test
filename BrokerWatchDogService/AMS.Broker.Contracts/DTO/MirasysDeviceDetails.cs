using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public partial class MirasysDeviceDetails
    {
        [DataMember]
        public string CameraName { get; set; }

        [DataMember]
        public string CameraGuid { get; set; }

        [DataMember]
        public string NvrIp { get; set; }

        [DataMember]
        public string NvrUserName { get; set; }

        [DataMember]
        public string NvrPassword { get; set; }

        [DataMember]
        public string NvrChannelNo { get; set; }

        [DataMember]
        public string CameraHeight { get; set; }

        [DataMember]
        public string CameraWidth { get; set; }

        [DataMember]
        public string CameraType { get; set; }
    }
}
