namespace AMS.Orchestrations.UsersService {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"ArrayOfUser", @"User", @"ArrayOfStation", @"Station", @"AlertStatusWrapper", @"Alert", @"ArrayOfInfo", @"Info", @"ArrayOfArea", @"Area", @"ArrayOfCategory", @"Category", @"Certainty", @"ArrayOfEventCode", @"EventCode", @"ArrayOfParameter", @"Parameter", @"ArrayOfResource", @"Resource", @"ArrayOfResponseType", @"ResponseType", @"Severity", @"Urgency", @"MessageType", @"Scope", @"Status", @"NotifyList", @"ArrayOfUserContactInformation", @"UserContactInformation", @"ArrayOfContactMethod", 
@"ContactMethod"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService.UsersService_schemas_microsoft_com_2003_10_Serialization", typeof(global::AMS.Orchestrations.UsersService.UsersService_schemas_microsoft_com_2003_10_Serialization))]
    public sealed class UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ser=""http://schemas.microsoft.com/2003/10/Serialization/"" xmlns:tns=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" elementFormDefault=""qualified"" targetNamespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.UsersService.UsersService_schemas_microsoft_com_2003_10_Serialization"" namespace=""http://schemas.microsoft.com/2003/10/Serialization/"" />
  <xs:annotation>
    <xs:appinfo>
      <references xmlns=""http://schemas.microsoft.com/BizTalk/2003"">
        <reference targetNamespace=""http://schemas.microsoft.com/2003/10/Serialization/"" />
      </references>
    </xs:appinfo>
  </xs:annotation>
  <xs:complexType name=""ArrayOfUser"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""User"" nillable=""true"" type=""tns:User"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfUser"" nillable=""true"" type=""tns:ArrayOfUser"" />
  <xs:complexType name=""User"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""ActiveFrom"" type=""xs:dateTime"" />
      <xs:element minOccurs=""0"" name=""ActiveTill"" nillable=""true"" type=""xs:dateTime"" />
      <xs:element minOccurs=""0"" name=""AuthToken"" type=""ser:guid"" />
      <xs:element minOccurs=""0"" name=""Identifier"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Machines"" nillable=""true"" type=""tns:ArrayOfStation"" />
      <xs:element minOccurs=""0"" name=""SecurityUserId"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""User"" nillable=""true"" type=""tns:User"" />
  <xs:complexType name=""ArrayOfStation"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Station"" nillable=""true"" type=""tns:Station"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfStation"" nillable=""true"" type=""tns:ArrayOfStation"" />
  <xs:complexType name=""Station"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""ActivationDate"" type=""xs:dateTime"" />
      <xs:element minOccurs=""0"" name=""Description"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Identifier"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""IsActive"" type=""xs:boolean"" />
      <xs:element minOccurs=""0"" name=""Latitude"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Longitued"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Metadata"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""StationId"" type=""xs:int"" />
      <xs:element minOccurs=""0"" name=""Type"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""Station"" nillable=""true"" type=""tns:Station"" />
  <xs:complexType name=""AlertStatusWrapper"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""AlertObject"" nillable=""true"" type=""tns:Alert"" />
      <xs:element minOccurs=""0"" name=""Status"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""AlertStatusWrapper"" nillable=""true"" type=""tns:AlertStatusWrapper"" />
  <xs:complexType name=""Alert"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""Addresses"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""AlertId"" type=""xs:long"" />
      <xs:element minOccurs=""0"" name=""AuthToken"" type=""ser:guid"" />
      <xs:element minOccurs=""0"" name=""Code"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Identifier"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Incidents"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""InfoCollection"" nillable=""true"" type=""tns:ArrayOfInfo"" />
      <xs:element minOccurs=""0"" name=""MessageTypeId"" type=""tns:MessageType"" />
      <xs:element minOccurs=""0"" name=""Note"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""References"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Restriction"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""ScopeId"" type=""tns:Scope"" />
      <xs:element minOccurs=""0"" name=""Sender"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""SentAsString"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Source"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""StatusId"" type=""tns:Status"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""Alert"" nillable=""true"" type=""tns:Alert"" />
  <xs:complexType name=""ArrayOfInfo"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Info"" nillable=""true"" type=""tns:Info"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfInfo"" nillable=""true"" type=""tns:ArrayOfInfo"" />
  <xs:complexType name=""Info"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""AlertId"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""AreasCollection"" nillable=""true"" type=""tns:ArrayOfArea"" />
      <xs:element minOccurs=""0"" name=""Audience"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""CategoriesCollection"" nillable=""true"" type=""tns:ArrayOfCategory"" />
      <xs:element minOccurs=""0"" name=""CertaintyId"" type=""tns:Certainty"" />
      <xs:element minOccurs=""0"" name=""Contact"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Description"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Effective"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Event"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""EventCodesCollection"" nillable=""true"" type=""tns:ArrayOfEventCode"" />
      <xs:element minOccurs=""0"" name=""Expires"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Headline"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""InfoId"" type=""xs:long"" />
      <xs:element minOccurs=""0"" name=""Instruction"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Language"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""OnSet"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""ParametersCollection"" nillable=""true"" type=""tns:ArrayOfParameter"" />
      <xs:element minOccurs=""0"" name=""ResourcesCollection"" nillable=""true"" type=""tns:ArrayOfResource"" />
      <xs:element minOccurs=""0"" name=""ResponseTypesCollection"" nillable=""true"" type=""tns:ArrayOfResponseType"" />
      <xs:element minOccurs=""0"" name=""SenderName"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""SeverityId"" type=""tns:Severity"" />
      <xs:element minOccurs=""0"" name=""UrgencyId"" type=""tns:Urgency"" />
      <xs:element minOccurs=""0"" name=""Web"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""Info"" nillable=""true"" type=""tns:Info"" />
  <xs:complexType name=""ArrayOfArea"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Area"" nillable=""true"" type=""tns:Area"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfArea"" nillable=""true"" type=""tns:ArrayOfArea"" />
  <xs:complexType name=""Area"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""Altitude"" nillable=""true"" type=""xs:double"" />
      <xs:element minOccurs=""0"" name=""AreaId"" type=""xs:long"" />
      <xs:element minOccurs=""0"" name=""Celing"" nillable=""true"" type=""xs:double"" />
      <xs:element minOccurs=""0"" name=""Description"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""InfoId"" type=""xs:long"" />
      <xs:element minOccurs=""0"" name=""Latitude"" nillable=""true"" type=""xs:double"" />
      <xs:element minOccurs=""0"" name=""Longitude"" nillable=""true"" type=""xs:double"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""Area"" nillable=""true"" type=""tns:Area"" />
  <xs:complexType name=""ArrayOfCategory"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Category"" type=""tns:Category"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfCategory"" nillable=""true"" type=""tns:ArrayOfCategory"" />
  <xs:simpleType name=""Category"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""CBRNE"" />
      <xs:enumeration value=""Env"" />
      <xs:enumeration value=""Fire"" />
      <xs:enumeration value=""Geo"" />
      <xs:enumeration value=""Health"" />
      <xs:enumeration value=""Infra"" />
      <xs:enumeration value=""Met"" />
      <xs:enumeration value=""Other"" />
      <xs:enumeration value=""Rescue"" />
      <xs:enumeration value=""Safety"" />
      <xs:enumeration value=""Security"" />
      <xs:enumeration value=""Transport"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""Category"" nillable=""true"" type=""tns:Category"" />
  <xs:simpleType name=""Certainty"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""Likely"" />
      <xs:enumeration value=""Observed"" />
      <xs:enumeration value=""Possible"" />
      <xs:enumeration value=""Unknown"" />
      <xs:enumeration value=""Unlikely"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""Certainty"" nillable=""true"" type=""tns:Certainty"" />
  <xs:complexType name=""ArrayOfEventCode"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""EventCode"" nillable=""true"" type=""tns:EventCode"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfEventCode"" nillable=""true"" type=""tns:ArrayOfEventCode"" />
  <xs:complexType name=""EventCode"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""Key"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Value"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""EventCode"" nillable=""true"" type=""tns:EventCode"" />
  <xs:complexType name=""ArrayOfParameter"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Parameter"" nillable=""true"" type=""tns:Parameter"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfParameter"" nillable=""true"" type=""tns:ArrayOfParameter"" />
  <xs:complexType name=""Parameter"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""Key"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Value"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""Parameter"" nillable=""true"" type=""tns:Parameter"" />
  <xs:complexType name=""ArrayOfResource"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Resource"" nillable=""true"" type=""tns:Resource"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfResource"" nillable=""true"" type=""tns:ArrayOfResource"" />
  <xs:complexType name=""Resource"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""DerefUri"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Description"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Digest"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""InfoId"" type=""xs:int"" />
      <xs:element minOccurs=""0"" name=""MimeType"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""ResourceId"" type=""xs:int"" />
      <xs:element minOccurs=""0"" name=""Size"" type=""xs:int"" />
      <xs:element minOccurs=""0"" name=""Uri"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""Resource"" nillable=""true"" type=""tns:Resource"" />
  <xs:complexType name=""ArrayOfResponseType"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""ResponseType"" type=""tns:ResponseType"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfResponseType"" nillable=""true"" type=""tns:ArrayOfResponseType"" />
  <xs:simpleType name=""ResponseType"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""Assess"" />
      <xs:enumeration value=""Evacuate"" />
      <xs:enumeration value=""Execute"" />
      <xs:enumeration value=""Monitor"" />
      <xs:enumeration value=""None"" />
      <xs:enumeration value=""Prepare"" />
      <xs:enumeration value=""Shelter"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""ResponseType"" nillable=""true"" type=""tns:ResponseType"" />
  <xs:simpleType name=""Severity"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""Extreme"" />
      <xs:enumeration value=""Minor"" />
      <xs:enumeration value=""Moderate"" />
      <xs:enumeration value=""Severe"" />
      <xs:enumeration value=""Unknown"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""Severity"" nillable=""true"" type=""tns:Severity"" />
  <xs:simpleType name=""Urgency"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""Expected"" />
      <xs:enumeration value=""Future"" />
      <xs:enumeration value=""Immediate"" />
      <xs:enumeration value=""Past"" />
      <xs:enumeration value=""Unknown"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""Urgency"" nillable=""true"" type=""tns:Urgency"" />
  <xs:simpleType name=""MessageType"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""Ack"" />
      <xs:enumeration value=""Alert"" />
      <xs:enumeration value=""Cancel"" />
      <xs:enumeration value=""Error"" />
      <xs:enumeration value=""Update"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""MessageType"" nillable=""true"" type=""tns:MessageType"" />
  <xs:simpleType name=""Scope"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""Private"" />
      <xs:enumeration value=""Public"" />
      <xs:enumeration value=""Restricted"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""Scope"" nillable=""true"" type=""tns:Scope"" />
  <xs:simpleType name=""Status"">
    <xs:restriction base=""xs:string"">
      <xs:enumeration value=""Actual"" />
      <xs:enumeration value=""Exercise"" />
      <xs:enumeration value=""System"" />
      <xs:enumeration value=""Test"" />
      <xs:enumeration value=""Draft"" />
    </xs:restriction>
  </xs:simpleType>
  <xs:element name=""Status"" nillable=""true"" type=""tns:Status"" />
  <xs:complexType name=""NotifyList"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""Alert"" nillable=""true"" type=""tns:Alert"" />
      <xs:element minOccurs=""0"" name=""UsersCollection"" nillable=""true"" type=""tns:ArrayOfUserContactInformation"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""NotifyList"" nillable=""true"" type=""tns:NotifyList"" />
  <xs:complexType name=""ArrayOfUserContactInformation"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""UserContactInformation"" nillable=""true"" type=""tns:UserContactInformation"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfUserContactInformation"" nillable=""true"" type=""tns:ArrayOfUserContactInformation"" />
  <xs:complexType name=""UserContactInformation"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""ContactMethodsCollection"" nillable=""true"" type=""tns:ArrayOfContactMethod"" />
      <xs:element minOccurs=""0"" name=""Username"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""UserContactInformation"" nillable=""true"" type=""tns:UserContactInformation"" />
  <xs:complexType name=""ArrayOfContactMethod"">
    <xs:sequence>
      <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""ContactMethod"" nillable=""true"" type=""tns:ContactMethod"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ArrayOfContactMethod"" nillable=""true"" type=""tns:ArrayOfContactMethod"" />
  <xs:complexType name=""ContactMethod"">
    <xs:sequence>
      <xs:element minOccurs=""0"" name=""Name"" nillable=""true"" type=""xs:string"" />
      <xs:element minOccurs=""0"" name=""Value"" nillable=""true"" type=""xs:string"" />
    </xs:sequence>
  </xs:complexType>
  <xs:element name=""ContactMethod"" nillable=""true"" type=""tns:ContactMethod"" />
</xs:schema>";
        
