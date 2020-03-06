using System.ServiceModel;
using AMS.Broker.Contracts.DTO;
using System.Collections.Generic;
using System.Security.Principal;
namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface ISecuritySetOperationService
    {
        [OperationContract]
        [FaultContract(typeof(UniqueFault))]
        UserDto AddUser(UserDto userDto, string authToken);

        [OperationContract]
        IEnumerable<tblUserPrivilegesDTO> AddUserPrivileges(IList<tblUserPrivilegesDTO> userPrivileges, string authToken);

        [OperationContract]
        void DeleteUser(int userId);

        [OperationContract]
        bool UpdateUser(UserDto userDto, string authToken);

        [OperationContract]
        bool UpdateUsernew(UserDto userDto, bool IsChecked, string authToken);

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        int ChangePasswordNew(string username, string oldPassword, string newPassword); //amit 27092017

        [OperationContract]
        bool SetPassword(string username, string newPassword);

        [OperationContract]
        UsersGroupDto CreateUsersGroup(string name);

        [OperationContract]
        void RemoveUsersGroup(string name);
       

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
        bool UpdateUserTeams(UserDto userDto, IList<TeamDto> teams, string authToken);

        [OperationContract]
        IEnumerable<tbluserdeviceinfoDTO> AddUserDevicePrivileges(IList<tbluserdeviceinfoDTO> userDeviceData,IList<tbluserdeviceinfoDTO> _tbluserdeviceinfoDTOOldlist, string authToken);

    }
}
