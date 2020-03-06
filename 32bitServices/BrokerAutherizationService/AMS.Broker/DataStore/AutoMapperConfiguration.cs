using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using AMS.Broker.AutherizationService.AlertProcessingServiceReference;
using AMS.Broker.Contracts.DTO;
using AutoMapper;
using AlertDTO = AMS.Broker.Contracts.DTO.Alert;
using AreaDTO = AMS.Broker.Contracts.DTO.Area;
using CategoryDTO = AMS.Broker.Contracts.DTO.Category;
using GroupDTO = AMS.Broker.Contracts.DTO.Group;
using InfoDTO = AMS.Broker.Contracts.DTO.Info;
using ResponseTypeDTO = AMS.Broker.Contracts.DTO.ResponseType;
using StationDTO = AMS.Broker.Contracts.DTO.Station;
using ResourceDTO = AMS.Broker.Contracts.DTO.Resource;
using ZoneDTO = AMS.Broker.Contracts.DTO.Zone;
using ZoneLocationsDTO = AMS.Broker.Contracts.DTO.ZoneLocations;
using SiteDTO = AMS.Broker.Contracts.DTO.SiteDto;
using ValuesLookUpDTO = AMS.Broker.Contracts.DTO.ValuesLookUp;

namespace AMS.Broker.AutherizationService.DataStore
{
    public static class AutoMapperConfiguration
    {
        public static object EntityCollection { get; set; }

