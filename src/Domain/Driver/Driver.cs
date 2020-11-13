using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Driver
{
    public sealed record DriverId : EntityId
    {

    }

    [Serializable]
    public class Driver
    {
        public DriverId Id { get; }
        
        public string FirstName { get; }
        public string LastName { get; }

        public string Description { get; }

        public UserGroupId UserGroupId { get; }

        public DriverGroup Group { get; }
    }
}
