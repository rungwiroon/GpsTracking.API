using System;
using System.Collections.Generic;
using Core.Domain.Identity.Events;
using Core.Domain.SeedWork;
using LanguageExt;

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

#pragma warning disable CS8618
        private UserAccount() { }
#pragma warning restore CS8618

        internal UserAccount(
            Tenant account, string userName, string passwordHash, UserRoleId roleId, 
            string? email = null, string? name = null, string? descriptions = null)
        {
            Id = new();
            Account = account;
            UserName = userName;
            RoleId = roleId;
            Email = email;
            Name = name;
            Descriptions = descriptions;
        }

        internal Seq<IDomainEvent> ChangeRole(UserRole newRole)
        {
            var @event = new UserRoleChanged(Account.Id, Id, RoleId, newRole.Id, newRole.Name);

            RoleId = newRole.Id;

            return new() { @event };
        }

        internal Seq<IDomainEvent> ChangeInfo(string newName, string? newDescriptions)
        {
            var @event = new UserInfoUpdated(
                Name, newName, Descriptions, newDescriptions, DateTimeOffset.UtcNow);

            Apply(@event);

            return new() { @event };
        }

        internal void Apply(UserInfoUpdated @event)
        {
            Name = @event.NewName;
            Descriptions = @event.NewDescriptions;
        }

        internal void ChangePassword()
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}
