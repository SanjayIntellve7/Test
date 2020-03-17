using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblVMDPreDefinedImageDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String PredfinedImageName { get; set; }

        [DataMember()]
        public String PredefinedImage { get; set; }

        [DataMember()]
        public Boolean IsAllowAuto { get; set; }

        public tblVMDPreDefinedImageDTO()
        {
        }

        public tblVMDPreDefinedImageDTO(Int32 id, String predfinedImageName, String predefinedImage)
        {
            this.ID = id;
            this.PredfinedImageName = predfinedImageName;
            this.PredefinedImage = predefinedImage;
        }
    }
}
