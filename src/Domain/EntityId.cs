﻿using System;
using System.Runtime.Serialization;

namespace Domain
{
    [Serializable]
    public record EntityId : ISerializable
    {
        public Guid Value { get; }

        public EntityId() => Value = Guid.NewGuid();

        public EntityId(Guid value) => Value = value;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}