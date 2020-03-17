using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AMS.Broker.Contracts.DTO
{
    public sealed class Resource
    {
        public Resource()
        {
            Uri = " ";
            DerefUri = " ";
            Digest = " ";
        }
        [DataMember, Key, Required]
        public Int32 ResourceId { get; set; }
        [DataMember, Required]
        public Int32 InfoId { get; set; }
        [DataMember, Required]
        public String Description { get; set; }
        [DataMember, Required]
        public String MimeType { get; set; }
        [DataMember]
        public Int32 Size { get; set; }
        [DataMember]
        public String Uri { get; set; }
        [DataMember]
        public String DerefUri { get; set; }
        [DataMember]
        public String Digest { get; set; }
    }
}