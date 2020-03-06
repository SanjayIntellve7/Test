using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QL.Communication.Messaging.Data;

namespace AMS.Broker.IntegrationService.Services
{
    public class CameraEx : Camera
    {
        private int GetResolution(int index)
        {
            var regEx = new Regex(@"\(\d+[x]\d+\)");
            if (regEx.IsMatch(LiveViewGraph))
            {
                var dims = regEx.Match(LiveViewGraph).ToString().Trim('(', ')').Split('x');
                if (dims.Length == 2)
                {
                    var result = 0;
                    int.TryParse(dims[index], out result);
                    return result;
                }
            }
            return 0;
        }

        public bool Allowed { get; set; }
        public string Key { get; set; }

        public bool ShowVcaTabs { get; set; }
        public bool AudioNative { get; set; }
        public string AudioNativeId { get; set; }
        public bool AudioRecordDisable { get; set; }
        public bool CamValidity { get; set; }
        public Guid CameraVolumeId { get; set; }
        public bool CameraVisibility { get; set; }
        public string ColorProfile { get; set; }
        public string Compressions { get; set; }
        public string DeliveryMode { get; set; }
        public string H264Resolutions { get; set; }
        public string ImageResolutions { get; set; }
        public string LiveViewGraph { get; set; }

        public int Width
        {
            get { return GetResolution(0); }
        }

        public int Height
        {
            get { return GetResolution(1); }
        }

        public int LocationDirection { get; set; }
        public int LocationHeight { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationTiltAngle { get; set; }
        public string Login { get; set; }

        public string MpegResolutions { get; set; }
        public string MulticastAddress { get; set; }
        public int NvsDeviceNumber { get; set; }
        public string Password { get; set; }
        public string PicoloCardNumber { get; set; }
        public Guid PtzDriverId { get; set; }
        public int PtzExtPatternCount { get; set; }
        public int PtzExtended { get; set; }
        public int PtzExternal { get; set; }
        public int PtzHomepreset { get; set; }
        public int PtzPatrolId { get; set; }
        public int PtzRecoveryTime { get; set; }
        public int PtzSpeed { get; set; }
        public int PtzTouring { get; set; }
        public Guid? PtzDeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string UdpCardNumber { get; set; }
        public string UiBrandName { get; set; }


    }
}


