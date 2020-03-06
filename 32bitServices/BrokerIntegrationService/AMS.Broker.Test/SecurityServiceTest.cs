using System;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.Contracts.Services;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace AMS.Broker.Test
{
    [TestFixture]
    public class SecurityServiceTest : BaseTest
    {
        private static ISecurityService _securityService;

        public SecurityServiceTest()
        {
            _securityService = BrokerService.Container.Resolve<ISecurityService>();
        }

        [Test]
        public void Can_Create_Remove_UsersGroup()
        {
            _securityService.CreateUsersGroup("Developers");

            var getUserGroup = _securityService.GetUsersGroupByName("Developers");
            Assert.NotNull(getUserGroup);
            Assert.IsTrue(getUserGroup.Name == "Developers");

            _securityService.RemoveUsersGroup(getUserGroup.Name);
        }

        [Test]
        public void Can_Create_Remove_Users()
        {
            var user = GetUserDto();
            var userDto = _securityService.AddUser(user);
            
            Assert.IsTrue(userDto.UserId > 0);
            _securityService.DeleteUser(userDto.UserId);

            var deletedUser = _securityService.GetUser(userDto.UserId);
            Assert.IsNotNull(deletedUser);
        }

        [Test]
        public void Can_Apply_Permissions()
        {
            var user = GetUserDto();

            var userDto = _securityService.AddUser(user);

            _securityService.CreateUsersGroup("AdminUserGroup");
            _securityService.CreateChildUserGroupOf("AdminUserGroup", "GuestUserGroup");

            _securityService.CreateOperation("/Content/Manage");
            _securityService.CreateOperation("/Content/View");

            _securityService.AssociateUserWith(userDto, "AdminUserGroup");
            
            _securityService.ApplyPermisionForUsersGroup("/Content", true, "AdminUserGroup");
            _securityService.ApplyPermisionForUser("/Content/View", false, userDto.UserId);


            bool isAllowedContentOp = _securityService.IsAllowed(userDto.UserId, "/Content");
            Assert.IsTrue(isAllowedContentOp);

            bool isAllowedContentManageOp = _securityService.IsAllowed(userDto.UserId, "/Content/Manage");
            Assert.IsTrue(isAllowedContentManageOp);

            bool isAllowedContentVewiOp = _securityService.IsAllowed(userDto.UserId, "/Content/View");
            Assert.IsFalse(isAllowedContentVewiOp);

            _securityService.RemoveOperation("/Content/Manage");
            _securityService.RemoveOperation("/Content/View");
            _securityService.RemoveOperation("/Content");

            _securityService.RemoveUsersGroup("GuestUserGroup");
            _securityService.RemoveUsersGroup("AdminUserGroup");

            _securityService.DeleteUser(userDto.UserId);
        }

        private static UserDto GetUserDto()
        {
            var person = new PersonDto
            {
                Address = null,
                AgeRange = 30,
                BirthDate = new DateTime(1983, 08, 23),
                Contacts = null,
                CreatedBy = null,
                CreatedOn = DateTime.Now,
                Description = "Person Description",
                EducationCode = null,
                Ethnicity = null,
                ExternalIdentifier = "External Identifier",
                FirstName = "Victor",
                FullName = "Victor Lungu Gheorghe",
                GenderCode = 1,
                LastName = "Lungu",
                MiddleName = "Gheorghe",
                ModifiedBy = null,
                ModifiedOn = DateTime.Now,
                NickName = "fiteoc",
                Portrait = null,
                Suffix = "Msr.",
                Title = "Victor Lungu"
            };

            var user = new UserDto()
            {
                Person = person,
                //BadPasswordCount = 0,
               // CreatedBy = 1,
               // CreatedOn = DateTime.Now,
               // ModifiedBy = 1,
                //ModifiedOn = DateTime.Now,
                Password = "qwe123",
                StatusCode = 1,
                UserSid = "User Sid",
                Username = "fiteoc"
            };
            return user;
        }
    }
}
