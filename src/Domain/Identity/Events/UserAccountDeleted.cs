using Domain;
using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserAccountDeleted : IEvent
    {
        public AccountId AccountId { get; }
        public UserAccountId UserAccountId { get; }

        public UserAccountDeleted(AccountId accountId, UserAccountId userAccountId)
        {
            AccountId = accountId;
            UserAccountId = userAccountId;
        }
    }
}
