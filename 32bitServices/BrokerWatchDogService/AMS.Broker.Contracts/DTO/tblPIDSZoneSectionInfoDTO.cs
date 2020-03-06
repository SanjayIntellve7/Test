using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPIDSZoneSectionInfoDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> PIDSZoneID { get; set; }

        [DataMember()]
        public Nullable<Int32> SenorID { get; set; }

        [DataMember()]
        public Nullable<Int32> SectionID { get; set; }

        [DataMember()]
        public Nullable<Double> CableStart { get; set; }

        [DataMember()]
        public Nullable<Double> CableEnd { get; set; }

        [DataMember()]
        public Nullable<Boolean> Opposite { get; set; }

        [DataMember()]
        public Nullable<Double> PermiterStart { get; set; }

        [DataMember()]
        public Nullable<Double> PermiterEnd { get; set; }

        [DataMember()]
        public Nullable<Int32> SensorStartIdx { get; set; }

        [DataMember()]
        public Nullable<Int32> SensorEndIdx { get; set; }

        [DataMember()]
        public Nullable<Int32> SequenceNo { get; set; }

        [DataMember()]
        public Nullable<Double> Lat { get; set; }

        [DataMember()]
        public Nullable<Double> Long_ { get; set; }

        public tblPIDSZoneSectionInfoDTO()
        {
        }

        public tblPIDSZoneSectionInfoDTO(Int32 iD, Nullable<Int32> pIDSZoneID, Nullable<Int32> senorID, Nullable<Int32> sectionID, Nullable<Double> cableStart, Nullable<Double> cableEnd, Nullable<Boolean> opposite, Nullable<Double> permiterStart, Nullable<Double> permiterEnd, Nullable<Int32> sensorStartIdx, Nullable<Int32> sensorEndIdx, Nullable<Int32> sequenceNo, Nullable<Double> lat, Nullable<Double> long_)
        {
            this.ID = iD;
            this.PIDSZoneID = pIDSZoneID;
            this.SenorID = senorID;
            this.SectionID = sectionID;
            this.CableStart = cableStart;
            this.CableEnd = cableEnd;
            this.Opposite = opposite;
            this.PermiterStart = permiterStart;
            this.PermiterEnd = permiterEnd;
            this.SensorStartIdx = sensorStartIdx;
            this.SensorEndIdx = sensorEndIdx;
            this.SequenceNo = sequenceNo;
            this.Lat = lat;
            this.Long_ = long_;
        }
    }
}
