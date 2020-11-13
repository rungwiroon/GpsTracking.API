using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Tracker.Commands
{
    public class AddSimCard : ICommand
    {
        public string PhoneNumber { get; }

        public string? SerialNumber { get; }

        public string? MobileOperator { get; }

        public string? Type { get; }
    }
}
