using Domain;
using Domain.User;

namespace Core.Domain.Trackers.Commands
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