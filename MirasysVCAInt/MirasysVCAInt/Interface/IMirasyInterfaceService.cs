using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MirasysVCAInt.Interface
{   
    [ServiceContract]
    public interface IMirasyInterfaceService
    {      

        [OperationContract]
        IList<MirasysDeviceDetails> GetMirasysCamDeviceList(string MirasysNvrIP, string MirasysNvrPort, string MirasysUserName, string MirasysPassword);
    }
}
