using Domain;
using System;
using System.Collections.Generic;

namespace Core.Domain.Trackers.Commands
{
    public class AddCellularModule : ICommand
    {
        public string SerialNumber { get; }
        public string Imei { get; }

        public string? Brand { get; }

        public string? Model { get; }

        public AddCellularModule(
            string serialNumber, string imei,
            string? brand = null, string? model = null)
        {
            SerialNumber = serialNumber;
            Imei = imei;
            Brand = brand;
            Model = model;
        }
    }
}
