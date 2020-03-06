using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.SqlServer.Types;
using System.Xml.Linq;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public sealed class Station : IComparable<Station>, IComparable
    {
        [DataMember]
        public Int32 StationId { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Type { get; set; }
        [DataMember]
        public String Metadata { get; set; }
        [DataMember]
        public String Identifier { get; set; }
        [DataMember]
        public Boolean IsActive { get; set; }
        [DataMember]
        public DateTime ActivationDate { get; set; }
        [DataMember]
        public Decimal Lat { get; set; }
        [DataMember]
        public Decimal Long { get; set; }
        [DataMember]
        public Decimal Altitude { get; set; }
        [DataMember]
        public String LocationDescription { get; set; }

        public int NumberOfMonitors
        {
            get { return XElement.Parse(Metadata).Descendants(XName.Get("monitor")).Count(); }
            set { }
        }
        public bool IsBlocked
        {
            get { return false; /* read it from XML */}
            set { /* set it in XML */ }
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as Station);
        }
        public int CompareTo(Station other)
        {
            return other != null ?
                (StationId == other.StationId ? 0 : -1) :
                1;
        }
    }
}
