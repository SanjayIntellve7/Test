﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.AutherizationService.DashBoardCallBackCommServiceClientRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DashBoardCallBackCommServiceClientRef.IDashBoardCallBackCommServiceClient")]
    public interface IDashBoardCallBackCommServiceClient {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashBoardCallBackCommServiceClient/RaiseCurrentWeatherInfo", ReplyAction="http://tempuri.org/IDashBoardCallBackCommServiceClient/RaiseCurrentWeatherInfoRes" +
            "ponse")]
        void RaiseCurrentWeatherInfo(string currentWeather);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashBoardCallBackCommServiceClient/RaiseCurrentWeatherInfo", ReplyAction="http://tempuri.org/IDashBoardCallBackCommServiceClient/RaiseCurrentWeatherInfoRes" +
            "ponse")]
        System.Threading.Tasks.Task RaiseCurrentWeatherInfoAsync(string currentWeather);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDashBoardCallBackCommServiceClientChannel : AMS.Broker.AutherizationService.DashBoardCallBackCommServiceClientRef.IDashBoardCallBackCommServiceClient, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DashBoardCallBackCommServiceClientClient : System.ServiceModel.ClientBase<AMS.Broker.AutherizationService.DashBoardCallBackCommServiceClientRef.IDashBoardCallBackCommServiceClient>, AMS.Broker.AutherizationService.DashBoardCallBackCommServiceClientRef.IDashBoardCallBackCommServiceClient {
        
        public DashBoardCallBackCommServiceClientClient() {
        }
        
        public DashBoardCallBackCommServiceClientClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DashBoardCallBackCommServiceClientClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DashBoardCallBackCommServiceClientClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DashBoardCallBackCommServiceClientClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void RaiseCurrentWeatherInfo(string currentWeather) {
            base.Channel.RaiseCurrentWeatherInfo(currentWeather);
        }
        
        public System.Threading.Tasks.Task RaiseCurrentWeatherInfoAsync(string currentWeather) {
            return base.Channel.RaiseCurrentWeatherInfoAsync(currentWeather);
        }
    }
}
