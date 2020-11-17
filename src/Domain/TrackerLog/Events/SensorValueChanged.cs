using Core.Domain.Trackers;
using System;

namespace Domain.TrackerLog.Events
{
    public class DigitalSensorEvent : DeviceEvent
    {
        public SensorData<bool> Value { get; }

        public DigitalSensorEvent(TrackerId trackerId, DateTimeOffset timeStamp,
            int channel, bool value) 
            : base(trackerId, timeStamp)
        {
            Value = new SensorData<bool>(channel, value);
        }
    }

    public class AnalogSensorEvent : DeviceEvent
    {
        public SensorData<float> Value { get; }

        public AnalogSensorEvent(TrackerId trackerId, DateTimeOffset timeStamp,
            int channel, float value)
            : base(trackerId, timeStamp)
        {
            Value = new SensorData<float>(channel, value);
        }
    }
}
