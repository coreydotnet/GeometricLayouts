
namespace GeometricLayouts.Services
{
    using System;
    using System.Linq;
    using Models;

    /// <summary>
    /// Service for calculating triangle coordinates and cells in a geometric layout.
    /// </summary>
    public class TriangleService : ITriangeService
    {
        private const int RowHeight = 10;
        private const int ColumnWidth = 10;
        private const int LayoutWidth = 60;
        private const int LayoutHeight = 60;
        private const int MaxRows = 6;
        private const int MaxColumns = 12;

        /// <inheritdoc />
        public Triangle GetTriangle(Cell cell)
        {
            if (cell == null)
            {
                throw new ArgumentNullException(nameof(cell));
            }
            if (cell.Row < 1 || cell.Row > MaxRows)
            {
                throw new ArgumentOutOfRangeException(nameof(cell));
            }
            if (cell.Column < 1 || cell.Column > MaxColumns)
            {
                throw new ArgumentOutOfRangeException(nameof(cell));
            }

            // Every two columns share the same X position.
            int x1 = ((cell.Column - 1) / 2) * ColumnWidth;
            int x2 = x1 + ColumnWidth;

            int y1 = (cell.Row - 1) * RowHeight;
            int y2 = y1 + RowHeight;

            // Odd and even column triangles share upper left and lower right vertices.
            var triangle = new Triangle { Vertex1 = new Coordinate { X = x1, Y = y1 } };
            var lowerRightVertex = new Coordinate { X = x2, Y = y2 };

            if (cell.Column % 2 == 1)
            {
                // Odd columns:
                triangle.Vertex2 = lowerRightVertex;
                triangle.Vertex3 = new Coordinate { X = x1, Y = y2 };
            }
            else
            {
                // Even columns:
                triangle.Vertex2 = new Coordinate { X = x2, Y = y1 };
                triangle.Vertex3 = lowerRightVertex;
            }

            return triangle;
        }

        /// <inheritdoc />
        public Cell GetCell(Triangle triangle)
        {
            if (triangle == null)
            {
                throw new ArgumentNullException(nameof(triangle));
            }
            ValidateVertex(triangle.Vertex1);
            ValidateVertex(triangle.Vertex2);
            ValidateVertex(triangle.Vertex3);

            var vertices = new[] { triangle.Vertex1, triangle.Vertex2, triangle.Vertex3 };
            var minX = vertices.Min(v => v.X);
            var maxX = vertices.Max(v => v.X);
            var minY = vertices.Min(v => v.Y);
            var maxY = vertices.Max(v => v.Y);

            if (minX == maxX || minX + ColumnWidth != maxX ||
                minY == maxY || minY + ColumnWidth != maxY)
            {
                throw new InvalidOperationException("The coordinates do not represent a valid triangle.");
            }

            int row = (minY / RowHeight) + 1;

            // Calculate column for left-most point.
            int column = 2 * (minX / ColumnWidth) + 1;

            // If upper right corner exists, then this is an even column
            if (vertices.Contains(new Coordinate { X = maxX, Y = minY }))
            {
                ++column;
            }

            return new Cell { Row = row, Column = column };
        }

        /// <summary>
        /// Checks if a vertex is valid.
        /// </summary>
        /// <param name="vertex">Vertex to validate.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the vertex's values are out of range.</exception>
        private void ValidateVertex(Coordinate vertex)
        {
            if (vertex.X < 0 || vertex.X > LayoutWidth || (vertex.X % ColumnWidth != 0))
            {
                throw new ArgumentOutOfRangeException(nameof(vertex), $"Vertex's X is out of range [0-{LayoutWidth}].");
            }
            if (vertex.Y < 0 || vertex.Y > LayoutHeight || (vertex.Y % RowHeight != 0))
            {
                throw new ArgumentOutOfRangeException(nameof(vertex), $"Vertex's Y is out of range [0-{LayoutHeight}].");
            }
        }
    }
}
