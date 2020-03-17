using AMS.Broker.WatchDogService;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.WatchDogService.DataStore;
using AMS.Broker.WatchDogService.Services;
using AMS.Broker.WatchDogService.Services.ServicesImplementations;
using AMS.Broker.WatchDogServiceTests.SitesWcfService;
using AutoMapper;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AMS.Broker.WatchDogServiceTests
{
    [TestClass]
    public class SiteServiceTests : BaseTest
    {
        private static AMS.Broker.Contracts.Services.ISitesGetOperationService _sitesService;
        private static SitesWcfService.ISitesService _wcfSitesService;
        private static IAccountsGetOperationService _accountsService;

        #region Additional test attributes

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {            
            AutoMapperConfiguration.CreateAllMaps();
            var service = new BrokerService();
            AutoMapperConfiguration.CreateAllMaps();
            _sitesService = new SitesService();
           // _accountsService = new AccountsServiceImpl();
            _wcfSitesService = new SitesServiceClient();
        }
        
        #endregion

        #region Testing the mappings

        [TestMethod]
        public void CanMap_SiteEntity_To_SiteDto()
        {
            var entry = CreateSite();
            var dto = Mapper.Map<SiteDto>(entry);

            AssertAreEqual(entry, dto);
        }

        [TestMethod]
        public void CanMap_SiteDto_To_SiteEntity()
        {
            var dto = CreateSiteDto();
            var entry = Mapper.Map<Site>(dto);

            AssertAreEqual(entry, dto);
        }

        [TestMethod]
        public void CanMap_SiteTypeEntity_To_SiteTypeDto()
        {
            var entry = CreateSiteType();
            var dto = Mapper.Map<SiteTypeDto>(entry);

            AssertAreEqual(entry, dto);
        }

        [TestMethod]
        public void CanMap_SiteTypeDto_To_SiteTypeEntity()
        {
            var dto = CreateSiteTypeDto();
            var entry = Mapper.Map<SiteType>(dto);

            AssertAreEqual(entry, dto);
        }

        [TestMethod]
        public void CanMap_SiteTypeEntityCollection_To_SiteTypeDtoCollection()
        {
            var entry = CreateSiteType();
            var entryList = new List<SiteType>() {entry};
            var dtoList = Mapper.Map<List<SiteTypeDto>>(entryList);  
          
            Assert.AreEqual(dtoList.Count, entryList.Count);
        }

        [TestMethod]
        public void CanMap_SiteTypeDtoCollection_To_SiteTypeEntityCollection()
        {
            var dto = CreateSiteTypeDto();
            var dtoList = new List<SiteTypeDto>() {dto};
            var entryList = Mapper.Map<List<SiteType>>(dtoList);

            Assert.AreEqual(dtoList.Count, entryList.Count);
        }

        #endregion

        #region Sites Logic

        /*
        [TestMethod]
        public void Does_AddSite_SetRelations()
        {
            var site = CreateSiteDto();

            var siteType = CreateSiteTypeDto();
            var address = CreateAddressDto();
            var account = CreateAccountDto();
            var parentSite = CreateSiteDto();
            var bbox = new List<BBoxPointDto>();
            bbox.Add(CreateBBoxPointDto());
            bbox.Add(CreateBBoxPointDto());

            var repMock = new Mock<IRepository<Site>>();
            BrokerService.Container.RegisterType<IRepository<Site>>().RegisterInstance(repMock.Object);
            repMock.Setup(x => x.Create(It.IsAny<Site>()))
                   .Returns<Site>(x=>x);

            var resultSite = _sitesService.AddSite(site, siteType, parentSite, address, account, bbox);

            AssertAreEqual(siteType, resultSite.SiteType);
            AssertAreEqual(address, resultSite.Address);
            AssertAreEqual(account, resultSite.Account);
            AssertAreEqual(parentSite, resultSite.ParentSite);
        }
        
        [TestMethod]
        public void Does_AddBBoxPoint_SetRelations()
        {
            var bboxPointDto = CreateBBoxPointDto();
            var site = CreateSiteDto();

            var repMock = new Mock<IRepository<BBoxPoint>>();
            BrokerService.Container.RegisterType<IRepository<BBoxPoint>>().RegisterInstance(repMock.Object);
            repMock.Setup(x => x.Create(It.IsAny<BBoxPoint>()))
                   .Returns<BBoxPoint>(x => x);

            var resultSite = _sitesService.AddBBoxPoint(bboxPointDto, site);

            AssertAreEqual(site, resultSite.Site);
        }
        */
        
        #endregion

        [TestMethod]
        public void CRUD_BBoxPoint()
        {
            var bboxPoint1 = CreateBBoxPointDto();
            bboxPoint1.BBoxPointId = -1;

            var site = _sitesService.GetSites()[0];

            //Add
            var addResult = _sitesService.AddBBoxPoint(bboxPoint1, site);

            Assert.IsTrue(addResult.BBoxPointId > 0);
            Assert.IsTrue(addResult.SiteId == site.SiteId);

            //Read
            var readResult = _sitesService.GetBBoxPointsBySite(site.SiteId);

            Assert.IsTrue(readResult.Count == 1);
            Assert.IsTrue(readResult[0].BBoxPointId == addResult.BBoxPointId);
            
            //Update
            bboxPoint1 = addResult;
            bboxPoint1.Lat = -33;
          
            var updateResult = _sitesService.UpdateBBoxPoint(bboxPoint1);
            Assert.IsTrue(updateResult.Lat == -33);

            //Delete
            var deleteResult = _sitesService.DeleteBBoxPoint(updateResult.BBoxPointId);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void CRUD_Site()
        {
            const string newDescription = "qwerty";

            var site = CreateSiteDto();
            var siteType = _sitesService.GetSiteTypes()[0];
            var parentSite = _sitesService.GetSites()[0];
            var bboxPoints = new List<BBoxPointDto>() {CreateBBoxPointDto(), CreateBBoxPointDto()};

            //Add
            var addResult = _sitesService.AddSite(site, siteType, parentSite, null, null, bboxPoints);
            Assert.IsTrue(addResult.BBoxPointCollection.Count == 2);


            //Update
            addResult.Description = newDescription;
            var editResult = _sitesService.UpdateSite(addResult);

            Assert.IsTrue(editResult.Description == newDescription);

            //Read
            var readResult = _sitesService.GetSite(editResult.SiteId);

            Assert.IsTrue(readResult.BBoxPointCollection.Count == 2);

            //Delete
            foreach (var bBoxPointDto in readResult.BBoxPointCollection)
            {
               _sitesService.DeleteBBoxPoint(bBoxPointDto.BBoxPointId);
            }
            /*var deleteResult = _sitesService.DeleteSite(readResult.SiteId);

            Assert.IsTrue(deleteResult);*/

        }

        [TestMethod]
        public void CRUD_SiteType()
        {
            const string newName = "data";

            var siteType = CreateSiteTypeDto();

            //Add
            var addResult = _sitesService.AddSiteType(siteType);

            Assert.IsTrue(addResult.SiteTypeId > 0);
            Assert.IsTrue(addResult.Name == siteType.Name);

            //Read
            var readResult = _sitesService.GetSiteType(addResult.SiteTypeId);

            Assert.IsTrue(addResult.SiteTypeId == readResult.SiteTypeId);

            //Edit
            readResult.Name = newName;
            var editResult = _sitesService.UpdateSiteType(readResult);

            Assert.IsTrue(editResult.Name == newName);

            //Delete
            var deleteResult = _sitesService.DeleteSiteType(editResult.SiteTypeId);

            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void WCF_CRUD_BBoxPoint()
        {
            var bboxPoint1 = CreateBBoxPointDto();
            bboxPoint1.BBoxPointId = -1;

            var site = _sitesService.GetSites()[0];

            //Add
            var addResult = _wcfSitesService.AddBBoxPoint(bboxPoint1, site);

            Assert.IsTrue(addResult.BBoxPointId > 0);
            Assert.IsTrue(addResult.SiteId == site.SiteId);

            //Read
            var readResult = _wcfSitesService.GetBBoxPointsBySite(site.SiteId);

            Assert.IsTrue(readResult.Length == 1);
            Assert.IsTrue(readResult[0].BBoxPointId == addResult.BBoxPointId);

            //Update
            bboxPoint1 = addResult;
            bboxPoint1.Lat = -33;

            var updateResult = _wcfSitesService.UpdateBBoxPoint(bboxPoint1);
            Assert.IsTrue(updateResult.Lat == -33);

            //Delete
            var deleteResult = _wcfSitesService.DeleteBBoxPoint(updateResult.BBoxPointId);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void WCF_CRUD_Site()
        {
            const string newDescription = "qwerty";

            var site = CreateSiteDto();
            var siteType = _wcfSitesService.GetSiteTypes()[0];
            var parentSite = _wcfSitesService.GetSites()[0];
            var bboxPoints = new List<BBoxPointDto>() { CreateBBoxPointDto(), CreateBBoxPointDto() };

            //Add
            var addResult = _wcfSitesService.AddSite(site, siteType, parentSite, null, null, bboxPoints.ToArray());
            //Assert.IsTrue(addResult.BBoxPointCollection.Count == 2);


            //Update
            addResult.Description = newDescription;
            var editResult = _wcfSitesService.UpdateSite(addResult);

            Assert.IsTrue(editResult.Description == newDescription);

            //Read
            var readResult = _wcfSitesService.GetSite(editResult.SiteId);

           // Assert.IsTrue(readResult.BBoxPointCollection.Count == 2);

            //Delete
            if (readResult.BBoxPointCollection != null)
            {
                foreach (var bBoxPointDto in readResult.BBoxPointCollection)
                {
                    _wcfSitesService.DeleteBBoxPoint(bBoxPointDto.BBoxPointId);
                }
            }
            var deleteResult = _wcfSitesService.DeleteSite(readResult.SiteId);

            Assert.IsTrue(deleteResult);

        }

        [TestMethod]
        public void WCF_CRUD_SiteType()
        {
            const string newName = "data";

            var siteType = CreateSiteTypeDto();

            //Add
            var addResult = _wcfSitesService.AddSiteType(siteType);

            Assert.IsTrue(addResult.SiteTypeId > 0);
            Assert.IsTrue(addResult.Name == siteType.Name);

            //Read
            var readResult = _wcfSitesService.GetSiteType(addResult.SiteTypeId);

            Assert.IsTrue(addResult.SiteTypeId == readResult.SiteTypeId);

            //Edit
            readResult.Name = newName;
            var editResult = _wcfSitesService.UpdateSiteType(readResult);

            Assert.IsTrue(editResult.Name == newName);

            //Delete
            var deleteResult = _wcfSitesService.DeleteSiteType(editResult.SiteTypeId);

            Assert.IsTrue(deleteResult);
        }
    }
}