        public static void CreateAllMaps()
        {
            try
            {
                Mapper.CreateMap<ZoneLocations, ZoneLocationsDTO>();

                Mapper.CreateMap<AccountType, AccountTypeDto>();

                Mapper.CreateMap<AccountInvoice, AccountInvoiceDto>();

                Mapper.CreateMap<Address, AddressDto>();

                Mapper.CreateMap<ContactType, ContactTypeDto>();

                Mapper.CreateMap<ContactMethod, ContactMethodDto>();

                Mapper.CreateMap<DeliveryMethod, DeliveryMethodDto>();

                Mapper.CreateMap<PaymentMethod, PaymentMethodDto>();

                Mapper.CreateMap<AccountBilling, AccountBillingDto>();

                Mapper.CreateMap<Frequency, FrequencyDto>();

                Mapper.CreateMap<Gender, GenderDto>();

                Mapper.CreateMap<Person, PersonDto>().ForMember(x => x.PreferedContactTypes,
                                                                x => x.MapFrom(y => y.PersonContactType))
                      .AfterMap(
                          (db, dto) =>
                          {
                              var contactDtos = db.Contact.Select(Mapper.Map<ContactDto>).ToList();
                              dto.Contacts = contactDtos;

                              if (contactDtos.Count > 0)
                              {
                                  dto.PrimaryContact = contactDtos[0];
                              }
                          });

                Mapper.CreateMap<PersonContactType, PersonContactTypeDto>();


                Mapper.CreateMap<ServicePackage, ServicePackageDto>();


                Mapper.CreateMap<Contracts.DTO.UserLocation, UserLocation>();
                Mapper.CreateMap<UserLocation, Contracts.DTO.UserLocation>();

                Mapper.CreateMap<NvrDto, NVR>().ForMember(x => x.Port,
                                                          x =>
                                                          x.MapFrom(
                                                              y =>
                                                              y.Port == 0
                                                                  ? new int?() 
                                                                  : y.Port));
                Mapper.CreateMap<NVR, NvrDto>().ForMember(x => x.Port,
                                                          x => x.MapFrom(y => y.Port.HasValue ? y.Port.Value : 80));

                CreateSiteMapping();

                Mapper.CreateMap<DeviceType, DeviceTypeDto>()
                      .ForMember(dto => dto.Name, opt => opt.MapFrom(db => db.Description));

                Mapper.CreateMap<Device, DeviceDto>()
                      .Include<NvrCamera, NvrCameraDto>()
                      .ForSourceMember(device => device.Site, opt => opt.Ignore())
                      .ForSourceMember(device => device.Interface, opt => opt.Ignore())
                      .ForSourceMember(device => device.Event, opt => opt.Ignore())
                      .ForSourceMember(device => device.DevicesInZone, opt => opt.Ignore())
                      .ForSourceMember(device => device.NVR, opt => opt.Ignore())
                      .ForSourceMember(device => device.IncidentReportCamera, opt => opt.Ignore())
                      .ForSourceMember(device => device.Alert, opt => opt.Ignore());
                     // .ForSourceMember(device => device.DeviceVAnalyticsSchedule, opt => opt.Ignore());

                Mapper.CreateMap<DeviceDto, Device>().Include<NvrCameraDto, NvrCamera>().AfterMap((dto, db) => dto.CameraGUID = db.CameraGuid);
                //Mapper.CreateMap<DeviceDto, Device>().Include<DeviceVAnalyticsScheduleDTO, DeviceVAnalyticsSchedule>().AfterMap((dto, db) => dto.DeviceId = db.DeviceId);
                Mapper.CreateMap<NvrCamera, NvrCameraDto>()
                      .ForSourceMember(camera => camera.AnalyticsEventTemplate, opt => opt.Ignore());
                Mapper.CreateMap<AnalyticAlgorithmType, AnalyticAlgorithmTypeDto>()
                      .ForSourceMember(type => type.AccountAnalyticsAlgorithmType, opt => opt.Ignore())
                      .ForSourceMember(type => type.NvrCamera, opt => opt.Ignore());

                Mapper.CreateMap<DeviceTypeDto, DeviceType>()
                      .ForMember(dto => dto.Description, opt => opt.MapFrom(db => db.Name));
                Mapper.CreateMap<NvrCameraDto, NvrCamera>();
                Mapper.CreateMap<AnalyticAlgorithmTypeDto, AnalyticAlgorithmType>();

                Mapper.CreateMap<Station, StationDTO>();

                Mapper.CreateMap<Zone, GroupDTO>();
                Mapper.CreateMap<Zone, ZoneDTO>().AfterMap(
                    (db, dto) => dto.ZoneLocationCollection = Mapper.Map<List<ZoneLocationsDTO>>(db.ZoneLocation))
                    .AfterMap(
                        (db, dto) =>
                        dto.DeviceCollection = Mapper.Map<List<DeviceDto>>(db.DevicesInZone.Where(x => x.Device != null).Select(x => x.Device)));

                Mapper.CreateMap<ZoneLocation, ZoneLocationsDTO>();
                //.AfterMap((db, dto) => dto.DevicesCollection = Mapper.Map<ICollection<DeviceDTO>>(db.DevicesInGroups));

                Mapper.CreateMap<Alert, AlertDTO>()
                    .AfterMap((db, dto) => dto.InfoCollection = Mapper.Map<List<InfoDTO>>(db.Info))
                    .AfterMap((db, dto) => dto.DeviceDto = Mapper.Map<DeviceDto>(db.Device))
                    .AfterMap(
                        (db, dto) =>
                        {
                            if (db.Info == null || !db.Info.Any()) return;

                            switch (db.Info.First().SeverityId)
                            {
                                case "Extreme":
                                    dto.Severity = Contracts.DTO.Severity.Extreme;
                                    break;
                                case "Moderate":
                                    dto.Severity = Contracts.DTO.Severity.Moderate;
                                    break;
                                case "Severe":
                                    dto.Severity = Contracts.DTO.Severity.Severe;
                                    break;
                                case "Minor":
                                    dto.Severity = Contracts.DTO.Severity.Minor;
                                    break;
                                case "Unknown":
                                    dto.Severity = Contracts.DTO.Severity.Unknown;
                                    break;
                            }
                            //if (db.Device != null && db.Device.Site != null)
                            //    dto.DeviceDto.Site = Mapper.Map<SiteDto>(db.Device.Site);
                        });
                Mapper.CreateMap<Info, InfoDTO>()
                    .AfterMap(
                        (db, dto) =>
                        dto.ParametersCollection =
                        db.Parameter.Select(x => new Contracts.DTO.Parameter(x.Name, x.Value)).ToList())
                    .AfterMap(
                        (db, dto) => dto.ResponseTypesCollection = Mapper.Map<List<ResponseTypeDTO>>(db.InfoesResponseType))
                    .AfterMap((db, dto) => dto.CategoriesCollection = Mapper.Map<List<CategoryDTO>>(db.InfoesCategory))
                    .AfterMap((db, dto) => dto.AreasCollection = Mapper.Map<List<AreaDTO>>(db.Area))
                    .AfterMap((db, dto) => dto.ResourcesCollection = Mapper.Map<List<ResourceDTO>>(db.Resource));
                Mapper.CreateMap<InfoesCategory, CategoryDTO>()
                    .ConvertUsing(x => (CategoryDTO)Enum.Parse(typeof(CategoryDTO), x.CategoryId));
                Mapper.CreateMap<InfoesResponseType, ResponseTypeDTO>()
                    .ConvertUsing(x => (ResponseTypeDTO)Enum.Parse(typeof(ResponseTypeDTO), x.ResponseType));
                Mapper.CreateMap<Resource, ResourceDTO>();
                Mapper.CreateMap<Area, AreaDTO>();

                Mapper.CreateMap<IncidentReportAlert, AlertDTO>(); //tbgeolocation

                Mapper.CreateMap<IncidentReport, Contracts.DTO.IncidentReport>()
                      .ForMember(y => y.Id, y => y.MapFrom(x => x.IncidentReportId))
                      .ForMember(y => y.Status, y => y.MapFrom(x => x.IncidentReportStatus.Last().Status))
                      .ForMember(y => y.Alerts, y => y.MapFrom(x => x.IncidentReportAlert))
                      .ForMember(y => y.CreationDate, y => y.MapFrom(x => x.CreateDate))
                      .ForMember(y => y.CreationDateAsString, y => y.MapFrom(x => x.CreateDate.ToString()))
                      .AfterMap(
                          (db, dto) =>
                          {
                              dto.Cameras =
                                  Mapper.Map<List<DeviceDto>>(db.IncidentReportCamera.Select(x => x.Device).ToList());
                          })
                      .AfterMap(
                          ((db, dto) =>
                              {
                                  var reports = db.IncidentReportReference.Select(incidentReportReferencese => incidentReportReferencese.IncidentReportReferenceId).ToList();
                                  dto.IncidentReports = reports.ToList();
                              }));

                //trupti190216
                Mapper.CreateMap<IncidentReportAlert, IncidentReportAlertDTO>();
                Mapper.CreateMap<IncidentReportAlertDTO, IncidentReportAlert>();
                //


                Mapper.CreateMap<ValuesLookUp, ValuesLookUpDTO>();

                /// Map back form DTO
                //Mapper.CreateMap<Zone, ZoneDTO>().AfterMap((db, dto) => dto.ZoneLocationCollection = Mapper.Map<List<ZoneLocationsDTO>>(db.ZoneLocations))
                //   .AfterMap((db, dto) => dto.DeviceCollection = Mapper.Map<List<DeviceDTO>>(db.DevicesInZone.Select(x => x.Device)));
                Mapper.CreateMap<ZoneDTO, Zone>()
                    .AfterMap(
                        (dto, db) =>
                        db.ZoneLocation = Mapper.Map<EntityCollection<ZoneLocation>>(dto.ZoneLocationCollection))
                    .AfterMap(
                        (dto, db) =>
                        db.DevicesInZone =
                        Mapper.Map<EntityCollection<DevicesInZone>>(dto.DeviceCollection.Select(x => new DevicesInZone
                                                                                                         {
                                                                                                             DeviceId =
                                                                                                                 x.DeviceId
                                                                                                         })));
                Mapper.CreateMap<ScopeDto, Scope>();

                Mapper.CreateMap<TimeZone, TimeZoneDto>();

                Mapper.CreateMap<ZoneLocationsDTO, ZoneLocation>();

                Mapper.CreateMap<AccountTypeDto, AccountType>();

                Mapper.CreateMap<AccountInvoiceDto, AccountInvoice>();

                Mapper.CreateMap<AddressDto, Address>();

                Mapper.CreateMap<ContactTypeDto, ContactType>();

                Mapper.CreateMap<ContactMethodDto, ContactMethodDto>();

                Mapper.CreateMap<DeliveryMethodDto, DeliveryMethod>();

                Mapper.CreateMap<FrequencyDto, Frequency>();

                Mapper.CreateMap<GenderDto, Gender>();

                Mapper.CreateMap<PersonDto, Person>().ForMember(x => x.PersonContactType, x => x.MapFrom(y => y.PreferedContactTypes)); ;

                Mapper.CreateMap<PersonContactTypeDto, PersonContactType>();

                Mapper.CreateMap<ServicePackageDto, ServicePackage>();

                Mapper.CreateMap<AlertDTO, Alert>()
                    .AfterMap((dto, db) => db.Info = Mapper.Map<EntityCollection<Info>>(dto.InfoCollection));

                Mapper.CreateMap<AreaDTO, Area>()
                    .ForMember(x => x.Description, x => x.MapFrom(y => y.Description ?? string.Empty));

                Mapper.CreateMap<InfoDTO, Info>()
                    .AfterMap((dto, db) =>
                                  {
                                      foreach (Contracts.DTO.Parameter eventCode in dto.ParametersCollection)
                                          db.Parameter.Add(new Parameter
                                                               {
                                                                   Name = eventCode.Key,
                                                                   Value = eventCode.Value,
                                                                   Info = db
                                                               });
                                  })
                    .AfterMap((dto, db) =>
                                  {
                                      db.InfoesResponseType =
                                          Mapper.Map<EntityCollection<InfoesResponseType>>(dto.ResponseTypesCollection);
                                      foreach (InfoesResponseType item in db.InfoesResponseType)
                                          item.Info = db;
                                  })
                    .AfterMap((dto, db) =>
                                  {
                                      db.InfoesCategory =
                                          Mapper.Map<EntityCollection<InfoesCategory>>(dto.CategoriesCollection);
                                      foreach (InfoesCategory cat in db.InfoesCategory)
                                          cat.Info = db;
                                  })
                    .AfterMap(
                        (dto, db) => { db.Resource = Mapper.Map<EntityCollection<Resource>>(dto.ResourcesCollection); })
                    .AfterMap((dto, db) => db.Area = Mapper.Map<EntityCollection<Area>>(dto.AreasCollection));

                Mapper.CreateMap<CategoryDTO, InfoesCategory>()
                    .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.ToString()));
                Mapper.CreateMap<ResponseTypeDTO, InfoesResponseType>()
                    .ForMember(x => x.ResponseType, x => x.MapFrom(y => y.ToString()));
                Mapper.CreateMap<ResourceDTO, Resource>()
                    .ForMember(x => x.Description, x => x.MapFrom(y => y.Description ?? String.Empty))
                    .ForMember(x => x.Digest, x => x.MapFrom(y => y.Digest ?? String.Empty))
                    .ForMember(x => x.MimeType, x => x.MapFrom(y => y.MimeType ?? String.Empty))
                    .ForMember(x => x.Uri, x => x.MapFrom(y => y.Uri ?? String.Empty))
                    .ForMember(x => x.DerefUri, x => x.MapFrom(y => y.DerefUri ?? String.Empty));

