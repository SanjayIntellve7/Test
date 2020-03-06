using AMS.Broker.AutherizationService.DataStore;

namespace AMS.Broker.AutherizationService.Test
{
    public class BaseTest
    {
        public BaseTest()
        {
            AutoMapperConfiguration.CreateAllMaps();
            var service = new BrokerService();
            AutoMapperConfiguration.CreateAllMaps();
        }
    }
}
