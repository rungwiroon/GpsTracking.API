using System;
using System.Collections.Generic;
using Domain.Tracker.Modules;

namespace Domain.Tracker.Commands
{
    public class TerminateModule : ICommand
    {
        public DeviceModuleId ModuleId { get; }
        public DateTimeOffset EffectiveAt { get; }
    }
}