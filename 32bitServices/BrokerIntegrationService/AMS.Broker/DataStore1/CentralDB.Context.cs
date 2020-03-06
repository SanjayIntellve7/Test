﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.DataStore
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class CentralDBEntities : DbContext
    {
        public CentralDBEntities()
            : base("name=CentralDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountInvoice> AccountInvoice { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Alert> Alert { get; set; }
        public DbSet<AlertHistory> AlertHistory { get; set; }
        public DbSet<AlertTemplate> AlertTemplate { get; set; }
        public DbSet<AlertTemplateCondition> AlertTemplateCondition { get; set; }
        public DbSet<AlertTemplateValue> AlertTemplateValue { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<AuditType> AuditType { get; set; }
        public DbSet<BBoxPoint> BBoxPoint { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Certainty> Certainty { get; set; }
        public DbSet<ComparisonOperation> ComparisonOperation { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<DevicesInZone> DevicesInZone { get; set; }
        public DbSet<DeviceType> DeviceType { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Frequency> Frequency { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<GeneralSetting> GeneralSetting { get; set; }
        public DbSet<GeoBox> GeoBox { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<IncidentReport> IncidentReport { get; set; }
        public DbSet<IncidentReportAlert> IncidentReportAlert { get; set; }
        public DbSet<IncidentReportCamera> IncidentReportCamera { get; set; }
        public DbSet<IncidentReportResource> IncidentReportResource { get; set; }
        public DbSet<IncidentReportStatus> IncidentReportStatus { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<InfoesCategory> InfoesCategory { get; set; }
        public DbSet<InfoesResponseType> InfoesResponseType { get; set; }
        public DbSet<Interface> Interface { get; set; }
        public DbSet<InterfaceType> InterfaceType { get; set; }
        public DbSet<DvrNvrTypeMaster> DvrNvrType { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<MessageType> MessageType { get; set; }
        public DbSet<NVR> NVR { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<ResourcesData> ResourcesData { get; set; }
        public DbSet<ResponseType> ResponseType { get; set; }
        public DbSet<Scope> Scope { get; set; }
        public DbSet<ServicePackage> ServicePackage { get; set; }
        public DbSet<Severity> Severity { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<SiteType> SiteType { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<StationType> StationType { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TimeZone> TimeZone { get; set; }
        public DbSet<TuchControlLicenceSettings> TuchControlLicenceSettings { get; set; }
        public DbSet<Urgency> Urgency { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserLocation> UserLocation { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<ValuesHistory> ValuesHistory { get; set; }
        public DbSet<ValuesLookUp> ValuesLookUp { get; set; }
        public DbSet<Zone> Zone { get; set; }
        public DbSet<ZoneGroup> ZoneGroup { get; set; }
        public DbSet<ZoneLocation> ZoneLocation { get; set; }
        public DbSet<ZoneUser> ZoneUser { get; set; }
        public DbSet<EventCode> EventCode { get; set; }
        public DbSet<EventGroup> EventGroup { get; set; }
        public DbSet<EventQualifier> EventQualifier { get; set; }
        public DbSet<EventTypeTemplate> EventTypeTemplate { get; set; }
        public DbSet<EventTemplate> EventTemplate { get; set; }
        public DbSet<EventFieldDefinition> EventFieldDefinition { get; set; }
        public DbSet<EventFieldType> EventFieldType { get; set; }
        public DbSet<AlertType> AlertType { get; set; }
        public DbSet<DeviceExternalIdDefinition> DeviceExternalIdDefinition { get; set; }
        public DbSet<AnalyticAlgorithmType> AnalyticAlgorithmType { get; set; }
        public DbSet<AccountBilling> AccountBilling { get; set; }
        public DbSet<ContactMethod> ContactMethod { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<PersonContactType> PersonContactType { get; set; }
        public DbSet<PreferedContatMethod> PreferedContatMethod { get; set; }
        public DbSet<AccountAlarmPanel> AccountAlarmPanel { get; set; }
        public DbSet<AccountAnalyticsAlgorithmType> AccountAnalyticsAlgorithmType { get; set; }
        public DbSet<AccountNvrAlertType> AccountNvrAlertType { get; set; }
        public DbSet<NvrAlertType> NvrAlertType { get; set; }
        public DbSet<AccountView> AccountView { get; set; }
        public DbSet<AnalyticsEventTemplate> AnalyticsEventTemplate { get; set; }
        public DbSet<VideoAanalyticsEvent> VideoAanalyticsEvent { get; set; }
        public DbSet<IncidentReportReference> IncidentReportReference { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UsersGroup> UsersGroup { get; set; }
        public DbSet<MUser> MembershipUser { get; set; }
        public DbSet<tbpeoplecounter> tbpeoplecounter { get; set; }
        public DbSet<tbgeolocation> tbgeolocation { get; set; }
        public DbSet<BioAlerts> bioAlerts { get; set; }
        public DbSet<SubMember> subMember { get; set; }
        public DbSet<AlarmPanel> alarmPanel { get; set; }
        public DbSet<DeviceVAnalyticsSchedule> deviceVAnalyticsSchedule { get; set; }
        public DbSet<DeviceZoneData> DeviceZoneData { get; set; }
        public DbSet<tblNok> tblNok { get; set; }
        public DbSet<NvrCamera> NvrCamera { get; set; }
        public DbSet<tblVehicleCounter> tblVehicleCounter { get; set; }
        public DbSet<tbluserassigmentlog> tbluserassigmentlog { get; set; }
        public DbSet<WebClientAudit> webClientAudit { get; set; }
        //trupti21july15 Geo
        public DbSet<tblGeoFencingAlert> tblGeoFencingAlert { get; set; }
        public DbSet<tblGeoFencingHistory> tblGeoFencingHistory { get; set; }
        public DbSet<tblDeviceGeoTrackHistory> tblDeviceGeoTrackHistory { get; set; }

        public DbSet<tblgeofencesequence> tblgeofencesequence { get; set; }
        public DbSet<tblMeonMembers> tblMeonMembers { get; set; }

        public DbSet<tblANPRTransDetails> tblANPRTransDetails { get; set; } //trupti24Aug15 Device status
        public DbSet<tblANPRMaster> tblANPRMaster { get; set; } //trupti24Aug15 Device status
        public DbSet<tblUserSiteMaster> tblUserSiteMaster { get; set; } //Amit 26Aug15 Device status

        public DbSet<tblRssAlertMaster> tblRssAlertMaster { get; set; } //Amit 26Aug15 Device status
        public DbSet<tblRssFeed> tblRssFeed { get; set; } //Amit 26Aug15 

        public DbSet<tblCameraViewMode> tblCameraViewMode { get; set; } //Amit 07Sept15
        public DbSet<AlarmPanelTypeMaster> AlarmPanelTypeMaster { get; set; } //trupti09sept15
        public DbSet<tblCameraBookMark> tblCameraBookMark { get; set; } //trupti09sept15
        
        //public DbSet<tbgeolocation> tbgeolocation { get; set; }
        //

        public DbSet<tblCameraStatus> tblCameraStatus { get; set; } //trupti21Aug15 Device status

        public DbSet<tblAnaLyticsStatus> tblAnaLyticsStatus { get; set; } //Amit 09 Sept15
        

        public virtual ObjectResult<User> usp_GetUsersInTeam(Nullable<System.Guid> teamId)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("usp_GetUsersInTeam", teamIdParameter);
        }
    
        public virtual ObjectResult<User> usp_GetUsersInTeam(Nullable<System.Guid> teamId, MergeOption mergeOption)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("usp_GetUsersInTeam", mergeOption, teamIdParameter);
        }
    
        public virtual ObjectResult<User> Users(Nullable<System.Guid> teamId)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Users", teamIdParameter);
        }
    
        public virtual ObjectResult<User> Users(Nullable<System.Guid> teamId, MergeOption mergeOption)
        {
            var teamIdParameter = teamId.HasValue ?
                new ObjectParameter("TeamId", teamId) :
                new ObjectParameter("TeamId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Users", mergeOption, teamIdParameter);
        }
        public virtual int SPInsertAccount(string accountName, string accountnumber, string email, string addressName, string addressLine, string city, string state, string country, Nullable<int> postalCode, Nullable<float> latitude, Nullable<float> longitude, string title, string firstName, string lastName, string contactTelephone, string emailAddress, string mobileNumber, String faxNumber, string location, Nullable<int> result)
        {
            var accountNameParameter = accountName != null ?
                new ObjectParameter("accountName", accountName) :
                new ObjectParameter("accountName", typeof(string));

            var accountnumberParameter = accountnumber != null ?
               new ObjectParameter("accountnumber", accountnumber) :
               new ObjectParameter("accountnumber", typeof(string));

            var emailParameter = email != null ?
              new ObjectParameter("email", email) :
              new ObjectParameter("email", typeof(string));

            var addressNameParameter = addressName != null ?
              new ObjectParameter("addressName", addressName) :
              new ObjectParameter("addressName", typeof(string));

            var addressLineParameter = addressLine != null ?
             new ObjectParameter("addressLine", addressLine) :
             new ObjectParameter("addressLine", typeof(string));

            var cityParameter = city != null ?
             new ObjectParameter("city", city) :
             new ObjectParameter("city", typeof(string));

            var stateParameter = state != null ?
             new ObjectParameter("state", state) :
             new ObjectParameter("state", typeof(string));

            var countryParameter = country != null ?
             new ObjectParameter("country", country) :
             new ObjectParameter("country", typeof(string));

            var postalCodeParameter = postalCode.HasValue ?
                new ObjectParameter("postalCode", postalCode) :
                new ObjectParameter("postalCode", typeof(int));

            var latitudeParameter = latitude.HasValue ?
               new ObjectParameter("latitude", latitude) :
               new ObjectParameter("latitude", typeof(float));

            var longitudeParameter = longitude.HasValue ?
               new ObjectParameter("longitude", longitude) :
               new ObjectParameter("longitude", typeof(float));

            var titleParameter = title != null ?
             new ObjectParameter("title", title) :
             new ObjectParameter("title", typeof(string));

            var firstNameParameter = firstName != null ?
            new ObjectParameter("firstName", firstName) :
            new ObjectParameter("firstName", typeof(string));

            var lastNameParameter = lastName != null ?
            new ObjectParameter("lastName", lastName) :
            new ObjectParameter("lastName", typeof(string));

            var contactTelephoneParameter = contactTelephone != null ?
            new ObjectParameter("contactTelephone", contactTelephone) :
            new ObjectParameter("contactTelephone", typeof(string));

            var emailAddressParameter = emailAddress != null ?
            new ObjectParameter("emailAddress", emailAddress) :
            new ObjectParameter("emailAddress", typeof(string));

            var mobileNumberParameter = mobileNumber != null ?
            new ObjectParameter("mobileNumber", mobileNumber) :
            new ObjectParameter("mobileNumber", typeof(string));

            var faxNumberParameter = faxNumber != null ?
            new ObjectParameter("faxNumber", faxNumber) :
            new ObjectParameter("faxNumber", typeof(string));

            var locationParameter = location != null ?
            new ObjectParameter("location", location) :
            new ObjectParameter("location", typeof(string));

            var resultParameter = result.HasValue ?
                new ObjectParameter("result", result) :
                new ObjectParameter("result", typeof(int));

            var retval = ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPInsertAccount", accountNameParameter, accountnumberParameter, emailParameter, addressNameParameter, addressLineParameter, cityParameter, stateParameter, countryParameter, postalCodeParameter, latitudeParameter, longitudeParameter, titleParameter, firstNameParameter, lastNameParameter, contactTelephoneParameter, emailAddressParameter, mobileNumberParameter, faxNumberParameter, locationParameter, resultParameter);

            return Int32.Parse(resultParameter.Value.ToString());

        }
    }
}
