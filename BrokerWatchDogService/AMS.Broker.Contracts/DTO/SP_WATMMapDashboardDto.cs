using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_WATMMapDashboard_ResultDTO
    {
        [DataMember()]
        public Nullable<Int32> TotalDispenser { get; set; }

        [DataMember()]
        public Nullable<Int32> TotalWorkingDispenser { get; set; }

        [DataMember()]
        public Nullable<Int32> TotalNonWorkingDispenser { get; set; }

        [DataMember()]
        public Nullable<Decimal> TodayRevenue { get; set; }

        [DataMember()]
        public Nullable<Decimal> Yesterdayrevenue { get; set; }

        [DataMember()]
        public Nullable<Decimal> Lastsevenrevenue { get; set; }

        [DataMember()]
        public Nullable<Decimal> TodayQuantityDispensed { get; set; }

        [DataMember()]
        public Nullable<Decimal> Yesterdayqtydispensed { get; set; }

        [DataMember()]
        public Nullable<Decimal> Lastsevenqtydispensed { get; set; }

        [DataMember()]
        public String D1 { get; set; }

        [DataMember()]
        public String D2 { get; set; }

        [DataMember()]
        public String D3 { get; set; }

        [DataMember()]
        public String Latitude { get; set; }

        [DataMember()]
        public String Longtitude { get; set; }

        [DataMember()]
        public String GoogleCityName { get; set; }

        public SP_WATMMapDashboard_ResultDTO()
        {
        }

        public SP_WATMMapDashboard_ResultDTO(Nullable<Int32> totalDispenser, Nullable<Int32> totalWorkingDispenser, Nullable<Int32> totalNonWorkingDispenser, Nullable<Decimal> todayRevenue, Nullable<Decimal> yesterdayrevenue, Nullable<Decimal> lastsevenrevenue, Nullable<Decimal> todayQuantityDispensed, Nullable<Decimal> yesterdayqtydispensed, Nullable<Decimal> lastsevenqtydispensed, String d1, String d2, String d3, String latitude, String longtitude, String googleCityName)
        {
            this.TotalDispenser = totalDispenser;
            this.TotalWorkingDispenser = totalWorkingDispenser;
            this.TotalNonWorkingDispenser = totalNonWorkingDispenser;
            this.TodayRevenue = todayRevenue;
            this.Yesterdayrevenue = yesterdayrevenue;
            this.Lastsevenrevenue = lastsevenrevenue;
            this.TodayQuantityDispensed = todayQuantityDispensed;
            this.Yesterdayqtydispensed = yesterdayqtydispensed;
            this.Lastsevenqtydispensed = lastsevenqtydispensed;
            this.D1 = d1;
            this.D2 = d2;
            this.D3 = d3;
            this.Latitude = latitude;
            this.Longtitude = longtitude;
            this.GoogleCityName = googleCityName;
        }
    }
}
