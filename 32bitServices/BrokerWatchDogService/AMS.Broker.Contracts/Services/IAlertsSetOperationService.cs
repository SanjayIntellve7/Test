using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IAlertsSetOperationService
    {

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
        long SetAlertOwner(string authToken, int alertID);

        [OperationContract]
        bool AlertCollabration(string newOwner, long alertID, string oldeOwner, string authToken);

        [OperationContract]
        bool AcknowledgeAlerts(string alerts);

        [OperationContract]
        bool AcknowledgeAlertsMobile(string authToken, string alerts);

        [OperationContract]
        bool CancelAlerts(string alerts);

        [OperationContract]
        bool CancelallAlert(string authToken, int alertID);

        [OperationContract]
        bool CancelAlertsMobile(string alerts);

        [OperationContract]
        bool CapProfileUpdate(string authToken, string alerts);

        [OperationContract]
        void AddOperationAudit(string alertID, string NewMembershipUserId, string oldMembershipUserId, string OperationTypeName, string OperationName, string authToken);

    }
}
