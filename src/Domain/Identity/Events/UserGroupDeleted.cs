using Domain;
using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserGroupDeleted : IEvent
    {
        public UserGroupId UserGroupId { get; }

        public AccountId AccountId { get; }

        public UserGroupDeleted(UserGroupId userGroupId, AccountId accountId)
        {
            UserGroupId = userGroupId;
            AccountId = accountId;
        }
    }
}
