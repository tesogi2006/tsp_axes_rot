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
            var sample = 2;
            var data_gr = SampleData.LoadData(sample);
            var data_ar = SampleData.LoadData(sample);
            // var data = (List<Node>)null; 
            // if(args.Length == 1){
            //     try{
            //         var sampleNum = Convert.ToByte(args[0]);
            //         //Console.WriteLine("using sample data " + sampleNum);
                    
            //         // Load sample data
            //         data = SampleData.LoadData(sampleNum);
            //     }catch(Exception e){
            //         Console.WriteLine($"ERROR: {e}");
            //         throw;
            //     }
            // }else{
            //     Console.WriteLine("Pass sample number when running the app (1 or 2).");
            //     return;
            // }

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
