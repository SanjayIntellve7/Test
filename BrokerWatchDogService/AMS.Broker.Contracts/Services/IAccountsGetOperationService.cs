using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;


namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IAccountsGetOperationService
    {
        [OperationContract]
        IList<AccountDto> GetAccounts(string username, string authToken);

        [OperationContract]
        IList<AccountDto> GetAccountsWithShortDetails(string username, string authToken);

        [OperationContract]
        IList<AccountDto> FilterAccounts(string filterText, string authToken);

        [OperationContract]
        IList<AccountDto> GetAccountsByStatus(int deletionStateCode);
        

        [OperationContract]
        AccountDto GetAccount(int accountId, string authToken);

       

        [OperationContract]
        List<PersonDto> GetContactsByAccount(int accountId);

       
        [OperationContract]
        PersonDto GetContact(int personId, string authToken);

        
        [OperationContract]
        AddressDto GetLocationById(int addressId, string authToken);

        [OperationContract]
        IEnumerable<AddressDto> GetLocationsByAccountId(int accountId, string authToken);
        
    }
}
