namespace AMS.Orchestrations {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"GetActiveUsers", @"GetActiveUsersResponse", @"GetUsersList", @"GetUsersListResponse", @"GetUsersListByAlertGroup", @"GetUsersListByAlertGroupResponse", @"AddUserLocation", @"AddUserLocationResponse", @"AddUserLocationCollection", @"AddUserLocationCollectionResponse", @"GetUserLocations", @"GetUserLocationsResponse", @"SetUserLocationAsDefault", @"SetUserLocationAsDefaultResponse", @"DeleteUserLocationCollection", @"DeleteUserLocationCollectionResponse", @"DeleteUserLocation", @"DeleteUserLocationResponse", 
@"GetUsersLocations", @"GetUsersLocationsResponse"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO", typeof(global::AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO))]
    public sealed class UsersService__x32020_ams : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:tns=""http://2020.AMS"" elementFormDefault=""qualified"" targetNamespace=""http://2020.AMS"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""AMS.Orchestrations.UsersService_schemas_datacontract_org_2004_07_AMS_Broker_Contracts_DTO"" namespace=""http://schemas.datacontract.org/2004/07/AMS.Broker.Contracts.DTO"" />
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
  <xs:element name=""AddUserLocation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""userLocation"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""AddUserLocationResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""AddUserLocationCollection"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""userLocations"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""AddUserLocationCollectionResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUserLocations"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""userName"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUserLocationsResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""GetUserLocationsResult"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""SetUserLocationAsDefault"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""userLocationFavorite"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""SetUserLocationAsDefaultResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeleteUserLocationCollection"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""userLocationsCollection"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeleteUserLocationCollectionResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeleteUserLocation"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""userLocation"" nillable=""true"" type=""xs:string"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
  <xs:element name=""DeleteUserLocationResponse"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUsersLocations"">
    <xs:complexType>
      <xs:sequence />
    </xs:complexType>
  </xs:element>
  <xs:element name=""GetUsersLocationsResponse"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""0"" name=""GetUsersLocationsResult"" nillable=""true"" type=""xs:string"" />
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
                string[] _RootElements = new string [20];
                _RootElements[0] = "GetActiveUsers";
                _RootElements[1] = "GetActiveUsersResponse";
                _RootElements[2] = "GetUsersList";
                _RootElements[3] = "GetUsersListResponse";
                _RootElements[4] = "GetUsersListByAlertGroup";
                _RootElements[5] = "GetUsersListByAlertGroupResponse";
                _RootElements[6] = "AddUserLocation";
                _RootElements[7] = "AddUserLocationResponse";
                _RootElements[8] = "AddUserLocationCollection";
                _RootElements[9] = "AddUserLocationCollectionResponse";
                _RootElements[10] = "GetUserLocations";
                _RootElements[11] = "GetUserLocationsResponse";
                _RootElements[12] = "SetUserLocationAsDefault";
                _RootElements[13] = "SetUserLocationAsDefaultResponse";
                _RootElements[14] = "DeleteUserLocationCollection";
                _RootElements[15] = "DeleteUserLocationCollectionResponse";
                _RootElements[16] = "DeleteUserLocation";
                _RootElements[17] = "DeleteUserLocationResponse";
                _RootElements[18] = "GetUsersLocations";
                _RootElements[19] = "GetUsersLocationsResponse";
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
        
        [Schema(@"http://2020.AMS",@"AddUserLocation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"AddUserLocation"})]
        public sealed class AddUserLocation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public AddUserLocation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "AddUserLocation";
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
        
        [Schema(@"http://2020.AMS",@"AddUserLocationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"AddUserLocationResponse"})]
        public sealed class AddUserLocationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public AddUserLocationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "AddUserLocationResponse";
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
        
        [Schema(@"http://2020.AMS",@"AddUserLocationCollection")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"AddUserLocationCollection"})]
        public sealed class AddUserLocationCollection : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public AddUserLocationCollection() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "AddUserLocationCollection";
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
        
        [Schema(@"http://2020.AMS",@"AddUserLocationCollectionResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"AddUserLocationCollectionResponse"})]
        public sealed class AddUserLocationCollectionResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public AddUserLocationCollectionResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "AddUserLocationCollectionResponse";
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
        
        [Schema(@"http://2020.AMS",@"GetUserLocations")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUserLocations"})]
        public sealed class GetUserLocations : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUserLocations() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUserLocations";
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
        
        [Schema(@"http://2020.AMS",@"GetUserLocationsResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUserLocationsResponse"})]
        public sealed class GetUserLocationsResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUserLocationsResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUserLocationsResponse";
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
        
        [Schema(@"http://2020.AMS",@"SetUserLocationAsDefault")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"SetUserLocationAsDefault"})]
        public sealed class SetUserLocationAsDefault : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public SetUserLocationAsDefault() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "SetUserLocationAsDefault";
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
        
        [Schema(@"http://2020.AMS",@"SetUserLocationAsDefaultResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"SetUserLocationAsDefaultResponse"})]
        public sealed class SetUserLocationAsDefaultResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public SetUserLocationAsDefaultResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "SetUserLocationAsDefaultResponse";
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
        
        [Schema(@"http://2020.AMS",@"DeleteUserLocationCollection")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeleteUserLocationCollection"})]
        public sealed class DeleteUserLocationCollection : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeleteUserLocationCollection() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeleteUserLocationCollection";
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
        
        [Schema(@"http://2020.AMS",@"DeleteUserLocationCollectionResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeleteUserLocationCollectionResponse"})]
        public sealed class DeleteUserLocationCollectionResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeleteUserLocationCollectionResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeleteUserLocationCollectionResponse";
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
        
        [Schema(@"http://2020.AMS",@"DeleteUserLocation")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeleteUserLocation"})]
        public sealed class DeleteUserLocation : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeleteUserLocation() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeleteUserLocation";
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
        
        [Schema(@"http://2020.AMS",@"DeleteUserLocationResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"DeleteUserLocationResponse"})]
        public sealed class DeleteUserLocationResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public DeleteUserLocationResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "DeleteUserLocationResponse";
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
        
        [Schema(@"http://2020.AMS",@"GetUsersLocations")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUsersLocations"})]
        public sealed class GetUsersLocations : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUsersLocations() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUsersLocations";
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
        
        [Schema(@"http://2020.AMS",@"GetUsersLocationsResponse")]
        [System.SerializableAttribute()]
        [SchemaRoots(new string[] {@"GetUsersLocationsResponse"})]
        public sealed class GetUsersLocationsResponse : Microsoft.XLANGs.BaseTypes.SchemaBase {
            
            [System.NonSerializedAttribute()]
            private static object _rawSchema;
            
            public GetUsersLocationsResponse() {
            }
            
            public override string XmlContent {
                get {
                    return _strSchema;
                }
            }
            
            public override string[] RootNodes {
                get {
                    string[] _RootElements = new string [1];
                    _RootElements[0] = "GetUsersLocationsResponse";
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
