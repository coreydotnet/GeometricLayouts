
namespace GeometricLayouts.Services
{
    using Models;

    /// <summary>
    /// Service for calculating triangle coordinates and cells in a geometric layout.
    /// </summary>
    public interface ITriangeService
    {
        /// <summary>
        /// Calculates the triangle coordinates from a cell.
        /// </summary>
        /// <param name="cell"><see cref="Cell"/> to calculate triangle for.</param>
        /// <returns><see cref="Triangle"/> located at the specified cell.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="cell"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if either the cell's column or row is not valid.</exception>
        Triangle GetTriangle(Cell cell);

        /// <summary>
        /// Calculates the cell from triangle coordinates.
        /// </summary>
        /// <param name="triangle"><see cref="Triangle"/> to calculate cell for.</param>
        /// <returns><see cref="Cell"/> that corresponds to specified triangle.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="triangle"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any of the triangle's vertices are not valid.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the vertices do not make a valid triangle.</exception>
        Cell GetCell(Triangle triangle);
    }
}
