using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.SqlServer.Types;

namespace AMS.Broker.Contracts.DTO
{
    public sealed class Area
    {
        public Int64 AreaId { get; set; }
        public Int64 SiteId { get; set; }
        public Int64 InfoId { get; set; }
        public String Description { get; set; }

        [XmlElement(Type = typeof(float?))]
        public double? Altitude { get; set; }
        [XmlElement(Type = typeof(double?))]
        public double? Celing { get; set; }
        [XmlElement(Type = typeof(double?))]
        public double? Latitude { get; set; }
        [XmlElement(Type = typeof(double?))]
        public double? Longitude { get; set; }
    }
}