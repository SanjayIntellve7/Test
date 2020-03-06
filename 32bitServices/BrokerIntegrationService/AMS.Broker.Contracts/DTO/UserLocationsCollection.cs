using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, KnownType(typeof(UserLocation)), Serializable]
    public class UserLocationsCollection
    {

        public UserLocationsCollection(IEnumerable<UserLocation> items)
        {
            this.Items = new List<UserLocation>(items);
        }

        [DataMember]
        public List<UserLocation> Items
        {
            get; set;            
        }
    }
}
