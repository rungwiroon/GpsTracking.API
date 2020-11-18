using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class UserRoleChanged : IEvent
    {
        public AccountId AccountId { get; }

        public UserAccountId UserAccountId { get; }

        public UserRoleId OldUserRoleId { get; }

        public UserRoleId NewUserRoleId { get; }

        public string NewUserRoleName { get; }

        public UserRoleChanged(AccountId accountId, UserAccountId userAccountId, 
            UserRoleId oldUserRoleId,
            UserRoleId newUserRoleId, string newUserRoleName)
        {
            AccountId = accountId;
            UserAccountId = userAccountId;
            OldUserRoleId = oldUserRoleId;
            NewUserRoleId = newUserRoleId;
            NewUserRoleName = newUserRoleName;
        }
    }
}
