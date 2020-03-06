using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using QL.Communication.Messaging;
using QL.Communication.Messaging.Data;
using QL.Communication.Messaging.Messages;
using NLog;
namespace AMS.Broker.IntegrationService.Services
{
    public class AdditionalCameraInfoResponse : MessageBase
    {
        public override void Deserialize(IPropertyBag propertyBag)
        {
            try
            {
                base.Deserialize(propertyBag);
                var list = new List<CameraEx>();
                for (int index = 0; propertyBag.ContainsKey("camera_id" + (object)index); ++index)
                {
                    var camera = new CameraEx();
                    camera.Id = new Guid(propertyBag["camera_id" + (object)index].ToString());
                    object obj;
                    if (propertyBag.TryGetValue("camera_name" + (object)index, out obj))
                        camera.Name = obj.ToString();
                    if (propertyBag.TryGetValue("ip_address" + (object)index, out obj))
                        camera.Address = obj.ToString();
                    if (propertyBag.TryGetValue("model_name" + (object)index, out obj))
                        camera.ModelName = obj.ToString();
                    if (propertyBag.TryGetValue("driver_clsid" + (object)index, out obj))
                        camera.DriverId = new Guid(obj.ToString());
                    if (propertyBag.TryGetValue("recording_autostart" + (object)index, out obj))
                        camera.RecordingAutostart = (int)obj == 1;
                    if (propertyBag.TryGetValue("recording_directory" + (object)index, out obj))
                        camera.RecordingDirectory = obj.ToString();
                    if (propertyBag.TryGetValue("recording_dropframes" + (object)index, out obj))
                        camera.RecordingDropFrames = (int)obj == 1;
                    if (propertyBag.TryGetValue("recording_framerate" + (object)index, out obj))
                        camera.RecordingFrameRate = double.Parse(obj.ToString(), (IFormatProvider)CultureInfo.InvariantCulture);
                    if (propertyBag.TryGetValue("recording_graph" + (object)index, out obj))
                        camera.RecordingGraph = obj.ToString();
                    if (propertyBag.TryGetValue("liveview_graph" + (object)index, out obj))
                        camera.LiveViewGraph = obj.ToString();
                    if (propertyBag.TryGetValue("location_latitude" + index, out obj))
                    {
                        double locationLatitude;
                        double.TryParse(obj.ToString(), out locationLatitude);
                        camera.LocationLatitude = locationLatitude;
                    }

                    if (propertyBag.TryGetValue("location_longitude" + index, out obj))
                    {
                        double locationLongitude;
                        double.TryParse(obj.ToString(), out locationLongitude);
                        camera.LocationLongitude = locationLongitude;
                    }
                    list.Add(camera);
                }
                this.CamerasInfoCollection = (IEnumerable<CameraEx>)list;
            }
            catch (Exception ex)
            {
                Logger.Info("AdditionalCameraInfoResponse Deserialize() Exception" + ex.Message);
                InsertIntegrationLog.AddProcessLogIntegration("AdditionalCameraInfoResponse Deserialize() Exception" + ex.Message);//jatin
            }

        }

        public IEnumerable<CameraEx> CamerasInfoCollection { get; private set; }
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}


