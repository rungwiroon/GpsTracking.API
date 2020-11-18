using Core.Domain.Identity.Events;
using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Identity
{
    public interface IAccountRepository
    {
        Account GetById(AccountId accountId);

        Account GetByUserAccountId(UserAccountId userAccountId);

        UserAccount GetUserAccountById(UserAccountId userAccountId);

        void Update(Account account);
    }
}