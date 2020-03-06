using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
     [ServiceContract(Name = "WcfOutputAdapterService", Namespace = "http://www.logica.com/RealTimeDataManagement/Services")]
    interface ICameraPingService
    {
     //    bool getCameraStatus();
    }
}
