using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IOpeningClosingEventCheckService
    {
        [OperationContract]
        void CreateOpeningClosingAlert(string deviceID, string strEventCode, string Serverity, string AlertdateTime,string strHeadline);
    }
}
