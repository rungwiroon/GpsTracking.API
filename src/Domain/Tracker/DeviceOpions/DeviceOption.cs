using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Domain.DeviceOpions
{
    public class DeviceOption
    {
        public DeviceSensorOption[] SensorOptionHistories { get; }
    }

    public abstract class DeviceSensorOption
    {
        public DateTimeOffset EffectiveAt { get; }

        public int Channel { get; }

        public Sensor Sensor { get; }
    }
}
