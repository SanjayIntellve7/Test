namespace AMS.Orchestrations.PropertySchema {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Property)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Property1", @"Addresses", @"Altitude", @"Description", @"DeviceId", @"Lat", @"LocationDescription", @"Long", @"Metadata", @"__Type", @"MessageTypeId", @"Note", @"Sender", @"SentAsString", @"Source", @"StatusId", @"Code", @"AuthToken", @"AlertId", @"WorkflowStatus"})]
    public sealed class PropertySchema : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AMS.Orchestrations.PropertySchema"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""https://AMS.Orchestrations.PropertySchema"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo schema_type=""property"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" />
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""Property1"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""7f3829d0-11fd-4f0c-8d6c-c8cef022f274"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Addresses"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""12046c20-e259-45e4-a28d-6b5c510a1614"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Altitude"" type=""xs:decimal"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""eaa612bb-9aef-4bd1-b83d-d3a097902cb9"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Description"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""97418c6b-a261-43f5-a05a-b392848252d2"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""DeviceId"" type=""xs:long"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""3b6c8a05-002d-4b13-97aa-53846c1b6165"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Lat"" type=""xs:decimal"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""7f1da30d-06c8-4f22-be45-fd79b6b74354"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""LocationDescription"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""d7072a58-ae0b-4643-9cdb-cbb9db616df4"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Long"" type=""xs:decimal"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""edff83b9-054f-4e81-a47b-bfcc2a79c8c3"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Metadata"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""5e3a67b0-b0cd-4791-b186-a92be86fd28a"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""__Type"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""7da22717-3f89-4278-9e97-0b0c128f6fb9"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""MessageTypeId"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""0e59654b-3d4f-410f-9ecd-8f552ca6c647"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Note"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""03e9e677-eb36-4ab4-97e4-888876130d05"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Sender"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""62fd975d-fd2d-46d0-b7ca-6e0e891282c0"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""SentAsString"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""10fb87bc-1048-44d3-9202-9029624a3bf5"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Source"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""aa0fa77b-24eb-4f78-bb7f-ba92f56239d3"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""StatusId"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""3232e017-ffd3-4919-9e99-99236bfa0d2b"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""Code"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""51b12f1c-3a84-47e5-9fe7-b00abf629aa4"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""AuthToken"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""ad6636a2-1149-4410-bcdf-c2eb68eb7e30"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""AlertId"" type=""xs:long"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""95c404ef-0cbc-4cd9-9b02-135835fb0372"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""WorkflowStatus"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""2afd4933-924f-4a17-95d4-edabe74a3682"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
</xs:schema>";
        
        public PropertySchema() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [20];
                _RootElements[0] = "Property1";
                _RootElements[1] = "Addresses";
                _RootElements[2] = "Altitude";
                _RootElements[3] = "Description";
                _RootElements[4] = "DeviceId";
                _RootElements[5] = "Lat";
                _RootElements[6] = "LocationDescription";
                _RootElements[7] = "Long";
                _RootElements[8] = "Metadata";
                _RootElements[9] = "__Type";
                _RootElements[10] = "MessageTypeId";
                _RootElements[11] = "Note";
                _RootElements[12] = "Sender";
                _RootElements[13] = "SentAsString";
                _RootElements[14] = "Source";
                _RootElements[15] = "StatusId";
                _RootElements[16] = "Code";
                _RootElements[17] = "AuthToken";
                _RootElements[18] = "AlertId";
                _RootElements[19] = "WorkflowStatus";
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
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Property1",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"7f3829d0-11fd-4f0c-8d6c-c8cef022f274")]
    public sealed class Property1 : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Property1", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Addresses",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"12046c20-e259-45e4-a28d-6b5c510a1614")]
    public sealed class Addresses : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Addresses", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Altitude",@"https://AMS.Orchestrations.PropertySchema","decimal","System.Decimal")]
    [PropertyGuidAttribute(@"eaa612bb-9aef-4bd1-b83d-d3a097902cb9")]
    public sealed class Altitude : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Altitude", @"https://AMS.Orchestrations.PropertySchema");
        
        private static decimal PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(decimal);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Description",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"97418c6b-a261-43f5-a05a-b392848252d2")]
    public sealed class Description : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Description", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"DeviceId",@"https://AMS.Orchestrations.PropertySchema","long","System.Int64")]
    [PropertyGuidAttribute(@"3b6c8a05-002d-4b13-97aa-53846c1b6165")]
    public sealed class DeviceId : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"DeviceId", @"https://AMS.Orchestrations.PropertySchema");
        
        private static long PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(long);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Lat",@"https://AMS.Orchestrations.PropertySchema","decimal","System.Decimal")]
    [PropertyGuidAttribute(@"7f1da30d-06c8-4f22-be45-fd79b6b74354")]
    public sealed class Lat : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Lat", @"https://AMS.Orchestrations.PropertySchema");
        
        private static decimal PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(decimal);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"LocationDescription",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"d7072a58-ae0b-4643-9cdb-cbb9db616df4")]
    public sealed class LocationDescription : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"LocationDescription", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Long",@"https://AMS.Orchestrations.PropertySchema","decimal","System.Decimal")]
    [PropertyGuidAttribute(@"edff83b9-054f-4e81-a47b-bfcc2a79c8c3")]
    public sealed class Long : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Long", @"https://AMS.Orchestrations.PropertySchema");
        
        private static decimal PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(decimal);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Metadata",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"5e3a67b0-b0cd-4791-b186-a92be86fd28a")]
    public sealed class Metadata : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Metadata", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"__Type",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"7da22717-3f89-4278-9e97-0b0c128f6fb9")]
    public sealed class @__Type : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"__Type", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"MessageTypeId",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"0e59654b-3d4f-410f-9ecd-8f552ca6c647")]
    public sealed class MessageTypeId : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"MessageTypeId", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Note",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"03e9e677-eb36-4ab4-97e4-888876130d05")]
    public sealed class Note : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Note", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Sender",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"62fd975d-fd2d-46d0-b7ca-6e0e891282c0")]
    public sealed class Sender : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Sender", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"SentAsString",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"10fb87bc-1048-44d3-9202-9029624a3bf5")]
    public sealed class SentAsString : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"SentAsString", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Source",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"aa0fa77b-24eb-4f78-bb7f-ba92f56239d3")]
    public sealed class Source : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Source", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"StatusId",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"3232e017-ffd3-4919-9e99-99236bfa0d2b")]
    public sealed class StatusId : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"StatusId", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"Code",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"51b12f1c-3a84-47e5-9fe7-b00abf629aa4")]
    public sealed class Code : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"Code", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"AuthToken",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"ad6636a2-1149-4410-bcdf-c2eb68eb7e30")]
    public sealed class AuthToken : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"AuthToken", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"AlertId",@"https://AMS.Orchestrations.PropertySchema","long","System.Int64")]
    [PropertyGuidAttribute(@"95c404ef-0cbc-4cd9-9b02-135835fb0372")]
    public sealed class AlertId : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"AlertId", @"https://AMS.Orchestrations.PropertySchema");
        
        private static long PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(long);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"WorkflowStatus",@"https://AMS.Orchestrations.PropertySchema","string","System.String")]
    [PropertyGuidAttribute(@"2afd4933-924f-4a17-95d4-edabe74a3682")]
    public sealed class WorkflowStatus : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"WorkflowStatus", @"https://AMS.Orchestrations.PropertySchema");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
}
