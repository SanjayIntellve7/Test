﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IMatrixControllerTransactionService
    {
        [OperationContract]
        void ConsumeMatrixAlert(string MatrixId);
    }
}
