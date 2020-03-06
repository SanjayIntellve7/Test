using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.AutherizationService.BusinessLogic.Factories
{
    [Export("KronosAlertBuilder",typeof(IAlertBuilder<EventDTO>))]
    public class KronosEventAlertBuilder : IAlertBuilder<EventDTO>
    {
        public KronosEventAlertBuilder(EventDTO @event)
        {

        }

        public void SetSource(EventDTO @event)
        {
            throw new NotImplementedException();
        }

        public void BuildInfo()
        {
            throw new NotImplementedException();
        }

        public void BuildArea()
        {
            throw new NotImplementedException();
        }

        public void BuildAlert()
        {
            throw new NotImplementedException();
        }

        public Alert GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
