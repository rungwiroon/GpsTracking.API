using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.TrackerLog
{
    public struct SensorData<T>
        where T : struct
    {
        public int Channel { get; }

        public T Value { get; }
    }
}
