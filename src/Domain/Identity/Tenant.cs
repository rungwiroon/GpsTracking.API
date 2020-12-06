using Core.Domain.Identity.Events;
using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using Core.Domain.Trackers.Modules;
using Core.Domain.Vehicles;
using Core.Domain.Vehicles.Events;
using LanguageExt;
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
        public TenantId Id { get; private set; }

        public bool IsActive { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public DateTimeOffset? DeactivedAt { get; private set; }

        private readonly List<UserAccount> userAccounts = new();
        public IReadOnlyCollection<UserAccount> UserAccounts => userAccounts.AsReadOnly();

#pragma warning disable CS8618
        private Tenant()
#pragma warning restore CS8618
        {
        }

        // private Tenant(int tenantId)
        // {
        //     Id = new TenantId(tenantId);
        //     CreatedAt = DateTimeOffset.UtcNow;
        // }

        public static (Tenant, UserAccount, Seq<IDomainEvent>) CreateAccount(int tenantNumber,
            string userName, string passwordHash, string? email = null)
        {
            var tenant = new Tenant();
            var createdEvent = new TenantCreated(tenant.Id, DateTimeOffset.UtcNow);

            tenant.Apply(createdEvent);

            var userAccountId = new UserAccountId();
            var userRole = UserRole.Owner;
            var userAccountCreatedEvent = new UserAccountCreated(
                    tenant.Id,
                    userAccountId, userName, passwordHash,
                    userRole.Id, userRole.Name,
                    email);

            tenant.Apply(userAccountCreatedEvent);

            var userAccount = tenant.UserAccounts.Single(u => u.Id == userAccountId);

            var events = new Seq<IDomainEvent>()
            {
                createdEvent,
                userAccountCreatedEvent
            };

            return (tenant, userAccount, events);
        }

        public void Apply(TenantCreated @event)
        {
            Id = @event.TenantId;
            CreatedAt = @event.CreatedAt;
        }

        public void Apply(UserAccountCreated @event)
        {
            var newUser = new UserAccount(
                this, @event.UserName, @event.PasswordHash, 
                @event.UserRoleId,
                @event.Email, @event.Name, @event.Description);

            userAccounts.Add(newUser);
        }

        public Seq<IDomainEvent> Suspend()
        {
            throw new NotImplementedException();
        }

        public Seq<IDomainEvent> Close()
        {
            if (!IsActive)
                return new SeqEmpty();

            var @event = new TenantClosed(Id, DateTimeOffset.UtcNow);

            return new() { @event };
        }

        public void Apply(TenantClosed @event)
        {
            IsActive = false;
            DeactivedAt = @event.ClosedAt;
        }

        public (UserAccount, Seq<IDomainEvent>) CreateUserAccount(
            UserAccountId issuedBy,
            string userName, string passwordHash, UserRole role, 
            string? email = null, string? name = null, string? descriptions = null)
        {
            var userAcc = userAccounts.Single(ua => ua.Id == issuedBy);

            if(userAcc.RoleId != UserRole.Owner.Id)
                throw new InvalidOperationException("User doesn't have permission to create user account");
            
            var userAccountId = new UserAccountId();
            var @event = new UserAccountCreated(Id,
                        userAccountId, userName, passwordHash,
                        role.Id, role.Name,
                        email, name, descriptions);

            Apply(@event);

            var userAccount = UserAccounts.Single(u => u.Id == userAccountId);

            return (
                userAccount,
                new()
                {
                    @event
                });
        }

        public Seq<IDomainEvent> UpdateUserAccountInfo(
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
            return whoToEdit.ChangeInfo(name, descriptions);
        }

        public Seq<IDomainEvent> ChangePassword(string oldPasswordHash, string newPasswordHash)
        {
            throw new NotImplementedException();
        }

        public Seq<IDomainEvent> CloseUserAccount()
        {
            throw new NotImplementedException();
        }

        public (UserGroup, Seq<IDomainEvent>) CreateUserGroup(UserAccountId issuedBy, string name, string? descriptions = null)
        {
            var whoWantsToCreate = userAccounts.Single(ua => ua.Id == issuedBy);

            if(whoWantsToCreate.RoleId != UserRole.Owner.Id)
                throw new InvalidOperationException(
                    "User doesn't have permission to create user account");

            var userGroup = new UserGroup(Id, name, descriptions);

            return (
                userGroup,
                new Seq<IDomainEvent>()
                {
                    new UserGroupCreated(userGroup.Id, userGroup.Name, Id)
                });
        }

        public (Tracker, Seq<IDomainEvent>) CreateTracker()
        {
            throw new NotImplementedException();
        }

        public (DeviceModule, Seq<IDomainEvent>) CreateTrackerModule()
        {
            throw new NotImplementedException();
        }

        public (Vehicle, Seq<IDomainEvent>) CreateVehicle(
            string vehicleLicensePlateId, VehicleType vehicleType, string? name = null)
        {
            throw new NotImplementedException();
        }

        public (VehicleGroup, Seq<IDomainEvent>) CreateVehicleGroup(
            string name, string? description = null)
        {
            var vehicleGroup = new VehicleGroup(Id, name, description);

            return (
                vehicleGroup,
                new()
                {
                    new VehicleGroupCreated(Id, vehicleGroup.Id, vehicleGroup.Name)
                }
            );
        }
    }
}
