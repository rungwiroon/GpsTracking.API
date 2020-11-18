using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserGroupCreated : IEvent
    {
        public UserGroupId UserGroupId { get; }

        public string UserGroupName { get; }

        public AccountId AccountId { get; }

        public UserGroupCreated(UserGroupId userGroupId, string userGroupName, AccountId accountId)
        {
            UserGroupId = userGroupId;
            UserGroupName = userGroupName;
            AccountId = accountId;
        }
    }
}