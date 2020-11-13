using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User
{
    public sealed record UserId : EntityId
    {
        public UserId() : base() { }

        public UserId(Guid id) : base(id) { }
    }

    public class User
    {
        public UserId UserId { get; }

        public UserRole Role { get; }

        public string UserName { get; }

        public string Email { get; }

        public string? Description { get; }
    }
}