                Mapper.CreateMap<AlertDTO, AlertProcessingServiceReference.Alert>();
                Mapper.CreateMap<InfoDTO, AlertInfo>();
                Mapper.CreateMap<AreaDTO, AlertInfoArea>();

                Mapper.CreateMap
                    <Contracts.DTO.Parameter, AlertInfoParameter>();


                Mapper.CreateMap<AlertInfoArea, AreaDTO>();

                Mapper.CreateMap<ServicePackage, ServicePackageDto>();
                Mapper.CreateMap<AccountType, AccountTypeDto>();
                Mapper.CreateMap<Frequency, FrequencyDto>();
                Mapper.CreateMap<Contact, ContactDto>().ForMember(x => x.PreferedContatMethods, x => x.MapFrom(y => y.PreferedContatMethod));
                Mapper.CreateMap<PreferedContatMethod, PreferedContatMethodDto>();
                Mapper.CreateMap<AccountInvoice, AccountInvoiceDto>();
                Mapper.CreateMap<Account, AccountDto>()
                      .ForMember(x => x.ParentAccount, x => x.MapFrom(y => y.Account2))
                      .ForMember(x => x.ChildAccounts, x => x.MapFrom(y => y.Account1))
                      .AfterMap((db, dto) =>
                          {
                              if (db.Person == null || !db.Person.Any()) return;
                              var person = db.Person.First();
                              dto.PrimaryAccountAdministrator = Mapper.Map<PersonDto>(person);
                          });
                
