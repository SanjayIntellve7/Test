using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class AnalyticsAIAlertDto
    {
        public string IP { get; set; }
        public string ChannelNo { get; set; }
        public string DateTime { get; set; }
        public string ErrorCode { get; set; }
        public string Remarks { get; set; }
        public string Image { get; set; }
        public string ImageName { get; set; }
    }
}
