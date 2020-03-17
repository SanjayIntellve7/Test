using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class tblWardPropertiesDTO
    {
        [DataMember]
        public string stroke { get; set; }
        [DataMember]
        public int stroke_wid { get; set; }
        [DataMember]
        public int stroke_opa { get; set; }
        [DataMember]
        public string fill { get; set; }
        [DataMember]
        public float fill_opaci { get; set; }
        [DataMember]
        public int OBJECTID { get; set; }
        [DataMember]
        public float Shape_Leng { get; set; }
        [DataMember]
        public float Shape_Area { get; set; }
        [DataMember]
        public string WARDNAME { get; set; }
        [DataMember]
        public int WARD { get; set; }
        [DataMember]
        public List<tblWardGeometryDTO> _geometry { get; set; }
    }
}
