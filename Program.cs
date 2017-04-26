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
            // generate random data
            //SampleData.GenerateRandomData(10, true);

            var sample = 10;
            var data_gr = SampleData.LoadData(sample);
            var data_ar = SampleData.LoadData(sample);

            var axisRotation = new AxisRotation();

            // Result from Greedy Algorithm
            Console.WriteLine("********** GREEDY *********");
            var greedy = axisRotation.DoGreedyTspWithNoReturn(data_gr);
            axisRotation.DisplayData(greedy);
            Console.WriteLine("********** GREEDY *********");

            // Result from Axes Rotation Algorithm
            Console.WriteLine("********** AXES ROTATION *********");
            var axesRot = axisRotation.DoAxesRotationTspWithNoReturn(data_ar);
            axisRotation.DisplayData(axesRot);
            Console.WriteLine("********** AXES ROTATION *********");
        }
    }
}
