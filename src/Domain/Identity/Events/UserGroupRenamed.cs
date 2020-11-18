using Domain;
using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity.Events
{
    public class UserGroupRenamed : IEvent
    {
        public UserGroupId UserGroupId { get; }

        public string OldUserGroupName { get; }

        public string NewUserGroupName { get; }

        public UserGroupRenamed(UserGroupId userGroupId, string oldUserGroupName, string newUserGroupName)
        {
            UserGroupId = userGroupId;
            OldUserGroupName = oldUserGroupName;
            NewUserGroupName = newUserGroupName;
        }
    }
}