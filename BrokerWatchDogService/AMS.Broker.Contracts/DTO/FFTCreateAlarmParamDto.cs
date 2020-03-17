using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class FFTCreateAlarmParamDto
    {
        public  long alarmId  { get; set; } 
        public  string alarmTimeUtc  { get; set; } 
        public  bool acknowledged  { get; set; } 
        public  bool isValidLocation  { get; set; } 
        public  bool isOTDR  { get; set; } 
        public  string strAlertType  { get; set; } 
        public  SdkAlarmTypeDto alarmType  { get; set; } 
        public  SdkCtrlDataDto ctrl  { get; set; } 
        public  List<SdkSensorDataDto> sensors  { get; set; } 
        public  SdkLocationInfoDto location  { get; set; }
        public  SdkSensorDataDto sensor  { get; set; } 
        public  SdkZoneDataDTO zone  { get; set; } 
        public  string classification  { get; set; }
        public string functiontype { get; set; } 
    }
}
