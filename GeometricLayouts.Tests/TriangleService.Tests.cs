
namespace GeometricLayouts.Tests
{
    using System;
    using Models;
    using NUnit.Framework;
    using Services;

    [TestFixture]
    public class GivenTriangleService
    {
        private TriangleService service;

        private static readonly Triangle TriangleA1 = new Triangle
        {
            Vertex1 = new Coordinate { X = 0, Y = 0 },
            Vertex2 = new Coordinate { X = 10, Y = 10 },
            Vertex3 = new Coordinate { X = 0, Y = 10 }
        };

        private static readonly Triangle TriangleA2 = new Triangle
        {
            Vertex1 = new Coordinate { X = 0, Y = 0 },
            Vertex2 = new Coordinate { X = 10, Y = 0 },
            Vertex3 = new Coordinate { X = 10, Y = 10 }
        };

        private static readonly Triangle TriangleC12 = new Triangle
        {
            Vertex1 = new Coordinate { X = 50, Y = 20 },
            Vertex2 = new Coordinate { X = 60, Y = 20 },
            Vertex3 = new Coordinate { X = 60, Y = 30 }
        };

        private static readonly Triangle TriangleF7 = new Triangle
        {
            Vertex1 = new Coordinate { X = 30, Y = 50 },
            Vertex2 = new Coordinate { X = 40, Y = 60 },
            Vertex3 = new Coordinate { X = 30, Y = 60 }
        };

        [SetUp]
        public void SetUp()
        {
            service = new TriangleService();
        }

        [Test]
        public void WhenCellIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() => service.GetTriangle(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetTriangle(new Cell { Row = 0, Column = 1 }));
            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetTriangle(new Cell { Row = 7, Column = 1 }));
            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetTriangle(new Cell { Row = 1, Column = 0 }));
            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetTriangle(new Cell { Row = 1, Column = 13 }));
        }

        [Test]
        public void WhenGettingTriangles()
        {
            Assert.IsTrue(service.GetTriangle(Cell.Create("A", 1))
                                 .Equals(TriangleA1));

            Assert.IsTrue(service.GetTriangle(Cell.Create("A", 2))
                                 .Equals(TriangleA2));

            Assert.IsTrue(service.GetTriangle(Cell.Create("C", 12))
                                 .Equals(TriangleC12));

            Assert.IsTrue(service.GetTriangle(Cell.Create("F", 7))
                                 .Equals(TriangleF7));
        }
        
        public void WhenTriangleIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => service.GetCell(null));
        }

        [TestCase(-1, 10)]
        [TestCase(-1, 10)]
        [TestCase(61, 10)]
        [TestCase(70, 10)]
        [TestCase(35, 10)]
        [TestCase(10, -1)]
        [TestCase(10, 61)]
        [TestCase(10, 70)]
        [TestCase(10, 35)]
        public void WhenTriangleIsInvalid(int x, int y)
        {
            var invalidVertex = new Coordinate { X = x, Y = y };
            var validVertex = new Coordinate { X = 10, Y = 20 };

            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetCell(new Triangle
            {
                Vertex1 = invalidVertex,
                Vertex2 = validVertex,
                Vertex3 = validVertex
            }));

            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetCell(new Triangle
            {
                Vertex1 = validVertex,
                Vertex2 = invalidVertex,
                Vertex3 = validVertex
            }));

            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetCell(new Triangle
            {
                Vertex1 = validVertex,
                Vertex2 = validVertex,
                Vertex3 = invalidVertex
            }));
        }

        /// <remarks>
        /// The vertices are mixed up to increase coverage of input triangle coordinates
        /// which might not be in clockwise order.
        /// </remarks>
        [Test]
        public void WhenGettingCells()
        {
            Assert.IsTrue(service.GetCell(TriangleA1)
                                 .Equals(Cell.Create("A", 1)));

            Assert.IsTrue(service.GetCell(new Triangle
            {
                Vertex1 = TriangleA2.Vertex3,
                Vertex2 = TriangleA2.Vertex2,
                Vertex3 = TriangleA2.Vertex1,
            }).Equals(Cell.Create("A", 2)));

            Assert.IsTrue(service.GetCell(new Triangle
            {
                Vertex1 = TriangleC12.Vertex1,
                Vertex2 = TriangleC12.Vertex3,
                Vertex3 = TriangleC12.Vertex2
            }).Equals(Cell.Create("C", 12)));

            Assert.IsTrue(service.GetCell(new Triangle
            {
                Vertex1 = TriangleF7.Vertex2,
                Vertex2 = TriangleF7.Vertex1,
                Vertex3 = TriangleF7.Vertex3
            }).Equals(Cell.Create("F", 7)));
        }
    }
}
