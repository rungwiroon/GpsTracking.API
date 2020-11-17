using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Domain.User
{
    [Serializable]
    public sealed record AccountId : EntityId
    {

    }

    [Serializable]
    public record Account
    {
        public AccountId Id { get; }

        private List<UserGroup> userGroups = new();
        public IReadOnlyCollection<UserGroup> UserGroups => userGroups;

        public Account()
        {
            Id = new();
        }
    }

    [Serializable]
    public record IndividualAccount : Account
    {

    }

    [Serializable]
    public record OrganizationAccount : Account
    {
    }
}