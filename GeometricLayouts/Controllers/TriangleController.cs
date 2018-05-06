
namespace GeometricLayouts.Controllers
{
    using System;
    using System.Diagnostics;
    using GeometricLayouts.Models;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    /// <summary>
    /// Controller for getting coordinates and cells of a triangle layout.
    /// </summary>
    [Route("api/[controller]")]
    public class TriangleController : Controller
    {
        private readonly ITriangeService triangleService;

        /// <summary>
        /// Initializes a new instance of <see cref="TriangleController"/>.
        /// </summary>
        /// <param name="triangleService">Service for calculating triangle coordinates and cells in a geometric layout.</param>
        public TriangleController(ITriangeService triangleService)
        {
            this.triangleService = triangleService;
        }

        /// <summary>
        /// Gets the coordinates for a row and column;
        /// GET: api/Triangle/Coordinates?row=C&column=4
        /// </summary>
        /// <param name="row">Row letter of the triangle.</param>
        /// <param name="column">Column of the triangle.</param>
        /// <returns><see cref="IActionResult"/> that contains a <see cref="Triangle"/> if successful.</returns>
        [HttpGet("Coordinates")]
        public IActionResult GetCoordinates(string row, int column)
        {
            var cell = Cell.Create(row, column);

            try
            {
                var triangle = triangleService.GetTriangle(cell);
                return Ok(triangle);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetCoordinates)}:{Environment.NewLine}{e}");
                return NotFound();
            }

        }

        /// <summary>
        /// Gets the cell for a triangle.
        /// GET: api/Triangle/Cell?v1x=10&v1y=20&v2x=20&v2y=20&v3x=20&v3y=30
        /// </summary>
        /// <param name="v1x">First vertex's X value.</param>
        /// <param name="v1y">First vertex's Y value.</param>
        /// <param name="v2x">Second vertex's X value.</param>
        /// <param name="v2y">Second vertex's Y value.</param>
        /// <param name="v3x">Third vertex's X value.</param>
        /// <param name="v3y">Third vertex's Y value.</param>
        /// <returns><see cref="IActionResult"/> that contains a <see cref="Cell"/> if successful.</returns>
        [HttpGet("Cell")]
        public IActionResult GetCell(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            var triangle = new Triangle
            {
                Vertex1 = new Coordinate { X = v1x, Y = v1y },
                Vertex2 = new Coordinate { X = v2x, Y = v2y },
                Vertex3 = new Coordinate { X = v3x, Y = v3y }
            };

            try
            {
                var cell = triangleService.GetCell(triangle);
                return Ok(cell);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetCell)}:{Environment.NewLine}{e}");
                return NotFound();
            }
        }
    }
}
