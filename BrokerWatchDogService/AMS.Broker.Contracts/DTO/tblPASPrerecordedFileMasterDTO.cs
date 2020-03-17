using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblPASPrerecordedFileMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String FileName { get; set; }

        [DataMember()]
        public String FilePath { get; set; }

        public tblPASPrerecordedFileMasterDTO()
        {
        }

        public tblPASPrerecordedFileMasterDTO(Int32 iD, String fileName, String filePath)
        {
            this.ID = iD;
            this.FileName = fileName;
            this.FilePath = filePath;
        }
    }
}
