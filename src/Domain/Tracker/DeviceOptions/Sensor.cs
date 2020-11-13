using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Domain.DeviceOpions
{
    public class Sensor
    {
        public string Name { get; }

        public string? Unit { get; }
    }

    [Serializable]
    public class DigitalSensor : Sensor, ISerializable
    {
        public bool Inverted { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class AnalogSensor : Sensor, ISerializable
    {
        public Expression<Func<float, float>> ValueConverter { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
