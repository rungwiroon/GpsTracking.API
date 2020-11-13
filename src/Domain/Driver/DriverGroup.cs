using System;
using System.Collections.Generic;
using System.Text;
using Domain.User;

namespace Domain.Driver
{
    public sealed record DriverGroupId : EntityId
    {

    }

    [Serializable]
    public class DriverGroup
    {
        public DriverGroupId Id { get; }

        public string Name { get; }

        public UserGroupId UserGroupId { get; }
    }
}