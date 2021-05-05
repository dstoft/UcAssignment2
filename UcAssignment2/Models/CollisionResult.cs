using InterstellarLogistic.Shared;

namespace UcAssignment2.Models
{
    public class CollisionResult : IAggregateRoot<CollisionResult>
    {
        public CollisionResult(bool isCollided, CoordinatePoint coordinatePointToCheck,
            CollisionRectangle maybeCollisionRectangle)
        {
            IsCollided = isCollided;
            CoordinatePointToCheck = coordinatePointToCheck;
            MaybeCollisionRectangle = maybeCollisionRectangle;
        }

        public bool IsCollided { get; }
        public CoordinatePoint CoordinatePointToCheck { get; }
        public CollisionRectangle MaybeCollisionRectangle { get; }

        public string ToKey()
        {
            return CoordinatePointToCheck.ToKey();
        }

        public bool Equals(CollisionResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(CoordinatePointToCheck, other.CoordinatePointToCheck);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CollisionResult) obj);
        }

        public override int GetHashCode()
        {
            return CoordinatePointToCheck != null ? CoordinatePointToCheck.GetHashCode() : 0;
        }
    }
}