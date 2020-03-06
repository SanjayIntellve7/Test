namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://AMS.Orchestrations.UserProperContactInformation",@"Root")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Username", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Username' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Addresses", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Addresses' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Sender", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Sender' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Source", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Source' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.StatusId", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='StatusId' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.WorkflowStatus", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='WorkflowStatus' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Identifier", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Identifier' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Incidents", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Incidents' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Code", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Code' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.AuthToken", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='AuthToken' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.Int64), "Alert.AlertId", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='AlertId' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"long")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.MessageTypeId", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='MessageTypeId' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Note", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Note' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.References", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='References' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Alert.Restriction", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Restriction' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Sid", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Sid' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Phone", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Phone' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Email", XPath = @"/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Email' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Root"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO", typeof(global::AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO))]
    public sealed class UserProperContactInformation : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AMS.Orchestrations.UserProperContactInformation"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" targetNamespace=""http://AMS.Orchestrations.UserProperContactInformation"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO"" namespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
  <xs:annotation>
    <xs:appinfo>
      <b:references>
        <b:reference targetNamespace=""http://schemas.microsoft.com/2003/10/Serialization/"" />
        <b:reference targetNamespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
      </b:references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""Root"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Username' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Addresses' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Sender' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Source' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='StatusId' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='WorkflowStatus' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Identifier' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Incidents' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Code' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='AuthToken' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='AlertId' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='MessageTypeId' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Note' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='References' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Alert' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']/*[local-name()='Restriction' and namespace-uri()='http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Sid' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Phone' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='Root' and namespace-uri()='http://AMS.Orchestrations.UserProperContactInformation']/*[local-name()='Email' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element ref=""ns0:Alert"" />
        <xs:element name=""Username"" type=""xs:string"" />
        <xs:element name=""Sid"" type=""xs:string"" />
        <xs:element name=""Phone"" type=""xs:string"" />
        <xs:element name=""Email"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public UserProperContactInformation() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Root";
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
