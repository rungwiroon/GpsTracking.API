using Core.Domain.Trackers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.TrackerLogs.Repositories
{
    public interface ITrackerLogRepository
    {
        TrackerLog[] GetByTrackerId(TrackerId trackerId);

        void Add(TrackerLog trackerlog);
    }
}
