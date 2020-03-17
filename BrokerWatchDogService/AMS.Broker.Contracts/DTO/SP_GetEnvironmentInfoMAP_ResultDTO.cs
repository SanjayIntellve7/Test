using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class SP_GetEnvironmentInfoMAP_ResultDTO
    {
        [DataMember()]
        public Nullable<Int64> T1ID { get; set; }

        [DataMember()]
        public Nullable<DateTime> Env_ReceiveDateTime { get; set; }

        [DataMember()]
        public Nullable<Double> Env_CO2 { get; set; }

        [DataMember()]
        public Nullable<Double> Env_CO { get; set; }

        [DataMember()]
        public Nullable<Double> Env_NO2 { get; set; }

        [DataMember()]
        public Nullable<Double> Env_O3 { get; set; }

        [DataMember()]
        public Nullable<Double> Env_SO2 { get; set; }

        [DataMember()]
        public Nullable<Double> Env_O2 { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Sound { get; set; }

        [DataMember()]
        public Nullable<Double> Env_AmbientLight { get; set; }

        [DataMember()]
        public Nullable<Double> Env_SoundMax { get; set; }

        [DataMember()]
        public Nullable<Double> Env_SoundMin { get; set; }

        [DataMember()]
        public Nullable<Double> Env_PM2_5 { get; set; }

        [DataMember()]
        public Nullable<Double> Env_PM10 { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Pressure { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Rainfall { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Avg_Temp { get; set; }

        [DataMember()]
        public Nullable<Double> Env_ULTRA_VIOLET { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Avg_Humidity { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Air_Temperature { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Battery_Level { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Dew_Point { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Wind_Direction { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Wind_Speed { get; set; }

        [DataMember()]
        public Nullable<Double> Env_Avg_Visibility { get; set; }

        [DataMember()]
        public Nullable<Double> Env_NO { get; set; }

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
        public String UniqueIdT1 { get; set; }

        [DataMember()]
        public Int64 DeviceID { get; set; }

        [DataMember()]
        public String ExternalId { get; set; }

        [DataMember()]
        public String DName { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceId { get; set; }

        [DataMember()]
        public Nullable<Int32> SiteId { get; set; }

        [DataMember()]
        public String DType { get; set; }

        [DataMember()]
        public Double DLat { get; set; }

        [DataMember()]
        public Double DLong { get; set; }

        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String EqpCatgId { get; set; }

        [DataMember()]
        public String EqpCatgName { get; set; }

        [DataMember()]
        public String EqpTypeId { get; set; }

        [DataMember()]
        public String EqpTypeName { get; set; }

        [DataMember()]
        public String EqpId { get; set; }

        [DataMember()]
        public String Status { get; set; }

        [DataMember()]
        public String RegionId { get; set; }

        [DataMember()]
        public String RegionName { get; set; }

        [DataMember()]
        public String ZoneId { get; set; }

        [DataMember()]
        public String ZoneName { get; set; }

        [DataMember()]
        public String WardId { get; set; }

        [DataMember()]
        public String WardName { get; set; }

        [DataMember()]
        public String JunctionId { get; set; }

        [DataMember()]
        public String JunctionName { get; set; }

        [DataMember()]
        public String Lat { get; set; }

        [DataMember()]
        public String Long_ { get; set; }

        [DataMember()]
        public String DirectionId { get; set; }

        [DataMember()]
        public String DirectionName { get; set; }

        public SP_GetEnvironmentInfoMAP_ResultDTO()
        {
        }

        public SP_GetEnvironmentInfoMAP_ResultDTO(Nullable<Int64> t1ID, Nullable<DateTime> env_ReceiveDateTime, Nullable<Double> env_CO2, Nullable<Double> env_CO, Nullable<Double> env_NO2, Nullable<Double> env_O3, Nullable<Double> env_SO2, Nullable<Double> env_O2, Nullable<Double> env_Sound, Nullable<Double> env_AmbientLight, Nullable<Double> env_SoundMax, Nullable<Double> env_SoundMin, Nullable<Double> env_PM2_5, Nullable<Double> env_PM10, Nullable<Double> env_Pressure, Nullable<Double> env_Rainfall, Nullable<Double> env_Avg_Temp, Nullable<Double> env_ULTRA_VIOLET, Nullable<Double> env_Avg_Humidity, Nullable<Double> env_Air_Temperature, Nullable<Double> env_Battery_Level, Nullable<Double> env_Dew_Point, Nullable<Double> env_Wind_Direction, Nullable<Double> env_Wind_Speed, Nullable<Double> env_Avg_Visibility, Nullable<Double> env_NO, String env_RegionId, String env_RegionName, String env_ZoneId, String env_ZoneName, String env_WardId, String env_WardName, String env_JunctionId, String env_JunctionName, String env_DirectionId, String env_DirectionName, String env_EqpId, String env_EqpName, String env_EqpCatgId, String env_EqpCatgName, String env_EqpTypeId, String env_EqpTypeName, String env_Lat, String env_Long, String env_Status, String env_AQI, String uniqueIdT1, Int64 deviceID, String externalId, String dName, Nullable<Int32> interfaceId, Nullable<Int32> siteId, String dType, Double dLat, Double dLong, Int32 iD, String eqpCatgId, String eqpCatgName, String eqpTypeId, String eqpTypeName, String eqpId, String status, String regionId, String regionName, String zoneId, String zoneName, String wardId, String wardName, String junctionId, String junctionName, String lat, String long_, String directionId, String directionName)
        {
            this.T1ID = t1ID;
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
            this.UniqueIdT1 = uniqueIdT1;
            this.DeviceID = deviceID;
            this.ExternalId = externalId;
            this.DName = dName;
            this.InterfaceId = interfaceId;
            this.SiteId = siteId;
            this.DType = dType;
            this.DLat = dLat;
            this.DLong = dLong;
            this.ID = iD;
            this.EqpCatgId = eqpCatgId;
            this.EqpCatgName = eqpCatgName;
            this.EqpTypeId = eqpTypeId;
            this.EqpTypeName = eqpTypeName;
            this.EqpId = eqpId;
            this.Status = status;
            this.RegionId = regionId;
            this.RegionName = regionName;
            this.ZoneId = zoneId;
            this.ZoneName = zoneName;
            this.WardId = wardId;
            this.WardName = wardName;
            this.JunctionId = junctionId;
            this.JunctionName = junctionName;
            this.Lat = lat;
            this.Long_ = long_;
            this.DirectionId = directionId;
            this.DirectionName = directionName;
        }
    }
}
