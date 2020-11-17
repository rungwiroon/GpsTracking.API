using Domain;
using System;

namespace Core.Domain.Trackers.Commands
{
    public class TerminateTracker : ICommand
    {
        public TrackerId Id { get; }
        public DateTimeOffset EffectiveAt { get; }

        public TerminateTracker(TrackerId id, DateTimeOffset effectiveAt)
        {
            Id = id;
            EffectiveAt = effectiveAt;
        }
    }
}