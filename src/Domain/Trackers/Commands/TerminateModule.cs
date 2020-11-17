using Core.Domain.Trackers.Modules;
using Domain;
using System;

namespace Core.Domain.Trackers.Commands
{
    public class TerminateModule : ICommand
    {
        public DeviceModuleId ModuleId { get; }
        public DateTimeOffset EffectiveAt { get; }

        public TerminateModule(DeviceModuleId moduleId, DateTimeOffset effectiveAt)
        {
            ModuleId = moduleId;
            EffectiveAt = effectiveAt;
        }
    }
}