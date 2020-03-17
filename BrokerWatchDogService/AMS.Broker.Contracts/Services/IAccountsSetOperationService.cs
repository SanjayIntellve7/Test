using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;


namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IAccountsSetOperationService
    {
        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        int AddAccount(AccountDto account, string authToken);

        [OperationContract]
        bool UpdateAccount(AccountDto account, string authToken);

        [OperationContract]
        bool DeleteAccount(int account, string authToken);

        [OperationContract]
        PersonDto AddContact(PersonDto personDto, IList<AddressDto> addressDtos, IList<ContactDto> contactDtos,
                             int accountId, string authToken);

        [OperationContract]
        PersonDto UpdateContact(PersonDto personDto, int accountId, string authToken);

        [OperationContract]
        bool DeleteContact(int contactId, string authToken);

        [OperationContract]
        AddressDto AddLocation(AddressDto address, int accountId, string authToken);

        [OperationContract]
        AddressDto UpdateLocation(AddressDto address, string authToken);

        [OperationContract]
        bool DeleteLocation(int addressId, string authToken);

        [OperationContract]
        PersonDto SaveAccountPerson(PersonDto personDto, int accountId, string authToken);

        [OperationContract]
        void DeletePerson(int personId, string authToken);

        [OperationContract]
        ContactDto SaveAccountContact(ContactDto contactDto, int personId, string authToken);

        [OperationContract]
        AddressDto SaveAccountAddress(AddressDto addressDto, int accountId, string authToken);

        [OperationContract]
        AccountBillingDto SaveAccountBilling(AccountBillingDto accountBillingDto, int accountId, string authToken);

        [OperationContract]
        AccountDto SaveAccountNvrAlertType(IList<AccountNvrAlertTypeDto> accountNvrAlertTypes, int accountId, string authToken);

        [OperationContract]
        AccountDto SaveAccountAlarmPanel(IList<AccountAlarmPanelDto> accountAlarmPanels, int accountId, string authToken);

        [OperationContract]
        AccountDto SaveAccountAnalyticsAlgorithms(List<AccountAnalyticsAlgorithmTypeDto> accountAnalyticsAlgorithmTypeDtos, int accountId, string authToken);


    }
}
