using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;

namespace Domain
{
    public record IconId : EntityId
    {
        
    }

    public class Icon
    {
        public IconId Id { get; }

        public string Name { get; }

        public Uri Url { get; }

        public string? Description { get; }

        public static Icon Default { get; }
    }
}