                //trupti21july15 Geo
                Mapper.CreateMap<tblGeoFencingAlert, tblGeoFencingAlertDTO>();
                Mapper.CreateMap<tblGeoFencingAlertDTO, tblGeoFencingAlert>();

                //trupti21Aug15 Device status
                Mapper.CreateMap<tblCameraStatus, tblCameraStatusDto>();
                Mapper.CreateMap<tblCameraStatusDto, tblCameraStatus>();

                //trupti12dec15
                Mapper.CreateMap<tblPTZPresetAssociation, tblPTZPresetAssociationDto>();
                Mapper.CreateMap<tblPTZPresetAssociationDto, tblPTZPresetAssociation>();
                //


                //amit 06082015
               Mapper.CreateMap<tblgeofencesequence, tblgeofencesequenceDTO>();
               Mapper.CreateMap<tblgeofencesequenceDTO, tblgeofencesequence>();

                Mapper.CreateMap<tblMeonMembers, tblMeonMembersDTO>();
                Mapper.CreateMap<tblMeonMembersDTO, tblMeonMembers>();


                Mapper.CreateMap<tblGeoFencingHistory, tblGeoFencingHistoryDTO>();
                Mapper.CreateMap<tblGeoFencingHistoryDTO, tblGeoFencingHistory>().ForMember(x => x.Eventno, x => x.MapFrom(y => y.Eventno ?? 0)); ;

                Mapper.CreateMap<tblDeviceGeoTrackHistory, tblDeviceGeoTrackHistoryDTO>();
                Mapper.CreateMap<tblDeviceGeoTrackHistoryDTO, tblDeviceGeoTrackHistory>();

                Mapper.CreateMap<tbgeolocation, tbgeolocationDTO>();
                Mapper.CreateMap<tbgeolocationDTO, tbgeolocation>();

                //trupti26Aug15 Device status
                Mapper.CreateMap<tblUserSiteMaster, tblUserSiteMasterDto>();
                Mapper.CreateMap<tblUserSiteMasterDto, tblUserSiteMaster>();

                Mapper.CreateMap<tblRssAlertMaster, tblRssAlertMasterDto>();
                Mapper.CreateMap<tblRssAlertMasterDto, tblRssAlertMaster>();

                Mapper.CreateMap<tblRssFeed, tblRssFeedDto>();
                Mapper.CreateMap<tblRssFeedDto, tblRssFeed>();
                //


                //
                //trupti24Aug15 Device status
                Mapper.CreateMap<tblANPRMaster, tblANPRMasterDto>();
                Mapper.CreateMap<tblANPRMasterDto, tblANPRMaster>();

                Mapper.CreateMap<tblANPRTransDetails, tblANPRTransDetailsDto>();
                Mapper.CreateMap<tblANPRTransDetailsDto, tblANPRTransDetails>();

                //trupti180516
                Mapper.CreateMap<tblMatrixEvtInfo, tblMatrixEvtInfoDTO>();
                Mapper.CreateMap<tblMatrixEvtInfoDTO, tblMatrixEvtInfo>();
                //

                //amit 09 Sept 15
                Mapper.CreateMap<tblAnaLyticsStatus, tblAnaLyticsStatusDTO>();
                Mapper.CreateMap<tblAnaLyticsStatusDTO, tblAnaLyticsStatus>();
                //

                //amit 09 Sept 15
                Mapper.CreateMap<AlarmPanelTypeMaster, AlarmPanelTypeMasterDTO>();
                Mapper.CreateMap<AlarmPanelTypeMasterDTO, AlarmPanelTypeMaster>();
                //

