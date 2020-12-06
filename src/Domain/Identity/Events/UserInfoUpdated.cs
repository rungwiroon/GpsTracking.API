using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class UserInfoUpdated : IDomainEvent
    {
        public string? OldName { get; }

        public string? NewName { get; }

        public string? OldDescriptions { get; }
        public string? NewDescriptions { get; }

        public DateTimeOffset UpdatedAt { get; }

        public UserInfoUpdated(string? oldName, string? newName, 
            string? oldDescriptions, string? newDescriptions, 
            DateTimeOffset updatedAt)
        {
            OldName = oldName;
            NewName = newName;

            OldDescriptions = oldDescriptions;
            NewDescriptions = newDescriptions;

            UpdatedAt = updatedAt;
        }
    }
}
