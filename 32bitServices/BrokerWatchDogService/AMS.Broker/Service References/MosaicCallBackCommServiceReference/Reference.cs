﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.WatchDogService.MosaicCallBackCommServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MosaicCallBackCommServiceReference.IMosaicCallBackCommService")]
    public interface IMosaicCallBackCommService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMosaicCallBackCommService/DeviceStartRequest", ReplyAction="http://tempuri.org/IMosaicCallBackCommService/DeviceStartRequestResponse")]
        void DeviceStartRequest(int winId, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMosaicCallBackCommService/DeviceStartRequest", ReplyAction="http://tempuri.org/IMosaicCallBackCommService/DeviceStartRequestResponse")]
        System.Threading.Tasks.Task DeviceStartRequestAsync(int winId, string content);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMosaicCallBackCommService/CheckStatus", ReplyAction="http://tempuri.org/IMosaicCallBackCommService/CheckStatusResponse")]
        int CheckStatus();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMosaicCallBackCommService/CheckStatus", ReplyAction="http://tempuri.org/IMosaicCallBackCommService/CheckStatusResponse")]
        System.Threading.Tasks.Task<int> CheckStatusAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMosaicCallBackCommServiceChannel : AMS.Broker.WatchDogService.MosaicCallBackCommServiceReference.IMosaicCallBackCommService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MosaicCallBackCommServiceClient : System.ServiceModel.ClientBase<AMS.Broker.WatchDogService.MosaicCallBackCommServiceReference.IMosaicCallBackCommService>, AMS.Broker.WatchDogService.MosaicCallBackCommServiceReference.IMosaicCallBackCommService {
        
        public MosaicCallBackCommServiceClient() {
        }
        
        public MosaicCallBackCommServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MosaicCallBackCommServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MosaicCallBackCommServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MosaicCallBackCommServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DeviceStartRequest(int winId, string content) {
            base.Channel.DeviceStartRequest(winId, content);
        }
        
        public System.Threading.Tasks.Task DeviceStartRequestAsync(int winId, string content) {
            return base.Channel.DeviceStartRequestAsync(winId, content);
        }
        
        public int CheckStatus() {
            return base.Channel.CheckStatus();
        }
        
        public System.Threading.Tasks.Task<int> CheckStatusAsync() {
            return base.Channel.CheckStatusAsync();
        }
    }
}
