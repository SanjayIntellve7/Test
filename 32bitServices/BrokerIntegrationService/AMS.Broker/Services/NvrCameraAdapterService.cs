using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using NLog;
//using TwTw.NvrModule;

namespace AMS.Broker.IntegrationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal sealed class NvrCameraAdapterService : INvrCamerasService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                string Message = "NvrCameraAdapterService-ClearMemory -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }


        public static void ClearMemoryStatic()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                string Message = "NvrCameraAdapterService-ClearMemoryStatic -- Exception = " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
        }

        internal static NvrCameraAdapterService Initialise()
        {
            try
            {
                _logger.Info("------------------------------------");
                _logger.Info("starting NvrCamerasService service");

                var service = new NvrCameraAdapterService();
                var controllerHost = new ServiceHost(service);

                controllerHost.Open();

                _logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
                _logger.Info("------------------------------------");

                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016

                return service;
            }
            catch (Exception ex)
            {
                _logger.Info("NvrCameraAdapterService Initialise() Exception:" + ex.Message);
                string Message = "NvrCameraAdapterService--- Initialise Exception:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            return null;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("NvrCameraAdapterService Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
        }


        //TODO: this is a temporary solution, should take objects
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<DeviceDto> GetCameras(string nvr)
        {
            try
            {
                //TODO: inject service
                var nvrDto = Deserialize<NvrDto>(nvr);
                var nvrService = new NvrService();
                nvrService.Initialize();
                var cameras = nvrService.GetCameras(nvrDto);
               
                return cameras;
            }
            catch (Exception ex)
            {
                _logger.Info("NvrCameraAdapterService GetCameras() Exception:" + ex.Message);
                string Message = "NvrCameraAdapterService--- GetCameras Exception:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        //TODO: this is a temporary solution, should take objects
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<object> GetCamerasAdditionalInfoCollection(NvrDto nvr)
        {
            try
            {
                //TODO: inject service
                var nvrService = new NvrService();
                nvrService.Initialize();
                var cameras = nvrService.GetCameraAdditionalInfo(nvr);
               
                return cameras;
            }
            catch (Exception ex)
            {
                _logger.Info("NvrCameraAdapterService GetCamerasAdditionalInfoCollection() Exception:" + ex.Message);
                string Message = "NvrCameraAdapterService--- GetCamerasAdditionalInfoCollection Exception:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }

        //TODO: this is a temporary solution, should take objects
        public IEnumerable<DeviceDto> GetCamerasByNvr(NvrDto nvr)
        {
            try
            {
                //TODO: inject service
                var nvrService = new NvrService();
                nvrService.Initialize();
                var cameras = nvrService.GetCameras(nvr);
                
                return cameras;
            }
            catch (Exception ex)
            {
                _logger.Info("NvrCameraAdapterService GetCamerasByNvr() Exception:" + ex.Message);
                string Message = "NvrCameraAdapterService--- GetCamerasByNvr Exception:" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                InsertIntegrationLog.AddProcessLogIntegration(Message);//jatin
            }
            finally
            {
                ClearMemory();
            }
            return null;
        }        
        //TODO: this is a temporary solution, should take objects
        private static T Deserialize<T>(string json)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(json))
                {                   
                    return default(T);
                }
                var serializer = new DataContractJsonSerializer(typeof(T));
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {                  
                    return (T)serializer.ReadObject(stream);
                }
            }
            catch (Exception ex)
            {
                return default(T); 
            }
            finally
            {
                ClearMemoryStatic();
            }

        }
    }
}
