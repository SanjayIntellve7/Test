using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblHotlistVehicleOperationDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String VehCatgId { get; set; }

        [DataMember()]
        public String VehCatgName { get; set; }

        [DataMember()]
        public String HotlistCatId { get; set; }

        [DataMember()]
        public String HotlistCatName { get; set; }

        [DataMember()]
        public String VehRestrId { get; set; }

        [DataMember()]
        public String VehNum { get; set; }

        [DataMember()]
        public String HotlistFrmDate { get; set; }

        [DataMember()]
        public String HotlistToDate { get; set; }

        [DataMember()]
        public String OprTyp { get; set; }

        public tblHotlistVehicleOperationDTO()
        {
        }

        public tblHotlistVehicleOperationDTO(Int32 iD, String vehCatgId, String vehCatgName, String hotlistCatId, String hotlistCatName, String vehRestrId, String vehNum, String hotlistFrmDate, String hotlistToDate, String oprTyp)
        {
            this.ID = iD;
            this.VehCatgId = vehCatgId;
            this.VehCatgName = vehCatgName;
            this.HotlistCatId = hotlistCatId;
            this.HotlistCatName = hotlistCatName;
            this.VehRestrId = vehRestrId;
            this.VehNum = vehNum;
            this.HotlistFrmDate = hotlistFrmDate;
            this.HotlistToDate = hotlistToDate;
            this.OprTyp = oprTyp;
        }
    }
}
