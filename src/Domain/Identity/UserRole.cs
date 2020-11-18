using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity
{
    public record UserRoleId : EntityId
    {
        public UserRoleId() : base() { }

        public UserRoleId(Guid id) : base(id) { }
    }

    [Serializable]
    public class UserRole : Entity, IAggregateRoot
    {
        public UserRoleId Id { get; }

        public string Name { get; }

        public string? Description { get; }

        private static readonly UserRole viewerRole = new (
            new UserRoleId(Guid.Parse("b32d442e-424a-4bdd-80d8-f6f84a45d2e6")), "Viewer");
        public static UserRole Viewer => viewerRole;

        private static readonly UserRole ownerRole = new(
            new UserRoleId(Guid.Parse("2577dbaf-434e-4244-b447-7925abf0fc34")), "Owner");
        public static UserRole Owner => ownerRole;

        private static readonly UserRole editorRole = new(
            new UserRoleId(Guid.Parse("7975c1c0-cbd4-4554-b066-1cf813232a09")), "Editor");
        public static UserRole Editor => editorRole;

        private UserRole(UserRoleId id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
