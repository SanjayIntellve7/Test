using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class ImportInterfaceInsertStatus
    {
        public List<ErrorStatus> ErrorStatusList { get; set; }
        public List<SuccessStatus> SuccessStatusList { get; set; }
    }

    public class ErrorStatus
    {
        public string ErrorInterfaceName { get; set; }
        public string ErrorInterfaceType { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class SuccessStatus
    {
        public string SuccessInterfaceName { get; set; }
        public string SuccessInterfaceType { get; set; }
        public string SuccessMessage { get; set; }
    }
}
