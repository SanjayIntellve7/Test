using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(DeviceDto))]
    public sealed class Group
    {
        public Group()
        {
            DevicesCollection = new List<DeviceDto>();
        }
        [DataMember]
        public Int64 ZoneId { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Metadata { get; set; }
        [DataMember]
        public ICollection<DeviceDto> DevicesCollection { get; set; }

        public void AddDevice(DeviceDto deviceDto, string metadata)
        {
            if (!DevicesCollection.Any(x => x.DeviceId == deviceDto.DeviceId))
            {
                DevicesCollection.Add(deviceDto);

                if (String.IsNullOrWhiteSpace(Metadata))
                    Metadata = "<metadata></metadata>";

                var xmlMetadata = new XmlDocument();
                xmlMetadata.LoadXml(Metadata);

                var childNode = xmlMetadata.CreateElement("device");
                childNode.SetAttribute("id", deviceDto.DeviceId.ToString());
                childNode.InnerXml = metadata;
                xmlMetadata.DocumentElement.AppendChild(childNode);

                Metadata = xmlMetadata.InnerXml;
            }
        }
        public void RemoveDevice(DeviceDto deviceDto)
        {
            if (!DevicesCollection.Any(x => x.DeviceId == deviceDto.DeviceId))
            {
                DevicesCollection.Remove(deviceDto);
                //Add metadata removeal attribute
            }
        }
    }
}
