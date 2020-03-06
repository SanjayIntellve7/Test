using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    public enum MessageType
    {
        Ack,
        Alert,
        Cancel,
        Error,
        Update
    }
}
