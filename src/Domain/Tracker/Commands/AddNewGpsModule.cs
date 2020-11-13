using Domain.DeviceOpions;
using System;
using System.Collections.Generic;

namespace Domain.Tracker.Commands
{
    public class AddNewGpsModule : ICommand
    {
        public string SerialNumber { get; }

        public string? Brand { get; }

        public string? Model { get; }

        public AddNewGpsModule(
            string serialNumber,
            string? brand = null, string? model = null)
        {
            SerialNumber = serialNumber;
            Brand = brand;
            Model = model;
        }
    }
}