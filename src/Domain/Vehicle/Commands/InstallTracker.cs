using Core.Domain.Trackers;
using Domain;
using System;

namespace Core.Domain.Vehicle.Commands
{
    [Serializable]
    public class InstallTracker : ICommand
    {
        public VehicleId VehicleId { get; }

        public TrackerId TrackerId { get; }

        public DateTimeOffset InstalledAt { get; }

        public string? InstalledBy { get; }

        public InstallTracker(
            VehicleId vehicleId,
            TrackerId trackerId,
            DateTimeOffset installedAt,
            string? installedBy = null
        )
        {
            VehicleId = vehicleId;
            TrackerId = trackerId;
            InstalledAt = installedAt;
            InstalledBy = installedBy;
        }
    }
}
