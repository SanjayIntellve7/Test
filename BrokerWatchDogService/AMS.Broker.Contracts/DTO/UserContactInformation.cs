
namespace AMS.Broker.Contracts.DTO
{
    public sealed class UserContactInformation
    {
        public UserContactInformation()
        {
            ContactMethodsCollection = new ContactMethod[0];
        }

        public string Username { get; set; }

        public Alert Alert { get; set; }

        public ContactMethod[] ContactMethodsCollection { get; set; }
    }
}
