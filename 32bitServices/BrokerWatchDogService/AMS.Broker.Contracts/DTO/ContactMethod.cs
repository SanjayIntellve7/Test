using System;
using System.Runtime.Serialization;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract, Serializable]
    public sealed class ContactMethod
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
