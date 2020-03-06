using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.AutherizationService.BusinessLogic.Factories
{
    public interface IAlertBuilder<in TSourceEvent>
    {
        void SetSource(TSourceEvent @event);
        void BuildInfo();
        void BuildArea();
        void BuildAlert();
        Alert GetResult();
    }
}
