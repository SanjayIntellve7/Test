using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Broker.AutherizationService;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.AutherizationService.DataStore;
using AMS.Broker.AutherizationServiceTests.AccountWcfService;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using IAccountsService = AMS.Broker.Contracts.Services.IAccountsService;

namespace AMS.Broker.AutherizationServiceTests
{
    [TestClass]
    public class AccountServiceTest
    {
        static IAccountsService _accountServiceImpl;
        static ILookupService _lookupServiceImpl;

        #region Additional test attributes
        
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            AutoMapperConfiguration.CreateAllMaps();
            var service = new BrokerService();
            AutoMapperConfiguration.CreateAllMaps();
            _accountServiceImpl = BrokerService.Container.Resolve<IAccountsService>();
            _lookupServiceImpl = BrokerService.Container.Resolve<ILookupService>();
        }
        
        #endregion

        [TestMethod]
        public void CanGetAccountTypes()
        {
            var accountTypes = _lookupServiceImpl.GetAccountTypes().ToList();
            Assert.IsTrue(accountTypes.Count > 0);
        }

        [TestMethod]
        public void CanGetContactTypes()
        {
            var accountTypes = _lookupServiceImpl.GetContactTypes().ToList();
            Assert.IsTrue(accountTypes.Count > 0);
        }

        [TestMethod]
        public void CanGetServicePackages()
        {
            var servicePackages = _lookupServiceImpl.GetServicePackages().ToList();
            Assert.IsTrue(servicePackages.Count > 0);
        }

        [TestMethod]
        public void CanGetDeliveryMethods()
        {
            var deliveryMethods = _lookupServiceImpl.GetDeliveryMethods().ToList();
            Assert.IsTrue(deliveryMethods.Count > 0);
        }

        [TestMethod]
        public void CanCreateAccount()
        {
            var account = GetNewAccount();

            var accountId = _accountServiceImpl.AddAccount(account);

            Assert.IsTrue(accountId > 0);

            var addedAccount = _accountServiceImpl.GetAccount(accountId);

            Assert.IsNotNull(addedAccount);
            Assert.IsTrue(addedAccount.Name == account.Name);
            Assert.IsTrue(addedAccount.ServicePackageId == account.ServicePackageId);
            Assert.IsTrue(addedAccount.AccountTypeId == account.AccountTypeId);
            Assert.IsTrue(addedAccount.ParentAccountId == account.ParentAccountId);
            Assert.IsTrue(addedAccount.AccountNumber == account.AccountNumber);
            Assert.IsTrue(addedAccount.Description == account.Description);
            Assert.IsTrue(addedAccount.WebSiteURL == account.WebSiteURL);
            Assert.IsTrue(addedAccount.TimeZoneId == account.TimeZoneId);

            addedAccount.Name = "AccountTestNameUpdated";

            var updatedAccount = _accountServiceImpl.UpdateAccount(addedAccount);

            Assert.IsTrue(updatedAccount);

            var accountDeleted = _accountServiceImpl.DeleteAccount(addedAccount.AccountId);

            Assert.IsTrue(accountDeleted);
        }

        [TestMethod]
        public void CanAddContacnt()
        {
            /*const int accountId = 68;
            var person = GetPersonDto();
            var addresses = new List<AddressDto> {GetNewAddress()};
            var contact = new ContactDto {ContactTypeId = 1, Value = "dezvoltator@gmail.com1"};
            var contacts = new List<ContactDto> {contact};

            var wcf = new AccountsServiceClient();
            var personDto = wcf.AddContact(person, addresses.ToArray(), contacts.ToArray(), accountId);

            Assert.IsTrue(personDto.PersonId > 0);

            personDto.Contacts.Add(new ContactDto { ContactTypeId = 2, Value = "333-333-333" });

            wcf.UpdateContact(personDto, accountId);

            var deleteAccount = wcf.DeleteContact(personDto.PersonId);

            Assert.IsTrue(deleteAccount);

            var persons = wcf.GetContactsByAccount(accountId);

            foreach (var dto in persons)
            {
                var deleteAccount1 = wcf.DeleteContact(dto.PersonId);
                Assert.IsTrue(deleteAccount1);
            }*/
        }

