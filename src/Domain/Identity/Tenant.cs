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
        public TenantId Id { get; }

        public bool IsActive { get; private set; }

        public DateTimeOffset CreatedAt { get; }

        public DateTimeOffset? DeactivedAt { get; set; }

        private readonly List<UserAccount> userAccounts = new();
        public IReadOnlyCollection<UserAccount> UserAccounts => userAccounts.AsReadOnly();

#pragma warning disable CS8618
        private Tenant()
#pragma warning restore CS8618
        {
        }

        private Tenant(int tenantId)
        {
            Id = new TenantId(tenantId);
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public static (Tenant, UserAccount, Seq<IDomainEvent>) CreateAccount(int tenantNumber,
            string userName, string password, string? email = null)
        {
            var tenant = new Tenant(tenantNumber);

            var userRole = UserRole.Owner;

            var newUser = new UserAccount(
                tenant, userName, password, userRole,
                email);

            tenant.userAccounts.Add(newUser);

            var events = new Seq<IDomainEvent>()
            {
                new TenantCreated(tenant.Id),
                new UserAccountCreated(
                    tenant.Id,
                    newUser.Id, newUser.UserName, userRole.Id, userRole.Name)
            };

            return (tenant, newUser, events);
        }

        public Seq<IDomainEvent> Deactivate()
        {
            if (!IsActive)
                return new SeqEmpty();

            IsActive = false;
            DeactivedAt = DateTimeOffset.UtcNow;

            return new() { new AccountDeactivated(Id) };
        }

        public (UserAccount, Seq<IDomainEvent>) CreateUserAccount(
            UserAccountId issuedBy,
            string userName, string password, UserRole role, 
            string? email = null, string? name = null, string? descriptions = null)
        {
            var userAcc = userAccounts.Single(ua => ua.Id == issuedBy);

            if(userAcc.RoleId != UserRole.Owner.Id)
                throw new InvalidOperationException("User doesn't have permission to create user account");

            var userAccount = new UserAccount(
                    this, userName, password, role,
                    email, name, descriptions);

            userAccounts.Add(userAccount);

            return (
                userAccount,
                new()
                {
                    new UserAccountCreated(Id,
                        userAccount.Id, userAccount.UserName,
                        role.Id, role.Name)
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

        public Seq<IDomainEvent> ChangePassword()
        {
            throw new NotImplementedException();
        }

        public Seq<IDomainEvent> DeleteUserAccount()
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
