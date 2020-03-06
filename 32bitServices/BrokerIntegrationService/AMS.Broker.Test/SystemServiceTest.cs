using System;
using System.Linq;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using NUnit.Framework;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace AMS.Broker.Test
{
    [TestFixture]
    public class SystemServiceTest : BaseTest
    {
        private static ISystemService _systemService;
        private static ILookupService _lookupService;
        private static IAccountsService _accountService;
        private static ISitesService _siteService;
        private static IEnumerable<CategoryDto> _categories;
        private static IEnumerable<CertaintyDto> _certainties;
        private static IEnumerable<EventQualifierDto> _qualifiers;
        private static IEnumerable<MessageTypeDto> _messageTypes;
        private static IEnumerable<StatusDto> _statuses;
        private static IEnumerable<UrgencyDto> _urgencies;
        private static IEnumerable<SeverityDto> _severities;
        private static IEnumerable<ResponseTypeDto> _responseTypes;
        private static IEnumerable<EventTypeTemplateDto> _eventTypes;
        private static IEnumerable<EventTypeTemplateDto> _alarmEventTypes;
        private static IEnumerable<EventCodeDto> _eventCodes;
        private static IEnumerable<AnalyticAlgorithmTypeDto> _algorithms;
        private static IEnumerable<ScopeDto> _scopes;

        public SystemServiceTest()
        {
            _systemService = BrokerService.Container.Resolve<ISystemService>();
            _lookupService = BrokerService.Container.Resolve<ILookupService>();
            _accountService = BrokerService.Container.Resolve<IAccountsService>();
            _siteService = BrokerService.Container.Resolve<ISitesService>();

            _eventTypes = _lookupService.GetEventTypes();
            _alarmEventTypes = _lookupService.GetAnalyticsEventTypes();
            _categories = _lookupService.GetCategories();
            _certainties = _lookupService.GetCertainties();
            _qualifiers = _lookupService.GetEventQualifiers();
            _messageTypes = _lookupService.GetMessageTypes();
            _statuses = _lookupService.GetStatuses();
            _urgencies = _lookupService.GetUrgencies();
            _severities = _lookupService.GetSeverities();
            _responseTypes = _lookupService.GetResponseTypes();
            _lookupService.GetEventGroups();
            _eventCodes = _lookupService.GetEventCodes();
            _algorithms = _lookupService.GetAnalyticAlgorithmTypes();
            _scopes = _lookupService.GetAlertScopes();
        }

        [Test]
        public void Can_Add_Get_Update_Delete_EventTemplate()
        {
            var eventTemplateDto = new EventTemplateDto
                {
                    Category = _categories.ToList()[0].Name,
                    Certainty = _certainties.ToList()[0].Name,
                    EventQualifierId = _qualifiers.ToList()[0].EventQualifierId,
                    EventCodeId = _eventCodes.ToList()[0].EventCode,
                    EventType = "Event Type",
                    EventTypeTeplateId = _eventTypes.ToList()[0].EventTypeTemplateId,
                    Headline = "Headline",
                    MessageType = _messageTypes.ToList()[0].Name,
                    ResponseType = _responseTypes.ToList()[0].Name,
                    Severity = _severities.ToList()[0].Name,
                    Status = _statuses.ToList()[0].Name,
                    Urgency = _urgencies.ToList()[0].Name

                };

            var eventTemplate = _systemService.SaveEventTemplate(eventTemplateDto);

            Assert.IsTrue(eventTemplate.EventTemplateId > 0);

            var getTemplate = _systemService.GetEventTemplate(eventTemplate.EventTemplateId);

            Assert.IsNotNull(getTemplate);

            Assert.IsTrue(getTemplate.Category == _categories.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Certainty == _certainties.ToList()[0].Name);
            Assert.IsTrue(getTemplate.EventQualifierId == _qualifiers.ToList()[0].EventQualifierId);
            Assert.IsTrue(getTemplate.EventCodeId == _eventCodes.ToList()[0].EventCode);
            Assert.IsTrue(getTemplate.EventType == "Event Type");
            Assert.IsTrue(getTemplate.EventTypeTeplateId == _eventTypes.ToList()[0].EventTypeTemplateId);
            Assert.IsTrue(getTemplate.Headline == "Headline");
            Assert.IsTrue(getTemplate.MessageType == _messageTypes.ToList()[0].Name);
            Assert.IsTrue(getTemplate.ResponseType == _responseTypes.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Severity == _severities.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Status == _statuses.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Urgency == _urgencies.ToList()[0].Name);

            getTemplate.Category = _categories.ToList()[1].Name;
            getTemplate.Certainty = _certainties.ToList()[1].Name;
            getTemplate.EventQualifierId = _qualifiers.ToList()[1].EventQualifierId;
            getTemplate.EventCodeId = _eventCodes.ToList()[1].EventCode;
            getTemplate.EventType = "Event Type 1";
            getTemplate.EventTypeTeplateId = _eventTypes.ToList()[0].EventTypeTemplateId;
            getTemplate.Headline = "Headline 1";
            getTemplate.MessageType = _messageTypes.ToList()[1].Name;
            getTemplate.ResponseType = _responseTypes.ToList()[1].Name;
            getTemplate.Severity = _severities.ToList()[1].Name;
            getTemplate.Status = _statuses.ToList()[1].Name;
            getTemplate.Urgency = _urgencies.ToList()[1].Name;

            var updatedTemplate = _systemService.SaveEventTemplate(getTemplate);

            Assert.IsTrue(updatedTemplate.Category == _categories.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Certainty == _certainties.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.EventQualifierId == _qualifiers.ToList()[1].EventQualifierId);
            Assert.IsTrue(updatedTemplate.EventCodeId == _eventCodes.ToList()[1].EventCode);
            Assert.IsTrue(updatedTemplate.EventType == "Event Type 1");
            Assert.IsTrue(updatedTemplate.EventTypeTeplateId == _eventTypes.ToList()[0].EventTypeTemplateId);
            Assert.IsTrue(updatedTemplate.Headline == "Headline 1");
            Assert.IsTrue(updatedTemplate.MessageType == _messageTypes.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.ResponseType == _responseTypes.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Severity == _severities.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Status == _statuses.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Urgency == _urgencies.ToList()[1].Name);

            var eventTemplateDeleted = _systemService.DeleteEventTemplate(updatedTemplate.EventTemplateId);
            Assert.IsTrue(eventTemplateDeleted);
        }

        [Test]
        public void Cannot_Add_EventTemplate_With_Same_EventCodeId_EventTypeTemplateId()
        {
            var eventTemplateDto = new EventTemplateDto
            {
                Category = _categories.ToList()[0].Name,
                Certainty = _certainties.ToList()[0].Name,
                EventQualifierId = _qualifiers.ToList()[0].EventQualifierId,
                EventCodeId = _eventCodes.ToList()[0].EventCode,
                EventType = "Event Type",
                EventTypeTeplateId = _eventTypes.ToList()[0].EventTypeTemplateId,
                Headline = "Headline",
                MessageType = _messageTypes.ToList()[0].Name,
                ResponseType = _responseTypes.ToList()[0].Name,
                Severity = _severities.ToList()[0].Name,
                Status = _statuses.ToList()[0].Name,
                Urgency = _urgencies.ToList()[0].Name

            };

            var eventTemplate = _systemService.SaveEventTemplate(eventTemplateDto);

            var duplicateEventTemplateDto = new EventTemplateDto
            {
                Category = _categories.ToList()[0].Name,
                Certainty = _certainties.ToList()[0].Name,
                EventQualifierId = _qualifiers.ToList()[0].EventQualifierId,
                EventCodeId = _eventCodes.ToList()[0].EventCode,
                EventType = "Event Type",
                EventTypeTeplateId = _eventTypes.ToList()[0].EventTypeTemplateId,
                Headline = "Headline",
                MessageType = _messageTypes.ToList()[0].Name,
                ResponseType = _responseTypes.ToList()[0].Name,
                Severity = _severities.ToList()[0].Name,
                Status = _statuses.ToList()[0].Name,
                Urgency = _urgencies.ToList()[0].Name

            };

            try
            {
                _systemService.SaveEventTemplate(duplicateEventTemplateDto);
                Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(true);
            }

            var eventTemplateDeleted = _systemService.DeleteEventTemplate(eventTemplate.EventTemplateId);
            Assert.IsTrue(eventTemplateDeleted);
        }

        [Test]
        public void Can_Add_InterfaceNvr()
        {
            var accounts = _accountService.GetAccounts();

            var accountDto = new AccountDto();
            var siteDto = new SiteDto();

            foreach (var account in accounts)
            {
                var sites = _siteService.GetSiteForAccount(account.AccountId);

                if (sites != null && sites.Any())
                {
                    accountDto = account;
                    siteDto = sites.FirstOrDefault();
                    break;
                }
            }

            var sysIterface = new InterfaceDto
                {
                    AccountId = accountDto.AccountId,
                    Name = "Nvr Interface Name",
                    Description = "Nvr",
                    InterfaceTypeId = 1
                };

            var addedInterface = _systemService.AddInterface(sysIterface, accountDto.AccountId, siteDto.SiteId);
            var getInterface = _systemService.GetInterface(addedInterface.InterfaceId);

            Assert.IsNotNull(getInterface);

            var newDeviceDto = new NvrCameraDto()
                {
                    Altitude = 100,
                    Description = "Device Description",
                    ExternalId = "External Id",
                    LocationDescription = "Location Description",
                    InterfaceId = getInterface.InterfaceId,
                    Lat = 100,
                    Long = 100,
                    SiteId = siteDto.SiteId,
                    Type = "FireAlarm",
                    ActiveAlert = false,
                    Name = "Device Name",
                    FPS = 21,
                    AnalyticAlgorithmType = _algorithms.First(),
                    AnalyticAlgorithmTypeId = _algorithms.First().AnalyticAlgorithmId,
                    AlarmDelay = 60,
                    Version = "1.0.0.167",
                    MaxBlobSize = 1000,
                    MinBlobSize = 100,
                    UpdateRate = (decimal)20.5,
                    Width = 100,
                    Height = 100,
                    ZoneRows = 13,
                    ZoneColumns = 14,
                    ZoneData = null
                };

            var addedDeviceDto = _systemService.AddDeviceToInterface(newDeviceDto, getInterface.InterfaceId);

            Assert.NotNull(addedDeviceDto);

            var updayedDevice = _systemService.UpdateDevice(addedDeviceDto, getInterface.InterfaceId);

            bool deletedDevice = _systemService.DeleteDevice(updayedDevice.DeviceId);

            Assert.IsTrue(deletedDevice);

            bool deletedInterface = _systemService.Delete(getInterface.InterfaceId);

            Assert.IsTrue(deletedInterface);
        }

        [Test]
        public void Can_Add_InterfaceDevice()
        {
            var accounts = _accountService.GetAccounts();

            var accountDto = new AccountDto();
            var siteDto = new SiteDto();

            foreach (var account in accounts)
            {
                var sites = _siteService.GetSiteForAccount(account.AccountId);

                if (sites != null && sites.Any())
                {
                    accountDto = account;
                    siteDto = sites.FirstOrDefault();
                    break;
                }
            }


            var sysIterface = new InterfaceDto
            {
                AccountId = accountDto.AccountId,
                Name = "Interface Name",
                Description = "Alarm Panel",
                InterfaceTypeId = 2
            };

            var addedInterface = _systemService.AddInterface(sysIterface, accountDto.AccountId, siteDto.SiteId);
            var getInterface = _systemService.GetInterface(addedInterface.InterfaceId);

            Assert.IsNotNull(getInterface);

            var newDeviceDto = new DeviceDto
            {
                Altitude = 100,
                Description = "Device Description",
                ExternalId = "External Id",
                LocationDescription = "Location Description",
                InterfaceId = getInterface.InterfaceId,
                Lat = 100,
                Long = 100,
                /*Metadata = "<Metadata>Metadata-Test-Method</Metadata>",*/
                SiteId = siteDto.SiteId,
                Type = "FireAlarm",
                ActiveAlert = false,
                Name = "Device Name"
            };

            var addedDeviceDto = _systemService.AddDeviceToInterface(newDeviceDto, getInterface.InterfaceId);

            Assert.NotNull(addedDeviceDto);

            bool deletedDevice = _systemService.DeleteDevice(addedDeviceDto.DeviceId);

            Assert.IsTrue(deletedDevice);

            bool deletedInterface = _systemService.Delete(getInterface.InterfaceId);

            Assert.IsTrue(deletedInterface);
        }

        [Test]
        public void Can_Get_NvrCameraDevice()
        {
            var camera = _systemService.GetDeviceById(10026);
        }

        [Test]
        public void Can_Add_Get_Update_Delete_AnalyticsEventTemplate()
        {
            var eventTemplateDto = new AnalyticsEventTemplateDto()
            {
                EventTypeTeplateId = _alarmEventTypes.ToList()[0].EventTypeTemplateId,
                Name = "Test_AnalyticsEventTypeTemplateDto",
                Headline = "Headline",
                EventType = "Event Type",
                MessageType = _messageTypes.ToList()[0].Name,
                Status = _statuses.ToList()[0].Name,
                Category = _categories.ToList()[0].Name,
                Urgency = _urgencies.ToList()[0].Name,
                Severity = _severities.ToList()[0].Name,
                Certainty = _certainties.ToList()[0].Name,
                ResponseType = _responseTypes.ToList()[0].Name,
                Description = "Desctription",
                Instruction = "Instruction",
                Scope = _scopes.ToList()[0].Name,
                AnalyticAlgorithmTypeId = _algorithms.ToList()[0].AnalyticAlgorithmId,
            };

            var eventTemplate = _systemService.SaveAnalyticsEventTemplate(eventTemplateDto);

            Assert.IsTrue(eventTemplate.AnalyticsEventTemplateId > 0);

            var getTemplate = _systemService.GetAnalyticsEventTemplate(eventTemplate.AnalyticsEventTemplateId);

            Assert.IsNotNull(getTemplate);

            Assert.IsTrue(getTemplate.EventTypeTeplateId == _alarmEventTypes.ToList()[0].EventTypeTemplateId);
            Assert.IsTrue(getTemplate.Name == "Test_AnalyticsEventTypeTemplateDto");
            Assert.IsTrue(getTemplate.Headline == "Headline");
            Assert.IsTrue(getTemplate.EventType == "Event Type");
            Assert.IsTrue(getTemplate.MessageType == _messageTypes.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Status == _statuses.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Category == _categories.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Urgency == _urgencies.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Severity == _severities.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Certainty == _certainties.ToList()[0].Name);
            Assert.IsTrue(getTemplate.ResponseType == _responseTypes.ToList()[0].Name);
            Assert.IsTrue(getTemplate.Description == "Desctription");
            Assert.IsTrue(getTemplate.Instruction == "Instruction");
            Assert.IsTrue(getTemplate.Scope == _scopes.ToList()[0].Name);
            Assert.IsTrue(getTemplate.AnalyticAlgorithmTypeId == _algorithms.ToList()[0].AnalyticAlgorithmId);


            getTemplate.EventTypeTeplateId = _alarmEventTypes.ToList()[0].EventTypeTemplateId;
            getTemplate.Name = "Test_AnalyticsEventTypeTemplateDto_Updated";
            getTemplate.Headline = "Headline_Updated";
            getTemplate.EventType = "Event Type_Updated";
            getTemplate.MessageType = _messageTypes.ToList()[1].Name;
            getTemplate.Status = _statuses.ToList()[1].Name;
            getTemplate.Category = _categories.ToList()[1].Name;
            getTemplate.Urgency = _urgencies.ToList()[1].Name;
            getTemplate.Severity = _severities.ToList()[1].Name;
            getTemplate.Certainty = _certainties.ToList()[1].Name;
            getTemplate.ResponseType = _responseTypes.ToList()[1].Name;
            getTemplate.Description = "Desctription_Updated";
            getTemplate.Instruction = "Instruction_Updated";
            getTemplate.Scope = _scopes.ToList()[1].Name;
            getTemplate.AnalyticAlgorithmTypeId = _algorithms.ToList()[1].AnalyticAlgorithmId;

            var updatedTemplate = _systemService.SaveAnalyticsEventTemplate(getTemplate);

            Assert.IsTrue(updatedTemplate.AnalyticsEventTemplateId == getTemplate.AnalyticsEventTemplateId);
            Assert.IsTrue(updatedTemplate.EventTypeTeplateId == _alarmEventTypes.ToList()[0].EventTypeTemplateId);
            Assert.IsTrue(updatedTemplate.Name == "Test_AnalyticsEventTypeTemplateDto_Updated");
            Assert.IsTrue(updatedTemplate.Headline == "Headline_Updated");
            Assert.IsTrue(updatedTemplate.EventType == "Event Type_Updated");
            Assert.IsTrue(updatedTemplate.MessageType == _messageTypes.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Status == _statuses.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Category == _categories.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Urgency == _urgencies.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Severity == _severities.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Certainty == _certainties.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.ResponseType == _responseTypes.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.Description == "Desctription_Updated");
            Assert.IsTrue(updatedTemplate.Instruction == "Instruction_Updated");
            Assert.IsTrue(updatedTemplate.Scope == _scopes.ToList()[1].Name);
            Assert.IsTrue(updatedTemplate.AnalyticAlgorithmTypeId == _algorithms.ToList()[1].AnalyticAlgorithmId);

            var eventTemplateDeleted = _systemService.DeleteAnalyticsEventTemplate(updatedTemplate.AnalyticsEventTemplateId);
            Assert.IsTrue(eventTemplateDeleted);
        }
    }
}
