using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IScheduleSetOperationService
    {
        [OperationContract]
        tblScheduleMasterDTO SaveScheduleConfiguration(tblScheduleMasterDTO _Obj, string AuthToken);

        [OperationContract]
        bool EnableScheduleConfiguration(int ScheduleId, string AuthToken);

        [OperationContract]
        bool DisableScheduleConfiguration(int ScheduleId, string AuthToken);


    }
}
