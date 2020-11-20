using Domain;
using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserAccountDeleted : IDomainEvent
    {
        public TenantId TenantId { get; }
        public UserAccountId UserAccountId { get; }

        public UserAccountDeleted(TenantId tenantId, UserAccountId userAccountId)
        {
            TenantId = tenantId;
            UserAccountId = userAccountId;
        }
    }
}
