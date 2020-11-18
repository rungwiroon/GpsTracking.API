using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class UserRoleCreated : IEvent
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
