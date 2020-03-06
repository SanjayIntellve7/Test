namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://AMS.Orchestrations.UserNotificationsEnvelope",@"UsersNotifications")]
    [BodyXPath(@"/*[local-name()='UsersNotifications' and namespace-uri()='http://AMS.Orchestrations.UserNotificationsEnvelope']")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"UsersNotifications"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO", typeof(global::AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO))]
    public sealed class UsersNotificationsEnvelope : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AMS.Orchestrations.UserNotificationsEnvelope"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" targetNamespace=""http://AMS.Orchestrations.UserNotificationsEnvelope"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO"" namespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo is_envelope=""yes"" />
      <b:references>
        <b:reference targetNamespace=""http://schemas.microsoft.com/2003/10/Serialization/"" />
        <b:reference targetNamespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
      </b:references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""UsersNotifications"">
    <xs:annotation>
      <xs:appinfo>
        <b:recordInfo body_xpath=""/*[local-name()='UsersNotifications' and namespace-uri()='http://AMS.Orchestrations.UserNotificationsEnvelope']"" />
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Notification"">
          <xs:complexType>
            <xs:sequence>
              <xs:element minOccurs=""1"" maxOccurs=""1"" ref=""ns0:Alert"" />
              <xs:element minOccurs=""1"" maxOccurs=""1"" ref=""ns0:UserContactInformation"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public UsersNotificationsEnvelope() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "UsersNotifications";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
