namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://2020imaging.com/schema/BizTalk",@"Audit")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "ActivityDateTime", XPath = @"/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='ActivityDateTime' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Type", XPath = @"/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Type' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UserId", XPath = @"/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UserId' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "SourceId", XPath = @"/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='SourceId' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "SourceType", XPath = @"/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='SourceType' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Description", XPath = @"/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Description' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Audit"})]
    public sealed class Audit : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://2020imaging.com/schema/BizTalk"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://2020imaging.com/schema/BizTalk"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Audit"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='ActivityDateTime' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Type' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UserId' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='SourceId' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='SourceType' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Audit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='Description' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""ActivityDateTime"" type=""xs:string"" />
        <xs:element name=""Type"" type=""xs:string"" />
        <xs:element name=""UserId"" nillable=""true"" type=""xs:string"" />
        <xs:element name=""SourceId"" type=""xs:string"" />
        <xs:element name=""SourceType"" type=""xs:string"" />
        <xs:element name=""Description"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Audit() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Audit";
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
