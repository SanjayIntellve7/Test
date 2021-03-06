﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IWcfACSIntegrationService
    {  
        [OperationContract(Name = "DoorOpen")]
        string DoorOpen(string strCmd, string CntrIp, string CntrPort);

        [OperationContract(Name = "DoorClose")]
        string DoorClose(string strCmd, string CntrIp, string CntrPort);
    }
}
