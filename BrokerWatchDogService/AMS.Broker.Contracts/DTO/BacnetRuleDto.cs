using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public partial class BacnetRuleDto
    {
        public string FromState { get; set; }

        public string ToState { get; set; }

        public string NotiFyType { get; set; }

        public string NPresentValue { get; set; }

        public string EventType { get; set; }

        public string NEventStateValue { get; set; }
    }
}
