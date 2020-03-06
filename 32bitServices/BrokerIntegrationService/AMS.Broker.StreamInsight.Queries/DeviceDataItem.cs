using Logica.RealTimeDataMgmt.DataTypes;

namespace AMS.Broker.StreamInsight.Queries
{
    public sealed class DeviceDataItem
    {
        public string DeviceId { get; set; }
        public string Description { get; set; }
        public string DeviceType { get; set; }
        public string StreamInsightId { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Altitude { get; set; }
        public string ZonesList { get; set; }
    }
}
