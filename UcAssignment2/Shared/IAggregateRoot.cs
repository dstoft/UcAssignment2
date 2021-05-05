using System;

namespace InterstellarLogistic.Shared
{
    public interface IAggregateRoot<TAggregate> : IEquatable<TAggregate>, IUniqueId
    {
    }
}