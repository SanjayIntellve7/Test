using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class MirasysAlertDto
    {
        public string AlertId { get; set; }

        public string ErrorCode { get; set; }

        public string Devicename { get; set; }

        public string Sitename { get; set; }

        public string AlertDateTime { get; set; }

    }
}