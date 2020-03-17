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
    public interface IBrokerLicense   
    {
        [OperationContract]
        void CheckLicenseValidity();

        [OperationContract]
        List<string> GetLicData();

        [OperationContract]
        string CheckClient(MachineDetailsDto _machineDetailsDto);

        [OperationContract]
        int IsActivated(string clientName, string macAddress);


    }
}
