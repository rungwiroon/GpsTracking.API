using Core.Domain.Trackers.Commands;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Trackers
{
    public class ModuleCommandHandler :
        ICommandHandler<AddCellularModule>,
        ICommandHandler<AddNewGpsModule>
    {
        public void Handle(AddCellularModule command)
        {
            throw new NotImplementedException();
        }

        public void Handle(AddNewGpsModule command)
        {
            throw new NotImplementedException();
        }
    }
}
