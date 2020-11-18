using System;
using System.Collections.Generic;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class AddUserAccountToGroup : ICommand
    {
        public UserAccountId UserAccountId { get; }

        public UserGroupId UserGroupId { get; }

        public AddUserAccountToGroup(UserAccountId userAccountId, UserGroupId userGroupId)
        {
            UserAccountId = userAccountId;
            UserGroupId = userGroupId;
        }
    }
}