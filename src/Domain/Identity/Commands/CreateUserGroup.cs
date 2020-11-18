using System;
using System.Collections.Generic;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class CreateUserGroup : ICommand
    {
        public UserAccountId IssuedBy { get; }

        public string UserGroupName { get; }

        public string UserGroupDescriptions { get; }
    }
}