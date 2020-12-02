using Core.Domain.Identity.Events;
using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Identity.Repositories
{
    public interface ITenantRepository
    {
        Tenant GetById(TenantId tenantId);

        Tenant GetByUserTenantId(UserAccountId userAccountId);

        UserAccount GetUserAccountById(UserAccountId userAccountId);

        void Create(Tenant account);

        void Update(Tenant account);
    }
}