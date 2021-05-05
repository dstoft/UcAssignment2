using System;
using InterstellarLogistic.Shared;

namespace UcAssignment2.Models
{
    public class CollisionRectangle : IAggregateRoot<CollisionRectangle>
    {
        public CollisionRectangle(CoordinatePoint cornerOne, CoordinatePoint cornerTwo)
        {
            CornerOne = cornerOne;
            CornerTwo = cornerTwo;
        }

        public CoordinatePoint CornerOne { get; }
        public CoordinatePoint CornerTwo { get; }

        public string ToKey()
        {
            return CornerOne.ToKey() + "-" + CornerTwo.ToKey();
        }

        public bool Equals(CollisionRectangle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(CornerOne, other.CornerOne) && Equals(CornerTwo, other.CornerTwo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CollisionRectangle) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CornerOne, CornerTwo);
        }
    }
}