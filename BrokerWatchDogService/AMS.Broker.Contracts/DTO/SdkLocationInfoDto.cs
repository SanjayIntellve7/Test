using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class SdkLocationInfoDto
    {
        public int CableDistance { get; set; }
        public CoordinateDto Location { get; set; }
        public int LocationWeight { get; set; }
        public int LocationWeightThreshold { get; set; }
        public int PerimeterDistance { get; set; }
    }

    public class SdkAlarmTypeDto
    {
        public const int CategoryExternal = 5;
        public const int CategoryLaser = 3;
        public const int CategoryMask = 100;
        public const int CategoryMobile = 6;
        public const int CategoryRedundancyGroup = 7;
        public const int CategorySensor = 4;
        public const int CategorySystem = 2;
        public const int CategoryZone = 1;
        public const long IdControllerShutdown = 1048576;
        public const long IdExternalAlarm = 4294967296;
        public const long IdFanFault = 10011;
        public const long IdFanWarning = 10010;
        public const long IdFibreBreak = 256;
        public const long IdFilterBlocked = 10009;
        public const long IdFilterWarning = 10008;
        public const long IdIntrusion = 1;
        public const long IdLaserFault = 10000;
        public const long IdLaserOff = 4096;
        public const long IdLaserWarning = 10001;
        public const long IdLeak = 2;
        public const long IdLocatorFault = 8388608;
        public const long IdLostComms = 16777216;
        public const long IdMaintenance = 2097152;
        public const long IdMobileAlarm = 17179869184;
        public const long IdOpticalPowerDegraded = 512;
        public const long IdOutputPowerFault = 10002;
        public const long IdOutputPowerWarning = 10003;
        public const long IdPowerSupplyDegraded = 134217728;
        public const long IdRedundancyGroupDegraded = 68719476736;
        public const long IdRedundancyGroupDisabled = 137438953472;
        public const long IdSopAlarm = 8192;
        public const long IdSystemError = 134217729;
        public const long IdSystemOutputPowerFault = 10004;
        public const long IdSystemOutputPowerWarning = 10005;
        public const long IdSystemTemperatureFault = 10007;
        public const long IdSystemTemperatureWarning = 10006;
        public const long IdTamper = 4194304;
        public const long IdTemperatureShutdown = 2048;
        public const long IdTemperatureWarning = 1024;
        public const long IdUnknown = 0;
        public const long IdUnknownLaser = 9997;
        public const long IdUnknownSensor = 9998;
        public const long IdUnknownSystem = 9999;
        public const long IdVoltageOutOfRangeFault = 10013;
        public const long IdVoltageOutOfRangeWarning = 10012;
        public const int SeverityAlarm = 3;
        public const int SeverityFlag = 10;
        public const int SeverityNotification = 1;
        public const int SeverityWarning = 2;
        public const int TypeEvent = 1;
        public const int TypeFault = 2;
        public const int TypeMask = 10;

        public int Category { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Severity { get; set; }
        public int Type { get; set; }
    }
}
