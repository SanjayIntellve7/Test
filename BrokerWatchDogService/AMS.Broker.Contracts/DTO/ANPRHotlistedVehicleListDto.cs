using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class ANPRHotlistedVehicleListDto
    {
        public string VehCatId { get; set; }
        public string VehCatName { get; set; }
        public string HotlistCatId { get; set; }
        public string HotlistCatName { get; set; }
        public string VehRestrId { get; set; }
        public string VehNum { get; set; }
        public string EqpId { get; set; }
        public string HotlistFrmDate { get; set; }
        public string HotlistToDate { get; set; }
        public string CapturedDate { get; set; }
        public string ImageFileName { get; set; }
        public string RegionId { get; set; }
        public string RegionName { get; set; }
        public string ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string WardId { get; set; }
        public string WardName { get; set; }
        public string JunctionId { get; set; }
        public string JunctionName { get; set; }
        public string DirectionId { get; set; }
        public string DirectionName { get; set; }
        public string EqpName { get; set; }
        public string EqpCatgId { get; set; }
        public string EqpCatgName { get; set; }
        public string EqpTypeId { get; set; }
        public string EqpTypeName { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Status { get; set; }
    }
}
