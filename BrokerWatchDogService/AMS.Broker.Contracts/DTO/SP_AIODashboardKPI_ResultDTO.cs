using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_AIODashboardKPI_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> TrfficSensroActive { get; set; }

        [DataMember()]
        public Nullable<Int32> TrfficSensroInActive { get; set; }

        [DataMember()]
        public Nullable<Int32> CCTVActive { get; set; }

        [DataMember()]
        public Nullable<Int32> CCTVInactive { get; set; }

        [DataMember()]
        public Nullable<Int32> EnvSenSorActive { get; set; }

        [DataMember()]
        public Nullable<Int32> EnvSenSorNotActive { get; set; }

        [DataMember()]
        public Nullable<Int32> SmartlightActive { get; set; }

        [DataMember()]
        public Nullable<Int32> SmartlightNotActive { get; set; }

        public SP_AIODashboardKPI_ResultDTO()
        {
        }

        public SP_AIODashboardKPI_ResultDTO(Nullable<Int32> trfficSensroActive, Nullable<Int32> trfficSensroInActive, Nullable<Int32> cCTVActive, Nullable<Int32> cCTVInactive, Nullable<Int32> envSenSorActive, Nullable<Int32> envSenSorNotActive, Nullable<Int32> smartlightActive, Nullable<Int32> smartlightNotActive)
        {
            this.TrfficSensroActive = trfficSensroActive;
            this.TrfficSensroInActive = trfficSensroInActive;
            this.CCTVActive = cCTVActive;
            this.CCTVInactive = cCTVInactive;
            this.EnvSenSorActive = envSenSorActive;
            this.EnvSenSorNotActive = envSenSorNotActive;
            this.SmartlightActive = smartlightActive;
            this.SmartlightNotActive = smartlightNotActive;
        }
    }
}
