using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IBrokerLicense   // jatin 08112017
    {
        [OperationContract]
        void CheckLicenseValidity();

    }
}
