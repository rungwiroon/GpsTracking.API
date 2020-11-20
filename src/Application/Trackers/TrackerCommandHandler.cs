using Core.Domain.Trackers.Commands;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Trackers
{
    public class TrackerCommandHandler :
        ICommandHandler<AddNewTracker>,
        ICommandHandler<TerminateTracker>
    {
        public void Handle(AddNewTracker command)
        {
            throw new NotImplementedException();
        }

        public void Handle(TerminateTracker command)
        {
            throw new NotImplementedException();
        }
    }
}
