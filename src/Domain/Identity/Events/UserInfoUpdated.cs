using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class UserInfoUpdated : IEvent
    {
        public string? Name { get; }

        public string? Descriptions { get; }

        public DateTimeOffset UpdatedAt { get; }

        public UserInfoUpdated(string? name, string? descriptions, DateTimeOffset updatedAt)
        {
            Name = name;
            Descriptions = descriptions;
            UpdatedAt = updatedAt;
        }
    }
}
