using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class AccountDeactivated : IEvent
    {
        public AccountId AccountId { get; }

        public AccountDeactivated(AccountId accountId)
        {
            AccountId = accountId;
        }
    }
}