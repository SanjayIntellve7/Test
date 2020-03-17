using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class IODeviceXmlClasses
    {

    }

    public class TriggeredData
    {
        public string date { get; set; }
        public List<En> en { get; set; }
        public Gsmsts gsmsts { get; set; }
        public List<Cellst> cellsts { get; set; }
        public List<string> ffiller { get; set; }
    }

    public class En
    {
        public string _id { get; set; }
        public string __text { get; set; }
    }

    public class Gsmsts
    {
        public string _gs { get; set; }
        public string _rssi { get; set; }
        public string _dbm { get; set; }
        public string _ber { get; set; }
        public string _smsvc { get; set; }
    }

    public class Cellst
    {
        public string _cell { get; set; }
        public string _arfcn { get; set; }
        public string _rxl { get; set; }
        public string _rxq { get; set; }
        public string _mcc { get; set; }
        public string _mnc { get; set; }
        public string _bsic { get; set; }
        public string _cellid { get; set; }
        public string _rla { get; set; }
        public string _txp { get; set; }
    }

    public class TriggerAlert
    {
        public string _id { get; set; }
        public string _dt { get; set; }
        public string _val { get; set; }
        public string __text { get; set; }
    }


}
