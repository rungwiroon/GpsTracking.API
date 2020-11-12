using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain
{
    [Serializable]
    public record GpsPosition : ISerializable
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public GpsPosition(double latitude, double longitude)
            => (Latitude, Longitude) = (latitude, longitude);

        public double Distance(GpsPosition position)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
