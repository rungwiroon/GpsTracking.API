using Core.Domain;
using Domain.DeviceOpions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tracker.Modules
{
    public sealed record DeviceModuleId : EntityId
    {

    }

    public abstract class DeviceModule : Entity
    {
        public DeviceModuleId Id { get; }

        public DateTimeOffset CreatedAt { get; }
    }
}