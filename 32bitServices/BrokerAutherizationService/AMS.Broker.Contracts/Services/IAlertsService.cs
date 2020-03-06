using System;
using System.Collections.Generic;
using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.IO;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IAlertsService
    {
        [OperationContract]
        IEnumerable<Alert> GetCurrentOpenAlerts(string authToken);

        [OperationContract]
        string GetMobCurrentOpenAlertsCount(string authToken);
      
        [OperationContract]
        IEnumerable<AlertMobDto> GetMobCurrentOpenAlerts(string authToken);

        [OperationContract]
        IEnumerable<Alert> GetAcknoledgeAlerts(string authToken);

        //[OperationContract]
        //Boolean SubmitNewAlert(string alert);        

        //Boolean SubmitNewAlert(Alert alert);

        //long SubmitNewAlertMycs(Alert alert);

        
        int AddAccount(AccountDto accountDto);       
 
        int SaveAccountPerson(PersonDto personDto, int accountID);   
    
        void SaveAccountContact(ContactDto contactDto, int personID);   
    
        int SaveAccountAddress(AddressDto addressDto, int accountID);   
     
        void SaveAccountBilling(AccountBillingDto accountBillingDto, int addressID);

        int AddInterfaceNew(InterfaceTypeDto InterfaceType, int accountID, int SiteId);

        [OperationContract]       
        Boolean UpdateAlertInformations(string alert);

        [OperationContract]
        Boolean UpdateAlertsCollection(string alerts);

        [OperationContract]
        Boolean CreateMobileAlert(string urgency, string severity, string note, string lattitude, string longitude, string retPath, string retVoicenotePath, string retVideoPath, string Imei_No);

        //
        [OperationContract]
        Boolean CreateDummySimulatorAlerts(string alertcode);

        [OperationContract]
        bool UpdateMobileAlert(string alertId, string retPath, string retVoicenotePath, string retVideoPath);
        
        //
        [OperationContract]       
        string fileUpload(Stream fileStream); 

        [OperationContract]
        IEnumerable<Alert> GetClosedAlerts(string authToken);

        [OperationContract]
        bool StartGetCurrentOpenAlerts(string authToken);

        [OperationContract]
        long SetAlertOwner(string authToken, int alertID);

        [OperationContract]
        bool AlertCollabration(string newOwner, long alertID, string oldeOwner);

        [OperationContract]
        IEnumerable<AlertKpi> GetAlertsKpi(Guid authToken, string startTime, string endTime);

        [OperationContract]
        IEnumerable<Alert> GetNewOpenAlerts(string authToken);

        [OperationContract]
        bool AcknowledgeAlerts(string alerts);

        [OperationContract]
        bool AcknowledgeAlertsMobile(string alerts);

        [OperationContract]
        bool CancelAlerts(string alerts);

        [OperationContract]
        bool CancelallAlert(string authToken, int alertID);

        [OperationContract]
        bool CancelAlertsMobile(string alerts);

        [OperationContract]
        IEnumerable<Alert> GetTop50Alert(string authToken);
       
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
        bool CapProfileUpdate(string authToken,string alerts);
        
        [OperationContract]
        IEnumerable<Alert> GetSingleAlert(int alertID);

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
        IEnumerable<AssociatedPtzDeviceDto> GetAssociatedPTZDeviceCollection();

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
