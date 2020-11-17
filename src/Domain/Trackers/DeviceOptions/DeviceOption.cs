using System;

namespace Core.Domain.Trackers.DeviceOpions
{
    public class DeviceOption
    {
        public SensorOption[] SensorOptionHistories { get; }
        public Sensor Sensor { get; }
    }

    public abstract class SensorOption
    {
        public DateTimeOffset EffectiveAt { get; }

        public int Channel { get; }
    }
}
