using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Identity.Events
{
    public class UserRoleCreated : IDomainEvent
    {
        public UserRoleId UserRoleId { get; }

        public string UserRoleName { get; }

        public UserRoleCreated(UserRoleId userRoleId, string userRoleName)
        {
            UserRoleId = userRoleId;
            UserRoleName = userRoleName;
        }
    }
}
