using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleInfoChanged : IDomainEvent
    {
        public string Brand { get; }
        public string Model { get; }

        public DateTimeOffset GlobalSequenceNumber { get; }

        public VehicleInfoChanged(string brand, string model)
        {
            Brand = brand;
            Model = model;

            GlobalSequenceNumber = DateTimeOffset.UtcNow;
        }
    }
}
