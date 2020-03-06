namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://2020.AMS",@"User")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"User"})]
    public sealed class User : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AMS.Orchestrations.User"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""http://2020.AMS"" targetNamespace=""http://2020.AMS"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""User"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='User' and namespace-uri()='http://2020.AMS']/*[local-name()='Username' and namespace-uri()='http://2020.AMS']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Username"" type=""xs:string"" />
        <xs:element name=""ContactMethodsCollection"">
          <xs:complexType>
            <xs:sequence>
              <xs:element maxOccurs=""unbounded"" name=""ContactMethod"">
                <xs:complexType>
                  <xs:simpleContent>
                    <xs:extension base=""xs:string"">
                      <xs:attribute name=""Name"" type=""xs:string"" />
                      <xs:attribute name=""Value"" type=""xs:string"" />
                    </xs:extension>
                  </xs:simpleContent>
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public User() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "User";
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
