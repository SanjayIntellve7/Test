using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public class PreferredContactMethod
    {
        [DataMember]
        public int ContactMethodId
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }
    }
}
