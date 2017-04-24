using System;
using System.Collections.Generic;
using TspAxesRot.BusinessLogic;
using TspAxesRot.Data;
using TspAxesRot.Domain;

namespace TspAxesRot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var axisRotation = new AxisRotation();
            // Load sample data
            var data1 = SampleData.LoadData();
            var data2 = SampleData.LoadData();

            // Get Greedy Path
            //var greedy = axisRotation.DoGreedyTspWithNoReturn(data1);
            //Console.WriteLine($"AxesRot Distance: {greedy.DistanceTravelled}");

            // Get Axes Rotation Path
            var axesRot = axisRotation.DoAxesRotationTspWithNoReturn(data2);
            axisRotation.PrintPath(axesRot.Path);
            Console.WriteLine($"AxesRot Distance: {axesRot.DistanceTravelled}");
        }

        private static Stack<Coordinate> GetPath(Stack<Coordinate> path)
        {
            return path;
        }

        public static void VisitNode(ref List<Node> nodes, int nodeIndex){
            nodes[nodeIndex].Visited = true;
        }
    }
}
