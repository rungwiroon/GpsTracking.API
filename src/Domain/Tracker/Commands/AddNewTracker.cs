using Domain.DeviceOpions;
using System;
using System.Collections.Generic;
using Domain.User;
using System.Security;

namespace Domain.Tracker.Commands
{
    public class AddNewTracker : ICommand
    {
        public string SerialNumber { get; }

        public string? Brand { get; }

        public string? Model { get; }

        public AccountId AccountId { get; }

        public AddNewTracker(
            string serialNumber, AccountId accountId,
            string? brand = null, string? model = null)
        {
            SerialNumber = serialNumber;
            AccountId = accountId;
            Brand = brand;
            Model = model;
        }
    }
}