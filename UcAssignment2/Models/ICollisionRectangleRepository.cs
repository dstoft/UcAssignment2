using InterstellarLogistic.Shared;

namespace UcAssignment2.Models
{
    public interface ICollisionRectangleRepository : IRepository<CollisionRectangle>
    {
        public CollisionResult CheckForCollision(double x, double y);
    }
}