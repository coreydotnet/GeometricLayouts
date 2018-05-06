
namespace GeometricLayouts.Models
{
    using System;

    /// <summary>
    /// Represents a triangle with three <see cref="Coordinate"/> values.
    /// </summary>
    public class Triangle : IEquatable<Triangle>
    {
        /// <summary>
        /// Gets or sets the first vertex.
        /// </summary>
        public Coordinate Vertex1 { get; set; }

        /// <summary>
        /// Gets or sets the second vertex.
        /// </summary>
        public Coordinate Vertex2 { get; set; }

        /// <summary>
        /// Gets or sets the third vertex.
        /// </summary>
        public Coordinate Vertex3 { get; set; }

        /// <inheritdoc />
        public bool Equals(Triangle other)
        {
            if(ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            return (Vertex1?.Equals(other.Vertex1) ?? false) &&
                   (Vertex2?.Equals(other.Vertex2) ?? false) &&
                   (Vertex3?.Equals(other.Vertex3) ?? false);
        }
    }
}
