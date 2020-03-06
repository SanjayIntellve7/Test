using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    public enum ResponseType
    {
        Assess,
        Evacuate,
        Execute,
        Monitor,
        None,
        Prepare,
        Shelter,
    }
}
