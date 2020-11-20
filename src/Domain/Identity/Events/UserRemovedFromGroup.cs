using System;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserRemovedFromGroup : IDomainEvent
    {
        public UserGroupId UserGroupId { get; }

        public UserAccountId UserAccountId { get; }

        public UserRemovedFromGroup(UserGroupId userGroupId, UserAccountId userAccountId)
        {
            UserGroupId = userGroupId;
            UserAccountId = userAccountId;
        }
    }
}