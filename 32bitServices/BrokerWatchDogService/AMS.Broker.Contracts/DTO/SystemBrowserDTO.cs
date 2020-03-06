using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public partial class SystemBrowserDTO
    {
        [DataMember()]
        public int Id { get; set; }

        [DataMember()]
        public string SystemName { get; set; }

        [DataMember()]
        public string Description { get; set; }

        [DataMember()]
        public string SystemURL { get; set; }

        [DataMember()]
        public int BrowserType { get; set; }
    }
}
