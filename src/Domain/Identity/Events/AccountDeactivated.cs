using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class AccountDeactivated : IDomainEvent
    {
        public TenantId TenantId { get; }

        public AccountDeactivated(TenantId tenantId)
        {
            TenantId = tenantId;
        }
    }
}