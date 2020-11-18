using System;
using System.Collections.Generic;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class RemoveUserAccountFromGroup : ICommand
    {
        public UserGroupId UserGroupId { get; }

        public UserAccountId UserAccountId { get; }

        public UserAccountId IssuedBy { get; }
    }
}