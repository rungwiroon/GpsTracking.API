using Domain.DeviceOpions;
using System;
using System.Collections.Generic;

namespace Domain.Tracker.Commands
{
    public class TerminateTracker : ICommand
    {
        public TrackerId Id { get; }
        public DateTimeOffset EffectiveAt { get; }
    }
}