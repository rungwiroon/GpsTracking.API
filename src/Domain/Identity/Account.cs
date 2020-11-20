using Core.Domain.Identity.Events;
using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using Core.Domain.Trackers.Modules;
using Core.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Identity
{
    public record AccountId
    {
        public int Value { get; }

        public AccountId(int value) => Value = value;
    }

    public class Account : Entity, IAggregateRoot
    {
        public AccountId Id { get; }

        public bool IsActive { get; private set; }

        public DateTimeOffset CreatedAt { get; }

        public DateTimeOffset? DeactivedAt { get; set; }

        private readonly List<UserAccount> userAccounts = new();
        public IReadOnlyCollection<UserAccount> UserAccounts => userAccounts.AsReadOnly();

        public Account(int accountId)
        {
            Id = new AccountId(accountId);
            CreatedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new AccountCreated(Id));
        }

        public void Deactivate()
        {
            if (!IsActive)
                return;

            IsActive = false;
            DeactivedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new AccountDeactivated(Id));
        }

        public UserAccount CreateUserAccount(
            UserAccountId issuedBy,
            string userName, string password, UserRole role, 
            string? email = null, string? name = null, string? descriptions = null)
        {
            var userAcc = userAccounts.Single(ua => ua.Id == issuedBy);

            if(userAcc.RoleId != UserRole.Owner.Id)
                throw new InvalidOperationException("User doesn't have permission to create user account");

            return new UserAccount(
                this, userName, password, role, 
                email, name, descriptions);
        }

        public void UpdateUserAccountInfo(
            UserAccountId issuedBy, UserAccountId userToUpdate, 
            string name, string? descriptions = null)
        {
            var whoWantsToEdit = userAccounts.Single(ua => ua.Id == issuedBy);
            
            if(issuedBy != userToUpdate
                && whoWantsToEdit.RoleId != UserRole.Owner.Id)
            {
                throw new InvalidOperationException("No permission");
            }

            var whoToEdit = userAccounts.Single(ua => ua.Id == issuedBy);
            whoToEdit.ChangeInfo(name, descriptions);
        }

        public void ChangePassword()
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAccount()
        {
            throw new NotImplementedException();
        }

        public UserGroup CreateUserGroup(UserAccountId issuedBy, string name, string? descriptions = null)
        {
            var whoWantsToCreate = userAccounts.Single(ua => ua.Id == issuedBy);

            if(whoWantsToCreate.RoleId != UserRole.Owner.Id)
                throw new InvalidOperationException("User doesn't have permission to create user account");

            return new UserGroup(Id, name, descriptions);
        }

        public Tracker CreateTracker()
        {
            throw new NotImplementedException();
        }

        public DeviceModule CreateTrackerModule()
        {
            throw new NotImplementedException();
        }

        public Vehicle CreateVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