                //amit 14 April 16
                Mapper.CreateMap<tblDisasterManagement, tblDisasterManagementDTO>();
                Mapper.CreateMap<tblDisasterManagementDTO, tblDisasterManagement>();
                //

                //Trupti 15 April 16
                Mapper.CreateMap<tblCrimeHeatMap, tblCrimeHeatMapDTO>();
                Mapper.CreateMap<tblCrimeHeatMapDTO, tblCrimeHeatMap>();

                Mapper.CreateMap<tblDisasterMap, tblDisasterMapDTO>();
                Mapper.CreateMap<tblDisasterMapDTO, tblDisasterMap>();

                Mapper.CreateMap<tblSwachchaBharatMap, tblSwachchaBharatMapDTO>();
                Mapper.CreateMap<tblSwachchaBharatMapDTO, tblSwachchaBharatMap>();

                Mapper.CreateMap<SP_SwatchBharatDashboard_Result, SP_SwatchBharatDashboard_ResultDTO>();
                Mapper.CreateMap<SP_SwatchBharatDashboard_ResultDTO, SP_SwatchBharatDashboard_Result>();

                Mapper.CreateMap<tblSmartCityStreetElec, tblSmartCityStreetElecDTO>();
                Mapper.CreateMap<tblSmartCityStreetElecDTO, tblSmartCityStreetElec>();

                Mapper.CreateMap<tblSmartCityStreetLight, tblSmartCityStreetLightDTO>();
                Mapper.CreateMap<tblSmartCityStreetLightDTO, tblSmartCityStreetLight>();
                //

                Mapper.CreateMap<tblCameraBookMark, tblCameraBookMarkDto>();
                Mapper.CreateMap<tblCameraBookMarkDto, tblCameraBookMark>();

                Mapper.CreateMap<SPTest_Result, SPTest_ResultDto>();  //trupti11sept15
                Mapper.CreateMap<SPTest_ResultDto, SPTest_Result>();

                Mapper.CreateMap<SPSearch_Result, SPSearch_ResultDto>();  //trupti11sept15
                Mapper.CreateMap<SPSearch_ResultDto, SPSearch_Result>();

                Mapper.CreateMap<SPRDLLocationAlertDashboard_Result, DashBoardDto>();  //amit 20 jan 16
                Mapper.CreateMap<DashBoardDto, SPRDLLocationAlertDashboard_Result>();


                Mapper.CreateMap<SPRDLAlertTypeDashBoard_Result, DashBoardDto>();  //amit 21 jan 16
                Mapper.CreateMap<DashBoardDto, SPRDLAlertTypeDashBoard_Result>();

                 Mapper.CreateMap<SP_RDLLocationVSDevice_Result, DashBoardDto>();  //amit 21 jan 16
                 Mapper.CreateMap<DashBoardDto, SP_RDLLocationVSDevice_Result>();

                 Mapper.CreateMap<SPRDLAlertStatusDashboard_Result, DashBoardDto>();  //amit 21 jan 16
                 Mapper.CreateMap<DashBoardDto, SPRDLAlertStatusDashboard_Result>();

                 Mapper.CreateMap<SPRDLUserAlertDashboard_Result, DashBoardDto>();  //amit 21 jan 16
                 Mapper.CreateMap<DashBoardDto, SPRDLUserAlertDashboard_Result>();

                 Mapper.CreateMap<SPRDLCummalativeDashBoard_Result, DashBoardDto>();  //amit 21 jan 16
                 Mapper.CreateMap<DashBoardDto, SPRDLCummalativeDashBoard_Result>();


                 Mapper.CreateMap<SPRDLLocationDeviceDashboard_Result, DeviceLocationDto>();  //amit 21 jan 16
                Mapper.CreateMap<DeviceLocationDto, SPRDLLocationDeviceDashboard_Result>();

                Mapper.CreateMap<tblDvrChanelMaster, tblDvrChanelMasterDto>(); //trupti160116
                Mapper.CreateMap<tblDvrChanelMasterDto, tblDvrChanelMaster>();

                //
                Mapper.CreateMap<tblWeatherchastronomy, tblWeatherchastronomyDTO>();
                Mapper.CreateMap<tblWeatherchastronomyDTO, tblWeatherchastronomy>();

                Mapper.CreateMap<tblweatherchcurrent, tblweatherchcurrentDTO>();
                Mapper.CreateMap<tblweatherchcurrentDTO, tblweatherchcurrent>();

                Mapper.CreateMap<tblWeatherchforecast, tblWeatherchforecastDTO>();
                Mapper.CreateMap<tblWeatherchforecastDTO, tblWeatherchforecast>();

                Mapper.CreateMap<tblWeatherchforecastdetails, tblWeatherchforecastdetailsDTO>();
                Mapper.CreateMap<tblWeatherchforecastdetailsDTO, tblWeatherchforecastdetails>();

                Mapper.CreateMap<tblWeatherCityName, tblWeatherCityNameDTO>();
                Mapper.CreateMap<tblWeatherCityNameDTO, tblWeatherCityName>();

                Mapper.CreateMap<tblWeatherthreshold, tblWeatherthresholdDTO>();
                Mapper.CreateMap<tblWeatherthresholdDTO, tblWeatherthreshold>();

