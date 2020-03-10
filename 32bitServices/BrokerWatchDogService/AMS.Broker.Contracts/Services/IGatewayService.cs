﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    public enum BrokerStatus
    {
        Live
    };

    [ServiceContract]
    public interface IGatewayService
    {
        [OperationContract]
        BrokerStatus Ping();

        [OperationContract]
        bool ValidateCredentials(string username, string password);

        [OperationContract]
        bool ValidateUserName(string username);

     //  [OperationContract]
     //  bool PingClient();

        
    }
}