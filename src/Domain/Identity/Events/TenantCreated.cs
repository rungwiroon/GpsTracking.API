using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class TenantCreated : IDomainEvent
    {
        public TenantId TenantId { get; }

        public DateTimeOffset CreatedAt { get; }

        public TenantCreated(TenantId tenantId, DateTimeOffset createdAt)
        {
            TenantId = tenantId;
            CreatedAt = createdAt;
        }
    }
}