                Mapper.CreateMap<tblWeatherhourlyforecast, tblWeatherhourlyforecastDTO>();
                Mapper.CreateMap<tblWeatherhourlyforecastDTO, tblWeatherhourlyforecast>();

                Mapper.CreateMap<SP_RDLHourlyWeatherReport_Result, SP_RDLHourlyWeatherReport_ResultDTO>();
                Mapper.CreateMap<SP_RDLHourlyWeatherReport_ResultDTO, SP_RDLHourlyWeatherReport_Result>();


                //

                Mapper.CreateMap<ServicePackageDto, ServicePackage>();
                Mapper.CreateMap<DeliveryMethodDto, DeliveryMethod>();
                Mapper.CreateMap<PaymentMethodDto, PaymentMethod>();
                Mapper.CreateMap<AccountBillingDto, AccountBilling>();
                Mapper.CreateMap<AccountTypeDto, AccountType>();
                Mapper.CreateMap<FrequencyDto, Frequency>();
                Mapper.CreateMap<ContactDto, Contact>().ForMember(x => x.PreferedContatMethod, x => x.MapFrom(y => y.PreferedContatMethods)); ;
                Mapper.CreateMap<PreferedContatMethodDto, PreferedContatMethod>();
                Mapper.CreateMap<AccountInvoiceDto, AccountInvoice>();
                Mapper.CreateMap<AccountDto, Account>()
                    .ForMember(x => x.Account2, x => x.MapFrom(y => y.ParentAccount))
                    .ForMember(x => x.Account1, x => x.MapFrom(y => y.ChildAccounts));

                Mapper.CreateMap<TimeZoneDto, TimeZone>();

                Mapper.CreateMap<Scope, ScopeDto>();

                CreateAccountMapping();

                CreateSystemMapping();

                CreateEventMapping();

