using System;
using System.Collections.Generic;
using Domain.User;
using Core.Domain.SeedWork;

namespace Domain.Driver
{
    public sealed record DriverGroupId : EntityId
    {
        public DriverGroupId() : base() { }

        public DriverGroupId(Guid id) : base(id) { }
    }

    [Serializable]
    public class DriverGroup
    {
        public DriverGroupId Id { get; }

        public string Name { get; }

        public UserGroupId UserGroupId { get; }

        public DriverGroup(DriverGroupId id, string name, UserGroupId userGroupId)
        {
            Id = id;
            Name = name;
            UserGroupId = userGroupId;
        }
    }
}