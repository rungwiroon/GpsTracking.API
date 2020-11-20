using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Identity.Events
{
    public class UserAddedToGroup : IDomainEvent
    {
        public UserGroupId UserGroupId { get; }

        public UserAccountId UserAccountId { get; }

        public string UserGroupName { get; }

        public string UserName { get; }

        public UserAddedToGroup(UserGroupId userGroupId, UserAccountId userAccountId, string userGroupName, string userName)
        {
            UserGroupId = userGroupId;
            UserAccountId = userAccountId;
            UserGroupName = userGroupName;
            UserName = userName;
        }
    }
}