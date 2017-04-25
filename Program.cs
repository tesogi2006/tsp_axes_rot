using System;
using TspAxesRot.BusinessLogic;
using TspAxesRot.Data;

namespace TspAxesRot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int sampleNum; 
            if(args.Length == 1){
                try{
                    sampleNum = Convert.ToByte(args[0]);
                    Console.WriteLine("using sample data " + sampleNum);
                }catch(Exception e){
                    Console.WriteLine("You need to pass in sample data number (1, 2, or 3) as argument");
                    throw;
                }
            }else{
                Console.WriteLine("Pass sample number when running the app");
                return;
            }

            var axisRotation = new AxisRotation();
            // Load sample data
            var data1 = SampleData.LoadData(sampleNum);
            var data2 = SampleData.LoadData(sampleNum);

            // Get Greedy Path
            //var greedy = axisRotation.DoGreedyTspWithNoReturn(data1);
            //Console.WriteLine($"AxesRot Distance: {greedy.DistanceTravelled}");

            // Get Axes Rotation Path
            var axesRot = axisRotation.DoAxesRotationTspWithNoReturn(data2);
            axisRotation.PrintPath(axesRot.Path);
            Console.WriteLine($"AxesRot Distance: {axesRot.DistanceTravelled}");
        }
    }
}
