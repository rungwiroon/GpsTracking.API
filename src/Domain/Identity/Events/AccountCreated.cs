using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class AccountCreated : IDomainEvent
    {
        public TenantId TenantId { get; }

        public AccountCreated(TenantId tenantId)
        {
            TenantId = tenantId;
        }
    }
}
