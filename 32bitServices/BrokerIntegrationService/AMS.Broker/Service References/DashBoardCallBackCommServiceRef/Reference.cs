﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMS.Broker.IntegrationService.DashBoardCallBackCommServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DashBoardCallBackCommServiceRef.IDashBoardCallBackCommService")]
    public interface IDashBoardCallBackCommService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashBoardCallBackCommService/RaiseCurrentClimateAlert", ReplyAction="http://tempuri.org/IDashBoardCallBackCommService/RaiseCurrentClimateAlertResponse" +
            "")]
        bool RaiseCurrentClimateAlert(string CurrentClimateData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashBoardCallBackCommService/RaiseCurrentClimateAlert", ReplyAction="http://tempuri.org/IDashBoardCallBackCommService/RaiseCurrentClimateAlertResponse" +
            "")]
        System.Threading.Tasks.Task<bool> RaiseCurrentClimateAlertAsync(string CurrentClimateData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashBoardCallBackCommService/RaiseForecastClimateAlert", ReplyAction="http://tempuri.org/IDashBoardCallBackCommService/RaiseForecastClimateAlertRespons" +
            "e")]
        bool RaiseForecastClimateAlert(string ForecastClimateData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashBoardCallBackCommService/RaiseForecastClimateAlert", ReplyAction="http://tempuri.org/IDashBoardCallBackCommService/RaiseForecastClimateAlertRespons" +
            "e")]
        System.Threading.Tasks.Task<bool> RaiseForecastClimateAlertAsync(string ForecastClimateData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDashBoardCallBackCommServiceChannel : AMS.Broker.IntegrationService.DashBoardCallBackCommServiceRef.IDashBoardCallBackCommService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DashBoardCallBackCommServiceClient : System.ServiceModel.ClientBase<AMS.Broker.IntegrationService.DashBoardCallBackCommServiceRef.IDashBoardCallBackCommService>, AMS.Broker.IntegrationService.DashBoardCallBackCommServiceRef.IDashBoardCallBackCommService {
        
        public DashBoardCallBackCommServiceClient() {
        }
        
        public DashBoardCallBackCommServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DashBoardCallBackCommServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DashBoardCallBackCommServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DashBoardCallBackCommServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool RaiseCurrentClimateAlert(string CurrentClimateData) {
            return base.Channel.RaiseCurrentClimateAlert(CurrentClimateData);
        }
        
        public System.Threading.Tasks.Task<bool> RaiseCurrentClimateAlertAsync(string CurrentClimateData) {
            return base.Channel.RaiseCurrentClimateAlertAsync(CurrentClimateData);
        }
        
        public bool RaiseForecastClimateAlert(string ForecastClimateData) {
            return base.Channel.RaiseForecastClimateAlert(ForecastClimateData);
        }
        
        public System.Threading.Tasks.Task<bool> RaiseForecastClimateAlertAsync(string ForecastClimateData) {
            return base.Channel.RaiseForecastClimateAlertAsync(ForecastClimateData);
        }
    }
}
