using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_CallingContacts_ResultDTO
    {
        [DataMember()]
        public String ContactName { get; set; }

        [DataMember()]
        public String ContactNo { get; set; }

        [DataMember()]
        public String ContactEmailID { get; set; }

        public SP_CallingContacts_ResultDTO()
        {
        }

        public SP_CallingContacts_ResultDTO(String contactName, String contactNo, String contactEmailID)
        {
            this.ContactName = contactName;
            this.ContactNo = contactNo;
            this.ContactEmailID = contactEmailID;
        }
    }
}
