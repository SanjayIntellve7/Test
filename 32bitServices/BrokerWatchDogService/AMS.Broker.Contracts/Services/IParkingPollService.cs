﻿using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IParkingPollService
    {
        [OperationContract]
        IEnumerable<tblHpcoeParkingDTO> GetHpcoeParkingCollection(string authToken); //amit 08012018
    }
}
