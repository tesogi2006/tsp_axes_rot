using System;
using TspAxesRot.Domain;
using Xunit;
using TspAxesRot.BusinessLogic;
using System.Collections.Generic;

namespace tsp_axes_rot.tests
{
    public class AxesRotationTests
    {
        [Fact]
        public void GetDistanceBetweenNodes_Test()
        {
            // arrange
            var a = new Coordinate{ X = 0, Y = 0 };
            var b = new Coordinate{ X = 3, Y = 4 };
            var axesRot = new AxisRotation();

            // act
            var d = axesRot.GetDistanceBetweenNodes(a, b);

            // assert
            Assert.Equal(d, 5);
        }

        [Fact]
        public void GetRotationAngle_Test()
        {
            // arrange
            var curr = new Coordinate{ X = 3, Y= 4 };
            var dest = new Coordinate { X = 3, Y = 0 }; // this gives rotation angle of -90deg
            var axesRot = new AxisRotation();

            // act
            var angle = axesRot.GetRotationAngle(curr, dest);

            // assert
            Assert.Equal(angle, -90);
        }
        
        [Fact]
        public void GetMappedCoord_Test()
        {
            // arrange
            var angle = -90;
            var dest = new Coordinate { X = 3, Y = 4 }; // this gives a map of (-4, 3) after -90deg rotation
            var axesRot = new AxisRotation();

            // act
            var map = axesRot.GetMappedCoord(angle, dest);

            // assert
            Assert.Equal(map.X, -4);
            Assert.Equal(map.Y, 3);
        }
        
        [Fact]
        public void DoGreedyTspWithNoReturn_Test()
        {
            // arrange
            var s = new Node { Coord = new Coordinate { X = 0, Y = 0 }, Visited = false, IsStartOrEnd = true };
            var a = new Node { Coord = new Coordinate { X = 1, Y = 1 }, Visited = false, IsStartOrEnd = false };
            var b = new Node { Coord = new Coordinate { X = 2, Y = 1 }, Visited = false, IsStartOrEnd = false };
            var c = new Node { Coord = new Coordinate { X = -1, Y = 6 }, Visited = false, IsStartOrEnd = false };
            var t = new Node { Coord = new Coordinate { X = 4, Y = 0 }, Visited = false, IsStartOrEnd = true };

            var nodes = new List<Node> { s, a, b, c, t };
            
            // expected path
            var expectedPath = new Queue<Coordinate>();
            expectedPath.Enqueue(s.Coord);
            expectedPath.Enqueue(a.Coord);
            expectedPath.Enqueue(b.Coord);
            expectedPath.Enqueue(c.Coord);
            expectedPath.Enqueue(t.Coord);
            
            var axesRot = new AxisRotation();


            // act
            var greedyPath = axesRot.DoGreedyTspWithNoReturn(nodes);

            // assert
            Assert.Equal(greedyPath.Path, expectedPath);
        }

        [Fact]
        public void DoAxesRotationTspWithNoReturn_Test()
        {
            // arrange
            var s = new Node { Coord = new Coordinate { X = 0, Y = 0 }, Visited = false, IsStartOrEnd = true };
            var a = new Node { Coord = new Coordinate { X = 1, Y = 1 }, Visited = false, IsStartOrEnd = false };
            var b = new Node { Coord = new Coordinate { X = 2, Y = 1 }, Visited = false, IsStartOrEnd = false };
            var c = new Node { Coord = new Coordinate { X = -1, Y = 6 }, Visited = false, IsStartOrEnd = false };
            var t = new Node { Coord = new Coordinate { X = 4, Y = 0 }, Visited = false, IsStartOrEnd = true };

            var nodes = new List<Node> { s, a, b, c, t };
            
            // expected path
            var expectedPath = new Queue<Coordinate>();
            expectedPath.Enqueue(s.Coord);
            expectedPath.Enqueue(c.Coord);
            expectedPath.Enqueue(a.Coord);
            expectedPath.Enqueue(b.Coord);
            expectedPath.Enqueue(t.Coord);
            
            var axesRot = new AxisRotation();


            // act
            var greedyPath = axesRot.DoAxesRotationTspWithNoReturn(nodes);

            // assert
            Assert.Equal(greedyPath.Path, expectedPath);
        }
    }
}
