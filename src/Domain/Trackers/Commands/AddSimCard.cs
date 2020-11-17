using Domain;
using System;
using System.Collections.Generic;

namespace Core.Domain.Trackers.Commands
{
    public class AddSimCard : ICommand
    {
        public string PhoneNumber { get; }

        public string? SerialNumber { get; }

        public string? MobileOperator { get; }

        public string? Type { get; }

        public AddSimCard(string phoneNumber, string? serialNumber, string? mobileOperator, string? type)
        {
            PhoneNumber = phoneNumber;
            SerialNumber = serialNumber;
            MobileOperator = mobileOperator;
            Type = type;
        }
    }
}
