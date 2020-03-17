using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    //lpu master
    public class LpuMasterObject
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string ip_address { get; set; }
        public string device_name { get; set; }
        public string lpu_password { get; set; }
        public string location { get; set; }
        public string https_port { get; set; }
        public string ssh_port { get; set; }
        public string registered_status { get; set; }
        public string interface_id { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
