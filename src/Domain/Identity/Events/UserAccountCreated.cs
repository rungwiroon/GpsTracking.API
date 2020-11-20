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

        public UserRoleId UserRoleId { get; }

        public string RoleName { get; }

        public UserAccountCreated(TenantId tenantId, 
            UserAccountId userAccountId, string userName, 
            UserRoleId userRoleId, string roleName)
        {
            TenantId = tenantId;
            UserAccountId = userAccountId;
            UserName = userName;
            UserRoleId = userRoleId;
            RoleName = roleName;
        }
    }
}