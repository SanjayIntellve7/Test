using System;
using System.Collections.Generic;
using AMS.Broker.AutherizationService.Services;


namespace AMS.Broker.Contracts.DTO
{
    public class User
    {
        public User() 
        {

        }

        public bool IsActive()
        {
            bool isActive = false;
            return isActive;
        }

        public string SecurityUserId;
        public Guid AuthToken;
        public string Identifier;

        public DateTime ActiveFrom;
        public DateTime? ActiveTill;

        public ICollection<Station> Machines;
    }
}
