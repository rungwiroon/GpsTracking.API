using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class AccountCreated : IEvent
    {
        public AccountId AccountId { get; }

        public AccountCreated(AccountId accountId)
        {
            AccountId = accountId;
        }
    }
}