        public UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [31];
                _RootElements[0] = "ArrayOfUser";
                _RootElements[1] = "User";
                _RootElements[2] = "ArrayOfStation";
                _RootElements[3] = "Station";
                _RootElements[4] = "AlertStatusWrapper";
                _RootElements[5] = "Alert";
                _RootElements[6] = "ArrayOfInfo";
                _RootElements[7] = "Info";
                _RootElements[8] = "ArrayOfArea";
                _RootElements[9] = "Area";
                _RootElements[10] = "ArrayOfCategory";
                _RootElements[11] = "Category";
                _RootElements[12] = "Certainty";
                _RootElements[13] = "ArrayOfEventCode";
                _RootElements[14] = "EventCode";
                _RootElements[15] = "ArrayOfParameter";
                _RootElements[16] = "Parameter";
                _RootElements[17] = "ArrayOfResource";
                _RootElements[18] = "Resource";
                _RootElements[19] = "ArrayOfResponseType";
                _RootElements[20] = "ResponseType";
                _RootElements[21] = "Severity";
                _RootElements[22] = "Urgency";
                _RootElements[23] = "MessageType";
                _RootElements[24] = "Scope";
                _RootElements[25] = "Status";
                _RootElements[26] = "NotifyList";
                _RootElements[27] = "ArrayOfUserContactInformation";
                _RootElements[28] = "UserContactInformation";
                _RootElements[29] = "ArrayOfContactMethod";
                _RootElements[30] = "ContactMethod";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfUser")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfUser"})]
        public sealed class ArrayOfUser : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfUser() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfUser";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"User")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"User"})]
        public sealed class User : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfStation"})]
        public sealed class ArrayOfStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfStation";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Station")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Station"})]
        public sealed class Station : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Station() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Station";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"AlertStatusWrapper")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"AlertStatusWrapper"})]
        public sealed class AlertStatusWrapper : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public AlertStatusWrapper() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "AlertStatusWrapper";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Alert")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Alert"})]
        public sealed class Alert : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfInfo")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfInfo"})]
        public sealed class ArrayOfInfo : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfInfo() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfInfo";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Info")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Info"})]
        public sealed class Info : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Info() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Info";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfArea")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfArea"})]
        public sealed class ArrayOfArea : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfArea() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfArea";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Area")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Area"})]
        public sealed class Area : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Area() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Area";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfCategory")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfCategory"})]
        public sealed class ArrayOfCategory : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfCategory() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfCategory";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Category")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Category"})]
        public sealed class Category : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Category() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Category";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Certainty")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Certainty"})]
        public sealed class Certainty : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Certainty() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Certainty";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfEventCode")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfEventCode"})]
        public sealed class ArrayOfEventCode : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfEventCode() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfEventCode";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"EventCode")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"EventCode"})]
        public sealed class EventCode : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public EventCode() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "EventCode";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfParameter")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfParameter"})]
        public sealed class ArrayOfParameter : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfParameter() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfParameter";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Parameter")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Parameter"})]
        public sealed class Parameter : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Parameter() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Parameter";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfResource")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfResource"})]
        public sealed class ArrayOfResource : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfResource() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfResource";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Resource")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Resource"})]
        public sealed class Resource : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Resource() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Resource";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfResponseType")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfResponseType"})]
        public sealed class ArrayOfResponseType : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfResponseType() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfResponseType";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ResponseType")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ResponseType"})]
        public sealed class ResponseType : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ResponseType() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ResponseType";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Severity")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Severity"})]
        public sealed class Severity : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Severity() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Severity";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Urgency")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Urgency"})]
        public sealed class Urgency : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Urgency() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Urgency";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"MessageType")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"MessageType"})]
        public sealed class MessageType : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public MessageType() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "MessageType";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Scope")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Scope"})]
        public sealed class Scope : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Scope() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Scope";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"Status")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Status"})]
        public sealed class Status : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Status() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Status";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"NotifyList")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"NotifyList"})]
        public sealed class NotifyList : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfUserContactInformation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfUserContactInformation"})]
        public sealed class ArrayOfUserContactInformation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfUserContactInformation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfUserContactInformation";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"UserContactInformation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"UserContactInformation"})]
        public sealed class UserContactInformation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public UserContactInformation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "UserContactInformation";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ArrayOfContactMethod")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ArrayOfContactMethod"})]
        public sealed class ArrayOfContactMethod : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ArrayOfContactMethod() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ArrayOfContactMethod";
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
        
        [Schema(@"http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO",@"ContactMethod")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ContactMethod"})]
        public sealed class ContactMethod : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ContactMethod() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ContactMethod";
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
