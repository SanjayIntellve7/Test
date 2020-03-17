using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    //Anpr Device Master

    public class AnprDeviceMasterObject
    {
        public int id { get; set; }
        public object anpr_id { get; set; }
        public object device_id { get; set; }
        public string anpr_camera_name { get; set; }
        public string app_key { get; set; }
        public string anpr_device_id { get; set; }
        public string camera_ip_address { get; set; }
        public string cam_port { get; set; }
        public object cam_user_name { get; set; }
        public string cam_password { get; set; }
        public string cam_registered_status { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
