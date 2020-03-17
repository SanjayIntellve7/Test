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
    public interface ISmartCitySetOperationService
    {
        [OperationContract(Name = "SetMultiVMDTransaction")]
        //string SetMultiVMDTransaction(string AllSelectedDevId, string VmdMessage, Guid authToken, string deviceid,byte[] imagebyte); 
        string SetMultiVMDTransaction(VMDSetMessageDTO VMDSetMessageDTO);
        
    }
}
