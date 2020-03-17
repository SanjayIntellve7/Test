using System;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IResourceService
    {
        [OperationContract(Name = "AddResource")]
        ResourceData AddResource(ResourceData data);

        [OperationContract(Name = "GetResource")]
        ResourceData GetResource(ResourceData data);

        [OperationContract(Name = "RemoveResource")]
        bool RemoveResource(ResourceData data);
    }
}
