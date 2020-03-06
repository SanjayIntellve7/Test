using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using AMS.Broker.AutherizationService.DataStore;
using AMS.Broker.AutherizationService.Helpers;
using NLog;
using UserDTO = AMS.Broker.Contracts.DTO.User;
using System.Collections.Generic;

namespace AMS.Broker.AutherizationService.Services.ServicesImplementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal sealed class DirectoryServiceImpl : IDirectoryService
    {
        public DirectoryServiceImpl() { }

        public void ClearMemory()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
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
            }
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void AddGroup(string authToken, string groupName)
        {
            try
            {
                _logger.Info("------------------------------------");
                _logger.Info("starting Directory.AddGroup");

                InsertAuthLog.AddProcessLogAuth("------------------------------------"); // jatin
                InsertAuthLog.AddProcessLogAuth("starting Directory.AddGroup");

                if (authToken.CanAccess(SecurityPriviliges.ADGroupCreate))
                    DirectoryHelper.AddGroup(groupName);
                else
                {
                    _logger.Warn("Not enoguht priviliges to add a new group");
                    InsertAuthLog.AddProcessLogAuth("Not enoguht priviliges to add a new group"); // jatin
                }

                _logger.Info("------------------------------------");
            }
            catch (Exception ex)
            {
                _logger.Info("DirectoryServiceImpl AddGroup() Exception:" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("DirectoryServiceImpl AddGroup() Exception:" + ex.Message); // jatin 
            }

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void AddUserToGroup(string authToken, string userName, string groupName)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("DirectoryServiceImpl AddUserToGroup() : Start ");
                _logger.Info("------------------------------------");
                _logger.Info("starting Directory.AddUserToGroup");
                InsertAuthLog.AddProcessLogAuth("DirectoryServiceImpl AddUserToGroup() : Start "); // jatin
                if (authToken.CanAccess(SecurityPriviliges.ADGroupCreate))
                    DirectoryHelper.AddUserToGroup(userName, groupName);
                else
                {
                    _logger.Warn("Not enoguht priviliges to add a new group");
                    InsertAuthLog.AddProcessLogAuth("Not enoguht priviliges to add a new group"); // jatin
                }

                _logger.Info("------------------------------------");
            }
            catch (Exception ex)
            {
                //InsertBrokerOperationLog.AddProcessLog("DirectoryServiceImpl AddUserToGroup() Exception :" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("DirectoryServiceImpl AddUserToGroup() Exception :" + ex.Message); //jatin
                _logger.Info("DirectoryServiceImpl AddUserToGroup() Exception:" + ex.Message);
            }

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void RemoveGroup(string authToken, string groupName)
        {
            try
            {
                //InsertBrokerOperationLog.AddProcessLog("DirectoryServiceImpl RemoveGroup() Start :");
                InsertAuthLog.AddProcessLogAuth("DirectoryServiceImpl RemoveGroup() Start :");//jatin
                _logger.Info("------------------------------------");
                _logger.Info("starting Directory.AddGroup");

                if (authToken.CanAccess(SecurityPriviliges.ADGroupRemove))
                    DirectoryHelper.RemoveGroup(groupName);
                else
                {
                    _logger.Warn("Not enoguht priviliges to add a new group");
                    InsertAuthLog.AddProcessLogAuth("Not enoguht priviliges to add a new group");//jatin
                }


                _logger.Info("------------------------------------");
            }
            catch (Exception ex)
            {
                _logger.Info("DirectoryServiceImpl RemoveGroup() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("DirectoryServiceImpl RemoveGroup() Exception :" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("DirectoryServiceImpl RemoveGroup() Exception :" + ex.Message); // jatin 
            }

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetUsersByGroup(string authToken, string groupName)
        {
            try
            {
                _logger.Info("------------------------------------");
                _logger.Info("starting Directory.AddGroup");
                _logger.Info("------------------------------------");
                //InsertBrokerOperationLog.AddProcessLog("DirectoryServiceImpl GetUsersByGroup():Start");
                InsertAuthLog.AddProcessLogAuth("------------------------------------");
                InsertAuthLog.AddProcessLogAuth("DirectoryServiceImpl GetUsersByGroup():Start");//jatin
                InsertAuthLog.AddProcessLogAuth("------------------------------------");
                IEnumerable<string> result = new string[0];
                if (authToken.CanAccess(SecurityPriviliges.ADGroupGetUsers))
                    result = DirectoryHelper.GetUsers(groupName);
                else
                {
                    _logger.Warn("Not enoguht priviliges to add a new group");
                    InsertAuthLog.AddProcessLogAuth("Not enoguht priviliges to add a new group");//jatin
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.Info("DirectoryServiceImpl GetUsersByGroup() Exception:" + ex.Message);
                //InsertBrokerOperationLog.AddProcessLog("DirectoryServiceImpl GetUsersByGroup() Exception :" + ex.Message);
                InsertAuthLog.AddProcessLogAuth("DirectoryServiceImpl GetUsersByGroup() Exception :" + ex.Message); // jatin 
            }
            finally
            {
                ClearMemoryStatic();
            }
            return null;
        }

        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();

    }
}
