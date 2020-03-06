namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://AMS.Orchestrations.LoopCounter",@"LoopCounter")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.Int32), "Index", XPath = @"/*[local-name()='LoopCounter' and namespace-uri()='http://AMS.Orchestrations.LoopCounter']/*[local-name()='Index' and namespace-uri()='']", XsdType = @"int")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"LoopCounter"})]
    public sealed class LoopCounter : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AMS.Orchestrations.LoopCounter"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://AMS.Orchestrations.LoopCounter"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""LoopCounter"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='LoopCounter' and namespace-uri()='http://AMS.Orchestrations.LoopCounter']/*[local-name()='Index' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Index"" type=""xs:int"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public LoopCounter() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "LoopCounter";
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
