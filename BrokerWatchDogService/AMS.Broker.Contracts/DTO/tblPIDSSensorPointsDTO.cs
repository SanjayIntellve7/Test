using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{  
    [DataContract()]
    public partial class tblPIDSSensorPointsDTO
    {
        [DataMember()]
        public Int64 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> SensorID_ID { get; set; }

        [DataMember()]
        public Nullable<Int32> SensorID { get; set; }

        [DataMember()]
        public Nullable<Int32> SequenceNo { get; set; }

        [DataMember()]
        public Nullable<double> Lat { get; set; }

        [DataMember()]
        public Nullable<double> Lon { get; set; }

        [DataMember()]
        public Nullable<double> CableDistance { get; set; }

        [DataMember()]
        public Nullable<double> PerimeterDistance { get; set; }

        [DataMember()]
        public bool CalibrationPoint { get; set; }

        [DataMember()]
        public Nullable<double> Altitude { get; set; }


        public tblPIDSSensorPointsDTO()
        {
        }

        public tblPIDSSensorPointsDTO(Int64 iD, Nullable<Int32> sensorID_ID, Nullable<Int32> sensorID, Nullable<Int32> sequenceNo, Nullable<double> lat, Nullable<double> lon, Nullable<double> cableDistance, Nullable<double> perimeterDistance, bool calibrationPoint, Nullable<double> altitude)
        {
            this.ID = iD;
            this.SensorID_ID = sensorID_ID;
            this.SensorID = SensorID;
            this.SequenceNo = SequenceNo;
            this.Lat = lat;
            this.Lon = lon;
            this.CableDistance = CableDistance;
            this.PerimeterDistance = perimeterDistance;
            this.CalibrationPoint = calibrationPoint;
            this.Altitude = altitude;
        }
    }
}
