using AMS.Broker.Contracts.DTO;
using AMS.Broker.IntegrationService.DataStore;
using Remotion.Linq.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TwTw.Domain.ObjectsAssociations;

namespace AMS.Broker.IntegrationService.Services
{
    public class CollectionContainer
    {
        public  List<TwTw.Domain.ObjectsAssociations.ObjectsAssociation> AssociatedDevicesCollection { get; private set; }
        public List<DeviceDto> DeviceCollection { get; private set; }

        public CollectionContainer() //not use
        {
            AssociatedDevicesCollection = new List<TwTw.Domain.ObjectsAssociations.ObjectsAssociation>();
            DeviceCollection = new List<DeviceDto>();

           // Application.Current.Dispatcher.BeginInvoke((Action)(() =>
          //  {
               // GetAssociatedDeviceCollection();
               // GetDeviceCollection();
           /// }));

        }

        public List<TwTw.Domain.ObjectsAssociations.ObjectsAssociation> GetAssociatedDeviceCollection()
        {
            try
            {
                if (AssociatedDevicesCollection.Count() < 1)
                {
                    using (var associationRepository = new TwTw.DataLayer.Models.ObjectsAssociationRepository())
                    {
                         AssociatedDevicesCollection = associationRepository.All.Where(o=>o.ObjectType.Name == "Device").ToList();                        
                    }
                }
                return AssociatedDevicesCollection;
            }
            catch(Exception ex)
            {
            }
            finally
            {
            }
            return null;
        }

        public List<DeviceDto> GetDeviceCollection()
        {
            try
            {
                if (DeviceCollection.Count() < 1)
                {
                     
                    var result = new List<DeviceDto>();
                    using (var ctxdev = new CentralDBEntities())
                    {
                        var resultDb = (from dev in ctxdev.Device
                                        select dev).ToList();
                        if (resultDb != null)
                        {
                            foreach (var _dev in resultDb)
                            {
                                // var _devdto = Mapper.Map<DeviceDto>(_dev);
                                //amit 26092016
                                if (_dev is NvrCamera)
                                {
                                    try
                                    {
                                        var _entity1 = _dev as NvrCamera;
                                        var _deviceDto = new NvrCameraDto()
                                        {
                                            DeviceId = _entity1.DeviceId,
                                            ExternalId = _entity1.ExternalId,
                                            Description = _entity1.Description,
                                            Metadata = _entity1.Metadata,
                                            Type = _entity1.Type,
                                            Lat = _entity1.Lat,
                                            Long = _entity1.Long,
                                            Altitude = _entity1.Altitude,
                                            LocationDescription = _entity1.LocationDescription,
                                            CameraGUID = _entity1.CameraGuid,
                                            NvrId = _entity1.NvrId,
                                            SiteId = _entity1.SiteId.HasValue ? _entity1.SiteId.Value : 0,
                                            ActiveAlert = _entity1.ActiveAlert,
                                            //  HasPvAnalytics = _entity1.HasPvAnalytics,
                                            //  HasSzAnalytics = _entity1.HasSzAnalytics,
                                            //   HasAbAnalytics = _entity1.HasAbAnalytics,
                                            InterfaceId = _entity1.InterfaceId.HasValue ? _entity1.InterfaceId.Value : 0,
                                            IsMovable = _entity1.IsMovable,
                                            Name = _entity1.Name,
                                            AnalyticAlgorithmTypeId = _entity1.AnalyticAlgorithmTypeId, //None                                 
                                            FPS = _entity1.FPS,
                                            Version = _entity1.Version,
                                            MaxBlobSize = _entity1.MaxBlobSize,
                                            MinBlobSize = _entity1.MinBlobSize,
                                            AlarmDelay = _entity1.AlarmDelay,
                                            UpdateRate = _entity1.UpdateRate,
                                            Width = _entity1.Width,
                                            Height = _entity1.Height,
                                            ZoneRows = _entity1.ZoneRows,
                                            ZoneColumns = _entity1.ZoneColumns,
                                            ZoneData = null,
                                            AnalyticsEventTemplateId = _entity1.AnalyticsEventTemplateId,
                                            IsPtz = _entity1.IsPtz,
                                            CameraIp = _entity1.CameraIp,
                                            LineStart = _entity1.LineStart,
                                            LineEnd = _entity1.LineEnd,
                                            DirectionFlag = _entity1.DirectionFlag,
                                            CameraUrl = _entity1.CameraUrl,
                                            CamUser = _entity1.CamUser,
                                            CamPassword = _entity1.CamPassword,
                                            CameraPort = _entity1.CameraPort,
                                            CameraType = _entity1.CameraType,
                                            MaxBlobHeight = _entity1.MaxBlobHeight,
                                            MaxBlobWidth = _entity1.MaxBlobWidth,
                                            MinBlobHeight = _entity1.MinBlobHeight,
                                            MinBlobWidth = _entity1.MinBlobWidth,
                                            AnalyticsServerIp = _entity1.AnalyticsServerIp,
                                            Lane1 = _entity1.Lane1,
                                            Lane2 = _entity1.Lane2,
                                            Lane3 = _entity1.Lane3,
                                            NoOfLens = _entity1.NoOfLens,
                                            ChanelNo = _entity1.ChanelNo,
                                            IsEdgeAnalytics = _entity1.IsEdgeAnalytics,
                                            IPAddress = _entity1.NVR.IPAddress
                                        };
                                        result.Add(_deviceDto);
                                    }
                                    catch (Exception ES)
                                    {
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        var _deviceDto = new DeviceDto
                                        {
                                            DeviceId = _dev.DeviceId,
                                            ExternalId = _dev.ExternalId,
                                            Description = _dev.Description,
                                            Metadata = _dev.Metadata,
                                            Type = _dev.Type,
                                            Lat = _dev.Lat,
                                            Long = _dev.Long,
                                            Altitude = _dev.Altitude,
                                            LocationDescription = _dev.LocationDescription,
                                            CameraGUID = _dev.CameraGuid,
                                            NvrId = _dev.NvrId,
                                            SiteId = _dev.SiteId.HasValue ? _dev.SiteId.Value : 0,
                                            ActiveAlert = _dev.ActiveAlert,
                                            //HasPvAnalytics = _entity.HasPvAnalytics,
                                            // HasSzAnalytics = _entity.HasSzAnalytics,
                                            // HasAbAnalytics = _entity.HasAbAnalytics,
                                            InterfaceId = _dev.InterfaceId.HasValue ? _dev.InterfaceId.Value : 0,
                                            IsMovable = _dev.IsMovable,
                                            Name = _dev.Name
                                        };

                                        result.Add(_deviceDto);
                                    }
                                    catch (Exception es)
                                    {
                                    }
                                }

                            }
                        }
                    }
                    DeviceCollection = result;
                }
                return DeviceCollection;

            }
            catch (Exception ex)
            {
            }
            finally
            { 
            }
            return null;
        }

        public bool deleteAssociation()
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
            finally
            { 
            }
            return false;
        }

        public bool AddAssociation()
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return false;
        }
        public bool UpdateAssociation(TwTw.Domain.ObjectsAssociations.ObjectsAssociation objeAssoid)
        {
            try
            {
                var AssocitedDevcieToUpdate = AssociatedDevicesCollection.FirstOrDefault(x => x.ObjectsAssociationId == objeAssoid.ObjectsAssociationId);
                if (AssocitedDevcieToUpdate != null)
                {
                    AssocitedDevcieToUpdate = objeAssoid;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return false;
        }
        
    }
}
