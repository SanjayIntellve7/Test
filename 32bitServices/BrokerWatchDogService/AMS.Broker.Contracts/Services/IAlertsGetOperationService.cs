using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.IO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IAlertsGetOperationService
    {
        [OperationContract]
        IEnumerable<Alert> GetCurrentOpenAlerts(string authToken);

        [OperationContract]
        string GetMobCurrentOpenAlertsCount(string authToken);
      
        [OperationContract]
        IEnumerable<AlertMobDto> GetMobCurrentOpenAlerts(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetAcknoledgeAlerts(string authToken);     
        
        [OperationContract]
        IEnumerable<Alert> GetClosedAlerts(string authToken);

        [OperationContract]
        bool StartGetCurrentOpenAlerts(string authToken);
        
        [OperationContract]
        IEnumerable<AlertKpi> GetAlertsKpi(Guid authToken, string startTime, string endTime);

        [OperationContract]
        IEnumerable<Alert> GetNewOpenAlerts(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetTop50Alert(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetTop50AlertThinClient(string authToken); //amit 16022017 for thinclient
       
        //GetTop50AlertDummy
        [OperationContract]
        IEnumerable<Alert> GetTop50AlertDummy(string authToken);

        [OperationContract]
        IEnumerable<SeverityDto> GetAlertsSeverity(string authToken);

        [OperationContract]
        IEnumerable<CertaintyDto> GetAlertsCertinity(string authToken);

        [OperationContract]
        IEnumerable<UrgencyDto> GetAlertsUrgency(string authToken);

         //[OperationContract]
        //bool CapProfileUpdate(string authToken, int _alertId, Severity _severity, Urgency _urgency, AMS.Broker.Contracts.DTO.Certainty _certinity);
         
        [OperationContract]
        IEnumerable<Alert> GetSingleAlert(int alertID, string authToken);

        [OperationContract]
        IEnumerable<SP_GetSingleAlertAdminDto> GetSingleAlertAdmin(int alertID);

        [OperationContract]
        long GetOpenAlertCount(string authToken);

        //amit 28072015
        [OperationContract]
        IEnumerable<AlertMobDto> GetMobileSingleAlert(string authToken, int alertID);

        [OperationContract]
        IEnumerable<Alert> GetAlertByDeviceId(long DeviceId, string StartDate, string EndDate); //trupti10Aug15 dashboard

        //trupti 26 May 15
        [OperationContract]
        string GetDeviceAlertCount(string authToken, long DeviceId);

        [OperationContract]
        IEnumerable<AlertByDeviceDto> GetDeviceAlertByID(string authToken, long DeviceId);


        [OperationContract]
        IEnumerable<SPSearch_ResultDto> GetContextAlertData(string Context, string Component, bool IsDateFilter, string StartDate, string EndDate, string AuthToken);  //trupti10sept15
              

        [OperationContract]
        bool AnimateMapPin();

        //trupti24112015
        //[OperationContract]
        //bool CreatePAAlert(string strData);
        //
        
        //trupti09122015
        [OperationContract]
        IEnumerable<AssociatedPtzDeviceDto> GetAssociatedPTZDevice(string DeviceId);

        //amit 10102016
        [OperationContract]
        IEnumerable<AssociatedPtzDeviceDto> GetAssociatedPTZDeviceCollection(string authToken);

       // [OperationContract]
        //bool SubmitNewAlertEdgeAnalytics(Alert alert, byte[] managedArray);       

        //

        [OperationContract]
        string AllTypeAlertCounts(string authToken);   //trupti120516

        [OperationContract]
        IList<ObjectsAssociationDto> GetAssociatedDeviceCollection(string authToken);

        [OperationContract]
        string GetRecentAndAllTypeAlertCount(string authToken);
    }
}
