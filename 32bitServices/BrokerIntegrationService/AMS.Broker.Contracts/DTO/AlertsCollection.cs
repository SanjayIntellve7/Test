using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(Alert)), Serializable]
    public class AlertsCollection
    {

        public AlertsCollection(IEnumerable<Alert> items)
        {
            this.Items = new List<Alert>(items);
        }

        [DataMember]
        public List<Alert> Items
        {
            get; set;            
        }
    }
}
