using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Identity.Events
{
    public class UserGroupDeleted : IDomainEvent
    {
        public UserGroupId UserGroupId { get; }

        public TenantId TenantId { get; }

        public UserGroupDeleted(UserGroupId userGroupId, TenantId tenantId)
        {
            UserGroupId = userGroupId;
            TenantId = TenantId;
        }
    }
}
