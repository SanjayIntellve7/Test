using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(NvrDto)), KnownType(typeof(Mask)), Serializable]
    public class VideoAnalyticsParameters
    {
        [DataMember]
        public string VideoPath { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int MaxBlobSize { get; set; }

        [DataMember]
        public int MinBlobSize { get; set; }

        [DataMember]
        public int AlarmDelay { get; set; }

        [DataMember]
        public float UpdateRate { get; set; }

        [DataMember]
        public string NvrUser { get; set; }

        [DataMember]
        public string NvrPassword { get; set; }

        [DataMember]
        public Guid CameraGuid { get; set; }

        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }

        [DataMember]
        public int FPS { get; set; }

        [DataMember]
        public int ZoneRows { get; set; }

        [DataMember]
        public int ZoneColumns { get; set; }

        [DataMember]
        public byte[] ZoneData { get; set; }
       
    }
}
