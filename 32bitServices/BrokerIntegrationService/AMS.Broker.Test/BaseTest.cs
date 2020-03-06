using AMS.Broker.DataStore;

namespace AMS.Broker.Test
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
