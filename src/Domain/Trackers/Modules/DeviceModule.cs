using Core.Domain.Identity;
using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Core.Domain.Trackers.Modules
{
    public sealed record DeviceModuleId : EntityId
    {
        public DeviceModuleId() : base() { }

        public DeviceModuleId(Guid id) : base(id) { }
    }

    public abstract class DeviceModule : Entity
    {
        public DeviceModuleId Id { get; }

        public AccountId AccountId { get; }

        public DateTimeOffset CreatedAt { get; }

        public bool Enabled { get; }

        public string? Version { get; }

        //public abstract void Enable();

        //public abstract void Disable();
    }
}