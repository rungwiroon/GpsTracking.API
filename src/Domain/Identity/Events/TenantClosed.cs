using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class TenantClosed : IDomainEvent
    {
        public TenantId TenantId { get; }

        public DateTimeOffset ClosedAt { get; }

        public TenantClosed(TenantId tenantId, DateTimeOffset closedAt)
        {
            TenantId = tenantId;
            ClosedAt = closedAt;
        }
    }
}