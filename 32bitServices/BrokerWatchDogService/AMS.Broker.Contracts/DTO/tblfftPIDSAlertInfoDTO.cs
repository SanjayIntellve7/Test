using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblfftPIDSAlertInfoDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> EventID { get; set; }

        [DataMember()]
        public Nullable<DateTime> EventdateTImeUTC { get; set; }

        [DataMember()]
        public Nullable<DateTime> EventDateTImelocal { get; set; }

        [DataMember()]
        public Nullable<Int32> ControllerID { get; set; }

        [DataMember()]
        public Nullable<Int32> SensorID { get; set; }

        [DataMember()]
        public Nullable<Int32> ZoneID { get; set; }

        [DataMember()]
        public Nullable<Int32> CableDistance { get; set; }

        [DataMember()]
        public Nullable<Double> lat { get; set; }

        [DataMember()]
        public Nullable<Double> long_ { get; set; }

        [DataMember()]
        public Nullable<Int32> LocationWeight { get; set; }

        [DataMember()]
        public Nullable<Int32> LocationWeightThreshold { get; set; }

        [DataMember()]
        public Nullable<Int32> PerimeterDistance { get; set; }

        [DataMember()]
        public String EventType { get; set; }

        [DataMember()]
        public Nullable<Int32> AlertID { get; set; }

        public tblfftPIDSAlertInfoDTO()
        {
        }

        public tblfftPIDSAlertInfoDTO(Int32 iD, Nullable<Int32> eventID, Nullable<DateTime> eventdateTImeUTC, Nullable<DateTime> eventDateTImelocal, Nullable<Int32> controllerID, Nullable<Int32> sensorID, Nullable<Int32> zoneID, Nullable<Int32> cableDistance, Nullable<Double> lat, Nullable<Double> long_, Nullable<Int32> locationWeight, Nullable<Int32> locationWeightThreshold, Nullable<Int32> perimeterDistance, String eventType, Nullable<Int32> alertID)
        {
            this.ID = iD;
            this.EventID = eventID;
            this.EventdateTImeUTC = eventdateTImeUTC;
            this.EventDateTImelocal = eventDateTImelocal;
            this.ControllerID = controllerID;
            this.SensorID = sensorID;
            this.ZoneID = zoneID;
            this.CableDistance = cableDistance;
            this.lat = lat;
            this.long_ = long_;
            this.LocationWeight = locationWeight;
            this.LocationWeightThreshold = locationWeightThreshold;
            this.PerimeterDistance = perimeterDistance;
            this.EventType = eventType;
            this.AlertID = alertID;
        }
    }
}
