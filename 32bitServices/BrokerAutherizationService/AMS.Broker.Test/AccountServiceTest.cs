using System.Collections.Generic;
using System.Linq;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.DataStore;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AMS.Broker.Test
{
    [TestFixture]
    public class AccountServiceTest : BaseTest
    {
        private static IAccountsService _accountService;
        private static ILookupService _lookupService;

        public AccountServiceTest()
        {
            _accountService = BrokerService.Container.Resolve<IAccountsService>();
            _lookupService = BrokerService.Container.Resolve<ILookupService>();
        }

        [Test]
        public void Can_Create_Delete_Account()
        {
            var servicePackages = _lookupService.GetServicePackages();
            var contactTypes = _lookupService.GetContactTypes().ToList();
            var contactMethods = _lookupService.GetContactMethods().ToList();
            var paymentMethods = _lookupService.GetPaymentMethods().ToList();
            var nvralertTypes = _lookupService.GetNvrAlertTypes().ToList();
            var eventGroups = _lookupService.GetEventGroups().ToList();
            var analyticAlgorithms = _lookupService.GetAnalyticAlgorithmTypes().ToList();


            //step 1 - create account
            var accountDto = new AccountDto
            {
                AccountNumber = "123456789",
                Name = "Test_Account",
                ServicePackageId = servicePackages.ToList().SingleOrDefault(sp => sp.Name == "Silver").ServicePackageId,
                WebSiteURL = "http://2020Imaging.com",
                Email = "2020imaging@mail.com",
                Description = "Test_Account_Description",
                TimeZoneId = _lookupService.GetTimeZones().First().TimeZoneId,
                AccountTypeId = _lookupService.GetAccountTypes().Single(at => at.AccoutTypeId == 2).AccoutTypeId,
                AccountBilling = null,
            };

            var accountId = _accountService.AddAccount(accountDto);

            Assert.IsTrue(accountId > 0);

            var getAccount = _accountService.GetAccount(accountId);
            Assert.IsNotNull(getAccount);

            // step 2 - create person
            var personDto = new PersonDto
                {
                    Title = "Msr.",
                    FirstName = "Victor",
                    LastName = "Lungu",
                    JobTitle = "WPF Developer",
                    Password = "qwe123",
                    PrimaryAccountAdministratorPassword = "qwe123",
                };

            var preferedContact1 = new PersonContactTypeDto {ContactTypeId = contactTypes[0].ContactTypeId};
            var preferedContact2 = new PersonContactTypeDto {ContactTypeId = contactTypes[1].ContactTypeId};

            personDto.PreferedContactTypes = new List<PersonContactTypeDto> {preferedContact1, preferedContact2};
            var savedPerson = _accountService.SaveAccountPerson(personDto, getAccount.AccountId);

            Assert.IsNotNull(savedPerson);

            // step 3 - create contact
            var contactDto = new ContactDto
                {
                    TelephoneNumber = "37379604494",
                    EmailAddress = "dezvoltator@gmail.com",
                    MobileNumber = "37379604494",
                    LyncName = "Lync Name",
                    FaxNumber = "37379604494",
                };

            var preferedContatMethod1 = new PreferedContatMethodDto
                {
                    ContactMethodId = contactMethods[0].ContactMethodId
                };

            var preferedContatMethod2 = new PreferedContatMethodDto
            {
                ContactMethodId = contactMethods[1].ContactMethodId
            };

            contactDto.PreferedContatMethods.Add(preferedContatMethod1);
            contactDto.PreferedContatMethods.Add(preferedContatMethod2);

            var savedContact = _accountService.SaveAccountContact(contactDto, savedPerson.PersonId);
            Assert.IsNotNull(savedContact);

            //step 4 - create accounnt address
            var addressDto = new AddressDto
                {
                    AddressNumber = 3343,
                    AddressTypeCode = 22,
                    City = "Chisinau",
                    Country = "Moldova, Republic of",
                    County = "municipiiul Chisinau",
                    Fax = "37379604494",
                    Latitude = 100.22233,
                    Line1 = "str. Iazului 6",
                    Line2 = "ap. 53",
                    Longitude = 444332,
                    Name = "Main Address",
                    PostOfficeBox = "443332",
                    PostalCode = "PC5543"
                };

            var accountAddress = _accountService.SaveAccountAddress(addressDto, accountId);
            Assert.IsNotNull(accountAddress);

            //step 5 Billing address
            var billingAddress = new AddressDto
            {
                AddressNumber = 3343,
                AddressTypeCode = 22,
                City = "Chisinau",
                Country = "Moldova, Republic of",
                County = "municipiiul Chisinau",
                Fax = "37379604494",
                Latitude = 100.22233,
                Line1 = "str. Iazului 6",
                Line2 = "ap. 53",
                Longitude = 444332,
                Name = "Main Address",
                PostOfficeBox = "443332",
                PostalCode = "PC5543"
            };

            var accountBilling = new AccountBillingDto
                {
                    PaymentMethodId = paymentMethods.First().PaymentMethodId,
                    Address = billingAddress
                };

            var accountBillig = _accountService.SaveAccountBilling(accountBilling, accountId);
            Assert.IsNotNull(accountBillig);

            var accountNvrAlertTypeDto1 = new AccountNvrAlertTypeDto
                {
                    NvrAlertTypeId = nvralertTypes.First().NvrAlertTypeId
                };
            var accountNvrAlertTypeDto2 = new AccountNvrAlertTypeDto
            {
                NvrAlertTypeId = nvralertTypes.Last().NvrAlertTypeId
            };

            _accountService.SaveAccountNvrAlertType(
                new List<AccountNvrAlertTypeDto>() {accountNvrAlertTypeDto1, accountNvrAlertTypeDto2}, accountId);

            var accountAlarmPanel1 = new AccountAlarmPanelDto()
                {
                    EventGroupId = eventGroups.First().EventGroupId
                };
            var accountAlarmPanel2 = new AccountAlarmPanelDto()
                {
                    EventGroupId = eventGroups.Last().EventGroupId
                };

            _accountService.SaveAccountAlarmPanel(
                new List<AccountAlarmPanelDto>() { accountAlarmPanel1, accountAlarmPanel2 }, accountId);

            var analyticAlgorithm1 = new AccountAnalyticsAlgorithmTypeDto()
            {
                AnalyticsAlgorithTypeId = analyticAlgorithms.First().AnalyticAlgorithmId
            };
            var analyticAlgorithm2 = new AccountAnalyticsAlgorithmTypeDto()
            {
                AnalyticsAlgorithTypeId = analyticAlgorithms.Last().AnalyticAlgorithmId
            };

            _accountService.SaveAccountAnalyticsAlgorithms(
                new List<AccountAnalyticsAlgorithmTypeDto>() { analyticAlgorithm1, analyticAlgorithm2 }, accountId);

            var deleteContact = _accountService.DeleteContact(savedContact.ContactId);
            Assert.IsTrue(deleteContact);

            _accountService.DeletePerson(savedPerson.PersonId);
            var accountDeleted = _accountService.DeleteAccount(getAccount.AccountId);

            Assert.IsTrue(accountDeleted);
        }

        [Test]
        public void Can_Update_Account()
        {
            var servicePackages = _lookupService.GetServicePackages();
            var contactTypes = _lookupService.GetContactTypes().ToList();
            var contactMethods = _lookupService.GetContactMethods().ToList();
            var paymentMethods = _lookupService.GetPaymentMethods().ToList();
            var nvralertTypes = _lookupService.GetNvrAlertTypes().ToList();
            var eventGroups = _lookupService.GetEventGroups().ToList();
            var analyticAlgorithms = _lookupService.GetAnalyticAlgorithmTypes().ToList();

            var account = CreateAccount();

            if (account != null)
            {
                account.AccountNumber = "123456789_Updated";
                account.Name = "Test_Account_Updated";
                var servicePackageDto = servicePackages.ToList().SingleOrDefault(sp => sp.Name == "Bronze");
                if (servicePackageDto != null)
                    account.ServicePackageId =
                        servicePackageDto.ServicePackageId;
                account.WebSiteURL = "http://2020Imaging.com_Updated";
                account.Email = "2020imaging@mail.com_Updated";
                account.Description = "Test_Account_Description_Updated";
                account.TimeZoneId = _lookupService.GetTimeZones().Skip(1).First().TimeZoneId;
                account.AccountTypeId = _lookupService.GetAccountTypes().Single(at => at.AccoutTypeId == 1).AccoutTypeId;
                account.AccountBilling = null;

                bool accountUpdated = _accountService.UpdateAccount(account);

                Assert.IsTrue(accountUpdated);

                var updatedAccount = _accountService.GetAccount(account.AccountId);

                Assert.IsNotNull(updatedAccount);
                Assert.IsTrue(account.AccountNumber == updatedAccount.AccountNumber);
                Assert.IsTrue(account.Name == updatedAccount.Name);
                Assert.IsTrue(account.ServicePackageId == updatedAccount.ServicePackageId);
                Assert.IsTrue(account.WebSiteURL == updatedAccount.WebSiteURL);
                Assert.IsTrue(account.Email == updatedAccount.Email);
                Assert.IsTrue(account.Description == updatedAccount.Description);
                Assert.IsTrue(account.TimeZoneId == updatedAccount.TimeZoneId);
                Assert.IsTrue(account.AccountTypeId == updatedAccount.AccountTypeId);

                #region Primary Account Administrator

                if (updatedAccount.PrimaryAccountAdministrator != null)
                {
                    var primaryContact = updatedAccount.PrimaryAccountAdministrator;

                    primaryContact.Title = "Msr._Updated";
                    primaryContact.FirstName = "Victor_Updated";
                    primaryContact.LastName = "Lungu_Updated";
                    primaryContact.JobTitle = "WPF Developer_Updated";
                    primaryContact.Password = "qwe123_Updated";
                    primaryContact.PrimaryAccountAdministratorPassword = "qwe123_Updated";

                    var savedPerson = _accountService.SaveAccountPerson(primaryContact, updatedAccount.AccountId);

                    Assert.IsTrue(primaryContact.Title == savedPerson.Title);
                    Assert.IsTrue(primaryContact.FirstName == savedPerson.FirstName);
                    Assert.IsTrue(primaryContact.LastName == savedPerson.LastName);
                    Assert.IsTrue(primaryContact.JobTitle == savedPerson.JobTitle);
                    Assert.IsTrue(primaryContact.Password == savedPerson.Password);
                    Assert.IsTrue(primaryContact.PrimaryAccountAdministratorPassword == savedPerson.PrimaryAccountAdministratorPassword);
                    Assert.IsTrue(savedPerson.PreferedContactTypes.Count == 2);

                    var preferedContact1 = new PersonContactTypeDto { ContactTypeId = contactTypes[0].ContactTypeId };
                    var preferedContact3 = new PersonContactTypeDto { ContactTypeId = contactTypes[2].ContactTypeId };

                    savedPerson.PreferedContactTypes = new List<PersonContactTypeDto> { preferedContact1, preferedContact3 };

                    var savedPerson1 = _accountService.SaveAccountPerson(savedPerson, updatedAccount.AccountId);

                    Assert.IsTrue(savedPerson1.PreferedContactTypes.Count == 2);
                }

                #endregion

                #region Primary Contact Administrator

                if (updatedAccount.PrimaryAccountAdministrator != null &&
                    updatedAccount.PrimaryAccountAdministrator.PrimaryContact != null)
                {
                    var primaryContact = updatedAccount.PrimaryAccountAdministrator.PrimaryContact;

                    primaryContact.TelephoneNumber = "37379604494_Updated";
                    primaryContact.EmailAddress = "dezvoltator@gmail.com_Updated";
                    primaryContact.MobileNumber = "37379604494_Updated";
                    primaryContact.LyncName = "Lync Name_Updated";
                    primaryContact.FaxNumber = "37379604494_Updated";

                    var savedPrimaryContact = _accountService.SaveAccountContact(primaryContact,
                                                                                 updatedAccount
                                                                                     .PrimaryAccountAdministrator
                                                                                     .PersonId);

                    Assert.IsTrue(savedPrimaryContact.TelephoneNumber == primaryContact.TelephoneNumber);
                    Assert.IsTrue(savedPrimaryContact.EmailAddress == primaryContact.EmailAddress);
                    Assert.IsTrue(savedPrimaryContact.MobileNumber == primaryContact.MobileNumber);
                    Assert.IsTrue(savedPrimaryContact.LyncName == primaryContact.LyncName);
                    Assert.IsTrue(savedPrimaryContact.FaxNumber == primaryContact.FaxNumber);
                    Assert.IsTrue(savedPrimaryContact.PreferedContatMethods.Count == 2);

                    var preferedContatMethod1 = new PreferedContatMethodDto
                    {
                        ContactMethodId = contactMethods[0].ContactMethodId
                    };

                    var preferedContatMethod2 = new PreferedContatMethodDto
                    {
                        ContactMethodId = contactMethods[2].ContactMethodId
                    };

                    savedPrimaryContact.PreferedContatMethods.Clear();

                    savedPrimaryContact.PreferedContatMethods.Add(preferedContatMethod1);
                    savedPrimaryContact.PreferedContatMethods.Add(preferedContatMethod2);

                    var savedPrimaryContact1 = _accountService.SaveAccountContact(savedPrimaryContact,
                                                                                 updatedAccount
                                                                                     .PrimaryAccountAdministrator
                                                                                     .PersonId);

                    Assert.IsTrue(savedPrimaryContact1.PreferedContatMethods.Count == 2);
                }

                #endregion

                #region Account Address

                if (account.Address != null && account.Address.Any())
                {
                    var address = account.Address[0];

                    address.AddressNumber = 3344;
                    address.AddressTypeCode = 23;
                    address.City = "Chisinau_Updated";
                    address.Country = "Moldova, Republic of_Updated";
                    address.County = "municipiiul Chisinau_Updated";
                    address.Fax = "37379604494_Updated";
                    address.Latitude = 101.22233;
                    address.Line1 = "str. Iazului 6_Updated";
                    address.Line2 = "ap. 53_Updated";
                    address.Longitude = 444333;
                    address.Name = "Main Address_Updated";
                    address.PostOfficeBox = "443332_Updated";
                    address.PostalCode = "PC5543_Updated";

                    var updatedAddress = _accountService.SaveAccountAddress(address, updatedAccount.AccountId);

                    Assert.IsTrue(address.AddressNumber == updatedAddress.AddressNumber);
                    Assert.IsTrue(address.AddressTypeCode == updatedAddress.AddressTypeCode);
                    Assert.IsTrue(address.City == updatedAddress.City);
                    Assert.IsTrue(address.Country == updatedAddress.Country);
                    Assert.IsTrue(address.County == updatedAddress.County);
                    Assert.IsTrue(address.Fax == updatedAddress.Fax);
                    Assert.IsTrue(address.Latitude == updatedAddress.Latitude);
                    Assert.IsTrue(address.Line1 == updatedAddress.Line1);
                    Assert.IsTrue(address.Line2 == updatedAddress.Line2);
                    Assert.IsTrue(address.Longitude == updatedAddress.Longitude);
                    Assert.IsTrue(address.Name == updatedAddress.Name);
                    Assert.IsTrue(address.PostOfficeBox == updatedAddress.PostOfficeBox);
                    Assert.IsTrue(address.PostalCode == updatedAddress.PostalCode);
                }

                #endregion

                #region Account Billing

                if (updatedAccount.AccountBilling != null)
                {
                    var accountBilling = updatedAccount.AccountBilling;
                    accountBilling.PaymentMethodId = paymentMethods.Skip(1).First().PaymentMethodId;
                    accountBilling.Address.AddressNumber = 3344;
                    accountBilling.Address.AddressTypeCode = 23;
                    accountBilling.Address.City = "Chisinau_Updated";
                    accountBilling.Address.Country = "Moldova, Republic of_Updated";
                    accountBilling.Address.County = "municipiiul Chisinau_Updated";
                    accountBilling.Address.Fax = "37379604494_Updated";
                    accountBilling.Address.Latitude = 101.22233;
                    accountBilling.Address.Line1 = "str. Iazului 6_Updated";
                    accountBilling.Address.Line2 = "ap. 53_Updated";
                    accountBilling.Address.Longitude = 444333;
                    accountBilling.Address.Name = "Main Address_Updated";
                    accountBilling.Address.PostOfficeBox = "443332_Updated";
                    accountBilling.Address.PostalCode = "PC5543_Updated";

                    var savedAccountBilling = _accountService.SaveAccountBilling(accountBilling,
                                                                                 updatedAccount.AccountId);

                    Assert.IsTrue(accountBilling.PaymentMethodId == savedAccountBilling.PaymentMethodId);
                }

                #endregion

                #region Account Nvr Alert Types

                var accountNvrAlertTypeDto1 = new AccountNvrAlertTypeDto
                {
                    NvrAlertTypeId = nvralertTypes.First().NvrAlertTypeId
                };
                var accountNvrAlertTypeDto2 = new AccountNvrAlertTypeDto
                {
                    NvrAlertTypeId = nvralertTypes.Skip(1).First().NvrAlertTypeId
                };

                _accountService.SaveAccountNvrAlertType(
                    new List<AccountNvrAlertTypeDto>() { accountNvrAlertTypeDto1, accountNvrAlertTypeDto2 }, updatedAccount.AccountId);

                #endregion

                #region Account Alarm Panel

                var accountAlarmPanel1 = new AccountAlarmPanelDto
                {
                    EventGroupId = eventGroups.First().EventGroupId
                };
                var accountAlarmPanel2 = new AccountAlarmPanelDto
                {
                    EventGroupId = eventGroups.Skip(1).First().EventGroupId
                };

                _accountService.SaveAccountAlarmPanel(
                    new List<AccountAlarmPanelDto>() { accountAlarmPanel1, accountAlarmPanel2 }, updatedAccount.AccountId);

                #endregion

                #region Account Analytics Algorithm Type

                var accountAnalyticsAlgorithmType1 = new AccountAnalyticsAlgorithmTypeDto
                {
                    AnalyticsAlgorithTypeId = analyticAlgorithms.First().AnalyticAlgorithmId
                };
                var accountAnalyticsAlgorithmType2 = new AccountAnalyticsAlgorithmTypeDto
                {
                    AnalyticsAlgorithTypeId = analyticAlgorithms.Skip(1).First().AnalyticAlgorithmId
                };

                _accountService.SaveAccountAnalyticsAlgorithms(
                    new List<AccountAnalyticsAlgorithmTypeDto>() { accountAnalyticsAlgorithmType1, accountAnalyticsAlgorithmType2 }, updatedAccount.AccountId);

                #endregion

                if (updatedAccount.PrimaryAccountAdministrator != null)
                {
                    if (updatedAccount.PrimaryAccountAdministrator.PrimaryContact != null)
                        _accountService.DeleteContact(updatedAccount.PrimaryAccountAdministrator.PrimaryContact.ContactId);

                    if (updatedAccount.PrimaryAccountAdministrator != null)
                        _accountService.DeletePerson(updatedAccount.PrimaryAccountAdministrator.PersonId);
                }

                _accountService.DeleteAccount(updatedAccount.AccountId);
            }
        }

        private AccountDto CreateAccount()
        {
            var servicePackages = _lookupService.GetServicePackages();
            var contactTypes = _lookupService.GetContactTypes().ToList();
            var contactMethods = _lookupService.GetContactMethods().ToList();
            var paymentMethods = _lookupService.GetPaymentMethods().ToList();
            var nvralertTypes = _lookupService.GetNvrAlertTypes().ToList();
            var eventGroups = _lookupService.GetEventGroups().ToList();
            var analyticAlgorithms = _lookupService.GetAnalyticAlgorithmTypes().ToList();

            //step 1 - create account
            var servicePackageDto = servicePackages.ToList().SingleOrDefault(sp => sp.Name == "Silver");
            if (servicePackageDto != null)
            {
                var accountDto = new AccountDto
                    {
                        AccountNumber = "123456789",
                        Name = "Test_Account",
                        ServicePackageId = servicePackageDto.ServicePackageId,
                        WebSiteURL = "http://2020Imaging.com",
                        Email = "2020imaging@mail.com",
                        Description = "Test_Account_Description",
                        TimeZoneId = _lookupService.GetTimeZones().First().TimeZoneId,
                        AccountTypeId = _lookupService.GetAccountTypes().Single(at => at.AccoutTypeId == 2).AccoutTypeId,
                        AccountBilling = null,
                    };

                var accountId = _accountService.AddAccount(accountDto);

                var getAccount = _accountService.GetAccount(accountId);
                Assert.IsNotNull(getAccount);

                // step 2 - create person
                var personDto = new PersonDto
                {
                    Title = "Msr.",
                    FirstName = "Victor",
                    LastName = "Lungu",
                    JobTitle = "WPF Developer",
                    Password = "qwe123",
                    PrimaryAccountAdministratorPassword = "qwe123",
                };

                var preferedContact1 = new PersonContactTypeDto { ContactTypeId = contactTypes[0].ContactTypeId };
                var preferedContact2 = new PersonContactTypeDto { ContactTypeId = contactTypes[1].ContactTypeId };

                personDto.PreferedContactTypes = new List<PersonContactTypeDto> { preferedContact1, preferedContact2 };
                var savedPerson = _accountService.SaveAccountPerson(personDto, getAccount.AccountId);

                // step 3 - create contact
                var contactDto = new ContactDto
                {
                    TelephoneNumber = "37379604494",
                    EmailAddress = "dezvoltator@gmail.com",
                    MobileNumber = "37379604494",
                    LyncName = "Lync Name",
                    FaxNumber = "37379604494",
                };

                var preferedContatMethod1 = new PreferedContatMethodDto
                {
                    ContactMethodId = contactMethods[0].ContactMethodId
                };

                var preferedContatMethod2 = new PreferedContatMethodDto
                {
                    ContactMethodId = contactMethods[1].ContactMethodId
                };

                contactDto.PreferedContatMethods.Add(preferedContatMethod1);
                contactDto.PreferedContatMethods.Add(preferedContatMethod2);

               _accountService.SaveAccountContact(contactDto, savedPerson.PersonId);

               //step 4 - create accounnt address
               var addressDto = new AddressDto
               {
                   AddressNumber = 3343,
                   AddressTypeCode = 22,
                   City = "Chisinau",
                   Country = "Moldova, Republic of",
                   County = "municipiiul Chisinau",
                   Fax = "37379604494",
                   Latitude = 100.22233,
                   Line1 = "str. Iazului 6",
                   Line2 = "ap. 53",
                   Longitude = 444332,
                   Name = "Main Address",
                   PostOfficeBox = "443332",
                   PostalCode = "PC5543"
               };

               _accountService.SaveAccountAddress(addressDto, accountId);

               //step 5 Billing address
               var billingAddress = new AddressDto
               {
                   AddressNumber = 3343,
                   AddressTypeCode = 22,
                   City = "Chisinau",
                   Country = "Moldova, Republic of",
                   County = "municipiiul Chisinau",
                   Fax = "37379604494",
                   Latitude = 100.22233,
                   Line1 = "str. Iazului 6",
                   Line2 = "ap. 53",
                   Longitude = 444332,
                   Name = "Main Address",
                   PostOfficeBox = "443332",
                   PostalCode = "PC5543"
               };

               var accountBilling = new AccountBillingDto
               {
                   PaymentMethodId = paymentMethods.First().PaymentMethodId,
                   Address = billingAddress
               };

               _accountService.SaveAccountBilling(accountBilling, accountId);

               var accountNvrAlertTypeDto1 = new AccountNvrAlertTypeDto
               {
                   NvrAlertTypeId = nvralertTypes.First().NvrAlertTypeId
               };
               var accountNvrAlertTypeDto2 = new AccountNvrAlertTypeDto
               {
                   NvrAlertTypeId = nvralertTypes.Last().NvrAlertTypeId
               };

               _accountService.SaveAccountNvrAlertType(
                   new List<AccountNvrAlertTypeDto>() { accountNvrAlertTypeDto1, accountNvrAlertTypeDto2 }, accountId);

               var accountAlarmPanel1 = new AccountAlarmPanelDto()
               {
                   EventGroupId = eventGroups.First().EventGroupId
               };
               var accountAlarmPanel2 = new AccountAlarmPanelDto()
               {
                   EventGroupId = eventGroups.Last().EventGroupId
               };

               _accountService.SaveAccountAlarmPanel(
                   new List<AccountAlarmPanelDto>() { accountAlarmPanel1, accountAlarmPanel2 }, accountId);

               var analyticAlgorithm1 = new AccountAnalyticsAlgorithmTypeDto()
               {
                   AnalyticsAlgorithTypeId = analyticAlgorithms.First().AnalyticAlgorithmId
               };
               var analyticAlgorithm2 = new AccountAnalyticsAlgorithmTypeDto()
               {
                   AnalyticsAlgorithTypeId = analyticAlgorithms.Last().AnalyticAlgorithmId
               };

               _accountService.SaveAccountAnalyticsAlgorithms(
                   new List<AccountAnalyticsAlgorithmTypeDto>() { analyticAlgorithm1, analyticAlgorithm2 }, accountId);

               return _accountService.GetAccount(accountId);
            }
            return null;
        }
    }
}
