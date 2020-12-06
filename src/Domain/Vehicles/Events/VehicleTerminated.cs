using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Vehicles.Events
{
    public class VehicleTerminated : IDomainEvent
    {
        public VehicleId VehicleId { get; }

        public DateTimeOffset TerminatedAt { get; }

        public VehicleTerminated(VehicleId vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}
