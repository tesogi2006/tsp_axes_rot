using System;
using System.Collections.Generic;

namespace TspAxesRot
{
    public class AxisRotation : IAxisRotation
    {
        public double GetDistanceBetweenNodes(Coordinate n1, Coordinate n2)
        {
            return Math.Round(Math.Sqrt(Math.Pow(n2.X - n1.X, 2) + Math.Pow(n2.Y - n1.Y, 2)), 2);
        }

        // This evaluates the angle the current xy-coordinate will have to rotate so that 
        // it is parallel to the line created by joining current node and destination node.
        public double GetRotationAngle(Coordinate currentNodeCoord, Coordinate destNodeCoord){
            return Math.Round(
                            RadiansToDegrees(
                                Math.Atan2(destNodeCoord.Y - currentNodeCoord.Y, destNodeCoord.X - currentNodeCoord.X)), 2);
        }

        public Coordinate GetMappedCoord(double rotationAngle, Coordinate coord){
            // Math.Sin and Math.Cos from the System assembly only take radians
            // so we need to convert the angle to radians
            var angleRad = DegreesToRadians(rotationAngle);

            return new Coordinate{
                X = Math.Round(coord.X * Math.Cos(angleRad) - coord.Y * Math.Sin(angleRad), 2),
                Y = Math.Round(coord.X * Math.Sin(angleRad) + coord.Y * Math.Cos(angleRad), 2)
            };
        }

        public TspProcessedData DoGreedyTspWithNoReturn(List<Node> graphNodes)
        {
            var path = new Queue<Coordinate>();
            var curNode = graphNodes[0].Coord;
            path.Enqueue(curNode);

            graphNodes.Remove(graphNodes[0]);
            double totalDist = 0.0;
            while (graphNodes.Count > 0)
            {
                Console.WriteLine($"Current node is {curNode}");
                var d = Double.PositiveInfinity;
                var nextNode = (Node)null;
                foreach (var node in graphNodes)
                {
                    // don't process starting or ending node
                    // if it is not the last one
                    if (node.IsStartOrEnd && graphNodes.Count != 1)
                    {
                        continue;
                    }
                    var v = GetDistanceBetweenNodes(curNode, node.Coord);
                    if (v < d)
                    {
                        d = v;
                        nextNode = node;
                    }
                    Console.WriteLine($"Distance between {curNode} and {node.Coord}: {v}");
                }

                curNode = nextNode.Coord;
                path.Enqueue(curNode);
                Console.WriteLine($"****Next node is {nextNode.Coord}****");
                graphNodes.Remove(nextNode);
                totalDist += d;
            }

            return new TspProcessedData {
                Path = path,
                DistanceTravelled = totalDist
            };
        }

        public TspProcessedData DoAxesRotationTspWithNoReturn(List<Node> graphNodes)
        {

            var path = new Queue<Coordinate>();
            var curNode = graphNodes[0].Coord;
            path.Enqueue(curNode);
            graphNodes.Remove(graphNodes[0]);
            double totalDist = 0.0;
            var destNode = graphNodes[graphNodes.Count - 1];
            
            while (graphNodes.Count > 0)
            {
                Console.WriteLine($"Current node is {curNode}");
                var d = Double.PositiveInfinity;    // distance between current and next node
                var xx = Double.PositiveInfinity;   // x' values of the next node
                var nextNode = (Node)null;
                foreach (var node in graphNodes)
                {
                    // don't process starting or ending node
                    // if it is not the last one
                    if (node.IsStartOrEnd && graphNodes.Count != 1)
                    {
                        continue;
                    }
                    // mapped coordinates in x'y' plane
                    var rotAngle = GetRotationAngle(curNode, destNode.Coord);
                    Console.WriteLine($"RotationAngle: {rotAngle}");
                    var coord_primes = GetMappedCoord(rotAngle, node.Coord);
                    Console.WriteLine($"{node.Coord} is mapped to {coord_primes}");
                    d = GetDistanceBetweenNodes(curNode, node.Coord);

                    if(coord_primes.X < xx){
                        nextNode = node;
                        xx = coord_primes.X;
                    }
                    Console.WriteLine($"Distance between {curNode} and {node.Coord}: {d}");
                }

                curNode = nextNode.Coord;
                path.Enqueue(curNode);
                Console.WriteLine($"****Next node is {nextNode.Coord}****");
                graphNodes.Remove(nextNode);
                totalDist += d;
            }

            return new TspProcessedData
            {
                Path = path,
                DistanceTravelled = totalDist
            };
        }

        private double RadiansToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}