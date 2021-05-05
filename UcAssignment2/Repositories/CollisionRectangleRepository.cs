using System.Linq;
using InterstellarLogistic.Shared;
using UcAssignment2.Models;

namespace UcAssignment2.Repositories
{
    public class CollisionRectangleRepository : RepositoryBase<CollisionRectangle>, ICollisionRectangleRepository
    {
        public CollisionResult CheckForCollision(double x, double y)
        {
            var coordinatePoint = new CoordinatePoint(x, y);
            var isCollided = false;
            // CollisionRectangle maybeCollisionRectangle = null;

            var maybeCollisionRectangle = Items.Values.FirstOrDefault(collisionRectangle =>
                CheckCollisionRectangle(collisionRectangle, coordinatePoint));
            if (maybeCollisionRectangle != null) isCollided = true;

            // foreach (var collisionRectangle in Items.Values.Where(collisionRectangle => CheckCollisionRectangle(collisionRectangle, coordinatePoint)))
            // {
            //     isCollided = true;
            //     maybeCollisionRectangle = collisionRectangle;
            //     break;
            // }

            return new CollisionResult(isCollided, coordinatePoint, maybeCollisionRectangle);
        }

        private bool CheckCollisionRectangle(CollisionRectangle collisionRectangle, CoordinatePoint toCheck)
        {
            var xPair = GetMaxPair(collisionRectangle.CornerOne.X, collisionRectangle.CornerTwo.X);
            var yPair = GetMaxPair(collisionRectangle.CornerOne.Y, collisionRectangle.CornerTwo.Y);
            return IsWithin(xPair, toCheck.X) && IsWithin(yPair, toCheck.Y);
        }

        private bool IsWithin((double, double) valueTuple, double toCheck)
        {
            var (max, min) = valueTuple;
            return max >= toCheck && min <= toCheck;
        }

        private (double, double) GetMaxPair(double first, double second)
        {
            return first > second ? (first, second) : (second, first);
        }
    }
}