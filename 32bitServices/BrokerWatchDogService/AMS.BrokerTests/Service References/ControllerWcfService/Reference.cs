﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.WatchDogServiceTests.ControllerWcfService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ControllerWcfService.IControllerService")]
    public interface IControllerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/Test", ReplyAction="http://tempuri.org/IControllerService/TestResponse")]
        bool Test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/Test", ReplyAction="http://tempuri.org/IControllerService/TestResponse")]
        System.Threading.Tasks.Task<bool> TestAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDevicesCollection", ReplyAction="http://tempuri.org/IControllerService/GetDevicesCollectionResponse")]
        AMS.Broker.Contracts.DTO.DeviceDto[] GetDevicesCollection(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDevicesCollection", ReplyAction="http://tempuri.org/IControllerService/GetDevicesCollectionResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetDevicesCollectionAsync(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDevicesCollectionUnsafe", ReplyAction="http://tempuri.org/IControllerService/GetDevicesCollectionUnsafeResponse")]
        AMS.Broker.Contracts.DTO.DeviceDto[] GetDevicesCollectionUnsafe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDevicesCollectionUnsafe", ReplyAction="http://tempuri.org/IControllerService/GetDevicesCollectionUnsafeResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetDevicesCollectionUnsafeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetGroupsCollection", ReplyAction="http://tempuri.org/IControllerService/GetGroupsCollectionResponse")]
        AMS.Broker.Contracts.DTO.Group[] GetGroupsCollection(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetGroupsCollection", ReplyAction="http://tempuri.org/IControllerService/GetGroupsCollectionResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Group[]> GetGroupsCollectionAsync(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDeviceById", ReplyAction="http://tempuri.org/IControllerService/GetDeviceByIdResponse")]
        AMS.Broker.Contracts.DTO.DeviceDto GetDeviceById(string authToken, long deviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDeviceById", ReplyAction="http://tempuri.org/IControllerService/GetDeviceByIdResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto> GetDeviceByIdAsync(string authToken, long deviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateGroup", ReplyAction="http://tempuri.org/IControllerService/UpdateGroupResponse")]
        AMS.Broker.Contracts.DTO.Group UpdateGroup(string authToken, string serializedGroup);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateGroup", ReplyAction="http://tempuri.org/IControllerService/UpdateGroupResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Group> UpdateGroupAsync(string authToken, string serializedGroup);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDeviceTypes", ReplyAction="http://tempuri.org/IControllerService/GetDeviceTypesResponse")]
        string[] GetDeviceTypes(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetDeviceTypes", ReplyAction="http://tempuri.org/IControllerService/GetDeviceTypesResponse")]
        System.Threading.Tasks.Task<string[]> GetDeviceTypesAsync(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/CreateDeviceType", ReplyAction="http://tempuri.org/IControllerService/CreateDeviceTypeResponse")]
        bool CreateDeviceType(string authToken, string newType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/CreateDeviceType", ReplyAction="http://tempuri.org/IControllerService/CreateDeviceTypeResponse")]
        System.Threading.Tasks.Task<bool> CreateDeviceTypeAsync(string authToken, string newType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateDeviceType", ReplyAction="http://tempuri.org/IControllerService/UpdateDeviceTypeResponse")]
        bool UpdateDeviceType(string authToken, string currentType, string newType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateDeviceType", ReplyAction="http://tempuri.org/IControllerService/UpdateDeviceTypeResponse")]
        System.Threading.Tasks.Task<bool> UpdateDeviceTypeAsync(string authToken, string currentType, string newType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateDevice", ReplyAction="http://tempuri.org/IControllerService/UpdateDeviceResponse")]
        bool UpdateDevice(System.Guid authToken, string device);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateDevice", ReplyAction="http://tempuri.org/IControllerService/UpdateDeviceResponse")]
        System.Threading.Tasks.Task<bool> UpdateDeviceAsync(System.Guid authToken, string device);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/DeleteDeviceType", ReplyAction="http://tempuri.org/IControllerService/DeleteDeviceTypeResponse")]
        bool DeleteDeviceType(string authToken, string typeToDelete);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/DeleteDeviceType", ReplyAction="http://tempuri.org/IControllerService/DeleteDeviceTypeResponse")]
        System.Threading.Tasks.Task<bool> DeleteDeviceTypeAsync(string authToken, string typeToDelete);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/SubmitDevice", ReplyAction="http://tempuri.org/IControllerService/SubmitDeviceResponse")]
        bool SubmitDevice(string authToken, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/SubmitDevice", ReplyAction="http://tempuri.org/IControllerService/SubmitDeviceResponse")]
        System.Threading.Tasks.Task<bool> SubmitDeviceAsync(string authToken, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/DeleteDevice", ReplyAction="http://tempuri.org/IControllerService/DeleteDeviceResponse")]
        bool DeleteDevice(string authToken, long devId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/DeleteDevice", ReplyAction="http://tempuri.org/IControllerService/DeleteDeviceResponse")]
        System.Threading.Tasks.Task<bool> DeleteDeviceAsync(string authToken, long devId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/AddNvr", ReplyAction="http://tempuri.org/IControllerService/AddNvrResponse")]
        bool AddNvr(string authToken, string Nvr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/AddNvr", ReplyAction="http://tempuri.org/IControllerService/AddNvrResponse")]
        System.Threading.Tasks.Task<bool> AddNvrAsync(string authToken, string Nvr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetNvrs", ReplyAction="http://tempuri.org/IControllerService/GetNvrsResponse")]
        AMS.Broker.Contracts.DTO.NvrDto[] GetNvrs(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetNvrs", ReplyAction="http://tempuri.org/IControllerService/GetNvrsResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.NvrDto[]> GetNvrsAsync(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateNvr", ReplyAction="http://tempuri.org/IControllerService/UpdateNvrResponse")]
        bool UpdateNvr(string authToken, string nvr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/UpdateNvr", ReplyAction="http://tempuri.org/IControllerService/UpdateNvrResponse")]
        System.Threading.Tasks.Task<bool> UpdateNvrAsync(string authToken, string nvr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/DeleteNvr", ReplyAction="http://tempuri.org/IControllerService/DeleteNvrResponse")]
        bool DeleteNvr(string authToken, long nvrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/DeleteNvr", ReplyAction="http://tempuri.org/IControllerService/DeleteNvrResponse")]
        System.Threading.Tasks.Task<bool> DeleteNvrAsync(string authToken, long nvrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetNvrById", ReplyAction="http://tempuri.org/IControllerService/GetNvrByIdResponse")]
        AMS.Broker.Contracts.DTO.NvrDto GetNvrById(string authToken, long nvrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetNvrById", ReplyAction="http://tempuri.org/IControllerService/GetNvrByIdResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.NvrDto> GetNvrByIdAsync(string authToken, long nvrId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetGroupById", ReplyAction="http://tempuri.org/IControllerService/GetGroupByIdResponse")]
        AMS.Broker.Contracts.DTO.Group GetGroupById(string authToken, long groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetGroupById", ReplyAction="http://tempuri.org/IControllerService/GetGroupByIdResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Group> GetGroupByIdAsync(string authToken, long groupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetValuesLookUp", ReplyAction="http://tempuri.org/IControllerService/GetValuesLookUpResponse")]
        AMS.Broker.Contracts.DTO.ValuesLookUp[] GetValuesLookUp(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetValuesLookUp", ReplyAction="http://tempuri.org/IControllerService/GetValuesLookUpResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.ValuesLookUp[]> GetValuesLookUpAsync(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetValuesHistory", ReplyAction="http://tempuri.org/IControllerService/GetValuesHistoryResponse")]
        string[] GetValuesHistory(string authToken, long deviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetValuesHistory", ReplyAction="http://tempuri.org/IControllerService/GetValuesHistoryResponse")]
        System.Threading.Tasks.Task<string[]> GetValuesHistoryAsync(string authToken, long deviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetNewEvents", ReplyAction="http://tempuri.org/IControllerService/GetNewEventsResponse")]
        AMS.Broker.Contracts.DTO.Event[] GetNewEvents(string authToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IControllerService/GetNewEvents", ReplyAction="http://tempuri.org/IControllerService/GetNewEventsResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Event[]> GetNewEventsAsync(string authToken);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IControllerServiceChannel : AMS.Broker.WatchDogServiceTests.ControllerWcfService.IControllerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ControllerServiceClient : System.ServiceModel.ClientBase<AMS.Broker.WatchDogServiceTests.ControllerWcfService.IControllerService>, AMS.Broker.WatchDogServiceTests.ControllerWcfService.IControllerService {
        
        public ControllerServiceClient() {
        }
        
        public ControllerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ControllerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ControllerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ControllerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Test() {
            return base.Channel.Test();
        }
        
        public System.Threading.Tasks.Task<bool> TestAsync() {
            return base.Channel.TestAsync();
        }
        
        public AMS.Broker.Contracts.DTO.DeviceDto[] GetDevicesCollection(string authToken) {
            return base.Channel.GetDevicesCollection(authToken);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetDevicesCollectionAsync(string authToken) {
            return base.Channel.GetDevicesCollectionAsync(authToken);
        }
        
        public AMS.Broker.Contracts.DTO.DeviceDto[] GetDevicesCollectionUnsafe() {
            return base.Channel.GetDevicesCollectionUnsafe();
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetDevicesCollectionUnsafeAsync() {
            return base.Channel.GetDevicesCollectionUnsafeAsync();
        }
        
        public AMS.Broker.Contracts.DTO.Group[] GetGroupsCollection(string authToken) {
            return base.Channel.GetGroupsCollection(authToken);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Group[]> GetGroupsCollectionAsync(string authToken) {
            return base.Channel.GetGroupsCollectionAsync(authToken);
        }
        
        public AMS.Broker.Contracts.DTO.DeviceDto GetDeviceById(string authToken, long deviceId) {
            return base.Channel.GetDeviceById(authToken, deviceId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto> GetDeviceByIdAsync(string authToken, long deviceId) {
            return base.Channel.GetDeviceByIdAsync(authToken, deviceId);
        }
        
        public AMS.Broker.Contracts.DTO.Group UpdateGroup(string authToken, string serializedGroup) {
            return base.Channel.UpdateGroup(authToken, serializedGroup);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Group> UpdateGroupAsync(string authToken, string serializedGroup) {
            return base.Channel.UpdateGroupAsync(authToken, serializedGroup);
        }
        
        public string[] GetDeviceTypes(string authToken) {
            return base.Channel.GetDeviceTypes(authToken);
        }
        
        public System.Threading.Tasks.Task<string[]> GetDeviceTypesAsync(string authToken) {
            return base.Channel.GetDeviceTypesAsync(authToken);
        }
        
        public bool CreateDeviceType(string authToken, string newType) {
            return base.Channel.CreateDeviceType(authToken, newType);
        }
        
        public System.Threading.Tasks.Task<bool> CreateDeviceTypeAsync(string authToken, string newType) {
            return base.Channel.CreateDeviceTypeAsync(authToken, newType);
        }
        
        public bool UpdateDeviceType(string authToken, string currentType, string newType) {
            return base.Channel.UpdateDeviceType(authToken, currentType, newType);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateDeviceTypeAsync(string authToken, string currentType, string newType) {
            return base.Channel.UpdateDeviceTypeAsync(authToken, currentType, newType);
        }
        
        public bool UpdateDevice(System.Guid authToken, string device) {
            return base.Channel.UpdateDevice(authToken, device);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateDeviceAsync(System.Guid authToken, string device) {
            return base.Channel.UpdateDeviceAsync(authToken, device);
        }
        
        public bool DeleteDeviceType(string authToken, string typeToDelete) {
            return base.Channel.DeleteDeviceType(authToken, typeToDelete);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteDeviceTypeAsync(string authToken, string typeToDelete) {
            return base.Channel.DeleteDeviceTypeAsync(authToken, typeToDelete);
        }
        
        public bool SubmitDevice(string authToken, string content) {
            return base.Channel.SubmitDevice(authToken, content);
        }
        
        public System.Threading.Tasks.Task<bool> SubmitDeviceAsync(string authToken, string content) {
            return base.Channel.SubmitDeviceAsync(authToken, content);
        }
        
        public bool DeleteDevice(string authToken, long devId) {
            return base.Channel.DeleteDevice(authToken, devId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteDeviceAsync(string authToken, long devId) {
            return base.Channel.DeleteDeviceAsync(authToken, devId);
        }
        
        public bool AddNvr(string authToken, string Nvr) {
            return base.Channel.AddNvr(authToken, Nvr);
        }
        
        public System.Threading.Tasks.Task<bool> AddNvrAsync(string authToken, string Nvr) {
            return base.Channel.AddNvrAsync(authToken, Nvr);
        }
        
        public AMS.Broker.Contracts.DTO.NvrDto[] GetNvrs(string authToken) {
            return base.Channel.GetNvrs(authToken);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.NvrDto[]> GetNvrsAsync(string authToken) {
            return base.Channel.GetNvrsAsync(authToken);
        }
        
        public bool UpdateNvr(string authToken, string nvr) {
            return base.Channel.UpdateNvr(authToken, nvr);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateNvrAsync(string authToken, string nvr) {
            return base.Channel.UpdateNvrAsync(authToken, nvr);
        }
        
        public bool DeleteNvr(string authToken, long nvrId) {
            return base.Channel.DeleteNvr(authToken, nvrId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteNvrAsync(string authToken, long nvrId) {
            return base.Channel.DeleteNvrAsync(authToken, nvrId);
        }
        
        public AMS.Broker.Contracts.DTO.NvrDto GetNvrById(string authToken, long nvrId) {
            return base.Channel.GetNvrById(authToken, nvrId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.NvrDto> GetNvrByIdAsync(string authToken, long nvrId) {
            return base.Channel.GetNvrByIdAsync(authToken, nvrId);
        }
        
        public AMS.Broker.Contracts.DTO.Group GetGroupById(string authToken, long groupId) {
            return base.Channel.GetGroupById(authToken, groupId);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Group> GetGroupByIdAsync(string authToken, long groupId) {
            return base.Channel.GetGroupByIdAsync(authToken, groupId);
        }
        
        public AMS.Broker.Contracts.DTO.ValuesLookUp[] GetValuesLookUp(string authToken) {
            return base.Channel.GetValuesLookUp(authToken);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.ValuesLookUp[]> GetValuesLookUpAsync(string authToken) {
            return base.Channel.GetValuesLookUpAsync(authToken);
        }
        
        public string[] GetValuesHistory(string authToken, long deviceId) {
            return base.Channel.GetValuesHistory(authToken, deviceId);
        }
        
        public System.Threading.Tasks.Task<string[]> GetValuesHistoryAsync(string authToken, long deviceId) {
            return base.Channel.GetValuesHistoryAsync(authToken, deviceId);
        }
        
        public AMS.Broker.Contracts.DTO.Event[] GetNewEvents(string authToken) {
            return base.Channel.GetNewEvents(authToken);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.Event[]> GetNewEventsAsync(string authToken) {
            return base.Channel.GetNewEventsAsync(authToken);
        }
    }
}
