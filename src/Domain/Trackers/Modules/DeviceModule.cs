using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Core.Domain.Trackers.Modules
{
    public sealed record DeviceModuleId : EntityId
    {

    }

    public abstract class DeviceModule : Entity
    {
        public DeviceModuleId Id { get; }

        public DateTimeOffset CreatedAt { get; }

        public bool Enabled { get; }

        //public abstract void Enable();

        //public abstract void Disable();
    }
}