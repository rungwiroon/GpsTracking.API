using System;
using System.Collections.Generic;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class RenameUserGroup : ICommand
    {
        public UserGroupId UserGroupId { get; }

        public string NewName { get; }

        public UserAccountId IssuedBy { get; }
    }
}