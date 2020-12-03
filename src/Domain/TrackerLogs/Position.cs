using Core.Domain.SeedWork;
using System;
using System.Runtime.Serialization;

namespace Domain.TrackerLogs
{
    [Serializable]
    public class GpsPosition : IValueObject
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public GpsPosition(double latitude, double longitude)
            => (Latitude, Longitude) = (latitude, longitude);

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Latitude), Latitude);
            info.AddValue(nameof(Longitude), Longitude);
        }
    }
}
