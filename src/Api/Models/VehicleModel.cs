using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class VehicleModel
    {
        public Guid VehicleId { get; }

        public string LicensePlateId { get; }

        public string Name { get; }

        public string Type { get; }

        public VehicleModel(Guid vehicleId, string licensePlateId, string name, string type)
        {
            VehicleId = vehicleId;
            LicensePlateId = licensePlateId;
            Name = name;
            Type = type;
        }
    }
}
