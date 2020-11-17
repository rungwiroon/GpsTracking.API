using Domain;

namespace Core.Domain.Trackers.Commands
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