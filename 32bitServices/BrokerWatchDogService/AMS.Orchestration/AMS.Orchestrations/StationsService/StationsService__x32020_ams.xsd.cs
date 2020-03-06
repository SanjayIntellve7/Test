namespace AMS.Orchestrations.StationsService {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Test", @"TestResponse", @"RegisterStation", @"RegisterStationResponse", @"UpdateRegistionInfoStation", @"UpdateRegistionInfoStationResponse", @"ActivateStation", @"ActivateStationResponse", @"DeactivateStation", @"DeactivateStationResponse", @"DeactivateStationByIdentifier", @"DeactivateStationByIdentifierResponse", @"SentAlertToStation", @"SentAlertToStationResponse", @"SentMessage", @"SentMessageResponse", @"GetStationsCollection", @"GetStationsCollectionResponse", @"InformAboutRaisedAlerts", 
@"InformAboutRaisedAlertsResponse", @"InformAboutUserLoggedIn", @"InformAboutUserLoggedInResponse", @"InformAboutUserLoggedOut", @"InformAboutUserLoggedOutResponse", @"ActivatedStation", @"ActivatedStationResponse", @"DeactivatedStation", @"DeactivatedStationResponse", @"RefreshStation", @"RefreshStationResponse", @"RequestMessage", @"RequestMessageResponse", @"RaiseAlert", @"RaiseAlertResponse", @"UserLoggedIn", @"UserLoggedInResponse", @"UserLoggedOut", @"UserLoggedOutResponse", 
@"IncidentReportRaised", @"IncidentReportRaisedResponse"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.StationsService.StationsService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO", typeof(global::AMS.Orchestrations.StationsService.StationsService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO))]
    public sealed class StationsService__x32020_ams : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:tns=""http://2020.AMS"" elementFormDefault=""qualified"" targetNamespace=""http://2020.AMS"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.StationsService.StationsService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO"" namespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
  <xs:annotation>
    <xs:appinfo>
      <references xmlns=""http://schemas.microsoft.com/BizTalk/2003"">
        <reference targetNamespace=""http://schemas.microsoft.com/2003/10/Serialization/"" />
        <reference targetNamespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
      </references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""Test"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""TestResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""TestResult"" type=""xs:boolean"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""RegisterStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""identifier"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""type"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""description"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""metadata"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""longitued"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""latitude"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""RegisterStationResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""RegisterStationResult"" type=""xs:boolean"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""UpdateRegistionInfoStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""identifier"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""description"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""metadata"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""longitued"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""latitude"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""UpdateRegistionInfoStationResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q1=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""UpdateRegistionInfoStationResult"" nillable=""true"" type=""q1:Station"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""ActivateStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""identifier"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""ActivateStationResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q2=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""ActivateStationResult"" nillable=""true"" type=""q2:Station"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeactivateStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""identifier"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeactivateStationResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeactivateStationByIdentifier"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""identifier"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeactivateStationByIdentifierResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""SentAlertToStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""userSID"" nillable=""true"" type=""xs:string"" />
        <xs:element xmlns:q3=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""alert"" nillable=""true"" type=""q3:Alert"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""SentAlertToStationResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""SentAlertToStationResult"" type=""xs:boolean"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""SentMessage"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""stationId"" type=""xs:int"" />
        <xs:element minOccurs=""0"" name=""monitorId"" type=""xs:int"" />
        <xs:element minOccurs=""0"" name=""type"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""content"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""SentMessageResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetStationsCollection"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
        <xs:element minOccurs=""0"" name=""includeInactive"" type=""xs:boolean"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetStationsCollectionResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q4=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""GetStationsCollectionResult"" nillable=""true"" type=""q4:ArrayOfStation"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""InformAboutRaisedAlerts"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q5=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""alertDto"" nillable=""true"" type=""q5:Alert"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""InformAboutRaisedAlertsResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""InformAboutUserLoggedIn"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q6=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""user"" nillable=""true"" type=""q6:User"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""InformAboutUserLoggedInResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""InformAboutUserLoggedOut"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q7=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""user"" nillable=""true"" type=""q7:User"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""InformAboutUserLoggedOutResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""ActivatedStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q8=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""station"" nillable=""true"" type=""q8:Station"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""ActivatedStationResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeactivatedStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""stationId"" type=""xs:int"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeactivatedStationResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""RefreshStation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q9=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""station"" nillable=""true"" type=""q9:Station"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""RefreshStationResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""RequestMessage"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q10=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""message"" nillable=""true"" type=""q10:Message"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""RequestMessageResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""RaiseAlert"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q11=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""alert"" nillable=""true"" type=""q11:Alert"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""RaiseAlertResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""UserLoggedIn"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q12=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""user"" nillable=""true"" type=""q12:User"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""UserLoggedInResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""UserLoggedOut"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q13=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""user"" nillable=""true"" type=""q13:User"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""UserLoggedOutResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""IncidentReportRaised"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q14=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""incidentReport"" nillable=""true"" type=""q14:IncidentReport"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""IncidentReportRaisedResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public StationsService__x32020_ams() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [40];
                _RootElements[0] = "Test";
                _RootElements[1] = "TestResponse";
                _RootElements[2] = "RegisterStation";
                _RootElements[3] = "RegisterStationResponse";
                _RootElements[4] = "UpdateRegistionInfoStation";
                _RootElements[5] = "UpdateRegistionInfoStationResponse";
                _RootElements[6] = "ActivateStation";
                _RootElements[7] = "ActivateStationResponse";
                _RootElements[8] = "DeactivateStation";
                _RootElements[9] = "DeactivateStationResponse";
                _RootElements[10] = "DeactivateStationByIdentifier";
                _RootElements[11] = "DeactivateStationByIdentifierResponse";
                _RootElements[12] = "SentAlertToStation";
                _RootElements[13] = "SentAlertToStationResponse";
                _RootElements[14] = "SentMessage";
                _RootElements[15] = "SentMessageResponse";
                _RootElements[16] = "GetStationsCollection";
                _RootElements[17] = "GetStationsCollectionResponse";
                _RootElements[18] = "InformAboutRaisedAlerts";
                _RootElements[19] = "InformAboutRaisedAlertsResponse";
                _RootElements[20] = "InformAboutUserLoggedIn";
                _RootElements[21] = "InformAboutUserLoggedInResponse";
                _RootElements[22] = "InformAboutUserLoggedOut";
                _RootElements[23] = "InformAboutUserLoggedOutResponse";
                _RootElements[24] = "ActivatedStation";
                _RootElements[25] = "ActivatedStationResponse";
                _RootElements[26] = "DeactivatedStation";
                _RootElements[27] = "DeactivatedStationResponse";
                _RootElements[28] = "RefreshStation";
                _RootElements[29] = "RefreshStationResponse";
                _RootElements[30] = "RequestMessage";
                _RootElements[31] = "RequestMessageResponse";
                _RootElements[32] = "RaiseAlert";
                _RootElements[33] = "RaiseAlertResponse";
                _RootElements[34] = "UserLoggedIn";
                _RootElements[35] = "UserLoggedInResponse";
                _RootElements[36] = "UserLoggedOut";
                _RootElements[37] = "UserLoggedOutResponse";
                _RootElements[38] = "IncidentReportRaised";
                _RootElements[39] = "IncidentReportRaisedResponse";
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
        
        [Schema(@"http://2020.AMS",@"Test")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"Test"})]
        public sealed class Test : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public Test() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "Test";
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
        
        [Schema(@"http://2020.AMS",@"TestResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"TestResponse"})]
        public sealed class TestResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public TestResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "TestResponse";
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
        
        [Schema(@"http://2020.AMS",@"RegisterStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RegisterStation"})]
        public sealed class RegisterStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RegisterStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RegisterStation";
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
        
        [Schema(@"http://2020.AMS",@"RegisterStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RegisterStationResponse"})]
        public sealed class RegisterStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RegisterStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RegisterStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"UpdateRegistionInfoStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"UpdateRegistionInfoStation"})]
        public sealed class UpdateRegistionInfoStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public UpdateRegistionInfoStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "UpdateRegistionInfoStation";
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
        
        [Schema(@"http://2020.AMS",@"UpdateRegistionInfoStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"UpdateRegistionInfoStationResponse"})]
        public sealed class UpdateRegistionInfoStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public UpdateRegistionInfoStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "UpdateRegistionInfoStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"ActivateStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ActivateStation"})]
        public sealed class ActivateStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ActivateStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ActivateStation";
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
        
        [Schema(@"http://2020.AMS",@"ActivateStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ActivateStationResponse"})]
        public sealed class ActivateStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ActivateStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ActivateStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"DeactivateStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeactivateStation"})]
        public sealed class DeactivateStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeactivateStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeactivateStation";
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
        
        [Schema(@"http://2020.AMS",@"DeactivateStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeactivateStationResponse"})]
        public sealed class DeactivateStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeactivateStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeactivateStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"DeactivateStationByIdentifier")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeactivateStationByIdentifier"})]
        public sealed class DeactivateStationByIdentifier : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeactivateStationByIdentifier() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeactivateStationByIdentifier";
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
        
        [Schema(@"http://2020.AMS",@"DeactivateStationByIdentifierResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeactivateStationByIdentifierResponse"})]
        public sealed class DeactivateStationByIdentifierResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeactivateStationByIdentifierResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeactivateStationByIdentifierResponse";
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
        
        [Schema(@"http://2020.AMS",@"SentAlertToStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"SentAlertToStation"})]
        public sealed class SentAlertToStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public SentAlertToStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "SentAlertToStation";
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
        
        [Schema(@"http://2020.AMS",@"SentAlertToStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"SentAlertToStationResponse"})]
        public sealed class SentAlertToStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public SentAlertToStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "SentAlertToStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"SentMessage")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"SentMessage"})]
        public sealed class SentMessage : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public SentMessage() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "SentMessage";
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
        
        [Schema(@"http://2020.AMS",@"SentMessageResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"SentMessageResponse"})]
        public sealed class SentMessageResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public SentMessageResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "SentMessageResponse";
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
        
        [Schema(@"http://2020.AMS",@"GetStationsCollection")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetStationsCollection"})]
        public sealed class GetStationsCollection : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetStationsCollection() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetStationsCollection";
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
        
        [Schema(@"http://2020.AMS",@"GetStationsCollectionResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetStationsCollectionResponse"})]
        public sealed class GetStationsCollectionResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetStationsCollectionResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetStationsCollectionResponse";
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
        
        [Schema(@"http://2020.AMS",@"InformAboutRaisedAlerts")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"InformAboutRaisedAlerts"})]
        public sealed class InformAboutRaisedAlerts : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public InformAboutRaisedAlerts() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "InformAboutRaisedAlerts";
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
        
        [Schema(@"http://2020.AMS",@"InformAboutRaisedAlertsResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"InformAboutRaisedAlertsResponse"})]
        public sealed class InformAboutRaisedAlertsResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public InformAboutRaisedAlertsResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "InformAboutRaisedAlertsResponse";
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
        
        [Schema(@"http://2020.AMS",@"InformAboutUserLoggedIn")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"InformAboutUserLoggedIn"})]
        public sealed class InformAboutUserLoggedIn : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public InformAboutUserLoggedIn() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "InformAboutUserLoggedIn";
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
        
        [Schema(@"http://2020.AMS",@"InformAboutUserLoggedInResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"InformAboutUserLoggedInResponse"})]
        public sealed class InformAboutUserLoggedInResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public InformAboutUserLoggedInResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "InformAboutUserLoggedInResponse";
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
        
        [Schema(@"http://2020.AMS",@"InformAboutUserLoggedOut")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"InformAboutUserLoggedOut"})]
        public sealed class InformAboutUserLoggedOut : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public InformAboutUserLoggedOut() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "InformAboutUserLoggedOut";
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
        
        [Schema(@"http://2020.AMS",@"InformAboutUserLoggedOutResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"InformAboutUserLoggedOutResponse"})]
        public sealed class InformAboutUserLoggedOutResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public InformAboutUserLoggedOutResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "InformAboutUserLoggedOutResponse";
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
        
        [Schema(@"http://2020.AMS",@"ActivatedStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ActivatedStation"})]
        public sealed class ActivatedStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ActivatedStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ActivatedStation";
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
        
        [Schema(@"http://2020.AMS",@"ActivatedStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"ActivatedStationResponse"})]
        public sealed class ActivatedStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public ActivatedStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "ActivatedStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"DeactivatedStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeactivatedStation"})]
        public sealed class DeactivatedStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeactivatedStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeactivatedStation";
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
        
        [Schema(@"http://2020.AMS",@"DeactivatedStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeactivatedStationResponse"})]
        public sealed class DeactivatedStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeactivatedStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeactivatedStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"RefreshStation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RefreshStation"})]
        public sealed class RefreshStation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RefreshStation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RefreshStation";
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
        
        [Schema(@"http://2020.AMS",@"RefreshStationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RefreshStationResponse"})]
        public sealed class RefreshStationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RefreshStationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RefreshStationResponse";
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
        
        [Schema(@"http://2020.AMS",@"RequestMessage")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RequestMessage"})]
        public sealed class RequestMessage : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RequestMessage() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RequestMessage";
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
        
        [Schema(@"http://2020.AMS",@"RequestMessageResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RequestMessageResponse"})]
        public sealed class RequestMessageResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RequestMessageResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RequestMessageResponse";
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
        
        [Schema(@"http://2020.AMS",@"RaiseAlert")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RaiseAlert"})]
        public sealed class RaiseAlert : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RaiseAlert() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RaiseAlert";
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
        
        [Schema(@"http://2020.AMS",@"RaiseAlertResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"RaiseAlertResponse"})]
        public sealed class RaiseAlertResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public RaiseAlertResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "RaiseAlertResponse";
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
        
        [Schema(@"http://2020.AMS",@"UserLoggedIn")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"UserLoggedIn"})]
        public sealed class UserLoggedIn : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public UserLoggedIn() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "UserLoggedIn";
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
        
        [Schema(@"http://2020.AMS",@"UserLoggedInResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"UserLoggedInResponse"})]
        public sealed class UserLoggedInResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public UserLoggedInResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "UserLoggedInResponse";
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
        
        [Schema(@"http://2020.AMS",@"UserLoggedOut")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"UserLoggedOut"})]
        public sealed class UserLoggedOut : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public UserLoggedOut() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "UserLoggedOut";
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
        
        [Schema(@"http://2020.AMS",@"UserLoggedOutResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"UserLoggedOutResponse"})]
        public sealed class UserLoggedOutResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public UserLoggedOutResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "UserLoggedOutResponse";
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
        
        [Schema(@"http://2020.AMS",@"IncidentReportRaised")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"IncidentReportRaised"})]
        public sealed class IncidentReportRaised : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public IncidentReportRaised() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "IncidentReportRaised";
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
        
        [Schema(@"http://2020.AMS",@"IncidentReportRaisedResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"IncidentReportRaisedResponse"})]
        public sealed class IncidentReportRaisedResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public IncidentReportRaisedResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "IncidentReportRaisedResponse";
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
