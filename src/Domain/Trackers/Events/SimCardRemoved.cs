using Core.Domain.SeedWork;
using Core.Domain.Trackers.Modules;

namespace Core.Domain.Trackers.Events
{
    public record SimCardRemoved : IEvent
    {
        public string SimCardSerialNumber { get; }
        public string? SimCardPhoneNumber { get; }
        public DeviceModuleId CellularModuleId { get; }

        public SimCardRemoved(
            string simCardSerialNumber,
            DeviceModuleId cellularModuleId,
            string? simCardPhoneNumber = null)
        {
            SimCardSerialNumber = simCardSerialNumber;
            CellularModuleId = cellularModuleId;

            SimCardPhoneNumber = simCardPhoneNumber;
        }
    }
}
