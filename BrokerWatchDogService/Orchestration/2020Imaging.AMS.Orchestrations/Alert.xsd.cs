namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://2020imaging.com/schema/BizTalk",@"Alert")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "WorkflowStatus", XPath = @"/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='WorkflowStatus' and namespace-uri()='http://2020imaging.com/schema/BizTalk']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Sender", XPath = @"/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Sender' and namespace-uri()='http://2020imaging.com/schema/BizTalk']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Source", XPath = @"/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Source' and namespace-uri()='http://2020imaging.com/schema/BizTalk']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Identifier", XPath = @"/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Identifier' and namespace-uri()='http://2020imaging.com/schema/BizTalk']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "AuthToken", XPath = @"/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='AuthToken' and namespace-uri()='http://2020imaging.com/schema/BizTalk']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.UInt16), "AlertId", XPath = @"/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='AlertId' and namespace-uri()='http://2020imaging.com/schema/BizTalk']", XsdType = @"unsignedShort")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Addresses", XPath = @"/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Addresses' and namespace-uri()='http://2020imaging.com/schema/BizTalk']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Alert"})]
    public sealed class Alert : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://2020imaging.com/schema/BizTalk"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" attributeFormDefault=""unqualified"" elementFormDefault=""qualified"" targetNamespace=""http://2020imaging.com/schema/BizTalk"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Alert"" type=""Alert"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='WorkflowStatus' and namespace-uri()='http://2020imaging.com/schema/BizTalk']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Sender' and namespace-uri()='http://2020imaging.com/schema/BizTalk']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Source' and namespace-uri()='http://2020imaging.com/schema/BizTalk']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Identifier' and namespace-uri()='http://2020imaging.com/schema/BizTalk']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='AuthToken' and namespace-uri()='http://2020imaging.com/schema/BizTalk']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='AlertId' and namespace-uri()='http://2020imaging.com/schema/BizTalk']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Alert' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Addresses' and namespace-uri()='http://2020imaging.com/schema/BizTalk']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:complexType name=""Alert"">
    <xs:sequence>
      <xs:element name=""Addresses"" type=""xs:string"" />
      <xs:element name=""AlertId"" type=""xs:unsignedShort"" />
      <xs:element name=""AuthToken"" type=""xs:string"" />
      <xs:element name=""Code"" type=""xs:string"" />
      <xs:element name=""Identifier"" type=""xs:string"" />
      <xs:element name=""Incidents"" type=""xs:string"" />
      <xs:element name=""WorkflowStatus"" type=""xs:string"" />
      <xs:element name=""InfoCollection"">
        <xs:complexType>
          <xs:sequence>
            <xs:element maxOccurs=""unbounded"" name=""Info"">
              <xs:complexType>
                <xs:sequence>
                  <xs:element name=""AlertId"" type=""xs:unsignedShort"" />
                  <xs:element name=""AreasCollection"">
                    <xs:complexType>
                      <xs:sequence>
                        <xs:element maxOccurs=""unbounded"" name=""Area"">
                          <xs:complexType>
                            <xs:sequence>
                              <xs:element name=""Altitude"" type=""xs:unsignedByte"" />
                              <xs:element name=""AreaId"" type=""xs:unsignedShort"" />
                              <xs:element name=""Celing"" type=""xs:unsignedByte"" />
                              <xs:element name=""Description"" type=""xs:string"" />
                              <xs:element name=""InfoId"" type=""xs:unsignedInt"" />
                              <xs:element name=""Latitude"" type=""xs:unsignedShort"" />
                              <xs:element name=""Longitude"" type=""xs:unsignedShort"" />
                            </xs:sequence>
                          </xs:complexType>
                        </xs:element>
                      </xs:sequence>
                    </xs:complexType>
                  </xs:element>
                  <xs:element name=""Audience"" type=""xs:string"" />
                  <xs:element name=""CategoriesCollection"">
                    <xs:complexType>
                      <xs:sequence>
                        <xs:element maxOccurs=""unbounded"" name=""Category"" type=""xs:string"" />
                      </xs:sequence>
                    </xs:complexType>
                  </xs:element>
                  <xs:element name=""CertaintyId"" type=""xs:string"" />
                  <xs:element name=""Contact"" type=""xs:string"" />
                  <xs:element name=""Description"" type=""xs:string"" />
                  <xs:element name=""Effective"" type=""xs:string"" />
                  <xs:element name=""Event"" type=""xs:string"" />
                  <xs:element name=""EventCodesCollection"">
                    <xs:complexType>
                      <xs:sequence minOccurs=""0"">
                        <xs:element maxOccurs=""unbounded"" name=""EventCode"">
                          <xs:complexType>
                            <xs:sequence>
                              <xs:element name=""Key"" type=""xs:string"" />
                              <xs:element name=""Value"" type=""xs:string"" />
                            </xs:sequence>
                          </xs:complexType>
                        </xs:element>
                      </xs:sequence>
                    </xs:complexType>
                  </xs:element>
                  <xs:element name=""Expires"" type=""xs:string"" />
                  <xs:element name=""Headline"" type=""xs:string"" />
                  <xs:element name=""InfoId"" type=""xs:unsignedInt"" />
                  <xs:element name=""Instruction"" type=""xs:string"" />
                  <xs:element name=""Language"" type=""xs:string"" />
                  <xs:element name=""OnSet"" type=""xs:string"" />
                  <xs:element name=""ParametersCollection"">
                    <xs:complexType>
                      <xs:sequence>
                        <xs:element maxOccurs=""unbounded"" name=""Parameter"">
                          <xs:complexType>
                            <xs:sequence>
                              <xs:element name=""Key"" type=""xs:string"" />
                              <xs:element name=""Value"" type=""xs:string"" />
                            </xs:sequence>
                          </xs:complexType>
                        </xs:element>
                      </xs:sequence>
                    </xs:complexType>
                  </xs:element>
                  <xs:element name=""ResourcesCollection"">
                    <xs:complexType>
                      <xs:sequence minOccurs=""0"">
                        <xs:element maxOccurs=""unbounded"" name=""Resource"">
                          <xs:complexType>
                            <xs:sequence>
                              <xs:element name=""DerefUri"" type=""xs:string"" />
                              <xs:element name=""Description"" type=""xs:string"" />
                              <xs:element name=""Digest"" type=""xs:string"" />
                              <xs:element name=""InfoId"" type=""xs:unsignedByte"" />
                              <xs:element name=""MimeType"" type=""xs:string"" />
                              <xs:element name=""ResourceId"" type=""xs:unsignedByte"" />
                              <xs:element name=""Size"" type=""xs:unsignedShort"" />
                              <xs:element name=""Uri"" type=""xs:string"" />
                            </xs:sequence>
                          </xs:complexType>
                        </xs:element>
                      </xs:sequence>
                    </xs:complexType>
                  </xs:element>
                  <xs:element name=""ResponseTypesCollection"">
                    <xs:complexType>
                      <xs:sequence>
                        <xs:element maxOccurs=""unbounded"" name=""ResponseType"" type=""xs:string"" />
                      </xs:sequence>
                    </xs:complexType>
                  </xs:element>
                  <xs:element name=""SenderName"" type=""xs:string"" />
                  <xs:element name=""SeverityId"" type=""xs:string"" />
                  <xs:element name=""UrgencyId"" type=""xs:string"" />
                  <xs:element name=""Web"" type=""xs:string"" />
                </xs:sequence>
              </xs:complexType>
            </xs:element>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name=""MessageTypeId"" type=""xs:string"" />
      <xs:element name=""Note"" type=""xs:string"" />
      <xs:element name=""References"" type=""xs:string"" />
      <xs:element name=""Restriction"" type=""xs:string"" />
      <xs:element name=""ScopeId"" type=""xs:string"" />
      <xs:element name=""Sender"" type=""xs:string"" />
      <xs:element name=""SentAsString"" type=""xs:string"" />
      <xs:element name=""Source"" type=""xs:string"" />
      <xs:element name=""StatusId"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
</xs:schema>";
        
        public Alert() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Alert";
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
