using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Identity.Events
{
    public class UserRoleChanged : IDomainEvent
    {
        public TenantId TenantId { get; }

        public UserAccountId UserAccountId { get; }

        public UserRoleId OldUserRoleId { get; }

        public UserRoleId NewUserRoleId { get; }

        public string NewUserRoleName { get; }

        public UserRoleChanged(TenantId tenantId, UserAccountId userAccountId, 
            UserRoleId oldUserRoleId,
            UserRoleId newUserRoleId, string newUserRoleName)
        {
            TenantId = tenantId;
            UserAccountId = userAccountId;
            OldUserRoleId = oldUserRoleId;
            NewUserRoleId = newUserRoleId;
            NewUserRoleName = newUserRoleName;
        }
    }
}
