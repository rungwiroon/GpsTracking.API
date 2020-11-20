using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Identity.Events
{
    public class UserGroupRenamed : IDomainEvent
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