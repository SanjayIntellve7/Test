using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class VmdDeviceConfigDto
    {
        public string vmsIP { get; set; }
        public int vmsPort { get; set; }
        public string vmsComapnyName { get; set; }
        public int vmsScreenHeight { get; set; }
        public int vmsScreenWidth { get; set; }
        public int vmsFlashOnTime { get; set; }
        public int vmsFlashOffTime { get; set; }
        public int vmsPageOnTime { get; set; }
        public int vmsPageOffTime { get; set; }
        public int vmsBackColor { get; set; }
        public int vmsFrontColor { get; set; }
        public int vmsDefFontNo { get; set; }
        public string vmsDefFontName { get; set; }
        public int vmsLineJust { get; set; }
        public int vmsPageJust { get; set; }
    }
}
