using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DeviceEvents
{
    class DigitalSensorEvent : DeviceEvent
    {
        public SensorData<bool> Value { get; }
    }

    class AnalogSensorEvent : DeviceEvent
    {
        public SensorData<float> Value { get; }
    }
}
