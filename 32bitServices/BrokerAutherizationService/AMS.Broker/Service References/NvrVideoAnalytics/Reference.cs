﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.AutherizationService.NvrVideoAnalytics {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VideoAnalyticsParameters", Namespace="http://schemas.datacontract.org/2004/07/TwTw.VideoAnaliyticsService")]
    [System.SerializableAttribute()]
    public partial class VideoAnalyticsParameters : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AlarmDelayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CamIpField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CamPassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CamUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CamUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid CameraGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FPSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MaxBlobSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MinBlobSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NvrPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NvrUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PeopleCounterStartCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResvOneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResvThreeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResvTwoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TripWireDirectionFlagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float UpdateRateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VideoPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WidthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ZoneColumnsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ZoneDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ZoneRowsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AlarmDelay {
            get {
                return this.AlarmDelayField;
            }
            set {
                if ((this.AlarmDelayField.Equals(value) != true)) {
                    this.AlarmDelayField = value;
                    this.RaisePropertyChanged("AlarmDelay");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CamIp {
            get {
                return this.CamIpField;
            }
            set {
                if ((object.ReferenceEquals(this.CamIpField, value) != true)) {
                    this.CamIpField = value;
                    this.RaisePropertyChanged("CamIp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CamPass {
            get {
                return this.CamPassField;
            }
            set {
                if ((object.ReferenceEquals(this.CamPassField, value) != true)) {
                    this.CamPassField = value;
                    this.RaisePropertyChanged("CamPass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CamUrl {
            get {
                return this.CamUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.CamUrlField, value) != true)) {
                    this.CamUrlField = value;
                    this.RaisePropertyChanged("CamUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CamUser {
            get {
                return this.CamUserField;
            }
            set {
                if ((object.ReferenceEquals(this.CamUserField, value) != true)) {
                    this.CamUserField = value;
                    this.RaisePropertyChanged("CamUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid CameraGuid {
            get {
                return this.CameraGuidField;
            }
            set {
                if ((this.CameraGuidField.Equals(value) != true)) {
                    this.CameraGuidField = value;
                    this.RaisePropertyChanged("CameraGuid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FPS {
            get {
                return this.FPSField;
            }
            set {
                if ((this.FPSField.Equals(value) != true)) {
                    this.FPSField = value;
                    this.RaisePropertyChanged("FPS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Height {
            get {
                return this.HeightField;
            }
            set {
                if ((this.HeightField.Equals(value) != true)) {
                    this.HeightField = value;
                    this.RaisePropertyChanged("Height");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxBlobSize {
            get {
                return this.MaxBlobSizeField;
            }
            set {
                if ((this.MaxBlobSizeField.Equals(value) != true)) {
                    this.MaxBlobSizeField = value;
                    this.RaisePropertyChanged("MaxBlobSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MinBlobSize {
            get {
                return this.MinBlobSizeField;
            }
            set {
                if ((this.MinBlobSizeField.Equals(value) != true)) {
                    this.MinBlobSizeField = value;
                    this.RaisePropertyChanged("MinBlobSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NvrPassword {
            get {
                return this.NvrPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.NvrPasswordField, value) != true)) {
                    this.NvrPasswordField = value;
                    this.RaisePropertyChanged("NvrPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NvrUser {
            get {
                return this.NvrUserField;
            }
            set {
                if ((object.ReferenceEquals(this.NvrUserField, value) != true)) {
                    this.NvrUserField = value;
                    this.RaisePropertyChanged("NvrUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PeopleCounterStartCount {
            get {
                return this.PeopleCounterStartCountField;
            }
            set {
                if ((this.PeopleCounterStartCountField.Equals(value) != true)) {
                    this.PeopleCounterStartCountField = value;
                    this.RaisePropertyChanged("PeopleCounterStartCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResvOne {
            get {
                return this.ResvOneField;
            }
            set {
                if ((object.ReferenceEquals(this.ResvOneField, value) != true)) {
                    this.ResvOneField = value;
                    this.RaisePropertyChanged("ResvOne");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResvThree {
            get {
                return this.ResvThreeField;
            }
            set {
                if ((object.ReferenceEquals(this.ResvThreeField, value) != true)) {
                    this.ResvThreeField = value;
                    this.RaisePropertyChanged("ResvThree");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResvTwo {
            get {
                return this.ResvTwoField;
            }
            set {
                if ((object.ReferenceEquals(this.ResvTwoField, value) != true)) {
                    this.ResvTwoField = value;
                    this.RaisePropertyChanged("ResvTwo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TripWireDirectionFlag {
            get {
                return this.TripWireDirectionFlagField;
            }
            set {
                if ((this.TripWireDirectionFlagField.Equals(value) != true)) {
                    this.TripWireDirectionFlagField = value;
                    this.RaisePropertyChanged("TripWireDirectionFlag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float UpdateRate {
            get {
                return this.UpdateRateField;
            }
            set {
                if ((this.UpdateRateField.Equals(value) != true)) {
                    this.UpdateRateField = value;
                    this.RaisePropertyChanged("UpdateRate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VideoPath {
            get {
                return this.VideoPathField;
            }
            set {
                if ((object.ReferenceEquals(this.VideoPathField, value) != true)) {
                    this.VideoPathField = value;
                    this.RaisePropertyChanged("VideoPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Width {
            get {
                return this.WidthField;
            }
            set {
                if ((this.WidthField.Equals(value) != true)) {
                    this.WidthField = value;
                    this.RaisePropertyChanged("Width");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ZoneColumns {
            get {
                return this.ZoneColumnsField;
            }
            set {
                if ((this.ZoneColumnsField.Equals(value) != true)) {
                    this.ZoneColumnsField = value;
                    this.RaisePropertyChanged("ZoneColumns");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] ZoneData {
            get {
                return this.ZoneDataField;
            }
            set {
                if ((object.ReferenceEquals(this.ZoneDataField, value) != true)) {
                    this.ZoneDataField = value;
                    this.RaisePropertyChanged("ZoneData");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ZoneRows {
            get {
                return this.ZoneRowsField;
            }
            set {
                if ((this.ZoneRowsField.Equals(value) != true)) {
                    this.ZoneRowsField = value;
                    this.RaisePropertyChanged("ZoneRows");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VideoAanalyticsEvent", Namespace="http://schemas.datacontract.org/2004/07/TwTw.VideoAnalyticsService.Interfaces")]
    [System.SerializableAttribute()]
    public partial class VideoAanalyticsEvent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ALGField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AlarmLevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CameraGuidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CenterXField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CenterYField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsInZoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LaneNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ObjectIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PeopleCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SentTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VehicleCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VehicleTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WidthField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ALG {
            get {
                return this.ALGField;
            }
            set {
                if ((this.ALGField.Equals(value) != true)) {
                    this.ALGField = value;
                    this.RaisePropertyChanged("ALG");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AlarmLevel {
            get {
                return this.AlarmLevelField;
            }
            set {
                if ((this.AlarmLevelField.Equals(value) != true)) {
                    this.AlarmLevelField = value;
                    this.RaisePropertyChanged("AlarmLevel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CameraGuid {
            get {
                return this.CameraGuidField;
            }
            set {
                if ((object.ReferenceEquals(this.CameraGuidField, value) != true)) {
                    this.CameraGuidField = value;
                    this.RaisePropertyChanged("CameraGuid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CenterX {
            get {
                return this.CenterXField;
            }
            set {
                if ((this.CenterXField.Equals(value) != true)) {
                    this.CenterXField = value;
                    this.RaisePropertyChanged("CenterX");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CenterY {
            get {
                return this.CenterYField;
            }
            set {
                if ((this.CenterYField.Equals(value) != true)) {
                    this.CenterYField = value;
                    this.RaisePropertyChanged("CenterY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Height {
            get {
                return this.HeightField;
            }
            set {
                if ((this.HeightField.Equals(value) != true)) {
                    this.HeightField = value;
                    this.RaisePropertyChanged("Height");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsInZone {
            get {
                return this.IsInZoneField;
            }
            set {
                if ((this.IsInZoneField.Equals(value) != true)) {
                    this.IsInZoneField = value;
                    this.RaisePropertyChanged("IsInZone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LaneNumber {
            get {
                return this.LaneNumberField;
            }
            set {
                if ((this.LaneNumberField.Equals(value) != true)) {
                    this.LaneNumberField = value;
                    this.RaisePropertyChanged("LaneNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ObjectId {
            get {
                return this.ObjectIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectIdField, value) != true)) {
                    this.ObjectIdField = value;
                    this.RaisePropertyChanged("ObjectId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PeopleCount {
            get {
                return this.PeopleCountField;
            }
            set {
                if ((this.PeopleCountField.Equals(value) != true)) {
                    this.PeopleCountField = value;
                    this.RaisePropertyChanged("PeopleCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SentTime {
            get {
                return this.SentTimeField;
            }
            set {
                if ((this.SentTimeField.Equals(value) != true)) {
                    this.SentTimeField = value;
                    this.RaisePropertyChanged("SentTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VehicleCount {
            get {
                return this.VehicleCountField;
            }
            set {
                if ((this.VehicleCountField.Equals(value) != true)) {
                    this.VehicleCountField = value;
                    this.RaisePropertyChanged("VehicleCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VehicleType {
            get {
                return this.VehicleTypeField;
            }
            set {
                if ((this.VehicleTypeField.Equals(value) != true)) {
                    this.VehicleTypeField = value;
                    this.RaisePropertyChanged("VehicleType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Width {
            get {
                return this.WidthField;
            }
            set {
                if ((this.WidthField.Equals(value) != true)) {
                    this.WidthField = value;
                    this.RaisePropertyChanged("Width");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NvrVideoAnalytics.IVideoAnalyticsService")]
    public interface IVideoAnalyticsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetCapabilities", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetCapabilitiesResponse")]
        string[] GetCapabilities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetCapabilities", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetCapabilitiesResponse")]
        System.Threading.Tasks.Task<string[]> GetCapabilitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/SetupAnalytics", ReplyAction="http://tempuri.org/IVideoAnalyticsService/SetupAnalyticsResponse")]
        bool SetupAnalytics(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/SetupAnalytics", ReplyAction="http://tempuri.org/IVideoAnalyticsService/SetupAnalyticsResponse")]
        System.Threading.Tasks.Task<bool> SetupAnalyticsAsync(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StartAnalytics", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StartAnalyticsResponse")]
        bool StartAnalytics(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StartAnalytics", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StartAnalyticsResponse")]
        System.Threading.Tasks.Task<bool> StartAnalyticsAsync(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetEvents", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetEventsResponse")]
        AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAanalyticsEvent[] GetEvents(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetEvents", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetEventsResponse")]
        System.Threading.Tasks.Task<AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAanalyticsEvent[]> GetEventsAsync(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StopAnalytics", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StopAnalyticsResponse")]
        bool StopAnalytics(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StopAnalytics", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StopAnalyticsResponse")]
        System.Threading.Tasks.Task<bool> StopAnalyticsAsync(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetStatus", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetStatusResponse")]
        string GetStatus(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetStatus", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetStatusResponse")]
        System.Threading.Tasks.Task<string> GetStatusAsync(System.Guid cameraGuid, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetCapabilities2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetCapabilities2020Response")]
        string[] GetCapabilities2020();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetCapabilities2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetCapabilities2020Response")]
        System.Threading.Tasks.Task<string[]> GetCapabilities2020Async();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StartAnalytics2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StartAnalytics2020Response")]
        bool StartAnalytics2020(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters, string strCamIp, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StartAnalytics2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StartAnalytics2020Response")]
        System.Threading.Tasks.Task<bool> StartAnalytics2020Async(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters, string strCamIp, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StopAnalytics2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StopAnalytics2020Response")]
        bool StopAnalytics2020(string strCamIp, string version, System.Guid cameraGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/StopAnalytics2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/StopAnalytics2020Response")]
        System.Threading.Tasks.Task<bool> StopAnalytics2020Async(string strCamIp, string version, System.Guid cameraGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetStatus2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetStatus2020Response")]
        string GetStatus2020(string strCamIp, string version, System.Guid cameraGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoAnalyticsService/GetStatus2020", ReplyAction="http://tempuri.org/IVideoAnalyticsService/GetStatus2020Response")]
        System.Threading.Tasks.Task<string> GetStatus2020Async(string strCamIp, string version, System.Guid cameraGuid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVideoAnalyticsServiceChannel : AMS.Broker.AutherizationService.NvrVideoAnalytics.IVideoAnalyticsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VideoAnalyticsServiceClient : System.ServiceModel.ClientBase<AMS.Broker.AutherizationService.NvrVideoAnalytics.IVideoAnalyticsService>, AMS.Broker.AutherizationService.NvrVideoAnalytics.IVideoAnalyticsService {
        
        public VideoAnalyticsServiceClient() {
        }
        
        public VideoAnalyticsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VideoAnalyticsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoAnalyticsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoAnalyticsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetCapabilities() {
            return base.Channel.GetCapabilities();
        }
        
        public System.Threading.Tasks.Task<string[]> GetCapabilitiesAsync() {
            return base.Channel.GetCapabilitiesAsync();
        }
        
        public bool SetupAnalytics(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters) {
            return base.Channel.SetupAnalytics(parameters);
        }
        
        public System.Threading.Tasks.Task<bool> SetupAnalyticsAsync(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters) {
            return base.Channel.SetupAnalyticsAsync(parameters);
        }
        
        public bool StartAnalytics(System.Guid cameraGuid, string version) {
            return base.Channel.StartAnalytics(cameraGuid, version);
        }
        
        public System.Threading.Tasks.Task<bool> StartAnalyticsAsync(System.Guid cameraGuid, string version) {
            return base.Channel.StartAnalyticsAsync(cameraGuid, version);
        }
        
        public AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAanalyticsEvent[] GetEvents(System.Guid cameraGuid, string version) {
            return base.Channel.GetEvents(cameraGuid, version);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAanalyticsEvent[]> GetEventsAsync(System.Guid cameraGuid, string version) {
            return base.Channel.GetEventsAsync(cameraGuid, version);
        }
        
        public bool StopAnalytics(System.Guid cameraGuid, string version) {
            return base.Channel.StopAnalytics(cameraGuid, version);
        }
        
        public System.Threading.Tasks.Task<bool> StopAnalyticsAsync(System.Guid cameraGuid, string version) {
            return base.Channel.StopAnalyticsAsync(cameraGuid, version);
        }
        
        public string GetStatus(System.Guid cameraGuid, string version) {
            return base.Channel.GetStatus(cameraGuid, version);
        }
        
        public System.Threading.Tasks.Task<string> GetStatusAsync(System.Guid cameraGuid, string version) {
            return base.Channel.GetStatusAsync(cameraGuid, version);
        }
        
        public string[] GetCapabilities2020() {
            return base.Channel.GetCapabilities2020();
        }
        
        public System.Threading.Tasks.Task<string[]> GetCapabilities2020Async() {
            return base.Channel.GetCapabilities2020Async();
        }
        
        public bool StartAnalytics2020(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters, string strCamIp, string version) {
            return base.Channel.StartAnalytics2020(parameters, strCamIp, version);
        }
        
        public System.Threading.Tasks.Task<bool> StartAnalytics2020Async(AMS.Broker.AutherizationService.NvrVideoAnalytics.VideoAnalyticsParameters parameters, string strCamIp, string version) {
            return base.Channel.StartAnalytics2020Async(parameters, strCamIp, version);
        }
        
        public bool StopAnalytics2020(string strCamIp, string version, System.Guid cameraGuid) {
            return base.Channel.StopAnalytics2020(strCamIp, version, cameraGuid);
        }
        
        public System.Threading.Tasks.Task<bool> StopAnalytics2020Async(string strCamIp, string version, System.Guid cameraGuid) {
            return base.Channel.StopAnalytics2020Async(strCamIp, version, cameraGuid);
        }
        
        public string GetStatus2020(string strCamIp, string version, System.Guid cameraGuid) {
            return base.Channel.GetStatus2020(strCamIp, version, cameraGuid);
        }
        
        public System.Threading.Tasks.Task<string> GetStatus2020Async(string strCamIp, string version, System.Guid cameraGuid) {
            return base.Channel.GetStatus2020Async(strCamIp, version, cameraGuid);
        }
    }
}
