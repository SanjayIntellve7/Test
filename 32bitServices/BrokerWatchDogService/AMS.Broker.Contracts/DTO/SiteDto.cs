using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable, KnownType(typeof(SiteDto)), KnownType(typeof(SiteTypeDto)), KnownType(typeof(NvrCameraDto))]
    [DebuggerDisplay("{SiteId}")]
    public class SiteDto
    {
        [DataMember, Required, Key]
        public int SiteId
        {
            get; set;
        }
       
        [DataMember]
        public int? ParentId
        {
            get; set;
        }

        [DataMember]
        public int? AccountId
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get; set;
        }

        [DataMember]
        public string SiteName
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get; set;
        }

        [DataMember]
        public double Lat
        {
            get; set;
        }

        [DataMember]
        public double Long
        {
            get; set;
        }

        [DataMember]
        public double Alt
        {
            get;
            set;
        }

        [DataMember]
        public double ZoomLevel
        {
            get; set;
        }

        [DataMember]
        public byte[] Map
        {
            get; set;
        }

        [DataMember]
        public byte[] Pin
        {
            get;
            set;
        }

        [DataMember]
        public string MapUrl
        {
            get;
            set;
        }

        [DataMember]
        public string PinUrl
        {
            get;
            set;
        }
        
         [DataMember]//trupti24122015
        public bool? IsBingMap { get; set; }

        


        [DataMember]
        public bool HasChildren { get; set; }

        [DataMember]
        public SiteTypeDto SiteType { get; set; }

        [DataMember]
        public AddressDto Address { get; set; }

        //[DataMember]
        public SiteDto ParentSite { get; set; }

        [DataMember]
        public List<int> ChildSites { get; set; }

        [DataMember]
        public List<DeviceDto> DevicesCollection { get; set; }

        [DataMember]
        public List<tblcustomeremergencycontactDTO> EmergencyContactCollection { get; set; } //amit 04042017


        [DataMember]
        public List<BBoxPointDto> BBoxPointCollection { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }


        [DataMember]
        public string ExternalIdentifier
        {
            get;
            set;
        }

        [DataMember()]
        public Guid SystemId { get; set; }

        [DataMember]
        public string EmContactName1
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail1
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo1
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName2
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail2
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo2
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName3
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail3
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo3
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName4
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail4
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo4
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName5
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail5
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo5
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName6
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail6
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo6
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName7
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail7
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo7
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName8
        {
            get;
            set;
        }
       
        [DataMember]
        public string EmContactEmail8
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo8
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName9
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail9
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo9
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactName10
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactEmail10
        {
            get;
            set;
        }
        [DataMember]
        public string EmContactNo10
        {
            get;
            set;
        }
        public static void CloneParentSite(SiteDto siteDto)
        {
            if (siteDto.ParentSite != null)
            {
                var parentSite = new SiteDto
                    {
                        Address = siteDto.ParentSite.Address,
                        Alt = siteDto.ParentSite.Alt,
                        Description = siteDto.ParentSite.Description,
                        Lat = siteDto.ParentSite.Lat,
                        Long = siteDto.ParentSite.Long,
                        Map = siteDto.ParentSite.Map,
                        MapUrl = siteDto.ParentSite.MapUrl,
                        Name = siteDto.ParentSite.Name,
                        SiteName= siteDto.ParentSite.SiteName,
                        ParentId = null,
                        ParentSite = null,
                        Pin = siteDto.ParentSite.Pin,
                        PinUrl = siteDto.ParentSite.PinUrl,
                        SiteId = siteDto.ParentSite.SiteId,
                        SiteType = siteDto.ParentSite.SiteType,
                        ZoomLevel = siteDto.ParentSite.ZoomLevel,
                        DevicesCollection = null,
                        BBoxPointCollection = null,
                        EmergencyContactCollection=null,
                        IsBingMap = siteDto.ParentSite.IsBingMap,
                        ExternalIdentifier=siteDto.ExternalIdentifier,
                        SystemId=siteDto.SystemId
                    };

                siteDto.ParentSite = parentSite;
                siteDto.ParentId = parentSite.SiteId;
            }
        }
    }
}