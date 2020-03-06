using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IDashBoardService
    {
        //Todays Total Register Mem details
        [OperationContract]
        long GetTodaysRegisterMemCount(string authToken);

        [OperationContract]
        IEnumerable<AccountDto> GetTodaysRegisterMemList(string authToken);

        //Total Register Mem details
        [OperationContract]
        long GetTotalRegisterMemCount(string authToken);

        [OperationContract]
        IEnumerable<AccountDto> GetTotalRegisterMemList(string authToken);

        //Total Free Subscriber details
        [OperationContract]
        long GetFreeSubscriberMemCount(string authToken);

        [OperationContract]
        IEnumerable<AccountDto> GetFreeSubscriberMemList(string authToken);

        //Total Paid Subscriber details
        [OperationContract]
        long GetPaidSubscriberMemCount(string authToken);

        [OperationContract]
        IEnumerable<AccountDto> GetPaidSubscriberMemList(string authToken);

        //Total Active Subscriber details
        [OperationContract]
        long GetActiveSubscriberMemCount(string authToken);

        [OperationContract]
        IEnumerable<AccountDto> GetActiveSubscriberMemList(string authToken);

        //Total DeActive Subscriber details
        [OperationContract]
        long GetDeActiveSubscriberMemCount(string authToken);

        [OperationContract]
        IEnumerable<AccountDto> GetDeActiveSubscriberMemList(string authToken);

        //Alert Details
        //Total Alert details
        [OperationContract]
        long GetTotalAlertCount(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetTotalAlertList(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetTotalAlertDashboard(string authToken);

        //Open Alert Assigned details
        [OperationContract]
        long GetOpenAlertAssignedCount(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetOpenAlertAssignedList(string authToken);

        //Open Alert Unassigned details
        [OperationContract]
        long GetOpenAlertUnAssignedCount(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetOpenAlertUnAssignedList(string authToken);

        //Close Alert details
        [OperationContract]
        long GetClosedAlertCount(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetClosedAlertList(string authToken);

        //incident Report details
        [OperationContract]
        long GetIncidentReportCount(string authToken);


        //Operator Details
        // Get operators name
        [OperationContract]
        IEnumerable<UserDto> GetTotalOperatorsList(string authToken);

        [OperationContract]
        long GetOperatorCount(string authToken);


        [OperationContract]
        IEnumerable<AccountDto> SearchMemResult(string authToken, string Name, string Phno);

        //Online Device details
        //[OperationContract]
        //long GetOnlineDevicecount(string authToken);

        [OperationContract]
        IEnumerable<DeviceDto> GetDeviceList(string authToken);

        [OperationContract]
        IEnumerable<DeviceDto> GetDeviceListDashBoard(string authToken);
        
        //

        [OperationContract]
        IEnumerable<DashBoardDto> GetAlertLocationData(string authToken);  

        [OperationContract]
        IEnumerable<DeviceLocationDto> GetDeviceLocationData(string authToken);  

        [OperationContract]
        IEnumerable<DashBoardDto> GetAlertAlertTypeData(string authToken);

        [OperationContract]
        IEnumerable<DashBoardDto> GetLocationVsDeviceData(string authToken);

        [OperationContract]
        IEnumerable<DashBoardDto> GetUserwiseAlertData(string authToken);

        [OperationContract]
        IEnumerable<DashBoardDto> GetAlertStatusWiseAlertData(string authToken);

        [OperationContract]
        IEnumerable<DashBoardDto> GetCummalativeDashBoardData(string authToken);  
        
        

        /* //Offline Device details
         [OperationContract]
         long GetOfflineDevicecount(string authToken);

         [OperationContract]
         IEnumerable<DeviceDto> GetOfflineDeviceList(string authToken);
         //*/

        //Offline Device details   
        [OperationContract]
        IEnumerable<tblCameraStatusDto> GetCameraStatus(string authToken);
        //

        [OperationContract]
        IEnumerable<tblCrimeHeatMapDTO> GetCrimeHeatCollection(string authToken);

        [OperationContract]
        IEnumerable<tblDisasterMapDTO> GetDisasterCollection(string authToken);

        [OperationContract]
        IEnumerable<tblSwachchaBharatMapDTO> GetSwatchBharatCollection(string authToken);

        [OperationContract]
        IEnumerable<SP_SwatchBharatDashboard_ResultDTO> GetChartListCollection(string authToken, string Number);

        //amit 30052016
        [OperationContract]
        IEnumerable<tblweatherchcurrentDTO> GetCurrentWeather(string authToken);

        [OperationContract]
        IEnumerable<tblWeatherhourlyforecastDTO> GetForecastWeather(string authToken);

        [OperationContract]
        IEnumerable<SP_RDLHourlyWeatherReport_ResultDTO> GetHourlyWeatherReport(string authToken);  
    }
}
