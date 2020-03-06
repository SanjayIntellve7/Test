using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.AutherizationService.DataStore;
using AMS.Broker.AutherizationService.Helpers;
using Microsoft.Practices.Unity;
using NLog;
using UserDTO = AMS.Broker.Contracts.DTO.User;
using System.Collections.Generic;

namespace AMS.Broker.AutherizationService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal sealed class DirectoryService : IDirectoryService
    {
        private IDirectoryService _directoryService;

        private DirectoryService()
        {
            _directoryService = BrokerService.Container.Resolve<IDirectoryService>();
        }

        internal static DirectoryService Initialise()
        {
            try
            {
                _logger.Info("------------------------------------");
                _logger.Info("starting Directory service");

                InsertAuthLog.AddProcessLogAuth("------------------------------------");//jatin
                InsertAuthLog.AddProcessLogAuth("starting Directory service");

                var service = new DirectoryService();
                var controllerHost = new ServiceHost(service);
                controllerHost.Open();

                _logger.Info("listening at {0}", controllerHost.Description.Endpoints[0].ListenUri);
                _logger.Info("------------------------------------");

                InsertAuthLog.AddProcessLogAuth("listening at " + controllerHost.Description.Endpoints[0].ListenUri);//jatin
                InsertAuthLog.AddProcessLogAuth("------------------------------------");
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);   //amit 04112016 
                return service;
            }
            catch(Exception  ex)
            {
                _logger.Info("DirectoryService Initialise() Exception" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("DirectoryService Initialise() Exception" + ex.Message); //jatin
            }
            return null;
           
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) //amit 04112016       
        {
            _logger.Info("Directory Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);
            InsertAuthLog.AddProcessLogAuth("Directory Service Unhandled UI Exception" + (e.ExceptionObject as Exception).Message);//jatin
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void AddGroup(string authToken, string groupName)
        {
            _directoryService.AddGroup(authToken, groupName);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void AddUserToGroup(string authToken, string userName, string groupName)
        {
            _directoryService.AddUserToGroup(authToken, userName, groupName);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void RemoveGroup(string authToken, string groupName)
        {
            _directoryService.RemoveGroup(authToken, groupName);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetUsersByGroup(string authToken, string groupName)
        {
            return _directoryService.GetUsersByGroup(authToken, groupName);
        }

        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();

    }
}
