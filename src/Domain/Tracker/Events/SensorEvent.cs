using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tracker.Events
{
    public class DigitalSensorEvent : DeviceEvent
    {
        public SensorData<bool> Value { get; }
    }

    public class AnalogSensorEvent : DeviceEvent
    {
        public SensorData<float> Value { get; }
    }
}
