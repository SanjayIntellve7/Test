using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Models
{
    [DataContract]
    public class DeviceType
    {
        [DataMember]
        public string Description { get; set; }
    }
    [DataContract]
    public class DeviceTypeRootObject
    {
        [DataMember]
        public List<DeviceType> DeviceTypes { get; set; }
    }
    public class DeviceTypeFilter
    {
        public string Text { get; set; }
        public string Value { get; set; } 
    } 



    [DataContract]
    public class Operator
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class OperatorRootObject
    {
        [DataMember]
        public List<Operator> Operators { get; set; }
    }
    public class OperatorFilter
    {
        public string Text { get; set; }
        public string Value { get; set; } 
    }  

    [DataContract]
    public class Branch
    {
        [DataMember]
        public string BranchId { get; set; }
    }
    [DataContract]
    public class BranchRootObject
    {
        [DataMember]
        public List<Branch> Branches { get; set; }
    } 
     
    public class BranchFilter
    {
        public string Text { get; set; }
        public string Value { get; set; }

    }  
}
