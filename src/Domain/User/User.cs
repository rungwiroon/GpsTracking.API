using System;
using System.Collections.Generic;

namespace Domain.User
{
    public sealed record UserId : EntityId
    {
        public UserId() : base() { }

        public UserId(Guid id) : base(id) { }
    }

    [Serializable]
    public record User
    {
        public UserId UserId { get; }

        public UserRole Role { get; }

        public string UserName { get; }

        public string? Email { get; }

        public string? Description { get; }

#pragma warning disable CS8618
        private User() { }
#pragma warning restore CS8618

        public User(string userName, UserRole? role = null, string? email = null, string? description = null)
        {
            UserId = new();
            UserName = userName;
            Role = role ?? UserRole.Default;
            Email = email;
            Description = description;
        }
    }
}
