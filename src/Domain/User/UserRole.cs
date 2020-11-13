using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public record UserRoleId : EntityId
    {
        public UserRoleId() : base() { }

        public UserRoleId(Guid id) : base(id) { }
    }

    public class UserRole
    {
        public UserRoleId Id { get; }

        public string Name { get; }

        public string? Description { get; }

        private static UserRole defaultRole = new (
            new UserRoleId(Guid.Empty), "Default", "Default user role");
        public static UserRole Role => defaultRole;

        private UserRole(UserRoleId id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
