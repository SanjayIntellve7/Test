using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract]
    public class BacNetEventDetailsDto
    {
        [DataMember]
        public string PanelID { get; set; }

        [DataMember]
        public string BACNET_OBJECT_IDENTIFIER { get; set; }

        [DataMember]
        public string BACNET_OBJECT_NAME { get; set; }

        [DataMember]
        public string EventDateTime { get; set; }

        [DataMember]
        public string BacnetEventStatesValue { get; set; }

        [DataMember]
        public string BacnetLifeSafetyModesValue { get; set; }

        [DataMember]
        public string BacnetEventStateFromValue { get; set; }

        [DataMember]
        public string BacnetEventStateToValue { get; set; }

        [DataMember]
        public string BacnetEventEnableFromName { get; set; }    

        [DataMember]
        public string BacnetEventEnableToName { get; set; }          

        [DataMember]
        public string BacnetEventStatesName { get; set; }

        [DataMember]
        public string BacnetEventEnableValue { get; set; }

        [DataMember]
        public string BacnetNotifyTypesName { get; set; }

        [DataMember]
        public string BacnetNotifyTypesValue { get; set; }

        [DataMember]
        public string BacnetEventTypesName { get; set; }

        [DataMember]
        public string BacnetEventTypesValue { get; set; }        

        [DataMember]
        public string BacnetLifeSafetyStatesName { get; set; }

        [DataMember]
        public string BacnetLifeSafetyStatesValue { get; set; }

        [DataMember]
        public string BacnetLifeSafetyModesName { get; set; }
             
        [DataMember]
        public string BacnetLifeSafetyOperationsName { get; set; }

        [DataMember]
        public string BacnetLifeSafetyOperationsValue { get; set; }  
    
        [DataMember]
        public string BacnetStatusFlags { get; set; }

        [DataMember]
        public string BacnetStatusFlags_OUT_OF_SERVICE { get; set; }

        [DataMember]
        public string PROP_OPERATION_EXPECTED_Name { get; set; }

        [DataMember]
        public string PROP_OPERATION_EXPECTED_Value { get; set; }

        [DataMember]
        public string PROP_MAINTENANCE_REQUIRED_Name { get; set; }

        [DataMember]
        public string PROP_MAINTENANCE_REQUIRED_Value { get; set; }

        [DataMember]
        public string PROP_PRESENT_VALUE { get; set; }

        [DataMember]
        public string PROP_ALARM_VALUES { get; set; }

        [DataMember]
        public string PROP_ALARM_LIFE_SAFETY_STATE { get; set; }

        //  [DataMember]
        //   public DeviceStorage DeviceStorage { get; set; }
    }
}
