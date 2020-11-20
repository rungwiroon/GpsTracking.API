using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Vehicles.Events
{
    public class VehicleGroupRenamed : IDomainEvent
    {
        public string NewName { get; }
    }
}
