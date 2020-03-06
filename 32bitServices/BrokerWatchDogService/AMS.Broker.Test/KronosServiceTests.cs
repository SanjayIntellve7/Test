using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AMS.Broker.WatchDogService.Test
{
    [TestFixture]
    public class KronosServiceTests : BaseTest
    {
        [Test]
        public void GetEventTypeTemplate_ContactIdProtocol_NoException()
        {
            var service = BrokerService.Container.Resolve<IKronosService>(); ;
            EventTypeTemplateDto res = service.GetEventTypeTemplate("6");
            Assert.IsNotNull(res);
        }
    }
}
