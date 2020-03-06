using AMS.Broker.WatchDogService.DataStore;

namespace AMS.Broker.WatchDogService.Test
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
