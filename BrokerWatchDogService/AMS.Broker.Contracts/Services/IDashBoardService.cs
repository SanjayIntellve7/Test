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

        //Total Sites count
        [OperationContract]
        long GetTotalSitesCount(string authToken);

        //Total Zone count
        [OperationContract]
        long GetTotalzonesCount(string authToken);

        //Total Intrusion device count
        [OperationContract]
        long getTotalNoOfIntrusionDeviceCount(string authToken);

        //Total Camera device count
        [OperationContract]
        long getTotalNoOfCameraDeviceCount(string authToken);

        [OperationContract]
        IEnumerable<SP_GetNoEventsReceivedDto> GetNoEventSiteReceivedList(string authToken);

        [OperationContract]
        IEnumerable<SP_GetNoOpeningClosingEventsReceived_ResultDto> GetNoOpeningClosingEventsList(string authToken, int flag);

        [OperationContract]
        IEnumerable<SP_GetTop10AlertGenerateSiteDto> GetMoreAlertGeneratedSiteList(string authToken);

        [OperationContract]
        IEnumerable<SP_GetTOPDisarmingSiteDto> GetTopDisarmingSiteList(string authToken);

        [OperationContract]
        IEnumerable<SP_WATMDahsboardStatus_ResultDTO> GetWATMDahsboardStatus(); // Janajal harsha 21012019

        [OperationContract]
        IEnumerable<SP_WATMDashboardTypeCollection_ResultDTO> GetWATMDashboardTypeCollection(); // Janajal harsha 21012019

        [OperationContract]
        IEnumerable<SP_WATMDispenserDahsboardStatus_ResultDTO> GetWATMDispenserDahsboardStatus(); // Janajal harsha 21012019

        [OperationContract]
        IEnumerable<SP_WATMDashboardCollection_ResultDTO> GetWATMDashboardCollection(); // Janajal harsha 22012019

        [OperationContract]
        IEnumerable<SP_WATMDashboardQuantityDispensed_ResultDTO> GetWATMDashboardQuantityDispensed(); // Janajal harsha 22012019

        [OperationContract]
        IEnumerable<SP_WATMStatusChart_ResultDTO> GetWATMStatusChart(); // Janajal harsha 22012019

        [OperationContract]
        IEnumerable<SP_WATMQuantityDispensedTrend_ResultDTO> GetWATMQuantityDispensedTrend(); // Janajal harsha 22012019

        [OperationContract]
        IEnumerable<SP_WATMMapDashboard_ResultDTO> GetWATMMapDashboard(string AtmId); // Janajal harsha 22012019

        [OperationContract]
        IEnumerable<SP_WATMDispenserStatusChart_ResultDTO> GetWATMDispenserStatusChart(); // Janajal harsha 22012019

        [OperationContract]
        IEnumerable<SP_WATMCollectionTrend_ResultDTO> GetWATMCollectionTrend(); // Janajal harsha 22012019

        [OperationContract]
        List<DeviceDto> GetWATMDeviceCollectionForMap(); // Janajal harsha 22012019

        [OperationContract]
        List<WATMAllInfoDto> GetWATMForPinInfoMap(string deviceId); // Janajal harsha 22012019


        //harsha (Managed Services)
        [OperationContract]
        IEnumerable<SP_IOTEnergyConsumption_ResultDTO> GetIOTEnergyConsumption(); //harsha 250119

        [OperationContract]
        IEnumerable<SP_IOTEnergyWeeklyConsumption_ResultDTO> GetIOTEnergyWeeklyConsumption(); //harsha 250119

        [OperationContract]
        IEnumerable<SP_IOTGasConsumption_ResultDTO> GetIOTGasConsumption(); //harsha 250119

        [OperationContract]
        IEnumerable<SP_IOTGasWeeklyConsumption_ResultDTO> GetIOTGasWeeklyConsumption(); //harsha 250119

        [OperationContract]
        IEnumerable<SP_IOTWaterConsumption_ResultDTO> GetIOTWaterConsumption(); //harsha 250119

        [OperationContract]
        IEnumerable<SP_IOTWaterWeeklyConsumption_ResultDTO> GetIOTWaterWeeklyConsumption(); //harsha 250119        

        [OperationContract]
        IEnumerable<SP_IOTMapDashboard_ResultDTO> GetIOTMapDashboard(string deviceID, int flag); //harsha 280119        

        [OperationContract]
        IEnumerable<SP_IOTMapDashboardTrend_ResultDTO> GetIOTMapDashboardTrend(string deviceID, int flag); //harsha 280119                

        [OperationContract]
        List<DeviceDto> GetIOTDeviceCollectionForMap(string deviceType); // harsha 280119

        [OperationContract]
        IEnumerable<Sp_GetIOTPanelDetails_ResultDTO> GetIOTPanelDetails(); //harsha 290119                

        [OperationContract]
        IEnumerable<SP_IOTDeviceStatus_ResultDTO> GetIOTDeviceStatus(); //harsha 290119   


        //komal SWM Smart City
        [OperationContract]
        IEnumerable<tblSWMBinMasterDTO> GetSWMBinMasterCollection(); // varanasi komal 08042019

        [OperationContract]
        IEnumerable<tblSWMBinTXDataDTO> GetSWMBinTXDataCollection(); // varanasi komal 08042019

        //[OperationContract]
        // IEnumerable<SP_SWMGarbageVehiclesKPI_ResultDTO> GetSWMVehicleTXDataCollection(); // varanasi komal 09042019
        //             

        [OperationContract]
        IEnumerable<SP_SWMVehicleLocNStatusKPI_ResultDTO> GetSWMVehicleLocNStatusKPI(string fromDate, string toDate);//komal16092019 18092019// varanasi komal 09042019 KPI

        [OperationContract]
        IEnumerable<SP_SWMBinFillStatusKPI_ResultDTO> GetSWMBinFillStatusKPIColl(string fromDate, string toDate);//komal16092019 18092019 // varanasi komal 09042019  SP_SWMBinFillStatusKPI KPI

        //
        [OperationContract]
        IEnumerable<SP_SWMBinCleaningStatusKPI_ResultDTO> GetSWMBinCleaningStatusKPIColl(string fromDate, string toDate);//komal16092019 18092019// varanasi komal 09042019  SP_SWMBinFillStatusKPI KPI

        [OperationContract]
        IEnumerable<SP_SWMPercentcriticalWardsbyWasteCollEffKPI_ResultDTO> GetSWMPercentcriticalWardsbyWasteColl(string fromDate, string toDate);//komal16092019 18092019 // varanasi komal 09042019  SP_SWMBinFillStatusKPI KPI

        [OperationContract]
        IEnumerable<SP_SWMRealtimebinfullalertKPI_ResultDTO> GetSWMRealtimebinfullalertKPI(string fromDate, string toDate);//komal16092019 18092019 // varanasi komal 09042019  SP_SWMBinFillStatusKPI KPI

        [OperationContract]
        IEnumerable<tblSWMVehicleMasterDTO> GetSWMVehicleMasterCollection();
        //
        [OperationContract]
        void StartSWMTxnThreads();

        [OperationContract]
        string TestCommunication();

        //harsha Varanasi
        [OperationContract]
        IEnumerable<SP_ComplaintHourly_ResultDTO> GetComplaintsHourlyCollection(); //harsha030619                

        [OperationContract]
        IEnumerable<SP_ComplaintWeekly_ResultDTO> GetComplaintsWeeklyCollection(); //harsha030619

        [OperationContract]
        IEnumerable<SP_SWMComplaintStatus_ResultDTO> GetComplaintsStatusCollection(string fromDate, string toDate);//komal16092019 18092019 //harsha030619                

        [OperationContract]
        IEnumerable<SP_SWMWardComplaint_ResultDTO> GetWardComplaintCollection(string fromDate, string toDate);//komal16092019 18092019//harsha030619

        [OperationContract]
        IEnumerable<SP_SWMWardAttendence_ResultDto> GetWardAttendenceCollection(); //harsha030619

        [OperationContract]
        IEnumerable<SP_AttendanceWeekly_ResultDTO> GetAttendanceWeeklyCollection(); //harsha030619

        [OperationContract]
        IEnumerable<SP_SWMBinCollectionPcikedStatus_ResultDTO> GetSWMBinCollectionPcikedStatusColl();//komal16092019 // varanasi komal 06062019

        [OperationContract]
        IEnumerable<SP_SWMKPIBinAlert_ResultDTO> GetSWMKPIBinAlertCollection();

        [OperationContract]
        IEnumerable<SP_SWMBinAlertWeekly_ResultDTO> GetSWMBinAlertWeeklyCollection();
        //

        //RLVD Screen
        [OperationContract]
        IEnumerable<SP_GetRLVDEquipmentStatusCountDto> GetRLVDEquipmentStatusCount(string authToken, string fromDate, string toDate);//komal16092019 18092019

        [OperationContract]
        IEnumerable<SP_GetRLVDStatusCountDto> GetRLVDStatusCount(string authToken, int flag);

        [OperationContract]
        IEnumerable<SP_GetRLVDZoneIncidentCountDto> GetRLVDZoneIncidentCount(string authToken);

        [OperationContract]
        IEnumerable<SP_GetRLVDVoilationTrendDto> GetRLVDVoilationTrend(string authToken);

        [OperationContract]
        IEnumerable<SP_GetRLVDTransactionbyZoneNameDto> GetRLVDTransactionbyZoneName(string authToken, int flag);

        [OperationContract]
        IEnumerable<SP_GetRLVDStatusMapDto> GetSP_GetRLVDStatusMap(string authToken);//komal16092019
        //

        //hotList
        [OperationContract]
        IEnumerable<SP_GetHotlistMapDto> GetHotlistMap(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<SP_GetHotlistTransactionbyZoneNameDto> GetHotlistTransactionbyZoneName(string authToken, string flag);//komal16092019

        [OperationContract]
        IEnumerable<SP_GetTrendHotlistTransactionDto> GetTrendHotlistTransaction(string authToken);

        [OperationContract]
        IEnumerable<SP_GetHotlistTransactionDto> GetHotlistTransaction(string authToken, string fromDate, string toDate);//komal16092019 18092019

        [OperationContract]
        IEnumerable<SP_GetHotlistStatusCountDto> GetHotlistStatusCount(string authToken);
        //

        //ITMS Komal 
        //anpr
        [OperationContract]
        IEnumerable<SP_ITMSANPRCamera_ResultDTO> GetITMSANPRCamera(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<SP_ITMSANPRIncidentTrend_ResultDTO> GetITMSANPRIncidentTrend(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<SP_ITMSANPRKPI_ResultDTO> GetITMSANPRKPI(string authToken);//komal16092019
        //RLVD
        [OperationContract]
        IEnumerable<SP_ITMSRLVDCamera_ResultDTO> GetITMSRLVDCamera(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<SP_ITMSViolationIncidentTrend_ResultDTO> GetITMSViolationIncidentTrend(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<SP_ITMSViolationKPI_ResultDTO> GetITMSViolationKPI(string authToken, string fromDate, string toDate);//komal16092019 18092019
        //
        //Echalan
        [OperationContract]
        IEnumerable<SP_ITMSChallanKPI_ResultDTO> GetITMSChallanKPI(string authToken, string fromDate, string toDate);//komal16092019 01112019

        [OperationContract]
        IEnumerable<SP_ITMSEchallanCollectionTrend_ResultDTO> GetITMSEchallanCollectionTrend(string authToken, string fromDate, string toDate);//komal16092019 01112019

        //environment
        [OperationContract]
        IEnumerable<SP_GetAVGEnvironmentInformation_ResultDTO> GetAVGEnvironmentInformation(string authToken);

        [OperationContract]
        IEnumerable<SP_GetEnvironmentInfoMAP_ResultDTO> GetEnvironmentInfoMAP(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<SP_GetEnvironmentTop5Polluted_ResultDTO> GetEnvironmentTop5Polluted(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<tblSWMAttendenceMasterDTO> GetWardAttendanceMasterCollection();//komal16092019

        [OperationContract]
        List<tblSWMWardMasterDTO> GetWardDetails();

        [OperationContract]
        List<tblEquipmentDetailsDto> GetEquipmentDetails(string authToken);

        [OperationContract]
        IEnumerable<tblSWMTotalWasteDumpedDTO> GetTotalWasteDumped(string authToken);

        [OperationContract]
        IEnumerable<tblSWMTotalWasteDumpedDTO> GetSelectedTotalWasteDumped(string authToken, string fromDate, string toDate); //new method with date filter

        [OperationContract]
        IEnumerable<SP_SWMBinAlertStatusKPI_ResultDTO> GetBinAlertStatusKPICollection(string authToken); //komal16092019 //harsha080719

        [OperationContract]
        IEnumerable<SP_SWMWardComplaintStatus_ResultDTO> GetComplaintStatusCollection(string authToken, string fromDate, string toDate);//komal16092019 18092019 //harsha080719

        [OperationContract]
        IEnumerable<SP_SWMWardComplaintStatusDetails_ResultDTO> GetComplaintStatusDetailsCollection(string authToken, string fromDate, string toDate);//harsha170220

        [OperationContract]
        IEnumerable<SP_ITMSEChallanKPI_ResultDTO> GetITMSEChallanKPICollection(string authToken); //harsha090719

        [OperationContract]
        IEnumerable<SP_ITMSCameraStatus_ResultDTO> GetITMSCameraStatusCollection(string authToken); //harsha090719

        [OperationContract]
        IEnumerable<SP_ITMSRLVDSVDSKPI_ResultDTO> GetITMSRLVDSVDSKPICollection(string authToken, string fromDate, string toDate);//komal16092019 18092019 //harsha090719

        [OperationContract]
        IEnumerable<SP_ITMSSuspectedKPI_ResultDTO> GetITMSSuspectedKPICollection(string authToken, string fromDate, string toDate);//komal16092019 18092019//harsha090719

        [OperationContract]
        IEnumerable<SP_CitizenCompalintTrend_ResultDTO> GetCitizenCompalintTrendCollection(string authToken);//komal16092019 //harsha090719

        [OperationContract]
        IEnumerable<SP_EnvDashaboard_ResultDTO> GetEnvDashaboardCollection(string authToken, string Flag, string fromDate, string toDate);//komal16092019 18092019//komal10072019 15072019

        [OperationContract]
        IEnumerable<SP_SurveillanceDashboard_ResultDTO> GetSurveillanceDashboardCollection(string authToken, string fromDate, string toDate);//komal16092019 18092019//komal10072019

        [OperationContract]
        IEnumerable<SP_EnvKPI_ResultDTO> GetEnvKPICollection(string authToken, string fromDate, string toDate);//komal16092019 18092019//komal10072019

        [OperationContract]
        IEnumerable<SP_SmartLightStatus_ResultDTO> GetSmartLightStatus(string authToken, string fromDate, string toDate);//komal16092019 18092019

        [OperationContract]
        IEnumerable<SP_SmartlightTrend_ResultDTO> GetSmartlightTrend(string authToken, string fromDate, string toDate);//komal16092019 18092019

        [OperationContract]
        IEnumerable<SP_AIODashboardKPI_ResultDTO> GetAIODashboardKPI(string authToken);//komal16092019

        [OperationContract]
        IEnumerable<SP_EchallanCollectionTrend_ResultDTO> GetEchallanCollectionTrend(string authToken, string fromDate, string toDate);//komal16092019);//filter apply 01112019

        [OperationContract]
        IEnumerable<SP_AIOEnvAQITrend_ResultDTO> GetAIOEnvAQITrend(string authToken, string fromDate, string toDate);//komal16092019);//filter apply 01112019

        [OperationContract]
        IEnumerable<SP_TotalWasteWardChard_ResultDTO> GetTotalWasteWardChart(string authToken, string fromDate, string toDate);//komal16092019)//filter apply 01112019

        [OperationContract]
        IEnumerable<SP_AIOCCTVDashboardTrend_ResultDTO> GetAIOCCTVDashboardTrend(string authToken, string fromDate, string toDate);//komal16092019) 18092019

        [OperationContract]
        IEnumerable<SP_AIOTotalConsumption_ResultDTO> GetAIOTotalConsumption(string authToken, string fromDate, string toDate);//komal16092019) 18092019

        [OperationContract]
        IEnumerable<SP_ComplaintlapsedTime_ResultDTO> GetComplaintlapsedTime(string authToken, string fromDate, string toDate);//komal16092019 18092019

        [OperationContract]
        IEnumerable<SP_CriticalWarddata_ResultDTO> GetCriticalWarddata(string authToken, string fromDate, string toDate);//komal16092019 18092019

        [OperationContract]
        IEnumerable<SP_SurveillanceDeviceDashboard_ResultDTO> GetSurveillanceDeviceDashboardCollection(string authToken);//komal22102019

        [OperationContract]
        IEnumerable<tblViolationTypeMasterDTO> GettblViolationTypeMasterCollection(string authToken);//komal01112019

        [OperationContract]
        List<DashboardAlertDto> GetDashboardAlertCollection(string authToken, string fromDate, string toDate);//komal13112019

        [OperationContract]
        List<SP_GetAlertInfo_ResultDTO> GetDashboardAlertInformation(string authToken, string fromDate, string toDate, int InputType);//harsha300120

        [OperationContract]
        IEnumerable<SP_SWMBinStatus_ResultDTO> GetSWMBinStatusCollection(string authToken);//harsha021219

        [OperationContract]
        IEnumerable<SP_GetITMSHomeDashboard_ResultDTO> GetITMSHomeDashboardCollection(string authToken, string fromDate, string toDate, int input);//harsha131219

        [OperationContract]
        IEnumerable<SP_GetITMSEChallanHomeDashboard_ResultDTO> GetITMSEChallanHomeDashboardCollection(string authToken, string fromDate, string toDate, int inputType);//harsha131219
         

        [OperationContract]
        IEnumerable<SP_SurveillanceWebDashboard_ResultDTO> GetSurveillanceWebDashCollection(string authToken, string fromDate, string toDate, int input);//harsha160120
        //

        [OperationContract]
        ApiResponse GetDashboardReportDetailsByUser(string authToken);

        [OperationContract]
        List<tblDashboardGroupMasterDTO> GetAllGroupsDashboard(string authtoken);

        [OperationContract]
        tblDashboardGroupMasterDTO GetGroupById(int Id, string authToken); // jatin 0502020

        [OperationContract]
        ApiResponse SaveGroupConfiguration(tblDashboardGroupMasterDTO _Obj);//jatin 07022020

        [OperationContract]
        tblDashboardGroupMasterDTO GetDefaultReportsStructure(string authToken);//jatin 10022020


        [OperationContract]
        UserGroupData GetAllUsers(string authToken); // jatin 11022020

        [OperationContract]
        ApiResponse Saveuser(tblDashboardGroupUserMappingDTO _data, string authToken);

        [OperationContract]
        IEnumerable<tblVMDSetMessageQueDTO> GetSelectedVMDSetMessageQue(string authToken, string fromDate, string toDate); //harsha050220

        [OperationContract]
        IEnumerable<SP_SWMBinMaster_ResultDTO> GetSWMBinMasterSPCollection(string authToken);//harsha140219

        [OperationContract]
        IEnumerable<SP_EnvironmentCorrelation_ResultDTO> GetEnvCorrelationCollection(string authToken);//harsha140219

        [OperationContract]
        IEnumerable<SP_PasStatus_ResultDTO> GetPASDeviceList(string authToken);//harsha301219

        [OperationContract]
        IEnumerable<SP_VMDStatus_ResultDTO> GetVMDDeviceList(string authToken);//harsha170219

        [OperationContract]
        IEnumerable<SP_SmartLightWebDashboardStatus_ResultDTO> GetSmartLightWebDashboardStatusCollection(string authToken);//harsha06032020

        [OperationContract]
        IEnumerable<SP_WardEnergyConsumption_ResultDTO> GetWardEnergyConsumptionCollection(string authToken, string fromDate, string toDate);//harsha06032020

        [OperationContract]
        IEnumerable<SP_SmartLightFeederDetails_ResultDTO> GetSmartLightFeederDetailsCollection(string authToken, string fromDate, string toDate);//harsha11032020

        [OperationContract]
        IEnumerable<SP_WardEnergyBurnTime_ResultDTO> GetWardEnergyBurnTimeCollection(string authToken, string fromDate, string toDate);//harsha11032020

    }
}