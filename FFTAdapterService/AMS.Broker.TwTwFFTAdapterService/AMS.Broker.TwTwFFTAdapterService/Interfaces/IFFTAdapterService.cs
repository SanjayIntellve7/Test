using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.TwTwFFTAdapterService.Interfaces
{
    [ServiceContract]
    public interface IFFTAdapterService
    {
        [OperationContract]
        string Test();
        [OperationContract]
        List<SdkCtrlDataDto> GetController();

        [OperationContract]
        List<SdkSensorDataDto> GetFFTSensor();

        [OperationContract]
        List<SdkZoneDataDTO> GetFFTZones();
    }
}
