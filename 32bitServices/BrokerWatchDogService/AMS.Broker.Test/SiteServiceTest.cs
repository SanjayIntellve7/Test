using AMS.Broker.Contracts.Services;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AMS.Broker.WatchDogService.Test
{
    [TestFixture]
    public class SiteServiceTest : BaseTest
    {
        private static ISitesGetOperationService _siteService;

        public SiteServiceTest()
        {
            _siteService = BrokerService.Container.Resolve<ISitesGetOperationService>();
        }

        [Test]
        public void Can_Get_Global_Site()
        {
            var globalSite = _siteService.GetSite(8);

            var globalSite2 = _siteService.GetSite(8);
        }
    }
}
