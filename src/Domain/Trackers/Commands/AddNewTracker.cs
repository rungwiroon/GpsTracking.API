using Domain;
using Core.Domain.Identity;

namespace Core.Domain.Trackers.Commands
{
    public class AddNewTracker : ICommand
    {
        public string SerialNumber { get; }

        public string? Brand { get; }

        public string? Model { get; }

        public UserAccountId IssuedBy { get; }

        public AddNewTracker(
            string serialNumber, UserAccountId issuedBy,
            string? brand = null, string? model = null)
        {
            SerialNumber = serialNumber;
            IssuedBy = issuedBy;
            Brand = brand;
            Model = model;
        }
    }
}