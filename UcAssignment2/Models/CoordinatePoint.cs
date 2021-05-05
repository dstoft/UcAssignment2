using System;
using InterstellarLogistic.Shared;

namespace UcAssignment2.Models
{
    public class CoordinatePoint : IAggregateRoot<CoordinatePoint>
    {
        public CoordinatePoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public string ToKey()
        {
            return X + ";" + Y;
        }

        public bool Equals(CoordinatePoint other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CoordinatePoint) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}