                CreateUserMapping();
            }
            catch (Exception es)
            {
            }
        }

        private static void CreateAccountMapping()
        {
            Mapper.CreateMap<AccountAlarmPanel, AccountAlarmPanelDto>();
            Mapper.CreateMap<AccountAnalyticsAlgorithmType, AccountAnalyticsAlgorithmTypeDto>();
            Mapper.CreateMap<AccountNvrAlertType, AccountNvrAlertTypeDto>();
            Mapper.CreateMap<NvrAlertType, NvrAlertTypeDto>();
            Mapper.CreateMap<AccountView, AccountDto>();

            Mapper.CreateMap<AccountAlarmPanelDto, AccountAlarmPanel>();
            Mapper.CreateMap<AccountAnalyticsAlgorithmTypeDto, AccountAnalyticsAlgorithmType>();
            Mapper.CreateMap<AccountNvrAlertTypeDto, AccountNvrAlertType>();
            Mapper.CreateMap<NvrAlertTypeDto, NvrAlertType>();
            Mapper.CreateMap<AccountDto, AccountView>();
        }

        private static void CreateSiteMapping()
        {
            Mapper.CreateMap<BBoxPoint, BBoxPointDto>()
                  .ForMember(dto => dto.Site, opt => opt.UseValue(null));
            Mapper.CreateMap<BBoxPointDto, BBoxPoint>()
                  .ForMember(db => db.Site, opt => opt.UseValue(null));

            Mapper.CreateMap<SiteType, SiteTypeDto>()
                  .ForMember(dto => dto.Name, opt => opt.MapFrom(db => db.siteTypeName));

            Mapper.CreateMap<SiteTypeDto, SiteType>()
                  .ForMember(db => db.siteTypeName, opt => opt.MapFrom(dto => dto.Name));

            
            Mapper.CreateMap<Site, SiteDto>()
                  .ForMember(dto => dto.AccountId, opt => opt.MapFrom(db => db.AccountId))
                  .ForMember(dto => dto.BBoxPointCollection, opt => opt.MapFrom(db => db.BBoxPoint))
                  .ForMember(dto => dto.SiteType, opt => opt.MapFrom(db => db.SiteType))
                  .ForMember(dto => dto.Address, opt => opt.MapFrom(db => db.Address))
                  .ForMember(dto => dto.DevicesCollection, opt => opt.Ignore())
                  .ForMember(dto => dto.ParentSite, opt => opt.Ignore())
                  .AfterMap((db, dto) => dto.HasChildren = db.Site1 != null && db.Site1.Any())
                  .AfterMap((db, dto) =>
                      {
                          foreach (var bboxPoint in dto.BBoxPointCollection)
                          {
                              bboxPoint.Site = null;
                          }
                      });

            Mapper.CreateMap<SiteDto, Site>()
                  .ForMember(db => db.AccountId, opt => opt.MapFrom(dto => dto.AccountId))
                  .ForMember(db => db.Site1, opt => opt.UseValue(null))
                  .ForMember(db => db.Device, opt => opt.UseValue(null))
                  .ForMember(db => db.BBoxPoint, opt => opt.UseValue(null))
                  .ForMember(db => db.SiteType, opt => opt.UseValue(null))
                  .ForMember(db => db.Site2, opt => opt.UseValue(null))
                  .ForMember(db => db.Address, opt => opt.UseValue(null))
                  .ForMember(db => db.Account, opt => opt.UseValue(null)); //To avoid issues with Update
            
            Mapper.CreateMap<tblCustomMapinfo, tblCustomMapinfoDTO>();

            Mapper.CreateMap<tblCustomMapinfoDTO, tblCustomMapinfo>();
        }

        private static void CreateSystemMapping()
        {
            Mapper.CreateMap<InterfaceType, InterfaceTypeDto>();
            Mapper.CreateMap<InterfaceTypeDto, InterfaceType>();

            Mapper.CreateMap<DeviceExternalIdDefinition, DeviceExternalIdDefinitionDto>()
                  .AfterMap(
                      (db, dto) =>
                      dto.EventFieldDefinition = Mapper.Map<EventFieldDefinitionDto>(db.EventFieldDefinition))
                  .AfterMap((db, dto) => dto.InterfaceId = db.InterfaceId);
                    
            Mapper.CreateMap<DeviceExternalIdDefinitionDto, DeviceExternalIdDefinition>()
                  .AfterMap(
                      (dto, db) => db.EventFieldDefinition = Mapper.Map<EventFieldDefinition>(dto.EventFieldDefinition))
                  .AfterMap(
                      (dto, db) => db.EventFieldId = dto.EventFieldDefinition.EventFieldId)
                  .AfterMap(
                      (dto, db) => db.InterfaceId = dto.InterfaceId);

            //Mapper.CreateMap<IQueryable<NVR>, List<NvrDto>>();

            Mapper.CreateMap<Interface, InterfaceDto>().Include<AlarmPanel, AlarmPanelDTO>()
                  .ForMember(dto => dto.InterfaceType, opt => opt.MapFrom(db => db.InterfaceType))
                  .ForMember(dto => dto.Account, opt => opt.MapFrom(db => db.Account))
                  .ForMember(dto => dto.NVR, opt => opt.MapFrom(db => db.NVR))
                  .AfterMap((db, dto) => dto.SiteId = db.Site.SiteId)
                  .AfterMap(
                      (db, dto) =>
                      dto.DeviceExternalIdDefinition =
                      Mapper.Map<List<DeviceExternalIdDefinitionDto>>(db.DeviceExternalIdDefinition));

            Mapper.CreateMap<AlarmPanel, AlarmPanelDTO>().ForMember(dto => dto.SiteId, opt => opt.MapFrom(db => db.Site.SiteId));

            Mapper.CreateMap<InterfaceDto, Interface>().Include<AlarmPanelDTO, AlarmPanel>()
                  .ForMember(db => db.InterfaceType, opt => opt.UseValue(null))
                  .ForMember(db => db.Account, opt => opt.UseValue(null))
                  .ForMember(db => db.NVR, opt => opt.UseValue(null))
                  .AfterMap((db, dto) =>
                            db.DeviceExternalIdDefinition =
                            Mapper.Map<ICollection<DeviceExternalIdDefinitionDto>>(dto.DeviceExternalIdDefinition));
            
            Mapper.CreateMap<AlarmPanelDTO, AlarmPanel>();

            Mapper.CreateMap<DvrNvrTypeMaster, DvrNvrTypeMasterDTO>();

            Mapper.CreateMap<DvrNvrTypeMasterDTO, DvrNvrTypeMaster>();

            Mapper.CreateMap<tblNok, tblNokDTO>();

            Mapper.CreateMap<tblNokDTO, tblNok>();

        }

        private static void CreateEventMapping()
        {
            Mapper.CreateMap<EventQualifier, EventQualifierDto>();
            Mapper.CreateMap<EventCode, EventCodeDto>()
                  .ForMember(dto => dto.EventCode, opt => opt.MapFrom(db => db.EventCode1))
                   .AfterMap((db, dto) =>
                       {
                           dto.EventGroup = null;
                       });

            Mapper.CreateMap<EventFieldType, EventFieldTypeDto>();

            Mapper.CreateMap<EventFieldTypeDto, EventFieldType>();

            Mapper.CreateMap<EventFieldDefinition, EventFieldDefinitionDto>()
                  .ForMember(dto => dto.EventFieldType, opt => opt.MapFrom(db => db.EventFieldType))
                  .ForMember(dto => dto.EventTypeTemplate, opt => opt.Ignore())
                  .AfterMap((db, dto) => dto.EventTypeTemplateId = db.EventTypeTemplate.EventTypeTemplateId);


            Mapper.CreateMap<EventFieldDefinitionDto, EventFieldDefinition>();

            Mapper.CreateMap<EventTypeTemplate, EventTypeTemplateDto>().AfterMap((db, dto) =>
                {
                    dto.EventFieldDefinition = Mapper.Map<List<EventFieldDefinitionDto>>(db.EventFieldDefinition);

                    foreach (var eventFieldDefinitionDto in dto.EventFieldDefinition)
                    {
                        eventFieldDefinitionDto.EventTypeTemplate = null;
                        eventFieldDefinitionDto.EventFieldType.EventFieldDefinition = null;
                    }
                });

            Mapper.CreateMap<EventGroup, EventGroupDto>()
                .ForMember(dto => dto.EventCodeCollection, opt => opt.MapFrom(db => db.EventCodes))
                .AfterMap((db, dto) =>
                {
                    foreach (var eventCodeDto in dto.EventCodeCollection)
                    {
                        eventCodeDto.EventGroup = null;
                    }
                });
            Mapper.CreateMap<Certainty, CertaintyDto>();
            Mapper.CreateMap<MessageType, MessageTypeDto>();
            Mapper.CreateMap<ResponseType, ResponseTypeDto>().ForMember(dto => dto.Name, opt => opt.MapFrom(db => db.Name));
            Mapper.CreateMap<Severity, SeverityDto>();
            Mapper.CreateMap<Status, StatusDto>();
            Mapper.CreateMap<Urgency, UrgencyDto>();
            Mapper.CreateMap<Category, CategoryDto>().ForMember(dto => dto.Name, opt => opt.MapFrom(db => db.Name));
            Mapper.CreateMap<EventTemplate, EventTemplateDto>();
            Mapper.CreateMap<AnalyticsEventTemplate, AnalyticsEventTemplateDto>();
            Mapper.CreateMap<VideoAanalyticsEvent, VideoAanalyticsEventDTO>();//VideoAanalyticsEventDto
            Mapper.CreateMap<BioAlerts, BioAlertsDTO>();
            Mapper.CreateMap<SubMember, SubMemberDTO>();
            Mapper.CreateMap<DeviceVAnalyticsSchedule, DeviceVAnalyticsScheduleDTO>();
            

            Mapper.CreateMap<EventQualifierDto, EventQualifier>();
            Mapper.CreateMap<EventCodeDto, EventCode>()
                  .ForMember(dto => dto.EventCode1, opt => opt.MapFrom(db => db.EventCode));
            Mapper.CreateMap<EventTypeTemplateDto, EventTypeTemplate>();
            Mapper.CreateMap<EventGroupDto, EventGroup>()
                  .ForMember(db => db.EventCodes, opt => opt.MapFrom(db => db.EventCodeCollection));
            Mapper.CreateMap<CertaintyDto, Certainty>();
            Mapper.CreateMap<MessageTypeDto, MessageType>();
            Mapper.CreateMap<ResponseTypeDto, ResponseType>().ForMember(db => db.Name, opt => opt.MapFrom(dto => dto.Name)); ;
            Mapper.CreateMap<SeverityDto, Severity>();
            Mapper.CreateMap<StatusDto, Status>();
            Mapper.CreateMap<UrgencyDto, Urgency>();
            Mapper.CreateMap<CategoryDto, Category>().ForMember(db => db.Name, opt => opt.MapFrom(dto => dto.Name));
            Mapper.CreateMap<EventTemplateDto, EventTemplate>();
            Mapper.CreateMap<Event, EventDTO>();
            Mapper.CreateMap<EventDTO, Event>();
            Mapper.CreateMap<AnalyticsEventTemplateDto, AnalyticsEventTemplate>();
            Mapper.CreateMap<VideoAanalyticsEventDTO, VideoAanalyticsEvent>();
            Mapper.CreateMap<BioAlertsDTO, BioAlerts>();           
            Mapper.CreateMap<SubMemberDTO, SubMember>();           
            Mapper.CreateMap<DeviceVAnalyticsScheduleDTO, DeviceVAnalyticsSchedule>();            
        }

        private static void MakeSiteNullForDeviceAndBBoxPointCollections(IEnumerable<SiteDto> sites)
        {
            if (sites == null) return;

            foreach (var site in sites)
            {
                foreach (var device in site.DevicesCollection)
                {
                    //device.Site = null;
                }

                foreach (var point in site.BBoxPointCollection)
                {
                    point.Site = null;
                }
            }
        }

        private static void CreateUserMapping()
        {
            Mapper.CreateMap<User, UserDto>()
                  .ForMember(dto => dto.Username, opt => opt.MapFrom(db => db.MembershipUser.UserName))
                  .ForMember(dto => dto.Password, opt => opt.UseValue(Guid.NewGuid().ToString()));//Note: hack to avoid validation issue on TouchConfig

            Mapper.CreateMap<UserType, UserTypeDto>();
            Mapper.CreateMap<Team, TeamDto>();
            Mapper.CreateMap<Rhino.Security.Model.UsersGroup, TeamDto>();            
            Mapper.CreateMap<Rhino.Security.Model.UsersGroup, UsersGroupDto>();
            Mapper.CreateMap<Rhino.Security.Model.Operation, OperationDto>();
            Mapper.CreateMap<Rhino.Security.Model.Permission, PermissionDto>()
                  .ForMember(dto => dto.User, opt => opt.MapFrom(db => (User)db.User));
            
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<UserTypeDto, UserType>();
            Mapper.CreateMap<TeamDto, Team>();
            Mapper.CreateMap<TeamDto, Rhino.Security.Model.UsersGroup>();
            Mapper.CreateMap<UsersGroupDto, Rhino.Security.Model.UsersGroup>();
            Mapper.CreateMap<OperationDto, Rhino.Security.Model.Operation>();
            Mapper.CreateMap<PermissionDto, Rhino.Security.Model.Permission>();
        }
    }
}