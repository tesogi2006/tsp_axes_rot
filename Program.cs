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
            var sampleNumber = 2;
            var sampleData = SampleData.LoadData(sampleNumber);

            var axisRotation = new AxisRotation();

            // Result from Greedy Algorithm
            Console.WriteLine("********** GREEDY *********");
            var greedy = axisRotation.DoGreedyTspWithNoReturn(sampleData);
            axisRotation.DisplayData(greedy);
            Console.WriteLine("********** GREEDY *********");

            // Result from Axes Rotation Algorithm
            Console.WriteLine("********** AXES ROTATION *********");
            var axesRot = axisRotation.DoAxesRotationTspWithNoReturn(sampleData);
            axisRotation.DisplayData(axesRot);
            Console.WriteLine("********** AXES ROTATION *********");
        }
    }
}
