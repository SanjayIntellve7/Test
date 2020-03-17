using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IWATMInterfacePushTxnService
    {
        [OperationContract]
        string PushDispenserStatus(WatmDispenserStatusData WatmDispenserData);

        [OperationContract]
        string PushWatmStatus(WatmStatusData WatmStatusData);

        [OperationContract]
        string PushWatmCollection(WATMCollectionData WATMCollectionData);
    }
}
