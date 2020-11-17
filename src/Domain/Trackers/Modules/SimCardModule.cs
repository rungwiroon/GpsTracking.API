
namespace Core.Domain.Trackers.Modules
{
    public abstract class SimCard
    {
        public string SerialNumber { get; protected set; }
    }

    public class PhoneSimCard : SimCard
    {
        public string PhoneNumber { get; }

        public PhoneSimCard(string serialNumber, string phoneNumber)
        {
            SerialNumber = serialNumber;
            PhoneNumber = phoneNumber;
        }
    }

    public class IotSimCard : SimCard
    {
        public IotSimCard(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }
}
