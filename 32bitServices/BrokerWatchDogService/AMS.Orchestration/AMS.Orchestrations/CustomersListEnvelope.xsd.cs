namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://AMS.Orchestrations.CustomersListEnvelope",@"Users")]
    [BodyXPath(@"/*[local-name()='Users' and namespace-uri()='http://AMS.Orchestrations.CustomersListEnvelope']")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Users"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.User", typeof(global::AMS.Orchestrations.User))]
    public sealed class CustomersListEnvelope : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AMS.Orchestrations.CustomersListEnvelope"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""http://2020.AMS"" targetNamespace=""http://AMS.Orchestrations.CustomersListEnvelope"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.User"" namespace=""http://2020.AMS"" />
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo is_envelope=""yes"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" />
      <b:references>
        <b:reference targetNamespace=""http://2020.AMS"" />
      </b:references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""Users"">
    <xs:annotation>
      <xs:appinfo>
        <b:recordInfo body_xpath=""/*[local-name()='Users' and namespace-uri()='http://AMS.Orchestrations.CustomersListEnvelope']"" />
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element maxOccurs=""unbounded"" ref=""ns0:User"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public CustomersListEnvelope() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Users";
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
