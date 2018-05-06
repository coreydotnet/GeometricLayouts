
namespace GeometricLayouts.Models
{
    using System;

    /// <summary>
    /// Represents a cell that makes up a geometric layout.
    /// </summary>
    public class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Creates a <see cref="Cell"/> given a row letter and column value.
        /// </summary>
        /// <param name="row">Row letter of the triangle.</param>
        /// <param name="column">Column of the triangle.</param>
        /// <returns><see cref="Cell"/> for the specified row or column. Returns null if parameters are invalid.</returns>
        public static Cell Create(string row, int column)
        {
            Cell result = null;

            if (row?.Length == 1)
            {
                int rowValue = char.ToUpperInvariant(row[0]) - 'A' + 1;
                if (rowValue >= 1 && column >= 1)
                {
                    result = new Cell { Row = rowValue, Column = column };
                }
            }

            return result;
        }

        /// <inheritdoc />
        public bool Equals(Cell other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            return Row == other.Row &&
                   Column == other.Column;
        }
    }
}
