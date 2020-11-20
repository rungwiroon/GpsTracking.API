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
    public record TenantId
    {
        public int Value { get; }

        public TenantId(int value) => Value = value;
    }

    public class Tenant : Entity, IAggregateRoot
    {
        public TenantId Id { get; }

        public bool IsActive { get; private set; }

        public DateTimeOffset CreatedAt { get; }

        public DateTimeOffset? DeactivedAt { get; set; }

        private readonly List<UserAccount> userAccounts = new();
        public IReadOnlyCollection<UserAccount> UserAccounts => userAccounts.AsReadOnly();

        private Tenant(int tenantId)
        {
            Id = new TenantId(tenantId);
            CreatedAt = DateTimeOffset.UtcNow;

            AddDomainEvent(new AccountCreated(Id));
        }

        public static (Tenant, UserAccount) CreateAccount(int tenantId,
            string userName, string password, string? email = null)
        {
            var account = new Tenant(tenantId);

            var newUser = new UserAccount(
                account, userName, password, UserRole.Owner,
                email);

            account.userAccounts.Add(newUser);

            return (account, newUser);
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

        public VehicleGroup CreateVehicleGroup()
        {
            throw new NotImplementedException();
        }
    }
}