        [TestMethod]
        public void CanGetPersonsByAccount()
        {
            var persons = _accountServiceImpl.GetContactsByAccount(68);

            Assert.IsTrue(persons.Any());
        }

        [TestMethod]
        public void CanAddEditRemoveLocation()
        {
            const int acountId = 68;
            var address = GetNewAddress();

            var wcfService = new AccountsServiceClient();

            var location = wcfService.AddLocation(address, acountId);

            location.PostalCode = "4444";
            Assert.IsTrue(location != null);

            var updatedLocation = wcfService.UpdateLocation(location);

            Assert.IsTrue(updatedLocation.PostalCode == "4444");

            var locations = wcfService.GetLocationsByAccountId(updatedLocation.AccountId.Value);

            Assert.IsTrue(locations.Any());

            bool deleted = wcfService.DeleteLocation(updatedLocation.AddressId);

            Assert.IsTrue(deleted);
        }

        private static PersonDto GetPersonDto()
        {
            var person = new PersonDto
                             {
                                 Title = "Software Engineer",
                                 FirstName = "John",
                                 NickName = "jsmith",
                                 MiddleName = "Steve",
                                 LastName = "Smith",
                                 Suffix = "Mr",
                                 FullName = "John Smith",
                                 BirthDate = new DateTime(1976, 08, 11),
                                 AgeRange = 35,
                                 Ethnicity = new Random().Next(),
                                 Description = "WPF Developer",
                                 GenderCode = 1,
                                 EducationCode = new Random().Next(),
                                 ExternalIdentifier = "Pers_" + new Random().Next(),
                                 Portrait = new byte[0]
                             };
            return person;
        }

        private static AccountDto GetNewAccount()
        {
            var deliveryMethods = _lookupServiceImpl.GetDeliveryMethods();
            var servicePackages = _lookupServiceImpl.GetServicePackages();
            var accountTypes = _lookupServiceImpl.GetAccountTypes();

            var account = new AccountDto
            {
                Name = "AccountTestName",
                ServicePackageId = servicePackages.ToList()[0].ServicePackageId,
                AccountTypeId = accountTypes.ToList()[0].AccoutTypeId,
                ParentAccountId = null,
                AccountNumber = "AN4433221",
                Description = "Account Description",
                WebSiteURL = "http://www.cga.com",
                TimeZoneId = 1,
                CreatedOn = DateTime.Now,
                CreatedBy = 1,
                ModifiedBy = 2,
                ModifiedOn = DateTime.Now
            };
            return account;
        }

        private static AddressDto GetNewAddress()
        {
            var addressDto = new AddressDto
                                 {
                                     AddressNumber = 1,
                                     AddressTypeCode = 1,
                                     City = "London",
                                     Country = "United Kingdom",
                                     County = "BC",
                                     Fax = "555-555-555",
                                     Latitude = 444.22,
                                     Line1 = "Line 1",
                                     Line2 = "Line 2",
                                     Line3 = "Line 3",
                                     Longitude = 555.33,
                                     Name = "Main Address",
                                     PostOfficeBox = "Post Office Box",
                                     PostalCode = "UK-6655",
                                     ShippingMethodCode = 444,
                                     SiteId = 5,
                                     StateOrProvince = "UK-State",
                                     Telephone1 = "555-555-551",
                                     Telephone2 = "555-555-552",
                                     Telephone3 = "555-555-553",
                                     UPSZone = "UPS1",
                                     UTCOffset = 4,
                                     DeletionStateCode = 1,
                                     VersionNumber = BitConverter.GetBytes(DateTime.Now.ToBinary())
                                 };

            return addressDto;
        }
    }
}
