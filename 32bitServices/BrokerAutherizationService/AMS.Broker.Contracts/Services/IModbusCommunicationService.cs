using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IModbusCommunicationService
    {
        [OperationContract(Name = "IntegrateModbus")]
        string IntegrateModbus(string Username, string Passward);

        [OperationContract(Name = "GetModbusDevice")]
        IList<DeviceDto> GetModbusDevice(string Username, string Passward);

        [OperationContract(Name = "StartModbusDevicePoll")]
        void StartModbusDevicePoll();
    }
}
