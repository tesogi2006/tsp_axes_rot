using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TspAxesRot.Domain;

namespace TspAxesRot.Data
{
    public static class SampleData
    {
        private static Random _random = new Random(1);

        public static List<Node> LoadData(int sampleNumber){
            using (StreamReader r = new StreamReader($"Data/sample_data_{sampleNumber}.json")){
                try{
                    string json = r.ReadToEnd();
                    List<Node> nodes = JsonConvert.DeserializeObject<List<Node>>(json);

                    return nodes;
                }catch(Exception e){
                    Console.WriteLine(e);
                    return null;
                }
            }
        }

        public static void GenerateRandomData(int numberOfNodes, bool save){
            var nodes = new List<Node>();
            for(int i = 0; i < numberOfNodes; i++){
                var node = new Node
                {
                    Coord = new Coordinate{ X = _random.Next(-50, 50), Y = _random.Next(-50, 50) },
                    Visited = false,
                    IsStartOrEnd = (i == 0 || i == numberOfNodes - 1) 
                                    ? true 
                                    : false
                };

                nodes.Add(node);
            }

            if(save){
                SaveDataToFile(nodes, numberOfNodes);
            }
        }

        public static void SaveDataToFile(List<Node> nodes, int numberOfNodes)
        {
            using (var r = new StreamWriter($"Data/sample_data_{numberOfNodes}.json"))
            {
                try
                {
                    string nodesStr = JsonConvert.SerializeObject(nodes);
                    r.WriteLine(nodesStr);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}