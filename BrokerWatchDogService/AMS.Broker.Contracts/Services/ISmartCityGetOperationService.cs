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
    public interface ISmartCityGetOperationService
    {
        [OperationContract]
        IEnumerable<tblPASPreDefinedVoiceMessageDTO> GetPASPrerecordedFilesList(string authtoken);

        [OperationContract]
        IEnumerable<tblVMDPreDefinedMessageDTO> GetVMDPreDefinedMessageList(string authtoken);

        [OperationContract]
        IEnumerable<tblVMDPreDefinedImageDTO> GetVMDPreDefinedImageList(string authtoken);

        [OperationContract]
        tblVMDPreDefinedImageDTO GetVMDPreDefinedImageData(string authtoken,int Id);

        [OperationContract]
        IEnumerable<tblEquipmentDetailsDto> GetVMDEquipmentDetails(string authToken);

        [OperationContract]
        IEnumerable<tblSmartlightTXNDTO> GetSmartlightTxnDetails(string authToken); //harsha120719 SmartLight

        [OperationContract]
        string GetVMDCurrentMessageDisplay(string eqpId);

        [OperationContract]
        List<tblAllDeviceStatusDTO> GetAllDeviceStatus(string authToken); //manish07112019 

       

    }
}
