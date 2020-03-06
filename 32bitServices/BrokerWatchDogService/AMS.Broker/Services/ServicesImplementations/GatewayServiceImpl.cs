using AMS.Broker.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace AMS.Broker.WatchDogService.Services.ServicesImplementations
{
    using AMS.Broker.Contracts.DTO;
    using Membership = System.Web.Security.Membership;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GatewayServiceImpl : IGatewayService
    {
        public GatewayServiceImpl()
        {
        }

        public void ClearMemory()
        {
            try
            {
                //GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                // GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
            }
        }
        public BrokerStatus Ping()
        {
            ClearMemory();
            return BrokerStatus.Live;
        }

        public bool ValidateCredentials(string username, string password)
        {
            try
            {
                InsertBrokerOperationLog.AddProcessLog("Gateway service ValidateCredentials() :Start ");
                ClearMemory();
                return Membership.ValidateUser(username, password);
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("Gateway service ValidateCredentials() Exception: " + ex.Message);
            }
            finally
            {
                ClearMemory();
            }

            return false;
        }
        public bool ValidateUserName(string username)
        {
            InsertBrokerOperationLog.AddProcessLog("Gateway service ValidateUserName() Start : " + username);
            try
            {
                using (var cxtLogin = new AMS.Broker.WatchDogService.DataStore.CentralDBEntities())
                {
                    var sid = AMS.Broker.WatchDogService.Helpers.AuthenticationHelper.GetUsersSID(username);
                    if (!String.IsNullOrWhiteSpace(sid))
                    {
                        return true; //valid username
                    }
                    else
                    {
                        return false;// invalid username
                    }
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("Gateway service ValidateUserName() Exception: " + ex.Message);
            }
            finally
            {
                ClearMemory();
            }
            return true;
        }

    }
}