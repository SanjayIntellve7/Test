using System;
using System.Collections.Generic;
using AMS.Broker.Contracts.DTO;

namespace AMS.Broker.Contracts.Interfaces
{
    public interface INvrAlarmProvider
    {
        IEnumerable<VideoAlarmEvent> GetVideoAlarms(NvrDto nvr, IEnumerable<Guid> sources);
        
        IEnumerable<VideoAlarmEvent> GetVideoAlarms(NvrDto nvr, IEnumerable<DeviceDto> devices );
    }
}
