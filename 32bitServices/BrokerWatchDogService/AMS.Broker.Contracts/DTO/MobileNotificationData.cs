using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public sealed class MobileNotificationData
    {
        public string DestStID { get; set; }
        public byte[] ImageData { get; set; }
        public string ResourceFlag { get; set; }
        public string Remarks { get; set; }
        public string DateTime { get; set; }
        public string Mobnumber { get; set; }
        public string authToken { get; set; }
        public string CamInterfaceType { get; set; }
    }
}
