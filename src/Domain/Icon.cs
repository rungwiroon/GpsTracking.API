using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vehicle
{
    public record IconId : EntityId
    {
        
    }

    public class Icon
    {
        public IconId Id { get; }

        public string Name { get; }

        public Uri Url { get; }

        public string Description { get; }
    }
}