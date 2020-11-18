using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserAccountCreated : IEvent
    {
        public AccountId AccountId { get; }

        public UserAccountId UserAccountId { get; }

        public string UserName { get; }

        public UserRoleId UserRoleId { get; }

        public string RoleName { get; }

        public UserAccountCreated(AccountId accountId, 
            UserAccountId userAccountId, string userName, 
            UserRoleId userRoleId, string roleName)
        {
            AccountId = accountId;
            UserAccountId = userAccountId;
            UserName = userName;
            UserRoleId = userRoleId;
            RoleName = roleName;
        }
    }
}