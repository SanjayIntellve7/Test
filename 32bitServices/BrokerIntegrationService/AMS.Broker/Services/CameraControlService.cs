using AMS.Broker.Contracts.DTO;
using AMS.Broker.IntegrationService.DataStore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using QL.VideoBrowser.Utils;
using AMS.Broker.Contracts.Services;

namespace AMS.Broker.IntegrationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CameraControlService : ICameraControlService
    {
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        public static NVRServiceAct _nvrService = null;
        private CameraControlService()
        {

        }
        ~CameraControlService()
        {
        }
        internal static void Initialise(NVRServiceAct nvrService)
        {
            try
            {
                _logger.Info("");
                _logger.Info("-----------------------------------l-");
                _logger.Info("starting CameraControlService service");

                _nvrService = nvrService;

                Uri httpUrl = new Uri("https://localhost:6530/CameraControlService");
                //Create ServiceHost
                WebServiceHost serviceHost
                = new WebServiceHost(typeof(CameraControlService), httpUrl);

                WebHttpBinding _webhttpbis = new WebHttpBinding(WebHttpSecurityMode.Transport);
                _webhttpbis.MaxReceivedMessageSize = 1073741823;
                _webhttpbis.ReceiveTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.CloseTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.OpenTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.SendTimeout = TimeSpan.Parse("00:10:00");
                _webhttpbis.MaxBufferPoolSize = 524288;
                _webhttpbis.CrossDomainScriptAccessEnabled = true;
                var endpoint = serviceHost.AddServiceEndpoint(typeof(ICameraControlService), _webhttpbis, "");//WSHttpBinding

                ServiceThrottlingBehavior throttleBehavior = new ServiceThrottlingBehavior
                {
                    MaxConcurrentCalls = 500,
                    MaxConcurrentInstances = 500,
                    MaxConcurrentSessions = 500,
                };

                serviceHost.Description.Behaviors.Add(throttleBehavior);
                WebHttpBehavior behavior = new WebHttpBehavior();
                behavior.DefaultOutgoingResponseFormat = WebMessageFormat.Json;

                endpoint.Behaviors.Add(behavior);

                serviceHost.Open();

                _logger.Info("CameraControlService service started successfully");

                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016    

                return;//service;
            }
            catch (Exception ex)
            {
                _logger.Info("GeoTrackingService Initialise() Exception" + ex.Message);
                string Message = "GeoTrackingService-Initialise() -- Exception  = " + ex.Message;
                InsertIntegrationLog.AddProcessLogIntegration(Message);
                return;
            }
            finally
            {
            }
            return;
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("CameraControlService Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
            string Message3 = "CameraControlService Service  CurrentDomain_UnhandledException() Unhandled UI Exception:" + (e.ExceptionObject as Exception).Message;
            InsertIntegrationLog.AddProcessLogIntegration(Message3);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void ControlPTZHandoff(string nNvrId, string srePresetNum, string strCamGuid)
        {
            try
            {
                Task.Run(() => PTZHandoff(nNvrId, srePresetNum, strCamGuid));
            }
            catch (Exception ex)
            {
            }
        }
        //PTZ Handoff
        public void PTZHandoff(string nNvrId, string srePresetNum, string strCamGuid)//For Quadrox only
        {
            try
            {
                InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff nNvrId:" + nNvrId + "--!--PresetNum:" + srePresetNum + "--!--CamGuid:" + strCamGuid);
                NvrDto result = null;
                int nPresetNum = Int32.Parse(srePresetNum);

                if (nPresetNum != 0)
                    nPresetNum = nPresetNum - 1;

                if (_nvrService != null)
                {
                    try
                    {
                        int _nNvrId = Int32.Parse(nNvrId);

                        using (var ctx = new CentralDBEntities())
                        {
                            var resultDb = (from nvr in ctx.NVR
                                            where nvr.NvrId == _nNvrId
                                            select nvr).First();
                            if (resultDb != null)
                            {
                                result = new NvrDto()
                                {
                                    Description = resultDb.Description,
                                    InterfaceId = int.Parse(resultDb.InterfaceId.ToString()),
                                    IPAddress = resultDb.IPAddress,
                                    NvrId = resultDb.NvrId,
                                    NvrUrl = resultDb.NvrUrl,
                                    Password = resultDb.Password,
                                    Port = int.Parse(resultDb.Port.ToString()),
                                    Username = resultDb.Username
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff get nvr details Exception :" + strCamGuid);
                    }

                    if (result != null)
                    {
                        NvrDto _nvr = result;

                        QL.Communication.Server.IServerController server;
                        _nvrService.AddServer(
                               _nvr.IPAddress,
                               _nvr.Port,
                               _nvr.Username,
                               _nvr.Password,
                               ""
                               );//2020IMAGING

                        if (_nvrService.GetServerController().State == QL.Communication.Server.ServerControllerState.Connected)
                        {
                            InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff  inside if :");

                            QL.Communication.Server.VideoServerEntity serverEntity = _nvrService.GetServer(_nvr.IPAddress);//nvr ipaddress

                            if (_nvrService.GetServerManager().TryGetServer(serverEntity.Id, out server))
                            {
                                var request = new QL.Communication.Messaging.Messages.PtzGoToPresetRequest
                                {
                                    SourceId = new Guid(strCamGuid),//PTX Camera Guid
                                    PresetNumber = (byte)nPresetNum
                                };

                                server.SendAndGetResponseAsObservable<QL.Communication.Messaging.Messages.EmptyMessage>(request).Subscribe(
                                ok =>
                                {
                                    InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff  ok :");
                                },
                                error =>
                                {
                                    InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff error :" + error);
                                });
                            }
                        }
                        else
                        {
                            InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff  inside else :");

                            _nvrService.GetServerController().Connected += (sender, args) =>
                            {
                                QL.Communication.Server.VideoServerEntity serverEntity = _nvrService.GetServer(_nvr.IPAddress);//nvr ipaddress

                                InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff  serverEntity.Id :" + serverEntity.Id);

                                if (_nvrService.GetServerManager().TryGetServer(serverEntity.Id, out server))
                                {
                                    var request = new QL.Communication.Messaging.Messages.PtzGoToPresetRequest
                                    {
                                        SourceId = new Guid(strCamGuid),//PTX Camera Guid
                                        PresetNumber = (byte)nPresetNum//_associatedPtzDev.PresetNumber //amit 23 May 16
                                    };
                                    server.SendAndGetResponseAsObservable<QL.Communication.Messaging.Messages.EmptyMessage>(request).Subscribe(
                                    ok =>
                                    {
                                        InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff else ok :");
                                    },
                                    error =>
                                    {
                                        InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff else error :" + error);
                                    });
                                }
                            };
                        }
                    }
                    //
                }

            }
            catch (Exception ex)
            {
                InsertIntegrationLog.AddProcessLogIntegration("PTZHandoff Main catch Exception :" + ex.Message);
                // LogManager.GetCurrentClassLogger().Error(ex.Message);
            }
        }
    }
}
