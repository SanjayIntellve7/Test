using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class VideoAlarmEvent
    {
        /// <summary>
        /// Gets or sets the id of the event.
        /// 
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the id of the alarm.
        /// 
        /// </summary>
        public Guid AlarmId { get; set; }

        /// <summary>
        /// Gets or sets the name of the alarm.
        /// 
        /// </summary>
        public string AlarmName { get; set; }

        /// <summary>
        /// Gets or sets the priority of the alarm.
        /// 
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the list of cameras associated with alarm.
        /// 
        /// </summary>
        public IEnumerable<Guid> Cameras { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the alarm is deactivated.
        /// 
        /// </summary>
        public bool Deactivated { get; set; }

        /// <summary>
        /// Gets or sets the description of the alarm.
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date when alarm was occurred.
        /// 
        /// </summary>
        public DateTime Date { get; set; }
    }
}
