using AMS.Broker.Contracts.Services;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AMS.Broker.Test
{
    [TestFixture]
    public class SiteServiceTest : BaseTest
    {
        private static ISitesService _siteService;

        public SiteServiceTest()
        {
            _siteService = BrokerService.Container.Resolve<ISitesService>();
        }

        [Test]
        public void Can_Get_Global_Site()
        {
            var globalSite = _siteService.GetSite(8);

            var globalSite2 = _siteService.GetSite(8);
        }
    }
}
