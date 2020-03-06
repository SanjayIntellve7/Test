﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.WatchDogServiceTests.AccountWcfService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountWcfService.IAccountsService")]
    public interface IAccountsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetAccounts", ReplyAction="http://tempuri.org/IAccountsService/GetAccountsResponse")]
        AMS.Broker.Contracts.DTO.AccountDto[] GetAccounts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetAccounts", ReplyAction="http://tempuri.org/IAccountsService/GetAccountsResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AccountDto[]> GetAccountsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetAccountsByStatus", ReplyAction="http://tempuri.org/IAccountsService/GetAccountsByStatusResponse")]
        AMS.Broker.Contracts.DTO.AccountDto[] GetAccountsByStatus(int deletionStateCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetAccountsByStatus", ReplyAction="http://tempuri.org/IAccountsService/GetAccountsByStatusResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AccountDto[]> GetAccountsByStatusAsync(int deletionStateCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/AddAccount", ReplyAction="http://tempuri.org/IAccountsService/AddAccountResponse")]
        int AddAccount(AMS.Broker.Contracts.DTO.AccountDto account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/AddAccount", ReplyAction="http://tempuri.org/IAccountsService/AddAccountResponse")]
        System.Threading.Tasks.Task<int> AddAccountAsync(AMS.Broker.Contracts.DTO.AccountDto account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetAccount", ReplyAction="http://tempuri.org/IAccountsService/GetAccountResponse")]
        AMS.Broker.Contracts.DTO.AccountDto GetAccount(int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetAccount", ReplyAction="http://tempuri.org/IAccountsService/GetAccountResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AccountDto> GetAccountAsync(int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/UpdateAccount", ReplyAction="http://tempuri.org/IAccountsService/UpdateAccountResponse")]
        bool UpdateAccount(AMS.Broker.Contracts.DTO.AccountDto account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/UpdateAccount", ReplyAction="http://tempuri.org/IAccountsService/UpdateAccountResponse")]
        System.Threading.Tasks.Task<bool> UpdateAccountAsync(AMS.Broker.Contracts.DTO.AccountDto account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/DeleteAccount", ReplyAction="http://tempuri.org/IAccountsService/DeleteAccountResponse")]
        bool DeleteAccount(int account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/DeleteAccount", ReplyAction="http://tempuri.org/IAccountsService/DeleteAccountResponse")]
        System.Threading.Tasks.Task<bool> DeleteAccountAsync(int account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetContactsByAccount", ReplyAction="http://tempuri.org/IAccountsService/GetContactsByAccountResponse")]
        AMS.Broker.Contracts.DTO.PersonDto[] GetContactsByAccount(int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetContactsByAccount", ReplyAction="http://tempuri.org/IAccountsService/GetContactsByAccountResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto[]> GetContactsByAccountAsync(int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/AddContact", ReplyAction="http://tempuri.org/IAccountsService/AddContactResponse")]
        AMS.Broker.Contracts.DTO.PersonDto AddContact(AMS.Broker.Contracts.DTO.PersonDto personDto, AMS.Broker.Contracts.DTO.AddressDto[] addressDtos, AMS.Broker.Contracts.DTO.ContactDto[] contactDtos, int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/AddContact", ReplyAction="http://tempuri.org/IAccountsService/AddContactResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto> AddContactAsync(AMS.Broker.Contracts.DTO.PersonDto personDto, AMS.Broker.Contracts.DTO.AddressDto[] addressDtos, AMS.Broker.Contracts.DTO.ContactDto[] contactDtos, int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/UpdateContact", ReplyAction="http://tempuri.org/IAccountsService/UpdateContactResponse")]
        AMS.Broker.Contracts.DTO.PersonDto UpdateContact(AMS.Broker.Contracts.DTO.PersonDto personDto, int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/UpdateContact", ReplyAction="http://tempuri.org/IAccountsService/UpdateContactResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto> UpdateContactAsync(AMS.Broker.Contracts.DTO.PersonDto personDto, int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/DeleteContact", ReplyAction="http://tempuri.org/IAccountsService/DeleteContactResponse")]
        bool DeleteContact(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/DeleteContact", ReplyAction="http://tempuri.org/IAccountsService/DeleteContactResponse")]
        System.Threading.Tasks.Task<bool> DeleteContactAsync(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetContact", ReplyAction="http://tempuri.org/IAccountsService/GetContactResponse")]
        AMS.Broker.Contracts.DTO.PersonDto GetContact(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetContact", ReplyAction="http://tempuri.org/IAccountsService/GetContactResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto> GetContactAsync(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/AddLocation", ReplyAction="http://tempuri.org/IAccountsService/AddLocationResponse")]
        AMS.Broker.Contracts.DTO.AddressDto AddLocation(AMS.Broker.Contracts.DTO.AddressDto address, int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/AddLocation", ReplyAction="http://tempuri.org/IAccountsService/AddLocationResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto> AddLocationAsync(AMS.Broker.Contracts.DTO.AddressDto address, int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/UpdateLocation", ReplyAction="http://tempuri.org/IAccountsService/UpdateLocationResponse")]
        AMS.Broker.Contracts.DTO.AddressDto UpdateLocation(AMS.Broker.Contracts.DTO.AddressDto address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/UpdateLocation", ReplyAction="http://tempuri.org/IAccountsService/UpdateLocationResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto> UpdateLocationAsync(AMS.Broker.Contracts.DTO.AddressDto address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/DeleteLocation", ReplyAction="http://tempuri.org/IAccountsService/DeleteLocationResponse")]
        bool DeleteLocation(int addressId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/DeleteLocation", ReplyAction="http://tempuri.org/IAccountsService/DeleteLocationResponse")]
        System.Threading.Tasks.Task<bool> DeleteLocationAsync(int addressId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetLocationById", ReplyAction="http://tempuri.org/IAccountsService/GetLocationByIdResponse")]
        AMS.Broker.Contracts.DTO.AddressDto GetLocationById(int addressId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetLocationById", ReplyAction="http://tempuri.org/IAccountsService/GetLocationByIdResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto> GetLocationByIdAsync(int addressId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetLocationsByAccountId", ReplyAction="http://tempuri.org/IAccountsService/GetLocationsByAccountIdResponse")]
        AMS.Broker.Contracts.DTO.AddressDto[] GetLocationsByAccountId(int accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountsService/GetLocationsByAccountId", ReplyAction="http://tempuri.org/IAccountsService/GetLocationsByAccountIdResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto[]> GetLocationsByAccountIdAsync(int accountId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountsServiceChannel : AMS.Broker.WatchDogServiceTests.AccountWcfService.IAccountsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountsServiceClient : System.ServiceModel.ClientBase<AMS.Broker.WatchDogServiceTests.AccountWcfService.IAccountsService>, AMS.Broker.WatchDogServiceTests.AccountWcfService.IAccountsService {
        
        public AccountsServiceClient() {
        }
        
        public AccountsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AMS.Broker.Contracts.DTO.AccountDto[] GetAccounts() {
            return base.Channel.GetAccounts();
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AccountDto[]> GetAccountsAsync() {
            return base.Channel.GetAccountsAsync();
        }
        
        public AMS.Broker.Contracts.DTO.AccountDto[] GetAccountsByStatus(int deletionStateCode) {
            return base.Channel.GetAccountsByStatus(deletionStateCode);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AccountDto[]> GetAccountsByStatusAsync(int deletionStateCode) {
            return base.Channel.GetAccountsByStatusAsync(deletionStateCode);
        }
        
        public int AddAccount(AMS.Broker.Contracts.DTO.AccountDto account) {
            return base.Channel.AddAccount(account);
        }
        
        public System.Threading.Tasks.Task<int> AddAccountAsync(AMS.Broker.Contracts.DTO.AccountDto account) {
            return base.Channel.AddAccountAsync(account);
        }
        
        public AMS.Broker.Contracts.DTO.AccountDto GetAccount(int accountId) {
            return base.Channel.GetAccount(accountId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AccountDto> GetAccountAsync(int accountId) {
            return base.Channel.GetAccountAsync(accountId);
        }
        
        public bool UpdateAccount(AMS.Broker.Contracts.DTO.AccountDto account) {
            return base.Channel.UpdateAccount(account);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAccountAsync(AMS.Broker.Contracts.DTO.AccountDto account) {
            return base.Channel.UpdateAccountAsync(account);
        }
        
        public bool DeleteAccount(int account) {
            return base.Channel.DeleteAccount(account);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAccountAsync(int account) {
            return base.Channel.DeleteAccountAsync(account);
        }
        
        public AMS.Broker.Contracts.DTO.PersonDto[] GetContactsByAccount(int accountId) {
            return base.Channel.GetContactsByAccount(accountId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto[]> GetContactsByAccountAsync(int accountId) {
            return base.Channel.GetContactsByAccountAsync(accountId);
        }
        
        public AMS.Broker.Contracts.DTO.PersonDto AddContact(AMS.Broker.Contracts.DTO.PersonDto personDto, AMS.Broker.Contracts.DTO.AddressDto[] addressDtos, AMS.Broker.Contracts.DTO.ContactDto[] contactDtos, int accountId) {
            return base.Channel.AddContact(personDto, addressDtos, contactDtos, accountId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto> AddContactAsync(AMS.Broker.Contracts.DTO.PersonDto personDto, AMS.Broker.Contracts.DTO.AddressDto[] addressDtos, AMS.Broker.Contracts.DTO.ContactDto[] contactDtos, int accountId) {
            return base.Channel.AddContactAsync(personDto, addressDtos, contactDtos, accountId);
        }
        
        public AMS.Broker.Contracts.DTO.PersonDto UpdateContact(AMS.Broker.Contracts.DTO.PersonDto personDto, int accountId) {
            return base.Channel.UpdateContact(personDto, accountId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto> UpdateContactAsync(AMS.Broker.Contracts.DTO.PersonDto personDto, int accountId) {
            return base.Channel.UpdateContactAsync(personDto, accountId);
        }
        
        public bool DeleteContact(int personId) {
            return base.Channel.DeleteContact(personId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteContactAsync(int personId) {
            return base.Channel.DeleteContactAsync(personId);
        }
        
        public AMS.Broker.Contracts.DTO.PersonDto GetContact(int personId) {
            return base.Channel.GetContact(personId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.PersonDto> GetContactAsync(int personId) {
            return base.Channel.GetContactAsync(personId);
        }
        
        public AMS.Broker.Contracts.DTO.AddressDto AddLocation(AMS.Broker.Contracts.DTO.AddressDto address, int accountId) {
            return base.Channel.AddLocation(address, accountId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto> AddLocationAsync(AMS.Broker.Contracts.DTO.AddressDto address, int accountId) {
            return base.Channel.AddLocationAsync(address, accountId);
        }
        
        public AMS.Broker.Contracts.DTO.AddressDto UpdateLocation(AMS.Broker.Contracts.DTO.AddressDto address) {
            return base.Channel.UpdateLocation(address);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto> UpdateLocationAsync(AMS.Broker.Contracts.DTO.AddressDto address) {
            return base.Channel.UpdateLocationAsync(address);
        }
        
        public bool DeleteLocation(int addressId) {
            return base.Channel.DeleteLocation(addressId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteLocationAsync(int addressId) {
            return base.Channel.DeleteLocationAsync(addressId);
        }
        
        public AMS.Broker.Contracts.DTO.AddressDto GetLocationById(int addressId) {
            return base.Channel.GetLocationById(addressId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto> GetLocationByIdAsync(int addressId) {
            return base.Channel.GetLocationByIdAsync(addressId);
        }
        
        public AMS.Broker.Contracts.DTO.AddressDto[] GetLocationsByAccountId(int accountId) {
            return base.Channel.GetLocationsByAccountId(accountId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.AddressDto[]> GetLocationsByAccountIdAsync(int accountId) {
            return base.Channel.GetLocationsByAccountIdAsync(accountId);
        }
    }
}
