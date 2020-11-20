using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserGroupCreated : IDomainEvent
    {
        public UserGroupId UserGroupId { get; }

        public string UserGroupName { get; }

        public TenantId TenantId { get; }

        public UserGroupCreated(UserGroupId userGroupId, string userGroupName, TenantId tenantId)
        {
            UserGroupId = userGroupId;
            UserGroupName = userGroupName;
            TenantId = TenantId;
        }
    }
}