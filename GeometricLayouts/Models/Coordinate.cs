
namespace GeometricLayouts.Models
{
    using System;

    /// <summary>
    /// Represents a single geometric point.
    /// </summary>
    public class Coordinate : IEquatable<Coordinate>
    {
        /// <summary>
        /// Gets or sets the X value of the coordinate.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y values of the coordinate.
        /// </summary>
        public int Y { get; set; }

        /// <inheritdoc />
        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            return X == other.X &&
                   Y == other.Y;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinate);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
