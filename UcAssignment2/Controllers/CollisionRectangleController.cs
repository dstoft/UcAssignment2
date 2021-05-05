using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UcAssignment2.Models;

namespace UcAssignment2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CollisionRectangleController : ControllerBase
    {
        private readonly ICollisionRectangleRepository _collisionRectangleRepository;

        public CollisionRectangleController(ICollisionRectangleRepository collisionRectangleRepository)
        {
            _collisionRectangleRepository = collisionRectangleRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CollisionRectangle[]), StatusCodes.Status200OK)]
        public ActionResult<IList<CollisionRectangle>> List()
        {
            return Ok(_collisionRectangleRepository.List());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CollisionRectangle> Create(double[] coordinates)
        {
            if (coordinates.Length != 4) return BadRequest("Exactly four doubles has to be inputted!");
            var collisionRectangle = new CollisionRectangle(new CoordinatePoint(coordinates[0], coordinates[1]),
                new CoordinatePoint(coordinates[2], coordinates[3]));
            _collisionRectangleRepository.Save(collisionRectangle);
            return Created("", collisionRectangle);
        }

        [HttpPost("check")]
        public ActionResult<CollisionResult> Check(double[] coordinates)
        {
            if (coordinates.Length != 2) return BadRequest("Exactly two doubles has to be inputted!");

            return Ok(_collisionRectangleRepository.CheckForCollision(coordinates[0], coordinates[1]));
        }
    }
}