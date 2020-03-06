using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IWcfIntegrationAdapterService
    {

        [OperationContract(Name = "ConsumeAlert")]
        long ConsumeAlert(string accountId, string deviceId, string errorCode, string latitude, string longitude, string dateTime, string LocationID, string PanicID);//RequestMessage request
        [OperationContract(Name = "ProcessAccount")]
        int ProcessAccount(string accountName, string accountnumber, string email, string addressName, string addressLine, string city, string state, string country, string postalCode,string latitude, string longitude, string title, string firstName, string lastName, string contactTelephone, string emailAddress, string mobileNumber); // String faxNumber, string location, string result);//RequestMessage request
       
        [OperationContract(Name = "UpdatePhoto")]
        int UpdatePhoto(byte[] bytArray,string accNo);
        [OperationContract(Name = "UpdateAlertResource")]
        int UpdateAlertResource(byte[] bytArray, string accNo);
        [OperationContract(Name = "AttachMetadata")]
        int AttachMetadata(string alertID, byte[] imgAudio, string IDType);
        [OperationContract(Name = "UpdateAlert")]
        int UpdateAlert(string alertID, string Lat, string Long, string LacationID);
        [OperationContract(Name = "AddMmemberToMembership")]
        int AddMmemberToMembership(string accountNumber, string name, string mobile, byte[] photo);
        [OperationContract(Name = "UpdateEmergencyContact")]
        int UpdateEmergencyContact(string accountNumber, string mobile);

        [OperationContract]
        string SaveImage(); //
        //trupti 27 Aug 15
        [OperationContract(Name = "ConsumeRSSAlert")]
        long ConsumeRSSAlert(string deviceLat, string deviceLong, string devID);//RequestMessage request
        
        [OperationContract(Name = "StartListen")]
        Boolean StartListen(string strIp);
        /*[DataContract]
        public class RequestMessage
        {
            [DataMember(IsRequired = true)]
            public string accountId { get; set; }

            [DataMember(IsRequired = true)]
            public string deviceId { get; set; }

            [DataMember(IsRequired = true)]
            public string errorCode { get; set; }

            [DataMember(IsRequired = true)]
            public string latitude { get; set; }

            [DataMember(IsRequired = true)]
            public string longitude { get; set; }

            [DataMember(IsRequired = true)]
            public string dateTime { get; set; }
        }*/
    }
}
