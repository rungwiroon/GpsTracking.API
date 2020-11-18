using System;
using System.Collections.Generic;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class DeleteUserGroup : ICommand
    {
        public UserGroupId UserGroupId { get; }
    }
}