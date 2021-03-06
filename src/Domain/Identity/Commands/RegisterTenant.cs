using System;
using System.Collections.Generic;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class RegisterTenant : ICommand
    {
        public string UserName { get; }

        public string Password { get; }

        public string Email { get; }
    }
}