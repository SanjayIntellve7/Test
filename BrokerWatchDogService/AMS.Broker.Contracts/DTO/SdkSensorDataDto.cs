using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class SdkSensorDataDto
    {
        public int ControllerId { get; set; }
        public List<CoordinateDto> DrawingPoints { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public List<SensorPointDto> SensorPoints { get; set; }
    }
    public class SensorPointDto
    {
        public double cableDistance { get; set; }
        public bool calibrationPoint { get; set; }
        public string calibrationPointName { get; set; }
        public CoordinateDto coordinate { get; set; }
        public int id { get; set; }
        public double perimeterDistance { get; set; }
        public double seq { get; set; }

        //public SensorPoint(SensorPoint point);
        //public SensorPoint(int id, double seq, Coordinate coordinate, bool calibrationPoint, double cableDistance, double perimeterDistance, string calibrationPointName);
        //public SensorPoint(int id, double seq, double latitude, double longitude, double altitude, bool calibrationPoint, double cableDistance, double perimeterDistance, string calibrationPointName);

        //public override bool Equals(object obj);
    }
}
