using System;
using System.Linq;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.Services;
using AMS.Broker.Services.ServicesImplementations;
using NUnit.Framework;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace AMS.Broker.Test
{
    [TestFixture]
    public class VideoAnalyticsManagerServiceTest : BaseTest
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
        private readonly IVideoAnalyticsManagerService _videoAnalyticsManagerService;
        private IControllerService __controllerService;

        public VideoAnalyticsManagerServiceTest()
        {
            _systemService = BrokerService.Container.Resolve<ISystemService>();
            _lookupService = BrokerService.Container.Resolve<ILookupService>();
            _accountService = BrokerService.Container.Resolve<IAccountsService>();
            _siteService = BrokerService.Container.Resolve<ISitesService>();

            _videoAnalyticsManagerService = BrokerService.Container.Resolve<IVideoAnalyticsManagerService>();

            __controllerService = BrokerService.Container.Resolve<IControllerService>();

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
        public void Can_Start_VideoAnalytics()
        {
            DeviceDto cameraDevice =
                __controllerService.GetCameraDeviceByGuid(Guid.Parse("{ff0e79c3-9a33-47f5-9552-223a69a22bbe}"));

            NvrCameraDto nvrCameraDto = cameraDevice as NvrCameraDto;
            AnalyticsEventTemplateDto analyticsEventTemplateDto =
                _systemService.GetAnalyticsEventTemplate(nvrCameraDto.AnalyticsEventTemplateId.Value);
        }

    }
}
