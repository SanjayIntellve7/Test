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
    public interface IGeneralPurposeService
    {
        /* [OperationContract]
         IEnumerable<AssociatedPtzDeviceDto> GetAssociatedPTZDevice(string DeviceId);*/

        [OperationContract]
        IList<AssociatedPtzDeviceDto> GetAssociatedPTZDeviceCollection(string DeviceID);


        [OperationContract]
        void MovePTZDevicePreset(Alert alert);

    }
}