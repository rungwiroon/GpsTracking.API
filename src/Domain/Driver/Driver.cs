using System;
using System.Collections.Generic;
using Core.Domain.Identity;
using Core.Domain.SeedWork;

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

        public Driver(DriverId id, string firstName, string lastName, string description, 
            UserGroupId userGroupId, DriverGroup group)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            UserGroupId = userGroupId;
            Group = group;
        }
    }
}
