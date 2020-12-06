using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserAccountCreated : IDomainEvent
    {
        public TenantId TenantId { get; }

        public UserAccountId UserAccountId { get; }

        public string UserName { get; }
        public string PasswordHash { get; }

        public UserRoleId UserRoleId { get; }
        public string RoleName { get; }

        public string? Email { get; }
        public string? Name { get; }
        public string? Description { get; }

        public UserAccountCreated(TenantId tenantId,
            UserAccountId userAccountId, string userName, string passwordHash,
            UserRoleId userRoleId, string roleName,
            string? email = null, string? name = null, string? description = null)
        {
            TenantId = tenantId;
            UserAccountId = userAccountId;
            UserName = userName;
            PasswordHash = passwordHash;
            UserRoleId = userRoleId;
            RoleName = roleName;
            Email = email;
            Name = name;
            Description = description;
        }
    }
}