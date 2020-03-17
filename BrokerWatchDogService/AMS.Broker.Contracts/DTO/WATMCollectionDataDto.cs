using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class WATMCollectionDataDto
    {
        public string DeviceId { get; set; }
        public string dispenserCollection { get; set; }
        public string CoinCollection { get; set; }
        public string CardCollection { get; set; }
        public string QtyDispensed { get; set; }
        public string RawWaterTDS { get; set; }
        public string QRCollection { get; set; }
        public string TotalCollection { get; set; }
        public string TreatedWaterVolume { get; set; }
        public string longtitude { get; set; }
        public string GoogleCityName { get; set; }
        public string latitude { get; set; }
        public string TreatedWaterTDS { get; set; }
        public string RawWaterVolume { get; set; }
        public string TxnDateTime { get; set; }
    }
}
