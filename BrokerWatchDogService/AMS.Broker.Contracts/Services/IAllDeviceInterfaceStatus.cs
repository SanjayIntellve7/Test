using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{   
    [ServiceContract]
    public interface IAllDeviceInterfaceStatus
    {
        [OperationContract]
        bool Test();

        [OperationContract]
        bool UpdateSparshDvrStatus(string EntityType, string ChannNo,string DvrID,string Status,string StrDateTime);
       
    }
}
