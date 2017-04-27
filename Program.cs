using System;
using System.Collections.Generic;
using System.IO;
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
            var sampleData = SampleData.LoadDataFromJsonFile($"Data/sample_data_{sampleNumber}.json");
            // generate random data
            // var nodes = SampleData.GenerateRandomData(10, true);

            // Printing sample data
            // int sample = 2;
            // var axisRotation = new AxisRotation();
            // PrintSample(axisRotation, sample);


            // Run multi sample comparison
            MultiSampleStats(5);
            
        }

        public static void MultiSampleStats(int sampleSize)
        {
            var sampleOfSamples = new List<List<Node>>();
            var stats = new List<Tuple<double, double>>();
            for(int i = 0; i < sampleSize; i++){
                var filename = $"Data/multi_{i}.json";
                var sample = SampleData.GenerateRandomData(20, filename);

                // load data
                var smp = SampleData.LoadDataFromJsonFile(filename);

                // this here is what you should never do, but for now...
                var alg = new AxisRotation();
                var grd = alg.DoGreedyTspWithNoReturn(sample);
                var axr = alg.DoAxesRotationTspWithNoReturn(smp);

                var cmp = new Tuple<double, double>(grd.DistanceTravelled, axr.DistanceTravelled);
                stats.Add(cmp);
            }

            SaveToDisk(stats, $"Data/cmp_2.csv");
        }

        public static void SaveToDisk(List<Tuple<double, double>> cmpData, string filename)
        {
            using(var writer = new StreamWriter(filename))
            {
                writer.WriteLine("Greedy,AxesRotation");
                foreach(var line in cmpData)
                {
                    writer.WriteLine($"{line.Item1},{line.Item2}");
                }
            }
        }
        public static void PrintSample(AxisRotation axisRotation, int sample)
        {
            var sampleData = SampleData.LoadDataFromJsonFile($"Data/sample_data_{sample}.json");

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
