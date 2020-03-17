using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof (InterfaceDto)), KnownType(typeof (NvrDto)), KnownType(typeof (AccountDto)),
     KnownType(typeof(AlarmPanelDTO)), KnownType(typeof(EventTypeTemplateDto))]
    public partial class InterfaceDto
    {
        [DataMember]
        public int InterfaceId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int SiteId { get; set; }

        [DataMember]
        public int InterfaceTypeId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public AccountDto Account { get; set; }

        [DataMember]
        public InterfaceTypeDto InterfaceType { get; set; }

        [DataMember]
        public List<NvrDto> NVR { get; set; }

        [DataMember]
        public List<AlarmPanelDTO> AlarmPanel { get; set; } //trupti20july15

        [DataMember]
        public virtual ICollection<DeviceExternalIdDefinitionDto> DeviceExternalIdDefinition { get; set; }

        [DataMember]
        public virtual EventTypeTemplateDto EventTypeTemplate { get; set; }

        [DataMember()]
        public Guid SystemId { get; set; }

        [DataMember]
        public string Channel { get; set; }

        [DataMember]
        public InternalContactDetailsDTO InternalContactDetails { get; set; }
        [DataMember]
        public ExternalContactDetailsDTO ExternalContactDetails { get; set; }

        [DataMember]
        public string ExternalContactName { get; set; }
        [DataMember]
        public string ExternalContactEmail { get; set; }
        [DataMember]
        public string ExternalContactMob { get; set; }

        [DataMember]
        public string InternalContactName { get; set; }
        [DataMember]
        public string InternalContactEmail { get; set; }
        [DataMember]
        public string InternalContactMob { get; set; }
       
    }
}
