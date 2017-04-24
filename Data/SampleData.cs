using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TspAxesRot.Domain;

namespace TspAxesRot.Data
{
    public class SampleData
    {
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
    }
}