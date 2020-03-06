using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IAccountsService
    {
        [OperationContract]
        IList<AccountDto> GetAccounts(string username);

        [OperationContract]
        IList<AccountDto> GetAccountsWithShortDetails(string username);

        [OperationContract]
        IList<AccountDto> FilterAccounts(string filterText);

        [OperationContract]
        IList<AccountDto> GetAccountsByStatus(int deletionStateCode);

        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        int AddAccount(AccountDto account);

        [OperationContract]
        AccountDto GetAccount(int accountId);

        [OperationContract]
        bool UpdateAccount(AccountDto account);

        [OperationContract]
        bool DeleteAccount(int account);

        [OperationContract]
        List<PersonDto> GetContactsByAccount(int accountId);

        [OperationContract]
        PersonDto AddContact(PersonDto personDto, IList<AddressDto> addressDtos, IList<ContactDto> contactDtos,
                             int accountId);

        [OperationContract]
        PersonDto UpdateContact(PersonDto personDto, int accountId);

        [OperationContract]
        bool DeleteContact(int contactId);

        [OperationContract]
        PersonDto GetContact(int personId);

        [OperationContract]
        AddressDto AddLocation(AddressDto address, int accountId);

        [OperationContract]
        AddressDto UpdateLocation(AddressDto address);

        [OperationContract]
        bool DeleteLocation(int addressId);

        [OperationContract]
        AddressDto GetLocationById(int addressId);

        [OperationContract]
        IEnumerable<AddressDto> GetLocationsByAccountId(int accountId);

        [OperationContract]
        PersonDto SaveAccountPerson(PersonDto personDto, int accountId);

        [OperationContract]
        void DeletePerson(int personId);

        [OperationContract]
        ContactDto SaveAccountContact(ContactDto contactDto, int personId);

        [OperationContract]
        AddressDto SaveAccountAddress(AddressDto addressDto, int accountId);

        [OperationContract]
        AccountBillingDto SaveAccountBilling(AccountBillingDto accountBillingDto, int accountId);

        [OperationContract]
        AccountDto SaveAccountNvrAlertType(IList<AccountNvrAlertTypeDto> accountNvrAlertTypes, int accountId);

        [OperationContract]
        AccountDto SaveAccountAlarmPanel(IList<AccountAlarmPanelDto> accountAlarmPanels, int accountId);

        [OperationContract]
        AccountDto SaveAccountAnalyticsAlgorithms(List<AccountAnalyticsAlgorithmTypeDto> accountAnalyticsAlgorithmTypeDtos, int accountId);
    }
}
