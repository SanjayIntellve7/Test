using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using System.Security.Principal;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISecurityGetOperationService
    {
        [OperationContract]
        TwTwPrincipalInfo GetPrincipalInfo();

        

        [OperationContract]
        UserDto GetUser(int userId);

        [OperationContract]
        IEnumerable<tblUserPrivilegesDTO> GetUserPrivileges(string userId, string authToken);

        [OperationContract]
        List<UserDto> GetUsers(string authToken);
        
        [OperationContract]
        bool IsAllowed(int userId, string operation);

        [OperationContract]
        string GetUserRole(string authToken);

        [OperationContract]
        TwTwPrincipalInfo GetPrincipalInfoNew(string Username);

        #region Teams

        [OperationContract]
        List<TeamDto> GetTeams(string authToken);

        [OperationContract]
        List<TeamDto> GetTeamsWithUsers(string authToken);

        [OperationContract]
        List<TeamDto> GetTeamsFor(int userId, string authToken);

        [OperationContract]
        List<TeamDto> GetTeamsWithUsersFor(int userId, string authToken);       

        #endregion

        #region Active Directory

        [OperationContract]
        List<UserDto> FindUser(string searchExpression, string SearchCriteria, string authToken);

        [OperationContract]
        List<UserDto> FindUserInActiveDirectory(string searchExpression, string authToken);

        [OperationContract]
        UsersGroupDto GetUsersGroupByName(string groupName);

        #endregion

        [OperationContract]
        List<DomainMasterDTO> GetDomainMasterList();
    }
}
