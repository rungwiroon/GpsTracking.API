using System;
using System.Collections.Generic;
using Core.Domain.Identity.Events;
using Core.Domain.SeedWork;

namespace Core.Domain.Identity
{
    public record UserAccountId : EntityId
    {
        public UserAccountId() : base() { }

        public UserAccountId(Guid id) : base(id) { }
    }

    public class UserAccount : Entity, IAggregateRoot
    {
        public UserAccountId Id { get; }

        public Tenant Account { get; }

        public UserRoleId RoleId { get; set; }

        public string UserName { get; }

        public string? Email { get; }

        public string? Name { get; private set; }

        public string? Descriptions { get; private set; }

        private UserAccount() { }

        internal UserAccount(
            Tenant account, string userName, string password, UserRole role, 
            string? email = null, string? name = null, string? descriptions = null)
        {
            Id = new();
            Account = account;
            UserName = userName;
            RoleId = role?.Id ?? UserRole.Viewer.Id;
            Email = email;
            Name = name;
            Descriptions = descriptions;
        }

        internal void ChangeRole(UserRole newRole)
        {
            var @event = new UserRoleChanged(Account.Id, Id, RoleId, newRole.Id, newRole.Name);

            RoleId = newRole.Id;

            AddDomainEvent(@event);
        }

        internal void ChangeInfo(string newName, string? newDescriptions)
        {
            Name = newName;
            Descriptions = newDescriptions;

            AddDomainEvent(new UserInfoUpdated(newName, newDescriptions, DateTimeOffset.UtcNow));
        }

        internal void ChangePassword()
        {
            throw new NotImplementedException();
        }
    }
}
