using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IMeonCloudService
    {
        [OperationContract]
        string login(string username, string password);

        [OperationContract]
        bool SendAlertNotification(string strgrouptag, string token, string strData);

        [OperationContract]
        bool SendImageNotification(string strgrouptag, string token, string strImageUrl);
        
        [OperationContract]
        bool SendVideoNotification(string strgrouptag, string token, string strVideoUrl);

        [OperationContract]
        string CreateGroup(string strgroup, string token);

        [OperationContract]
        string CreateTag(string strtag, string token);

        [OperationContract]
        bool AddCustomertoTag(string strcustomerid, string token, string tagid);

        [OperationContract]
        string UploadData(string type, string strPath);

        [OperationContract]
        string addcustomer(string name, string phonenumber, string countrycode, string countryalphacode, string token);

        [OperationContract]
        string addcustomerenterprise(string custid, string token);
        
    }
}
