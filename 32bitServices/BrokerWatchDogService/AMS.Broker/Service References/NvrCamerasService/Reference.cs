﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.WatchDogService.NvrCamerasService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NvrCamerasService.INvrCamerasService")]
    public interface INvrCamerasService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INvrCamerasService/GetCameras", ReplyAction="http://tempuri.org/INvrCamerasService/GetCamerasResponse")]
        AMS.Broker.Contracts.DTO.DeviceDto[] GetCameras(string nvr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INvrCamerasService/GetCameras", ReplyAction="http://tempuri.org/INvrCamerasService/GetCamerasResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetCamerasAsync(string nvr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INvrCamerasService/GetCamerasByNvr", ReplyAction="http://tempuri.org/INvrCamerasService/GetCamerasByNvrResponse")]
        AMS.Broker.Contracts.DTO.DeviceDto[] GetCamerasByNvr(AMS.Broker.Contracts.DTO.NvrDto nvr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INvrCamerasService/GetCamerasByNvr", ReplyAction="http://tempuri.org/INvrCamerasService/GetCamerasByNvrResponse")]
        System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetCamerasByNvrAsync(AMS.Broker.Contracts.DTO.NvrDto nvr);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INvrCamerasServiceChannel : AMS.Broker.WatchDogService.NvrCamerasService.INvrCamerasService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NvrCamerasServiceClient : System.ServiceModel.ClientBase<AMS.Broker.WatchDogService.NvrCamerasService.INvrCamerasService>, AMS.Broker.WatchDogService.NvrCamerasService.INvrCamerasService {
        
        public NvrCamerasServiceClient() {
        }
        
        public NvrCamerasServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NvrCamerasServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NvrCamerasServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NvrCamerasServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AMS.Broker.Contracts.DTO.DeviceDto[] GetCameras(string nvr) {
            return base.Channel.GetCameras(nvr);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetCamerasAsync(string nvr) {
            return base.Channel.GetCamerasAsync(nvr);
        }
        
        public AMS.Broker.Contracts.DTO.DeviceDto[] GetCamerasByNvr(AMS.Broker.Contracts.DTO.NvrDto nvr) {
            return base.Channel.GetCamerasByNvr(nvr);
        }
        
        public System.Threading.Tasks.Task<AMS.Broker.Contracts.DTO.DeviceDto[]> GetCamerasByNvrAsync(AMS.Broker.Contracts.DTO.NvrDto nvr) {
            return base.Channel.GetCamerasByNvrAsync(nvr);
        }
    }
}