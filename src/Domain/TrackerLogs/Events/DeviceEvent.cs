﻿using Core.Domain.Trackers;
using System;

namespace Domain.TrackerLogs.Events
{
    public abstract class DeviceEvent
    {
        public TrackerId TrackerId { get; }
        public DateTimeOffset TimeStamp { get; }

        protected DeviceEvent(TrackerId trackerId, DateTimeOffset timeStamp)
        {
            TrackerId = trackerId;
            TimeStamp = timeStamp;
        }
    }
}
