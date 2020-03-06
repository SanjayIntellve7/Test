namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.ActivityDateTime", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='ActivityDateTime' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.AuditType", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='AuditType' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.Description", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='Description' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.SourceId", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='SourceId' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.SourceType", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='SourceType' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.UserId", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='UserId' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"AuditRequest", @"AuditResponse"})]
    public sealed class SQLService_BizTalk : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://2020imaging.com/schema/BizTalk"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" attributeFormDefault=""unqualified"" elementFormDefault=""qualified"" targetNamespace=""http://2020imaging.com/schema/BizTalk"" version=""1.0"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:annotation>
    <xs:appinfo>
      <msbtssql:sqlScript value=""exec [UpdateAudit] @ActivityDateTime=NULL, @AuditType=NULL, @Description=NULL, @SourceId=NULL, @SourceType=NULL, @UserId=NULL"" xmlns:msbtssql=""http://schemas.microsoft.com/BizTalk/2003"" />
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""AuditRequest"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='ActivityDateTime' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='AuditType' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='Description' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='SourceId' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='SourceType' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='UserId' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""UpdateAudit"">
          <xs:complexType>
            <xs:attribute name=""ActivityDateTime"" type=""xs:string"" />
            <xs:attribute name=""AuditType"" type=""xs:string"" />
            <xs:attribute name=""Description"" type=""xs:string"" />
            <xs:attribute name=""SourceId"" type=""xs:string"" />
            <xs:attribute name=""SourceType"" type=""xs:string"" />
            <xs:attribute name=""UserId"" type=""xs:string"" />
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""AuditResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Success"" type=""xs:anyType"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public SQLService_BizTalk() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [2];
                _RootElements[0] = "AuditRequest";
                _RootElements[1] = "AuditResponse";
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
        
        [Schema(@"http://2020imaging.com/schema/BizTalk",@"AuditRequest")]
        [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.ActivityDateTime", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='ActivityDateTime' and namespace-uri()='']", XsdType = @"string")]
        [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.AuditType", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='AuditType' and namespace-uri()='']", XsdType = @"string")]
        [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.Description", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='Description' and namespace-uri()='']", XsdType = @"string")]
        [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.SourceId", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='SourceId' and namespace-uri()='']", XsdType = @"string")]
        [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.SourceType", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='SourceType' and namespace-uri()='']", XsdType = @"string")]
        [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "UpdateAudit.UserId", XPath = @"/*[local-name()='AuditRequest' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/*[local-name()='UpdateAudit' and namespace-uri()='http://2020imaging.com/schema/BizTalk']/@*[local-name()='UserId' and namespace-uri()='']", XsdType = @"string")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"AuditRequest"})]
        public sealed class AuditRequest : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public AuditRequest() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "AuditRequest";
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
        
        [Schema(@"http://2020imaging.com/schema/BizTalk",@"AuditResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"AuditResponse"})]
        public sealed class AuditResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public AuditResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "AuditResponse";
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
}
