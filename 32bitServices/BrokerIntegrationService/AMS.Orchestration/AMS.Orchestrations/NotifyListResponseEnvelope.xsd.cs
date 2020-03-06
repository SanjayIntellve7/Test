namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://AMS.Orchestrations.NotifyListResponseEnvelope",@"UsersCollection")]
    [BodyXPath(@"/*[local-name()='UsersCollection' and namespace-uri()='http://AMS.Orchestrations.NotifyListResponseEnvelope']")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"UsersCollection"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService__x32020_ams", typeof(global::AMS.Orchestrations.UsersService__x32020_ams))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO", typeof(global::AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO))]
    public sealed class NotifyListResponseEnvelope : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AMS.Orchestrations.NotifyListResponseEnvelope"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns1=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" xmlns:ns0=""http://2020.AMS"" elementFormDefault=""unqualified"" targetNamespace=""http://AMS.Orchestrations.NotifyListResponseEnvelope"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.UsersService__x32020_ams"" namespace=""http://2020.AMS"" />
  <xs:import schemaLocation=""AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO"" namespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo is_envelope=""yes"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" />
      <b:references>
        <b:reference targetNamespace=""http://schemas.microsoft.com/2003/10/Serialization/"" />
        <b:reference targetNamespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
        <b:reference targetNamespace=""http://2020.AMS"" />
      </b:references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""UsersCollection"" type=""ns1:ArrayOfUserContactInformation"">
    <xs:annotation>
      <xs:appinfo>
        <b:recordInfo body_xpath=""/*[local-name()='UsersCollection' and namespace-uri()='http://AMS.Orchestrations.NotifyListResponseEnvelope']"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
</xs:schema>";
        
        public NotifyListResponseEnvelope() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "UsersCollection";
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
