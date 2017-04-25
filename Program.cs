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
            var data = (List<Node>)null; 
            if(args.Length == 1){
                try{
                    var sampleNum = Convert.ToByte(args[0]);
                    Console.WriteLine("using sample data " + sampleNum);
                    
                    // Load sample data
                    data = SampleData.LoadData(sampleNum);
                }catch(Exception e){
                    Console.WriteLine($"ERROR: {e}");
                    throw;
                }
            }else{
                Console.WriteLine("Pass sample number when running the app (1, 2, or 3).");
                return;
            }

            var axisRotation = new AxisRotation();

            // Get Greedy Path
            //var greedy = axisRotation.DoGreedyTspWithNoReturn(data1);
            //Console.WriteLine($"AxesRot Distance: {greedy.DistanceTravelled}");

            // Get Axes Rotation Path
            var axesRot = axisRotation.DoAxesRotationTspWithNoReturn(data);
            axisRotation.PrintPath(axesRot.Path);
            Console.WriteLine($"AxesRot Distance: {axesRot.DistanceTravelled}");
        }
    }
}
