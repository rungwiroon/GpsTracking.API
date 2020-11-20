using System;
using System.Collections.Generic;
using System.Globalization;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class CreateEditorAccount : ICommand
    {
        public UserAccountId IssuedBy { get; }

        public UserGroupId UserGroupId { get; }

        public string UserName { get; }

        public string Password { get; }

        public string Email { get; }
    }
}