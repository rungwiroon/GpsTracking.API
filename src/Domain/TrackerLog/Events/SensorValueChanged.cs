using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TrackerLog.Events
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
