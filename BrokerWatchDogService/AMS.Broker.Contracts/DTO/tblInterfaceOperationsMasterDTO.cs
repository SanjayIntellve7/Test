using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblInterfaceOperationsMasterDTO
    {

        [DataMember()]
        public int ID { get; set; }

        [DataMember()]
        public string ActionName { get; set; }

        [DataMember()]
        public bool IsEnabled { get; set; }

        [DataMember()]
        public bool? IsChecked { get; set; }
    }
}
