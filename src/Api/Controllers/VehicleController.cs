using API.Models;
using Core.Domain.Identity;
using Core.Domain.SeedWork;
using Core.Domain.Vehicles.Queries;
using Core.Domain.Vehicles.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IViewRepository<UserGroupVehiclesView> userGroupVehiclesViewRepository;

        public VehicleController(IViewRepository<UserGroupVehiclesView> userGroupVehiclesViewRepository)
        {
            this.userGroupVehiclesViewRepository = userGroupVehiclesViewRepository;
        }

        [HttpGet("usergroup/{userGroupId}")]
        public IEnumerable<VehicleModel> GetByUserGroup(Guid userGroupId)
        {
            var view = userGroupVehiclesViewRepository.GetByQuery(
                new GetVehicleInUserGroup(new UserGroupId(userGroupId)));

            return view.Vehicles
                .Select(v => new VehicleModel(
                    v.VehicleId.Value,
                    v.LicensePlateId,
                    v.Name,
                    ""));
        }
    }
}
