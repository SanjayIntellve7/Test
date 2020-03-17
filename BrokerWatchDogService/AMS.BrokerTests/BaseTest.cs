using AMS.Broker.Contracts.DTO;
using AMS.Broker.WatchDogService.DataStore;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.WatchDogServiceTests
{
    public abstract class BaseTest
    {        
        protected int GetRand()
        {
            var rand = new Random((int)DateTime.Now.Ticks);

            return rand.Next(0, 10000);
        }

        #region Builders

        protected Site CreateSite()
        {
            var site = new Site()
            {
                SiteId = GetRand(),
                Description = "qwerty",
                Account = new Account() { AccountId = GetRand() },
                Address = new Address() { AddressId = GetRand() },
                SiteType = new SiteType() { siteTypeId = GetRand() },
                Site2 = new Site() { SiteId = GetRand() }
            };

            return site;
        }
        
        protected SiteDto CreateSiteDto()
        {
            var siteDto = new SiteDto()
            {
                SiteId = GetRand(),
                Name = "someSite",
                Description = "qwerty",
                Lat = 3,
                Long = 6,
                Alt = 9,
                Address = new AddressDto() { AddressId = GetRand() },
                SiteType = new SiteTypeDto() { SiteTypeId = GetRand() },
                ParentSite = new SiteDto() { SiteId = 6 }
            };

            return siteDto;
        }

        protected SiteType CreateSiteType()
        {
            var siteType = new SiteType() { siteTypeName = "someType", Description = "qwerty" };

            return siteType;
        }

        protected SiteTypeDto CreateSiteTypeDto()
        {
            var siteTypeDto = new SiteTypeDto() { Name = "someType", Description = "qwerty" };

            return siteTypeDto;
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        protected Address CreateAddress()
        {
            var address = new Address()
            {
                AddressId = GetRand()
            };

            return address;
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        protected AddressDto CreateAddressDto()
        {
            var address = new AddressDto()
                {
                    AddressId = GetRand()
                };

            return address;
        }

        protected BBoxPoint CreateBBoxPoint()
        {
            var bboxPoint = new BBoxPoint()
            {
                BBoxPointId = GetRand(),
                Alt = GetRand(),
                Long = GetRand(),
                Lat = GetRand(),
                Site = CreateSite()                
            };

            return bboxPoint;
        }

        protected BBoxPointDto CreateBBoxPointDto()
        {            
            var bboxPointDto = new BBoxPointDto()
            {
                BBoxPointId = GetRand(),
                Alt = GetRand(),
                Long = GetRand(),
                Lat = GetRand(),
                Site = CreateSiteDto()
            };

            return bboxPointDto;
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        protected Account CreateAccount()
        {
            var account = new Account()
            {
                AccountId = GetRand()
            };

            return account;
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        protected AccountDto CreateAccountDto()
        {
            var account = new AccountDto()
            {
                AccountId = GetRand()
            };

            return account;
        }

        #endregion

        #region Equality

        public void AssertAreEqual(SiteDto site1, SiteDto site2)
        {
            if (site1 != null || site2 != null)
            {
                Assert.AreEqual(site1.SiteId, site2.SiteId);
                Assert.AreEqual(site1.Name, site2.Name);
                Assert.AreEqual(site1.Description, site2.Description);
                Assert.AreEqual(site1.Alt, site2.Alt);
                Assert.AreEqual(site1.Lat, site2.Lat);
                Assert.AreEqual(site1.Long, site2.Long);
                Assert.AreEqual(site1.MapUrl, site2.MapUrl);
                Assert.AreEqual(site1.PinUrl, site2.PinUrl);

                if (site1.DevicesCollection != null || site2.DevicesCollection != null)
                {
                    Assert.AreEqual(site1.DevicesCollection.Count, site2.DevicesCollection.Count);
                }

                //if (site1.ChildSitesCollection != null || site2.DevicesCollection != null)
                //{
                //    Assert.AreEqual(site1.ChildSitesCollection.Count, site2.ChildSitesCollection.Count);
                //}
                
                AssertAreEqual(site1.SiteType, site2.SiteType);
                AssertAreEqual(site1.Address, site2.Address);
                AssertAreEqual(site1.ParentSite, site2.ParentSite);

                //ToDO: when mapping - the array is instanciated, should stay with NULL value
                // Assert.AreEqual(site1.Pin, site2.Pin);
                // Assert.AreEqual(site1.Map, site2.Map);
            }
        }

        public void AssertAreEqual(Site site, SiteDto siteDto)
        {
            if (site != null || siteDto != null)
            {
                Assert.AreEqual(site.SiteId, siteDto.SiteId);
                Assert.AreEqual(site.Name, siteDto.Name);
                Assert.AreEqual(site.Description, siteDto.Description);
                Assert.AreEqual(site.Alt, siteDto.Alt);
                Assert.AreEqual(site.Lat, siteDto.Lat);
                Assert.AreEqual(site.Long, siteDto.Long);
                Assert.AreEqual(site.MapUrl, siteDto.MapUrl);
                Assert.AreEqual(site.PinUrl, siteDto.PinUrl);

                if (site.Device != null || siteDto.DevicesCollection != null)
                {
                    Assert.AreEqual(site.Device.Count, siteDto.DevicesCollection.Count);
                }

                //if (site.Site1 != null || siteDto.DevicesCollection != null)
                //{
                //    Assert.AreEqual(site.Site1.Count, siteDto.ChildSitesCollection.Count);
                //}
                
                AssertAreEqual(site.SiteType, siteDto.SiteType);
                AssertAreEqual(site.Address, siteDto.Address);
                AssertAreEqual(site.Site2, siteDto.ParentSite);

                //ToDO: when mapping - the array is instanciated, should stay with NULL value
                // Assert.AreEqual(entry.Pin, entry2.Pin);
                // Assert.AreEqual(entry.Map, entry2.Map);
            }
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        public void AssertAreEqual(Address address, AddressDto addressDto)
        {
            if (address != null || addressDto != null)
            {
                Assert.AreEqual(address.AddressId, addressDto.AddressId);
                Assert.AreEqual(address.Name, addressDto.Name);
                Assert.AreEqual(address.AccountId, addressDto.AccountId);
                Assert.AreEqual(address.AddressNumber, addressDto.AddressNumber);
                Assert.AreEqual(address.AddressTypeCode, addressDto.AddressTypeCode);
                Assert.AreEqual(address.City, addressDto.City);
                Assert.AreEqual(address.Country, addressDto.Country);
                Assert.AreEqual(address.CreatedBy, addressDto.CreatedBy);
                Assert.AreEqual(address.CreatedOn, addressDto.CreatedOn);
                Assert.AreEqual(address.DeletionStateCode, addressDto.DeletionStateCode);
                Assert.AreEqual(address.Fax, addressDto.Fax);
                Assert.AreEqual(address.Latitude, addressDto.Latitude);
                Assert.AreEqual(address.Longitude, addressDto.Longitude);
                Assert.AreEqual(address.Line1, addressDto.Line1);
                Assert.AreEqual(address.Line2, addressDto.Line2);
                Assert.AreEqual(address.Line3, addressDto.Line3);
                Assert.AreEqual(address.ModifiedBy, addressDto.ModifiedBy);
                Assert.AreEqual(address.ModifiedOn, addressDto.ModifiedOn);
                Assert.AreEqual(address.PersonId, addressDto.PersonId);
                Assert.AreEqual(address.PostOfficeBox, addressDto.PostOfficeBox);
                Assert.AreEqual(address.PostalCode, addressDto.PostalCode);
                Assert.AreEqual(address.ShippingMethodCode, addressDto.ShippingMethodCode);
                Assert.AreEqual(address.SiteId, addressDto.SiteId);
                Assert.AreEqual(address.StateOrProvince, addressDto.StateOrProvince);
                Assert.AreEqual(address.Telephone1, addressDto.Telephone1);
                Assert.AreEqual(address.Telephone2, addressDto.Telephone2);
                Assert.AreEqual(address.Telephone3, addressDto.Telephone3);
                Assert.AreEqual(address.UPSZone, addressDto.UPSZone);
                Assert.AreEqual(address.UTCOffset, addressDto.UTCOffset);
                Assert.AreEqual(address.VersionNumber, addressDto.VersionNumber);                
            }
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        public void AssertAreEqual(AddressDto address1, AddressDto address2)
        {
        }

        public void AssertAreEqual(SiteType siteType, SiteTypeDto siteTypeDto)
        {
            if (siteType != null || siteTypeDto != null)
            {
                Assert.AreEqual(siteType.siteTypeId, siteTypeDto.SiteTypeId);
                Assert.AreEqual(siteType.siteTypeName, siteTypeDto.Name);
                Assert.AreEqual(siteType.Description, siteTypeDto.Description);

                //ToDO: when mapping - the array is instanciated, should stay with NULL value
                // Assert.AreEqual(entry.Icon, entry2.Icon);
                // Assert.AreEqual(entry.Map, entry2.Map);
            }
        }

        public void AssertAreEqual(SiteTypeDto siteType1, SiteTypeDto siteType2)
        {
            if (siteType1 != null || siteType2 != null)
            {
                Assert.AreEqual(siteType1.SiteTypeId, siteType2.SiteTypeId);
                Assert.AreEqual(siteType1.Name, siteType2.Name);
                Assert.AreEqual(siteType1.Description, siteType2.Description);

                //ToDO: when mapping - the array is instanciated, should stay with NULL value
                // Assert.AreEqual(entry.Icon, entry2.Icon);
                // Assert.AreEqual(entry.Map, entry2.Map);
            }
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        public void AssertAreEqual(Account account, AccountDto accountDto)
        {            
        }

        /// <summary>
        /// ToDO: define
        /// </summary>
        /// <returns></returns>
        public void AssertAreEqual(AccountDto account1, AccountDto account2)
        {
        }
     
        #endregion
    }
}
