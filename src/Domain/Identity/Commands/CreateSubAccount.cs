using System;
using System.Collections.Generic;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class CreateSubAccount : ICommand
    {
        public UserAccountId IssuedBy { get; }

        public UserGroupId UserGroupId { get; }

        public string UserName { get; }

        public string Email { get; }
    }
}