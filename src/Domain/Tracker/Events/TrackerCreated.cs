using Domain.DeviceOpions;
using System;
using System.Collections.Generic;

namespace Domain.Tracker.Events
{
    public class TrackerCreated : IEvent
    {
        public TrackerId Id { get; }
        
    }
}