using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Domain.User
{
    [Serializable]
    public record UserGroupId : EntityId
    {
        public UserGroupId() : base() { }

        public UserGroupId(Guid id) : base(id) { }
    }

    [Serializable]
    public record UserGroup
    {
        public UserGroupId Id { get; }

        public UserGroup? Parent { get; }

        public string Name { get; }

        public string? Description { get; }

        private static readonly UserGroup defaultGroup = new (
            new UserGroupId(Guid.Empty), "Default", "Default user group");
        public static UserGroup Default => defaultGroup;

        public UserGroup(string name, string? description = null)
        {
            Id = new UserGroupId();
            Name = name;
            Description = description;
        }

        public UserGroup(UserGroupId id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public void ChangeName(string newName)
        {
            throw new NotImplementedException();
        }

        public void ChangeDescription(string newDescription)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(UserId user)
        {
            throw new NotImplementedException();
        }
    }
}
