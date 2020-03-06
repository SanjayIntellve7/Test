namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://2020imaging.com/schema/BizTalk",@"NotifyList")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"NotifyList"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.Alert", typeof(global::AMS.Orchestrations.Alert))]
    public sealed class NotifyList : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://2020imaging.com/schema/BizTalk"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://2020imaging.com/schema/BizTalk"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:include schemaLocation=""AMS.Orchestrations.Alert"" />
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo root_reference=""NotifyList"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" />
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""NotifyList"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""1"" maxOccurs=""1"" name=""UsersCollection"">
          <xs:complexType>
            <xs:sequence minOccurs=""0"">
              <xs:element maxOccurs=""unbounded"" name=""User"">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element name=""username"" type=""xs:string"" />
                    <xs:element name=""ContactMethodsCollection"">
                      <xs:complexType>
                        <xs:sequence>
                          <xs:element maxOccurs=""unbounded"" name=""ContactMethod"">
                            <xs:complexType>
                              <xs:simpleContent>
                                <xs:extension base=""xs:string"">
                                  <xs:attribute name=""Name"" type=""xs:string"" />
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
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name=""Alert"" type=""Alert"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public NotifyList() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "NotifyList";
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
