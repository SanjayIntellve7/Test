using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class EscallationDirectory
    {
        // public EscallationDirectory();
        public DateTime AlertDateTime { get; set; }

        public int LevelNo { get; set; } //level

        public int MessageTypeID { get; set; } //1  1

        public int EscallationTime { get; set; }//100 200

        public bool IExecuted { get; set; } //NO  No

        public EscalationContactDetailsDataDtoList EscallationContactDto { get; set; }
       
    }
}
