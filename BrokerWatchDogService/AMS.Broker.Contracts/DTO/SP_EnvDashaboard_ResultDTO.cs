using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_EnvDashaboard_ResultDTO
    {
        [DataMember()]
        public Nullable<DateTime> Tempdate { get; set; }

        [DataMember()]
        public Nullable<Int32> Hour { get; set; }

        [DataMember()]
        public Nullable<Int64> ID { get; set; }

        [DataMember()]
        public Nullable<DateTime> Env_ReceiveDateTime { get; set; }

        [DataMember()]
        public String Env_CO2 { get; set; }

        [DataMember()]
        public String Env_CO { get; set; }

        [DataMember()]
        public String Env_NO2 { get; set; }

        [DataMember()]
        public String Env_O3 { get; set; }

        [DataMember()]
        public String Env_SO2 { get; set; }

        [DataMember()]
        public String Env_O2 { get; set; }

        [DataMember()]
        public String Env_Sound { get; set; }

        [DataMember()]
        public String Env_AmbientLight { get; set; }

        [DataMember()]
        public String Env_SoundMax { get; set; }

        [DataMember()]
        public String Env_SoundMin { get; set; }

        [DataMember()]
        public String Env_PM2_5 { get; set; }

        [DataMember()]
        public String Env_PM10 { get; set; }

        [DataMember()]
        public String Env_Pressure { get; set; }

        [DataMember()]
        public String Env_Rainfall { get; set; }

        [DataMember()]
        public String Env_Avg_Temp { get; set; }

        [DataMember()]
        public String Env_ULTRA_VIOLET { get; set; }

        [DataMember()]
        public String Env_Avg_Humidity { get; set; }

        [DataMember()]
        public String Env_Air_Temperature { get; set; }

        [DataMember()]
        public String Env_Battery_Level { get; set; }

        [DataMember()]
        public String Env_Dew_Point { get; set; }

        [DataMember()]
        public String Env_Wind_Direction { get; set; }

        [DataMember()]
        public String Env_Wind_Speed { get; set; }

        [DataMember()]
        public String Env_Avg_Visibility { get; set; }

        [DataMember()]
        public String Env_NO { get; set; }

        [DataMember()]
        public String Env_RegionId { get; set; }

        [DataMember()]
        public String Env_RegionName { get; set; }

        [DataMember()]
        public String Env_ZoneId { get; set; }

        [DataMember()]
        public String Env_ZoneName { get; set; }

        [DataMember()]
        public String Env_WardId { get; set; }

        [DataMember()]
        public String Env_WardName { get; set; }

        [DataMember()]
        public String Env_JunctionId { get; set; }

        [DataMember()]
        public String Env_JunctionName { get; set; }

        [DataMember()]
        public String Env_DirectionId { get; set; }

        [DataMember()]
        public String Env_DirectionName { get; set; }

        [DataMember()]
        public String Env_EqpId { get; set; }

        [DataMember()]
        public String Env_EqpName { get; set; }

        [DataMember()]
        public String Env_EqpCatgId { get; set; }

        [DataMember()]
        public String Env_EqpCatgName { get; set; }

        [DataMember()]
        public String Env_EqpTypeId { get; set; }

        [DataMember()]
        public String Env_EqpTypeName { get; set; }

        [DataMember()]
        public String Env_Lat { get; set; }

        [DataMember()]
        public String Env_Long { get; set; }

        [DataMember()]
        public String Env_Status { get; set; }

        [DataMember()]
        public String Env_AQI { get; set; }

        [DataMember()]
        public Nullable<Int64> AlertID { get; set; }

        public SP_EnvDashaboard_ResultDTO()
        {
        }

        public SP_EnvDashaboard_ResultDTO(Nullable<DateTime> tempdate, Nullable<Int32> hour, Nullable<Int64> iD, Nullable<DateTime> env_ReceiveDateTime, String env_CO2, String env_CO, String env_NO2, String env_O3, String env_SO2, String env_O2, String env_Sound, String env_AmbientLight, String env_SoundMax, String env_SoundMin, String env_PM2_5, String env_PM10, String env_Pressure, String env_Rainfall, String env_Avg_Temp, String env_ULTRA_VIOLET, String env_Avg_Humidity, String env_Air_Temperature, String env_Battery_Level, String env_Dew_Point, String env_Wind_Direction, String env_Wind_Speed, String env_Avg_Visibility, String env_NO, String env_RegionId, String env_RegionName, String env_ZoneId, String env_ZoneName, String env_WardId, String env_WardName, String env_JunctionId, String env_JunctionName, String env_DirectionId, String env_DirectionName, String env_EqpId, String env_EqpName, String env_EqpCatgId, String env_EqpCatgName, String env_EqpTypeId, String env_EqpTypeName, String env_Lat, String env_Long, String env_Status, String env_AQI, Nullable<Int64> alertID)
        {
            this.Tempdate = tempdate;
            this.Hour = hour;
            this.ID = iD;
            this.Env_ReceiveDateTime = env_ReceiveDateTime;
            this.Env_CO2 = env_CO2;
            this.Env_CO = env_CO;
            this.Env_NO2 = env_NO2;
            this.Env_O3 = env_O3;
            this.Env_SO2 = env_SO2;
            this.Env_O2 = env_O2;
            this.Env_Sound = env_Sound;
            this.Env_AmbientLight = env_AmbientLight;
            this.Env_SoundMax = env_SoundMax;
            this.Env_SoundMin = env_SoundMin;
            this.Env_PM2_5 = env_PM2_5;
            this.Env_PM10 = env_PM10;
            this.Env_Pressure = env_Pressure;
            this.Env_Rainfall = env_Rainfall;
            this.Env_Avg_Temp = env_Avg_Temp;
            this.Env_ULTRA_VIOLET = env_ULTRA_VIOLET;
            this.Env_Avg_Humidity = env_Avg_Humidity;
            this.Env_Air_Temperature = env_Air_Temperature;
            this.Env_Battery_Level = env_Battery_Level;
            this.Env_Dew_Point = env_Dew_Point;
            this.Env_Wind_Direction = env_Wind_Direction;
            this.Env_Wind_Speed = env_Wind_Speed;
            this.Env_Avg_Visibility = env_Avg_Visibility;
            this.Env_NO = env_NO;
            this.Env_RegionId = env_RegionId;
            this.Env_RegionName = env_RegionName;
            this.Env_ZoneId = env_ZoneId;
            this.Env_ZoneName = env_ZoneName;
            this.Env_WardId = env_WardId;
            this.Env_WardName = env_WardName;
            this.Env_JunctionId = env_JunctionId;
            this.Env_JunctionName = env_JunctionName;
            this.Env_DirectionId = env_DirectionId;
            this.Env_DirectionName = env_DirectionName;
            this.Env_EqpId = env_EqpId;
            this.Env_EqpName = env_EqpName;
            this.Env_EqpCatgId = env_EqpCatgId;
            this.Env_EqpCatgName = env_EqpCatgName;
            this.Env_EqpTypeId = env_EqpTypeId;
            this.Env_EqpTypeName = env_EqpTypeName;
            this.Env_Lat = env_Lat;
            this.Env_Long = env_Long;
            this.Env_Status = env_Status;
            this.Env_AQI = env_AQI;
            this.AlertID = alertID;
        }
    }
}
