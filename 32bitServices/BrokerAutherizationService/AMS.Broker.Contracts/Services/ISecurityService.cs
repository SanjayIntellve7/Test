using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using System.Security.Principal;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISecurityService
    {
        [OperationContract]
        TwTwPrincipalInfo GetPrincipalInfo();

        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        UserDto AddUser(UserDto userDto);

        [OperationContract]
        UserDto GetUser(int userId);

        [OperationContract]
        List<UserDto> GetUsers();

        [OperationContract]
        void DeleteUser(int userId);

        [OperationContract]
        bool UpdateUser(UserDto userDto);

        [OperationContract]
        bool UpdateUsernew(UserDto userDto,bool IsChecked);

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool SetPassword(string username, string newPassword);

        [OperationContract]
        UsersGroupDto CreateUsersGroup(string name);

        [OperationContract]
        void RemoveUsersGroup(string name);

        [OperationContract]
        UsersGroupDto GetUsersGroupByName(string groupName);

        [OperationContract]
        UsersGroupDto CreateChildUserGroupOf(string parentGroupName, string usersGroupName);

        [OperationContract]
        void AssociateUserWith(UserDto userDto, string groupName);

        [OperationContract]
        OperationDto CreateOperation(string operationName);

        [OperationContract]
        void RemoveOperation(string operationName);

        [OperationContract]
        void ApplyPermisionForUser(string operationName, bool allow, int userId);

        [OperationContract]
        void ApplyPermisionForUsersGroup(string operationName, bool allow, string groupName);

        [OperationContract]
        bool IsAllowed(int userId, string operation);

        [OperationContract]
        TwTwPrincipalInfo GetPrincipalInfoNew(string Username);

        #region Teams

        [OperationContract]
        List<TeamDto> GetTeams();

        [OperationContract]
        List<TeamDto> GetTeamsWithUsers();

        [OperationContract]
        List<TeamDto> GetTeamsFor(int userId);

        [OperationContract]
        List<TeamDto> GetTeamsWithUsersFor(int userId);

        [OperationContract]
        bool UpdateUserTeams(UserDto userDto, IList<TeamDto> teams);

        #endregion

        #region Active Directory

        [OperationContract]
        List<UserDto> FindUserInActiveDirectory(string searchExpression);

        #endregion
    }
}
