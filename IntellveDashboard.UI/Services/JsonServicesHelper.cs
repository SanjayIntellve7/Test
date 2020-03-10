using CustomLogContracts;
using IntellveDashboard.UI.Interfaces;
using IntellveDashboard.UI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace IntellveDashboard.UI
{
    public class JsonServicesHelper : IJsonServicesHelper
    {
        public bool _IsPrimaryAtive;
        private readonly IOptions<ConfigSettingsModel> _settings;
        private readonly ILoggerManager _loggerManager;

        public JsonServicesHelper(IOptions<ConfigSettingsModel> settings, ILoggerManager loggerManager)
        {
            _settings = settings;
            _loggerManager = loggerManager;
        }
        public string GetSerivcePath(string serviceName, string method, params string[] parameters)
        {


            string ServerPath = null;
            ServerIpConfigurationModel _ServerConfigModel = null;

            try
            {

                foreach (var _param in parameters)
                {
                    if (_param.Contains("authToken=") || _param.Contains("AuthToken="))
                    {
                        var _ParamVal = _param.Split('=');
                        Guid _authTok = new Guid(_ParamVal[1]);
                        var ConfigList = AuthenticationService.ServerIpConfigurationList.Where(x => x.AuthToken == _authTok).FirstOrDefault();
                        if (ConfigList != null)
                        {
                            _ServerConfigModel = ConfigList;
                        }
                    }
                }
                if (_ServerConfigModel != null)
                {
                    if (_IsPrimaryAtive)
                    {
                        if (serviceName == "GatewayService" || serviceName == "CameraStatusService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.WatchDogServiceIp + ":6530";
                        }
                        else if (serviceName == "StationServiceCommunication" || serviceName == "StationsService" || serviceName == "WebStation")
                        {
                            ServerPath = "https://" + _ServerConfigModel.CommunicationServiceIp + ":6530";
                        }
                        else if (serviceName == "Directory" || serviceName == "AuthService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.AutherizationServiceIp + ":6530";
                        }
                        else if (serviceName == "AlertsSetOperationService" || serviceName == "IncidentReportSetOperationService" || serviceName == "IncidentReportSetOperationServiceWeb" || serviceName == "ZoneSetOperation" ||
                            serviceName == "ControllerSetOperation" || serviceName == "AccountsSetOperationService" || serviceName == "SitesSetOperationService" || serviceName == "SystemSetOperationService"
                            || serviceName == "UsersSetOperationService" || serviceName == "SecuritySetOperationService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SetOperationServiceIp + ":6530";
                        }
                        else if (serviceName == "DashBoardService" || serviceName == "Harness" || serviceName == "ZoneGetOperation" || serviceName == "ControllerGetOperation" || serviceName == "AlertsGetOperationService" ||
                            serviceName == "AccountsGetOperationService" || serviceName == "SitesGetOperationService" || serviceName == "SystemGetOperationService" || serviceName == "LookupService" || serviceName == "UsersGetOperationService" ||
                            serviceName == "SecurityGetOperationService" || serviceName == "IncidentReportGetOperationService" || serviceName == "IncidentReportGetOperationServiceWeb" || serviceName == "ParkingPollGetopService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.GetOperationServiceIp + ":6530";
                        }
                        else if (serviceName == "GeneralPurposeService" || serviceName == "AlertsCreationService" || serviceName == "StreamInsightService" || serviceName == "StreamInsightAlertService" || serviceName == "VideoAnalyticsManagerService" ||
                            serviceName == "ACSTransactionService" || serviceName == "EdgeBaseAnalyticsService" || serviceName == "ANPRService" || serviceName == "MatrixControllerTransactionService" || serviceName == "_2020SNMPTrapService" ||
                            serviceName == "_2020IODeviceService" || serviceName == "FFTTransactionService" || serviceName == "ANPRService" || serviceName == "ModbusCommunicationService" || serviceName == "NvrAlarmConsumerService" || serviceName == "KronosService" || serviceName == "GeoTrackingService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.TransactionServiceIp + ":6530";
                        }
                        else if (serviceName == "VideoAnalyticsManagerIntegrationService" || serviceName == "ACSIntegrationService" || serviceName == "MatrixControllerService" || serviceName == "ClimateControlService" || serviceName == "IclockACSIntegrationService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.IntegrationServiceIp + ":6530";
                        }
                        else
                        {
                            ServerPath = _settings.Value.broker_SERVICE_HOSTS.AutherizationServiceIp;
                        }
                    }
                    else
                    {
                        if (serviceName == "GatewayService" || serviceName == "CameraStatusService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SecondaryWatchDogServiceIp + ":6530";
                        }
                        else if (serviceName == "StationServiceCommunication" || serviceName == "StationsService" || serviceName == "WebStation")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SecondaryCommunicationServiceIp + ":6530";
                        }
                        else if (serviceName == "Directory" || serviceName == "AuthService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SecondaryAutherizationServiceIp + ":6530";
                        }
                        else if (serviceName == "AlertsSetOperationService" || serviceName == "IncidentReportSetOperationService" || serviceName == "IncidentReportSetOperationServiceWeb" || serviceName == "ZoneSetOperation" ||
                            serviceName == "ControllerSetOperation" || serviceName == "AccountsSetOperationService" || serviceName == "SitesSetOperationService" || serviceName == "SystemSetOperationService"
                            || serviceName == "UsersSetOperationService" || serviceName == "SecuritySetOperationService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SecondarySetOperationServiceIp + ":6530";
                        }
                        else if (serviceName == "DashBoardService" || serviceName == "Harness" || serviceName == "ZoneGetOperation" || serviceName == "ControllerGetOperation" || serviceName == "AlertsGetOperationService" ||
                            serviceName == "AccountsGetOperationService" || serviceName == "SitesGetOperationService" || serviceName == "SystemGetOperationService" || serviceName == "LookupService" || serviceName == "UsersGetOperationService" ||
                            serviceName == "SecurityGetOperationService" || serviceName == "IncidentReportGetOperationService" || serviceName == "IncidentReportGetOperationServiceWeb" || serviceName == "ParkingPollGetopService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SecondaryGetOperationServiceIp + ":6530";
                        }
                        else if (serviceName == "GeneralPurposeService" || serviceName == "AlertsCreationService" || serviceName == "StreamInsightService" || serviceName == "StreamInsightAlertService" || serviceName == "VideoAnalyticsManagerService" ||
                            serviceName == "ACSTransactionService" || serviceName == "EdgeBaseAnalyticsService" || serviceName == "ANPRService" || serviceName == "MatrixControllerTransactionService" || serviceName == "_2020SNMPTrapService" ||
                            serviceName == "_2020IODeviceService" || serviceName == "ANPRService" || serviceName == "ModbusCommunicationService" || serviceName == "NvrAlarmConsumerService" || serviceName == "KronosService" || serviceName == "GeoTrackingService" || serviceName == "FFTTransactionService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SecondaryTransactionServiceIp + ":6530";
                        }
                        else if (serviceName == "VideoAnalyticsManagerIntegrationService" || serviceName == "ACSIntegrationService" || serviceName == "MatrixControllerService" || serviceName == "ClimateControlService")
                        {
                            ServerPath = "https://" + _ServerConfigModel.SecondaryIntegrationServiceIp + ":6530";
                        }
                        else
                        {
                            ServerPath = _settings.Value.broker_SERVICE_HOSTS.AutherizationServiceIp;
                        }
                    }
                }
                else
                {
                    ServerPath = _settings.Value.broker_SERVICE_HOSTS.AutherizationServiceIp;
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("Exception Occured " + ex.Message);
            }
            //return String.Format(
            //    "{0}/{1}/{2}?{3}&callback=service",
            //    ServerPath.Trim('/'),
            //    serviceName,
            //    method,
            //    String.Join("&", parameters)
            //);

            return String.Format(
               "{0}/{1}/{2}?{3}",
               ServerPath.Trim('/'),
               serviceName,
               method,
               String.Join("&", parameters)
           );
        }

    }
}
