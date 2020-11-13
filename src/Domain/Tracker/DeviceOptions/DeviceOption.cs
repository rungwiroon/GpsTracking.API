using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Domain.DeviceOpions
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
