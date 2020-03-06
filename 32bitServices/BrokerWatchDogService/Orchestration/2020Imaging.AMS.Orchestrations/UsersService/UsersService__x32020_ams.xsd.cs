namespace AMS.Orchestrations.UsersService {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"GetActiveUsers", @"GetActiveUsersResponse", @"GetUsersList", @"GetUsersListResponse", @"GetUsersListByAlertGroup", @"GetUsersListByAlertGroupResponse"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO", typeof(global::AMS.Orchestrations.UsersService.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO))]
    public sealed class UsersService__x32020_ams : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:tns=""http://2020.AMS"" elementFormDefault=""qualified"" targetNamespace=""http://2020.AMS"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.UsersService.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO"" namespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
  <xs:annotation>
    <xs:appinfo>
      <references xmlns=""http://schemas.microsoft.com/BizTalk/2003"">
        <reference targetNamespace=""http://schemas.microsoft.com/2003/10/Serialization/"" />
        <reference targetNamespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
      </references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""GetActiveUsers"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetActiveUsersResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q1=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""GetActiveUsersResult"" nillable=""true"" type=""q1:ArrayOfUser"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUsersList"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""authToken"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUsersListResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q2=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""GetUsersListResult"" nillable=""true"" type=""q2:ArrayOfUser"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUsersListByAlertGroup"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q3=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""content"" nillable=""true"" type=""q3:AlertStatusWrapper"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUsersListByAlertGroupResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element xmlns:q4=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" minOccurs=""0"" name=""GetUsersListByAlertGroupResult"" nillable=""true"" type=""q4:NotifyList"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public UsersService__x32020_ams() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [6];
                _RootElements[0] = "GetActiveUsers";
                _RootElements[1] = "GetActiveUsersResponse";
                _RootElements[2] = "GetUsersList";
                _RootElements[3] = "GetUsersListResponse";
                _RootElements[4] = "GetUsersListByAlertGroup";
                _RootElements[5] = "GetUsersListByAlertGroupResponse";
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
        
        [Schema(@"http://2020.AMS",@"GetActiveUsers")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetActiveUsers"})]
        public sealed class GetActiveUsers : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetActiveUsers() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetActiveUsers";
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
        
        [Schema(@"http://2020.AMS",@"GetActiveUsersResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetActiveUsersResponse"})]
        public sealed class GetActiveUsersResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetActiveUsersResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetActiveUsersResponse";
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
        
        [Schema(@"http://2020.AMS",@"GetUsersList")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUsersList"})]
        public sealed class GetUsersList : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUsersList() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUsersList";
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
        
        [Schema(@"http://2020.AMS",@"GetUsersListResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUsersListResponse"})]
        public sealed class GetUsersListResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUsersListResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUsersListResponse";
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
        
        [Schema(@"http://2020.AMS",@"GetUsersListByAlertGroup")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUsersListByAlertGroup"})]
        public sealed class GetUsersListByAlertGroup : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUsersListByAlertGroup() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUsersListByAlertGroup";
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
        
        [Schema(@"http://2020.AMS",@"GetUsersListByAlertGroupResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUsersListByAlertGroupResponse"})]
        public sealed class GetUsersListByAlertGroupResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUsersListByAlertGroupResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUsersListByAlertGroupResponse";
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
