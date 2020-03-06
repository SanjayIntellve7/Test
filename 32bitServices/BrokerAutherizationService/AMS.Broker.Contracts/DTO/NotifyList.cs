namespace AMS.Broker.Contracts.DTO
{
    public sealed class NotifyList
    {
        public UserContactInformation[] UsersCollection { get; set; }
        public Alert Alert { get; set; }
    }
}