using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class ANPRVehicleOperationDto
    {
        public string VehCatId { get; set; }
        public string VehCatName { get; set; }
        public string HotlistCatId { get; set; }
        public string HotlistCatName { get; set; }
        public string VehRestrId { get; set; }
        public string VehNum { get; set; }
        public string HotlistFrmDate { get; set; }
        public string HotlistToDate { get; set; }
    }
}
