using Core.Domain.Trackers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TrackerLog.Events
{
    public class PositionEvent : DeviceEvent
    {
        public GpsPosition Position { get; }

        public float Speed { get; }

        public float Heading { get; }

        public float Accuracy { get; }

        public PositionEvent(
            TrackerId trackerId, DateTimeOffset timestamp, 
            GpsPosition position, float speed, float heading, float accuracy)
            : base(trackerId, timestamp)
        {
            Position = position;
            Speed = speed;
            Heading = heading;
            Accuracy = accuracy;
        }
    }
}
