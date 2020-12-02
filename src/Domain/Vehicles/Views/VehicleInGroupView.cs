using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Vehicles.Views
{
    public record VehicleInGroupView
    {
        public VehicleId VehicleId { get; set; }

        public string LicensePlateId { get; set; }

        public string? Name { get; set; }
    }
}
